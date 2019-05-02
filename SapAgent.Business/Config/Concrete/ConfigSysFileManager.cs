using SapAgent.Entities.Concrete.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Helpers.Abstract;
using SapAgent.API.Model;
using SapAgent.Business.Config.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.General.@enum;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.Business.Config.Concrete
{
    public class ConfigSysFileManager : ConfigManager<SysFile>, IManagerConfigSysFileManager
    {
        private const int FunctionId = 7;
        private const int CustomerId = 1;
        private const int ProductId = 1;
        private readonly IHttpClientHelper<DashboardSignalRModel> _httpClientHelper;
        private IBaseDal<Entities.Concrete.Pure.SysFile> _basePureDal;
        private IBaseDal<Entities.Concrete.Config.SysFile> _baseConfigDal;
        private readonly IBaseDal<SysFileNotify> _notificationDal;
        private readonly IBaseDal<CustomerProductView> _customerProdDal;
        private readonly IBaseDal<SysFileNotifyDetailView> _notifyDetailDal;
        public ConfigSysFileManager(IBaseDal<SysFile> entityRepository,
            IBaseDal<FuncFlag> flagDal,
            IHttpClientHelper<DashboardSignalRModel> httpClientHelper,
            IBaseDal<Entities.Concrete.Pure.SysFile> basePureDal,
            IBaseDal<SysFile> baseConfigDal,
            IBaseDal<SysFileNotify> notificationDal,
            IBaseDal<CustomerProductView> customerProdDal,
            IBaseDal<SysFileNotifyDetailView> notifyDetailDal)
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

        public async Task<List<SysFileNotifyDetailView>> GetSysFileNotifyDetail(int customerProductId)
        {
            return await _notifyDetailDal.GetAll(x => x.CustomerProductId == customerProductId);
        }

        public Task<List<SysFile>> GetAll(Expression<Func<SysFile, bool>> filter)
        {
            throw new NotImplementedException();
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

        private List<SysFileNotify> CatchAlert(List<Entities.Concrete.Pure.SysFile> rawData)
        {

            var listNotify = new List<SysFileNotify>();
            var configList = _baseConfigDal.GetAll(x => x.CustomerId == CustomerId && x.ProductId == ProductId).Result;
            var clientList = _customerProdDal.GetAll(x => x.ProductId == ProductId).Result.ToList();
            foreach (var sysFile in rawData)
            {
                var configFile = configList.FirstOrDefault(x => x.Server == sysFile.Server && x.SysName == sysFile.Fsysname) ??
                                 _baseConfigDal.Add(new SysFile()
                                 {
                                     ProductId = ProductId,
                                     CustomerId = CustomerId,
                                     WarningRange = 20,
                                     ErrorRange = 10,
                                     Buffer = 0,
                                     Server = sysFile.Server,
                                     SysName = sysFile.Fsysname,
                                     Limit = 10
                                 });



                if (sysFile.FreePercent < configFile.ErrorRange)
                {
                    foreach (var client in clientList)
                    {
                        listNotify.Add(new SysFileNotify()
                        {
                            Level = (int)Level.error,
                            CustomerProductId = GetCustomerProductId(Convert.ToInt32(client.ClientId)),
                            Case = (int)SysFileEnumCase.LimitAsimi,
                            Date = DateTime.Now,
                            Desc = sysFile.Server + " sunucusunundaki " + sysFile.Fsysname + " diskinin boş kapasite oranı " + configFile.ErrorRange + " 'inin altında kalmıştır.",
                            FuncId = FunctionId,
                            Statu = 0
                        });
                    }

                }

                if (sysFile.FreePercent > configFile.ErrorRange && sysFile.FreePercent < configFile.WarningRange)
                {
                    foreach (var client in clientList)
                    {
                        listNotify.Add(new SysFileNotify()
                        {
                            Level = (int)Level.warning,
                            CustomerProductId = GetCustomerProductId(Convert.ToInt32(client.ClientId)),
                            Case = (int)SysFileEnumCase.LimitAsimi,
                            Date = DateTime.Now,
                            Desc = sysFile.Server + " sunucusunundaki " + sysFile.Fsysname + " diskinin boş kapasite oranı " + configFile.WarningRange + " 'inin altında kalmıştır.",
                            FuncId = FunctionId,
                            Statu = 0
                        });
                    }
                }
            }
            return listNotify;
        }

        private void AddNotificationToDb(List<SysFileNotify> alertlist)
        {
            foreach (var item in alertlist)
            {
                _notificationDal.Add(item);
            }
        }
        private int GetCustomerProductId(int clientId)
        {
            return _customerProdDal.Get(x => x.CustomerId == CustomerId && x.ProductId == ProductId && x.ClientId == clientId).CustomerProductId;
        }
    }
}
