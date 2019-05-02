using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class ConfigSysListManager : ConfigManager<SysList>, IManagerConfigSysListManager
    {
        private const int FunctionId = 4;
        private const int CustomerId = 1;
        private const int ProductId = 1;
        private readonly IHttpClientHelper<DashboardSignalRModel> _httpClientHelper;
        private IBaseDal<Entities.Concrete.Pure.SysList> _basePureDal;
        private IBaseDal<Entities.Concrete.Config.SysList> _baseConfigDal;
        private readonly IBaseDal<SysListNotify> _notificationDal;
        private readonly IBaseDal<CustomerProductView> _customerProdDal;
        private readonly IBaseDal<SysListNotifyDetailView> _notifyDetailDal;
        public ConfigSysListManager(IBaseDal<SysList> entityRepository,
            IBaseDal<FuncFlag> flagDal,
            IHttpClientHelper<DashboardSignalRModel> httpClientHelper,
            IBaseDal<Entities.Concrete.Pure.SysList> basePureDal,
            IBaseDal<SysList> baseConfigDal,
            IBaseDal<SysListNotify> notificationDal,
            IBaseDal<CustomerProductView> customerProdDal,
            IBaseDal<SysListNotifyDetailView> notifyDetailDal)
            : base(entityRepository, flagDal, FunctionId)
        {
            _httpClientHelper = httpClientHelper;
            _basePureDal = basePureDal;
            _baseConfigDal = baseConfigDal;
            _notificationDal = notificationDal;
            _customerProdDal = customerProdDal;
            _notifyDetailDal = notifyDetailDal;
            _customerProdDal = customerProdDal;
        }

        public async Task<List<SysListNotifyDetailView>> GetSysListNotifyDetail(int customerProductId)
        {
            return await _notifyDetailDal.GetAll(x => x.CustomerProductId == customerProductId);
        }

        public override void StartOperation(int customer, int productId)
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
            }

        }

        private void AddNotificationToDb(List<SysListNotify> alertlist)
        {
            foreach (var item in alertlist)
            {
                _notificationDal.Add(item);
            }
        }

        private List<SysListNotify> CatchAlert(List<Entities.Concrete.Pure.SysList> rawData)
        {
            try
            {
                var listNotify = new List<SysListNotify>();
                var savedHost = _baseConfigDal.GetAll(x => x.CustomerId == CustomerId && x.ProductId == ProductId).Result.ToList();
                var clientList = _customerProdDal.GetAll(x => x.ProductId == ProductId).Result.ToList();
                foreach (var item in rawData)
                {
                    var host = savedHost.FirstOrDefault(x => x.Host == item.HOST);
                    if (host != null)
                    {
                        if (host.Status == "Down")
                        {
                            foreach (var client in clientList)
                            {
                                listNotify.Add(new SysListNotify()
                                {
                                    FuncId = FunctionId,
                                    Desc = item.HOST + " sunucusunun durumu " + item.STATUS + " durumuna geçmiştir.",
                                    Case = (int)SysListEnumCase.AppServerDown,
                                    Date = DateTime.Now,
                                    Level = (int)Level.error,
                                    CustomerProductId = GetCustomerProductId(Convert.ToInt32(client.ClientId)),
                                    Statu = 0
                                });
                            }
                        }
                    }
                    else
                    {
                        if (item.STATUS == "Down")
                        {
                            foreach (var client in clientList)
                            {
                                listNotify.Add(new SysListNotify()
                                {
                                    FuncId = FunctionId,
                                    Desc = item.HOST + " sunucusunun durumu " + item.STATUS + " durumuna geçmiştir.",
                                    Case = (int)SysListEnumCase.AppServerDown,
                                    Date = DateTime.Now,
                                    Level = (int)Level.error,
                                    CustomerProductId = GetCustomerProductId(Convert.ToInt32(client.ClientId)),
                                    Statu = 0
                                });
                            }
                        }

                        _baseConfigDal.Add(new SysList()
                        {
                            ProductId = ProductId,
                            CustomerId = CustomerId,
                            Host = item.HOST,
                            Status = item.STATUS
                        });
                    }
                }

                return listNotify;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        private int GetCustomerProductId(int clientId)
        {
            return _customerProdDal.Get(x => x.CustomerId == CustomerId && x.ProductId == ProductId && x.ClientId == clientId).CustomerProductId;
        }
    }
}
