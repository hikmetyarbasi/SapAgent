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
    public class BackgroundProcessConfigManager : IManagerBpConfigManager
    {
        private const int FunctionId = 1;
        public int ProductId = 0;
        private readonly IBaseDal<Entities.Concrete.Pure.BackgroundProcess> _pureDal;
        private readonly IBaseDal<Entities.Concrete.Config.BackgroundProcess> _configDal;
        private readonly IBaseDal<Entities.Concrete.Config.BackgroundProcessNotify> _notificationDal;
        private readonly IBaseDal<Entities.Concrete.Config.FuncFlag> _flagDal;
        private readonly IBaseDal<BpNotifyView> _bpNotifyDal;
        private readonly IHttpClientHelper<DashboardSignalRModel> _httpClientHelper;
        public BackgroundProcessConfigManager(IBaseDal<BackgroundProcess> dal,
            IBaseDal<Entities.Concrete.Pure.BackgroundProcess> pureDal,
            IBaseDal<Entities.Concrete.Config.FuncFlag> flagDal,
            IBaseDal<Entities.Concrete.Config.BackgroundProcess> configDal,
            IBaseDal<Entities.Concrete.Config.BackgroundProcessNotify> spaNotificationDal, IBaseDal<BpNotifyView> bpNotifyDal,
            IHttpClientHelper<DashboardSignalRModel> httpClientHelper)
        {
            _pureDal = pureDal;
            _flagDal = flagDal;
            _configDal = configDal;
            _notificationDal = spaNotificationDal;
            _bpNotifyDal = bpNotifyDal;
            _httpClientHelper = httpClientHelper;
        }

        public Task<List<BackgroundProcess>> GetAll(Expression<Func<BackgroundProcess, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void StartOperation(int productId)
        {
            ProductId = productId;
            try
            {
                if (IsFlagUp())
                {
                    var lstExeTime = GetLastExecutionIndex();
                    var rawData = GetRawData(lstExeTime);
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

        public void UpFlag(Guid sRIndex)
        {
            throw new NotImplementedException();
        }

        public void DownFlag()
        {
            throw new NotImplementedException();
        }

        private bool IsFlagUp()
        {
            var flag = _flagDal.Get(o => o.Func == FunctionId);
            return flag.Flag == 1;
        }


        public int GetBackgroundProcessTotalJobCount()
        {
            var lstExeTime = GetLastExecutionIndex();
            return _pureDal.GetAll(x => x.SREQINDEX == lstExeTime).Result.Count;
        }

        public async Task<List<BpNotifyViewDto>> GetCurrentStateOfNotify(int customerId)
        {
            var list = await _bpNotifyDal.GetAll(o => o.CustomerId == customerId);

            var productsgroup = list.GroupBy(g => new { g.ProductId, g.ProductName }).Select(s => s.Key).ToList();
            var listDto = new List<BpNotifyViewDto>();
            foreach (var product in productsgroup)
            {
                var dto = new BpNotifyViewDto();
                dto.CustomerId = customerId;
                var p = new Product()
                {
                    Id = product.ProductId,
                    ProductName = product.ProductName
                };
                var clientsgroup = list.Where(x => x.ProductId == product.ProductId).GroupBy(g => new { g.ClientId, g.ClientName }).Select(s => s.Key).ToList();
                var clientlist = new List<ClientDto>();
                foreach (var client in clientsgroup)
                {
                    var c = new ClientDto()
                    {
                        ClientId = client.ClientId,
                        ClientName = client.ClientName
                    };
                    var notificationlevel = list.Where(y => y.ProductId == product.ProductId && y.ClientId == client.ClientId).ToList();
                    c.NotificationLevel = ClearUnNecessaryNotification(notificationlevel);
                    c.CustomerProductId = notificationlevel[0].CustomerProductId;
                    clientlist.Add(c);
                }

                dto.Product = p;
                dto.Clients = clientlist;
                listDto.Add(dto);
            }
            return listDto;
        }

        private NotificationLevel ClearUnNecessaryNotification(List<BpNotifyView> bpNotifyView)
        {
            var errorcount = bpNotifyView.Count(x => x.Level == (int)Category.error && x.Amount > 0);
            if (errorcount > 0)
            {
                return bpNotifyView.Where(x => x.Level == (int)Category.error).Select(y => new NotificationLevel()
                {
                    Category = Category.error,
                    Amount = y.Amount,
                    LevelName = Category.error.ToString()
                }).FirstOrDefault();
            }
            var warningcount = bpNotifyView.Count(x => x.Level == (int)Category.warning && x.Amount > 0);
            if (warningcount > 0)
            {
                return bpNotifyView.Where(x => x.Level == (int)Category.warning).Select(y => new NotificationLevel()
                {
                    Category = Category.warning,
                    Amount = y.Amount,
                    LevelName = Category.warning.ToString()
                }).FirstOrDefault();
            }
            var infocount = bpNotifyView.Count(x => x.Level == (int)Category.info && x.Amount > 0);
            if (infocount > 0)
            {
                return bpNotifyView.Where(x => x.Level == (int)Category.info).Select(y => new NotificationLevel()
                {
                    Category = Category.info,
                    Amount = y.Amount,
                    LevelName = Category.info.ToString()
                }).FirstOrDefault();
            }
            return new NotificationLevel()
            {
                Category = Category.None,
                Amount = 0,
                LevelName = Category.None.ToString()
            };
        }

        public List<BpNotifyView> PushNotifyModelToClient(int customerId)
        {
            var puredata = _bpNotifyDal.GetAll(o => o.CustomerId == customerId);
            return puredata.Result;
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
            return _pureDal.GetAll(o => o.SREQINDEX == sReqIndex).Result;
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
                        Level = (int)Category.error,//alert
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
                        Level = (int)Category.error,//alert
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
                        Level = (int)Category.warning,//warning
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
                        Level = (int)Category.error,//alert
                        CustomerProductId = GetRelationId(item.AUTHCKMAN),
                        Statu = 0
                    });
                }
            }
            return ntfy;
        }

        private int GetRelationId(string itemAuthckman)
        {
            return _bpNotifyDal.Get(x => x.ClientId == Convert.ToInt32(itemAuthckman) && x.ProductId == ProductId).CustomerProductId;
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
