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
using SapAgent.Entities.Concrete.Pure;
using SapAgent.Entities.Concrete.Spa;
using SapAgent.Entities.Concrete.Spa.Dto;
using RtmInfo = SapAgent.Entities.Concrete.Config.RtmInfo;

namespace SapAgent.Business.Config.Concrete
{
    public class ConfigRtmInfoManager : ConfigManager<RtmInfo>, IManagerConfigRtmInfoManager
    {
        private const int FunctionId = 1007;
        private const int CustomerId = 1;
        private const int ProductId = 1;
        private readonly IHttpClientHelper<DashboardSignalRModel> _httpClientHelper;
        private IBaseDal<Entities.Concrete.Pure.RtmInfo> _basePureDal;
        private IBaseDal<Entities.Concrete.Pure.RtmInfoBase> _basePureBaseDal;
        private IBaseDal<Entities.Concrete.Config.RtmInfo> _baseConfigDal;
        private readonly IBaseDal<RtmInfoNotify> _notificationDal;
        private readonly IBaseDal<CustomerProductView> _customerProdDal;
        private readonly IBaseDal<RtmInfoNotifyDetailView> _notifyDetailDal;
        public ConfigRtmInfoManager(IBaseDal<RtmInfo> entityRepository, IBaseDal<FuncFlag> funcFlagBaseDal, IHttpClientHelper<DashboardSignalRModel> httpClientHelper, IBaseDal<Entities.Concrete.Pure.RtmInfo> basePureDal, IBaseDal<RtmInfoBase> basePureBaseDal, IBaseDal<RtmInfo> baseConfigDal, IBaseDal<RtmInfoNotify> notificationDal, IBaseDal<CustomerProductView> customerProdDal, IBaseDal<RtmInfoNotifyDetailView> notifyDetailDal)
            : base(entityRepository, funcFlagBaseDal, FunctionId)
        {
            _httpClientHelper = httpClientHelper;
            _basePureDal = basePureDal;
            _basePureBaseDal = basePureBaseDal;
            _baseConfigDal = baseConfigDal;
            _notificationDal = notificationDal;
            _customerProdDal = customerProdDal;
            _notifyDetailDal = notifyDetailDal;
        }


        public Task<List<Entities.Concrete.Pure.RtmInfo>> GetAll(Expression<Func<Entities.Concrete.Pure.RtmInfo, bool>> filter)
        {
            throw new NotImplementedException();
        }
        public async Task<List<RtmInfoNotifyDetailView>> GetRtmInfoNotifyDetail(int customerProductId)
        {
            return await _notifyDetailDal.GetAll(x => x.CustomerProductId == customerProductId);
        }

        public void StartOperation(int customerId, int productId)
        {
            try
            {
                if (IsFlagUp())
                {
                    var lstExeTime = GetLastExecutionIndex();

                    var rawData = _basePureBaseDal.GetAll(x => x.SREQINDEX == lstExeTime).Result;
                    var list = new List<RtmModel>();
                    foreach (var rtmInfoBase in rawData)
                    {
                        var rtmModelEntity = new RtmModel();
                        rtmModelEntity.RtmBase = rtmInfoBase;
                        rtmModelEntity.RtmInfos = _basePureDal.GetAll(x => x.BASEID == rtmInfoBase.ID).Result;
                        list.Add(rtmModelEntity);
                    }
                    var alertlist = CatchAlert(list);

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

        private List<RtmInfoNotify> CatchAlert(List<RtmModel> rawData)
        {
            var listNotify = new List<RtmInfoNotify>();
            var configList = _baseConfigDal.GetAll(x => x.CustomerId == CustomerId && x.ProductId == ProductId).Result;
            var clientList = _customerProdDal.GetAll(x => x.ProductId == ProductId).Result.ToList();
            foreach (var item in rawData)
            {
                var table1Config = configList.FirstOrDefault(x => x.Type == "Table1");
                var table2Config = configList.FirstOrDefault(x => x.Type == "Table2");
                var currenttime = DateTime.Now.Hour;
                if (currenttime >= table1Config.StartTime && currenttime < table1Config.EndTime)
                {
                    if (item.RtmBase.STARTUPDATE == DateTime.Now.Date.ToString("yyyyMMdd"))
                    {
                        foreach (var client in clientList)
                        {
                            listNotify.Add(new RtmInfoNotify()
                            {
                                Level = (int)Level.error,
                                CustomerProductId = GetCustomerProductId(Convert.ToInt32(client.ClientId)),
                                Case = (int)SysFileEnumCase.LimitAsimi,
                                Date = DateTime.Now,
                                Desc = item.RtmBase.STARTUPDATE + " tarihinde " + item.RtmBase.SERVER +
                                       " sunucusu restart edilmiştir.Table 1",
                                FuncId = FunctionId,
                                Statu = 0
                            });
                        }
                    }
                }

                if (currenttime <= table2Config.EndTime && currenttime >= table2Config.StartTime)
                {
                    if (item.RtmBase.STARTUPDATE == DateTime.Now.Date.ToString("yyyyMMdd"))
                    {
                        foreach (var client in clientList)
                        {
                            listNotify.Add(new RtmInfoNotify()
                            {
                                Level = (int)Level.error,
                                CustomerProductId = GetCustomerProductId(Convert.ToInt32(client.ClientId)),
                                Case = (int)RtmInfoEnumCase.RestartTime,
                                Date = DateTime.Now,
                                Desc = item.RtmBase.STARTUPDATE + " tarihinde " + item.RtmBase.SERVER +
                                       " sunucusu restart edilmiştir. Table 2",
                                FuncId = FunctionId,
                                Statu = 0
                            });

                        }
                    }

                    foreach (var itemRtmInfo in item.RtmInfos)
                    {

                        if (itemRtmInfo.MAXSWAPPED > table2Config.WarningRange &&
                            itemRtmInfo.MAXSWAPPED < table2Config.ErrorRange)
                        {
                            foreach (var client in clientList)
                            {
                                listNotify.Add(new RtmInfoNotify()
                                {
                                    Level = (int)Level.warning,
                                    CustomerProductId = GetCustomerProductId(Convert.ToInt32(client.ClientId)),
                                    Case = (int)RtmInfoEnumCase.MaxSwapped,
                                    Date = DateTime.Now,
                                    Desc = item.RtmBase.SERVER+ " sunucusu RtmInfo MAXSWAPPED değeri " +itemRtmInfo.MAXSWAPPED + "'ine ulaşmıştır.",
                                    FuncId = FunctionId,
                                    Statu = 0
                                });
                            }
                        }

                        if (itemRtmInfo.MAXSWAPPED > table2Config.ErrorRange)
                        {
                            foreach (var client in clientList)
                            {
                                listNotify.Add(new RtmInfoNotify()
                                {
                                    Level = (int)Level.error,
                                    CustomerProductId = GetCustomerProductId(Convert.ToInt32(client.ClientId)),
                                    Case = (int)RtmInfoEnumCase.MaxSwapped,
                                    Date = DateTime.Now,
                                    Desc = item.RtmBase.SERVER + " sunucusu RtmInfo MAXSWAPPED değeri " + itemRtmInfo.MAXSWAPPED + "'ine ulaşmıştır.",
                                    FuncId = FunctionId,
                                    Statu = 0
                                });
                            }
                        }

                    }
                }
            }

            return listNotify;
        }

        private void AddNotificationToDb(List<RtmInfoNotify> alertlist)
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
