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
using SapAgent.Entities.Concrete.General.Dto;
using SapAgent.Entities.Concrete.General.@enum;
using SapAgent.Entities.Concrete.Spa;
using BackgroundProcessNotify = SapAgent.Entities.Concrete.Config.BackgroundProcessNotify;

namespace SapAgent.Business.Config.Concrete
{
    public class ConfigBackgroundProcessManager : ConfigManager<BackgroundProcess>, IManagerConfigBpManager
    {
        private const int FunctionId = 1;
        private int CustomerId = 1;
        private int ProductId = 1;
        private readonly IBaseDal<Entities.Concrete.Pure.BackgroundProcess> _pureDal;
        private readonly IBaseDal<Entities.Concrete.Config.BackgroundProcess> _configDal;
        private readonly IBaseDal<Entities.Concrete.Config.BackgroundProcessNotify> _notificationDal;
        private readonly IBaseDal<BpNotifyDetailView> _notifyDetailDal;
        private static IBaseDal<Entities.Concrete.Config.FuncFlag> _flagDal;
        private static IBaseDal<AllNotifyCountView> _allNotifyDal;
        private readonly IBaseDal<CustomerProductView> _customerProdDal;
        private readonly IHttpClientHelper<DashboardSignalRModel> _httpClientHelper;
        public ConfigBackgroundProcessManager(IBaseDal<BackgroundProcess> dal,
            IBaseDal<Entities.Concrete.Pure.BackgroundProcess> pureDal,
            IBaseDal<Entities.Concrete.Config.FuncFlag> flagDal,
            IBaseDal<Entities.Concrete.Config.BackgroundProcess> configDal,
            IBaseDal<Entities.Concrete.Config.BackgroundProcessNotify> spaNotificationDal,
            IBaseDal<AllNotifyCountView> bpNotifyDal,
            IHttpClientHelper<DashboardSignalRModel> httpClientHelper,
            IBaseDal<BpNotifyDetailView> notifyDetailDal, IBaseDal<CustomerProductView> customerProdDal, 
            IBaseDal<AllNotifyCountView> allNotifyDal)
        : base(dal, flagDal, FunctionId, allNotifyDal)
        {
            _pureDal = pureDal;
            _flagDal = flagDal;
            _configDal = configDal;
            _notificationDal = spaNotificationDal;
            _httpClientHelper = httpClientHelper;
            _notifyDetailDal = notifyDetailDal;
            _customerProdDal = customerProdDal;
            _allNotifyDal = allNotifyDal;
        }
        public void StartOperation(int customerId, int productId)
        {
            ProductId = productId;
            CustomerId = customerId;
            try
            {
                if (IsFlagUp())
                {
                    var lstExeTime = GetLastExecutionIndex();
                    var rawData = _pureDal.GetAll(x => x.SREQINDEX == lstExeTime).Result;
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
        public int GetBackgroundProcessTotalJobCount()
        {
            var lstExeTime = GetLastExecutionIndex();
            return _pureDal.GetAll(x => x.SREQINDEX == lstExeTime).Result.Count;
        }
        public void AddNotificationToDb(List<BackgroundProcessNotify> list)
        {
            foreach (var item in list)
            {
                _notificationDal.Add(item);
            }
        }
        private List<BackgroundProcessNotify> CatchAlert(List<Entities.Concrete.Pure.BackgroundProcess> list)
        {
            List<BackgroundProcessNotify> ntfy = new List<BackgroundProcessNotify>();
            foreach (var item in list)
            {
                var config = CheckIfExists(item.JOBNAME) ??
                                           _configDal.Add(new Entities.Concrete.Config.BackgroundProcess
                                           {
                                               JobName = item.JOBNAME,
                                               Latency = 300,
                                               Duration = 7200,
                                               AvgWorkTime = 3600,
                                               Starttime = new TimeSpan(0),
                                               ClientId = Convert.ToInt32(item.AUTHCKMAN)
                                           });

                if (item.LATENCY > config.Latency)
                {
                    ntfy.Add(new BackgroundProcessNotify()
                    {
                        FuncName = "BackgroundProcess",
                        PureBpId = item.Id,
                        FuncId = FunctionId,
                        JobId = config.Id,
                        Desc = "Latency Değeri " + config.Latency + " değerini aşmıştır.",
                        Case = (int)BpCase.Latency,//Latency
                        Date = DateTime.Now,
                        Level = (int)Level.error,//alert
                        CustomerProductId = GetRelationId(item.AUTHCKMAN),
                        Statu = 0
                    });
                }

                if (item.DURATION > config.Duration)
                {
                    ntfy.Add(new BackgroundProcessNotify()
                    {
                        FuncName = "BackgroundProcess",
                        PureBpId = item.Id,
                        FuncId = FunctionId,
                        JobId = config.Id,
                        Desc = "Duration Değeri " + config.Duration + " değerini aşmıştır.",
                        Case = (int)BpCase.Duration,//Duration
                        Date = DateTime.Now,
                        Level = (int)Level.error,//alert
                        CustomerProductId = GetRelationId(item.AUTHCKMAN),
                        Statu = 0
                    });
                }
                var avgWorkTime = item.LATENCY + item.DURATION;
                if (avgWorkTime > config.AvgWorkTime)
                {
                    ntfy.Add(new BackgroundProcessNotify()
                    {
                        FuncName = "BackgroundProcess",
                        PureBpId = item.Id,
                        FuncId = FunctionId,
                        JobId = config.Id,
                        Desc = "Duration Değeri " + config.Duration + " değerini aşmıştır.",
                        Case = (int)BpCase.AvgWorkTime,//avgWorkTime
                        Date = DateTime.Now,
                        Level = (int)Level.warning,//warning
                        CustomerProductId = GetRelationId(item.AUTHCKMAN),
                        Statu = 0
                    });
                }

                if (config.Starttime.TotalMilliseconds + item.LATENCY > config.Latency)
                {
                    ntfy.Add(new BackgroundProcessNotify()
                    {
                        FuncName = "BackgroundProcess",
                        PureBpId = item.Id,
                        FuncId = FunctionId,
                        JobId = config.Id,
                        Desc = "Job çalışma zamanı latency süresini geçmiştir.",
                        Case = (int)BpCase.StartTime,//StartTime
                        Date = DateTime.Now,
                        Level = (int)Level.error,//alert
                        CustomerProductId = GetRelationId(item.AUTHCKMAN),
                        Statu = 0
                    });
                }
            }
            return ntfy;
        }

        private int GetRelationId(string itemAuthckman)
        {
            return _customerProdDal.Get(x => x.ClientId == Convert.ToInt32(itemAuthckman) && x.ProductId == ProductId && x.CustomerId == CustomerId).CustomerProductId;
        }

        private BackgroundProcess CheckIfExists(string jobname)
        {
            return _configDal.Get(o => o.JobName == jobname);
        }

        public async Task<List<BpNotifyDetailView>> GetBpNotifyDetail(int customerProductId)
        {
            return await _notifyDetailDal.GetAll(x => x.CustomerProductId == customerProductId);
        }
    }
}
