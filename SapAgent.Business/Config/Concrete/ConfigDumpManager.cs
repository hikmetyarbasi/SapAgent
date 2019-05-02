using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Helpers.Abstract;
using SapAgent.API.Model;
using SapAgent.Business.Config.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.General.@enum;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.Business.Config.Concrete
{
    public class ConfigDumpManager : ConfigManager<Dump>, IManagerConfigDmpManager
    {
        private const int FunctionId = 2;
        private const int CustomerId = 1;
        private const int ProductId = 1;
        
        private readonly IHttpClientHelper<DashboardSignalRModel> _httpClientHelper;
        private IBaseDal<Entities.Concrete.Pure.Dump> _basePureDal;
        private IBaseDal<Entities.Concrete.Config.Dump> _baseConfigDal;
        private readonly IBaseDal<DumpNotify> _notificationDal;
        private readonly IBaseDal<CustomerProductView> _customerProdDal;
        private readonly IBaseDal<DumpNotifyDetailView> _notifyDetailDal;

        public ConfigDumpManager(
            IBaseDal<Dump> _entityRepository,
            IBaseDal<FuncFlag> funcFlagBaseDal, 
            IHttpClientHelper<DashboardSignalRModel> httpClientHelper, 
            IBaseDal<Entities.Concrete.Pure.Dump> basePureDal,
            IBaseDal<Dump> baseConfigDal,
            IBaseDal<DumpNotify> notificationDal,
            IBaseDal<CustomerProductView> customerProdDal,
            IBaseDal<DumpNotifyDetailView> notifyDetailDal) :
            base(_entityRepository, funcFlagBaseDal, FunctionId)
        {
            _httpClientHelper = httpClientHelper;
            _basePureDal = basePureDal;
            _baseConfigDal = baseConfigDal;
            _notificationDal = notificationDal;
            _customerProdDal = customerProdDal;
            _notifyDetailDal = notifyDetailDal;
        }

        public void StartOperation(int customerId, int productId)
        {
            try
            {
                if (IsFlagUp())
                {
                    var lstExeTime = GetLastExecutionIndex();
                    var rawData = _basePureDal.GetAll(x => x.SREQINDEX == lstExeTime).Result;
                    var alertlist = CatchAlert(rawData);

                    //Triggered SignalR
                    if (alertlist.Count > 0)
                    {
                        AddNotificationToDb(alertlist);
                        _httpClientHelper.PostRequest("Message/api/dashboardUpdate", new DashboardSignalRModel());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private void AddNotificationToDb(List<DumpNotify> list)
        {
            foreach (var item in list)
            {
                _notificationDal.Add(item);
            }
        }
        public async Task<List<DumpNotifyDetailView>> GetDmpNotifyDetail(int customerProductId)
        {
            return await _notifyDetailDal.GetAll(x => x.CustomerProductId == customerProductId);
        }

        private List<DumpNotify> CatchAlert(List<Entities.Concrete.Pure.Dump> rawData)
        {
            if (rawData.Count == 0) return null;
            List<DumpNotify> listNotify = new List<DumpNotify>();

            var groupList = rawData.GroupBy(x => new { x.ERRORID, x.MANDT }).Select(grp => new { grp.Key.ERRORID, CLIENTID = Convert.ToInt32(grp.Key.MANDT) });

            foreach (var item in groupList)
            {
                try
                {
                    if(item.CLIENTID==0) continue;
                    var config = _baseConfigDal.Get(x => x.CustomerId == CustomerId && x.ProductId == ProductId && x.ErrorId == item.ERRORID && x.ClientId == item.CLIENTID);

                    var listData = rawData.Where(x => x.ERRORID == item.ERRORID && x.MANDT == item.CLIENTID.ToString()).ToList();

                    if (listData.Count + config.Buffer > config.Limit * ((100 + config.ErrorRange) / 100))
                    {
                        listNotify.Add(new DumpNotify()
                        {
                            FuncId = FunctionId,
                            Desc = item.ERRORID + " için dump sayısı Limit değerini " + (config.Limit * (100 + config.ErrorRange) / 100).ToString() + " aşmıştır.",
                            Case = (int)DumpEnumCase.LimitAsimi,
                            Date = DateTime.Now,
                            Level = (int)Level.error,
                            CustomerProductId = GetCustomerProductId(Convert.ToInt32(item.CLIENTID)),
                            Statu = 0
                        });
                    }

                    if (listData.Count + config.Buffer < config.Limit * ((100 + config.WarningRange) / 100) &&
                        config.Limit < listData.Count)
                    {
                        listNotify.Add(new DumpNotify()
                        {
                            FuncId = FunctionId,
                            Desc = item.ERRORID + " için dump sayısı Limit değerini " + (config.Limit * (100 + config.ErrorRange) / 100).ToString() + " aşmıştır.",
                            Case = (int)DumpEnumCase.LimitAsimi,
                            Date = DateTime.Now,
                            Level = (int)Level.warning,
                            CustomerProductId = GetCustomerProductId(Convert.ToInt32(item.CLIENTID)),
                            Statu = 0
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return listNotify;
        }
        private int GetCustomerProductId(int clientId)
        {
            return _customerProdDal.Get(x => x.CustomerId == CustomerId && x.ProductId == ProductId && x.ClientId == clientId).CustomerProductId;
        }
    }
}
