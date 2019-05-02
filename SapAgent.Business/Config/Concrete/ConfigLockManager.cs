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
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.General.@enum;
using SapAgent.Entities.Concrete.Spa;
using Lock = SapAgent.Entities.Concrete.Pure.Lock;


namespace SapAgent.Business.Config.Concrete
{
    public class ConfigLockManager : ConfigManager<Entities.Concrete.Config.Lock>, IManagerConfigLockManager
    {
        private const int FunctionId = 3;
        private const int CustomerId = 1;
        private const int ProductId = 1;

        private IBaseDal<Entities.Concrete.Pure.Lock> _basePureDal;
        private IBaseDal<Entities.Concrete.Config.Lock> _baseConfigDal;
        private readonly IHttpClientHelper<DashboardSignalRModel> _httpClientHelper;
        private readonly IBaseDal<LockNotify> _notificationDal;
        private readonly IBaseDal<CustomerProductView> _customerProdDal;
        private readonly IBaseDal<LockNotifyDetailView> _notifyDetailDal;
        public ConfigLockManager(IBaseDal<Lock> pureDal,
            IBaseDal<FuncFlag> flagDal,
            IHttpClientHelper<DashboardSignalRModel> httpClientHelper,
            IBaseDal<LockNotify> notificationDal,
            IBaseDal<Entities.Concrete.Config.Lock> baseConfigDal,
            IBaseDal<CustomerProductView> customerProdDal, 
            IBaseDal<LockNotifyDetailView> notifyDetailDal)
        : base(baseConfigDal, flagDal, FunctionId)
        {
            _basePureDal = pureDal;
            _httpClientHelper = httpClientHelper;
            _notificationDal = notificationDal;
            _baseConfigDal = baseConfigDal;
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

        public async Task<List<LockNotifyDetailView>> GetLockNotifyDetail(int customerProductId)
        {
            return await _notifyDetailDal.GetAll(x => x.CustomerProductId == customerProductId);
        }

        private List<LockNotify> CatchAlert(List<Lock> rawData)
        {
            List<LockNotify> listNotify = new List<LockNotify>();
            var groupList = rawData.GroupBy(x => x.GCLIENT.Trim());
            foreach (var item in groupList)
            {
                var config = _baseConfigDal.Get(x => x.CustomerId == CustomerId && x.ClientId.ToString() == item.Key);
                if (config == null) continue;

                var listData = rawData.Select(x => x.GCLIENT == item.Key).ToList();
                if (listData.Count + config.Buffer > config.LockLimit * ((100 + config.RangeError) / 100))
                {
                    listNotify.Add(new LockNotify()
                    {
                        FuncId = FunctionId,
                        Desc = "Lock sayısı Lock Limit değerini " + (config.LockLimit * (100 + config.RangeError) / 100).ToString() + " aşmıştır.",
                        Case = (int)LockEnumCase.LimitAsimi,
                        Date = DateTime.Now,
                        Level = (int)Level.error,
                        CustomerProductId = GetCustomerProductId(Convert.ToInt32(item.Key)),
                        Statu = 0
                    });
                }
            }
            return listNotify;
        }
        private int GetCustomerProductId(int clientId)
        {
            return _customerProdDal.Get(x => x.CustomerId == CustomerId && x.ProductId == ProductId && x.ClientId == clientId).CustomerProductId;
        }
        public void AddNotificationToDb(List<LockNotify> list)
        {
            foreach (var item in list)
            {
                _notificationDal.Add(item);
            }
        }
    }
}
