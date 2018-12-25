using System;
using System.Collections.Generic;
using System.Linq;
using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.Spa;
using BackgroundProcessNotify = SapAgent.Entities.Concrete.Config.BackgroundProcessNotify;

namespace SapAgent.Business.Config.Concrete
{
    public class BackgroundProcessConfigManager : ManagerConfig<BackgroundProcess>
    {
        private const int FunctionId = 1;
        private readonly IBaseDal<Entities.Concrete.Pure.BackgroundProcess> _pureDal;
        private readonly IBaseDal<Entities.Concrete.Config.BackgroundProcess> _configDal;
        private readonly IBaseDal<Entities.Concrete.Config.BackgroundProcessNotify> _notificationDal;
        private readonly IBaseDal<Entities.Concrete.Config.FuncFlag> _flagDal;
        private readonly IBaseDal<BpNotifyView> _bpNotifyDal;
        private readonly IHttpClientHelper<BackgroundProcessNotify> _httpClientHelper;
        public BackgroundProcessConfigManager(IBaseDal<BackgroundProcess> dal,
            IBaseDal<Entities.Concrete.Pure.BackgroundProcess> pureDal,
            IBaseDal<Entities.Concrete.Config.FuncFlag> flagDal,
            IBaseDal<Entities.Concrete.Config.BackgroundProcess> configDal,
            IBaseDal<Entities.Concrete.Config.BackgroundProcessNotify> spaNotificationDal, IBaseDal<BpNotifyView> bpNotifyDal,
            IHttpClientHelper<BackgroundProcessNotify> httpClientHelper) :
            base(dal)
        {
            _pureDal = pureDal;
            _flagDal = flagDal;
            _configDal = configDal;
            _notificationDal = spaNotificationDal;
            _bpNotifyDal = bpNotifyDal;
            _httpClientHelper = httpClientHelper;
        }

        public override void StartOperation()
        {
            try
            {
                var lstExeTime = GetLastExecutionIndex();
                var rawData = GetRawData(lstExeTime);
                var alertlist = CatchAlert(rawData);
                AddNotificationToDb(alertlist);
                PushNotifyModelToClient(1);
                var response = _httpClientHelper.PostRequest("Message/api/BackgroundProcessChart1",new BackgroundProcessNotify());

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public override int GetBackgroundProcessTotalJobCount()
        {
            var lstExeTime = GetLastExecutionIndex();
            return _pureDal.GetAll(x => x.SREQINDEX == lstExeTime).Count;
        }

        public override List<BpNotifyView> GetCurrentStateOfNotify()
        {
            return _bpNotifyDal.GetAll(o => o.CustomerId == 1);
        }

        public List<BpNotifyView> PushNotifyModelToClient(int customerId)
        {
            var puredata = _bpNotifyDal.GetAll(o => o.CustomerId == customerId);
            return puredata;
        }

        public void AddNotificationToDb(List<BackgroundProcessNotify> list)
        {
            foreach (var item in list)
            {
                _notificationDal.Add(item);
            }
        }

        private Guid GetLastExecutionIndex()
        {
            return _flagDal.Get(o => o.Func == FunctionId).SReqIndex;
        }

        private List<Entities.Concrete.Pure.BackgroundProcess> GetRawData(Guid sReqIndex)
        {
            return _pureDal.GetAll(o => o.SREQINDEX == sReqIndex);
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
                        JobId = config.Id,
                        Desc = "Latency Değeri " + config.Latency + " değerini aşmıştır.",
                        Case = 1,//Latency
                        Date = DateTime.Now,
                        Level = 2,//alert
                        CustomerProductId = 10,
                        Statu = 0
                    });
                }

                if (item.DURATION > config.Duration)
                {
                    ntfy.Add(new BackgroundProcessNotify()
                    {
                        FuncName = "BackgroundProcess",
                        JobId = config.Id,
                        Desc = "Duration Değeri " + config.Duration + " değerini aşmıştır.",
                        Case = 2,//Duration
                        Date = DateTime.Now,
                        Level = 2,//alert
                        CustomerProductId = 2,
                        Statu = 0
                    });
                }
                var avgWorkTime = item.LATENCY + item.DURATION;
                if (avgWorkTime > config.AvgWorkTime)
                {
                    ntfy.Add(new BackgroundProcessNotify()
                    {
                        FuncName = "BackgroundProcess",
                        JobId = config.Id,
                        Desc = "Duration Değeri " + config.Duration + " değerini aşmıştır.",
                        Case = 3,//avgWorkTime
                        Date = DateTime.Now,
                        Level = 1,//warning
                        CustomerProductId = 1,
                        Statu = 0
                    });
                }

                if (config.Starttime.TotalMilliseconds + item.LATENCY > config.Latency)
                {
                    ntfy.Add(new BackgroundProcessNotify()
                    {
                        FuncName = "BackgroundProcess",
                        JobId = config.Id,
                        Desc = "Job çalışma zamanı latency süresini geçmiştir.",
                        Case = 4,//StartTime
                        Date = DateTime.Now,
                        Level = 2,//alert
                        CustomerProductId = 6,
                        Statu = 0
                    });
                }
            }
            return ntfy;
        }

        private void AddNotification(Entities.Concrete.Config.BackgroundProcessNotify ntfy)
        {
            _notificationDal.Add(ntfy);
        }

        private BackgroundProcess CheckIfExists(string jobname)
        {
            return _configDal.Get(o => o.JobName == jobname);
        }
    }
}
