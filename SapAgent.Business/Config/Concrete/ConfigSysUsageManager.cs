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
using SapAgent.Entities.Concrete.Pure;
using SapAgent.Entities.Concrete.Spa;
using Dump = SapAgent.Entities.Concrete.Pure.Dump;
using SysUsage = SapAgent.Entities.Concrete.Pure.SysUsage;

namespace SapAgent.Business.Config.Concrete
{
    public class ConfigSysUsageManager : ConfigManager<Entities.Concrete.Config.SysUsage>, IManagerConfigSysUsageManager
    {
        private const int FunctionId = 6;
        private const int CustomerId = 1;
        private const int ProductId = 1;
        private readonly IHttpClientHelper<DashboardSignalRModel> _httpClientHelper;
        private IBaseDal<Entities.Concrete.Pure.SysUsage> _basePureDal;
        private IBaseDal<Entities.Concrete.Config.SysUsage> _baseConfigDal;
        private readonly IBaseDal<SysUsageNotify> _notificationDal;
        private readonly IBaseDal<CustomerProductView> _customerProdDal;
        private readonly IBaseDal<SysUsageNotifyDetailView> _notifyDetailDal;
        public ConfigSysUsageManager(
            IBaseDal<Entities.Concrete.Config.SysUsage> _entityRepository,
            IBaseDal<FuncFlag> funcFlagBaseDal,
            IHttpClientHelper<DashboardSignalRModel> httpClientHelper,
            IBaseDal<Entities.Concrete.Pure.SysUsage> basePureDal,
            IBaseDal<Entities.Concrete.Config.SysUsage> baseConfigDal,
            IBaseDal<CustomerProductView> customerProdDal,
            IBaseDal<SysUsageNotify> notificationDal1,
            IBaseDal<SysUsageNotifyDetailView> notifyDetailDal1)
            : base(_entityRepository, funcFlagBaseDal, FunctionId)
        {
            _httpClientHelper = httpClientHelper;
            _baseConfigDal = baseConfigDal;
            _customerProdDal = customerProdDal;
            _basePureDal = basePureDal;
            _notificationDal = notificationDal1;
            _notifyDetailDal = notifyDetailDal1;
        }

        public async Task<List<SysUsageNotifyDetailView>> GetSysUsageNotifyDetail(int customerProductId)
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

        private void AddNotificationToDb(List<SysUsageNotify> alertlist)
        {
            foreach (var item in alertlist)
            {
                _notificationDal.Add(item);
            }
        }

        private List<SysUsageNotify> CatchAlert(List<SysUsage> rawData)
        {

            var listNotify = new List<SysUsageNotify>();
            try
            {
                if (rawData.Count == 0) return null;
                var cpuList = rawData.Where(x => x.TYPE.Trim() == "Cpu" && x.SECTION == "CPU Single").ToList();
                var memoryList = rawData.Where(x => x.TYPE.Trim() == "Mem" && x.SECTION == "Memory" && x.DESCR1 == "Physical" || x.DESCR1.Contains("Free")).ToList();

                var cpuConfig = _baseConfigDal.Get(x => x.Type == "Cpu" && x.CustomerId == CustomerId && x.ProductId == ProductId);
                var memConfig = _baseConfigDal.Get(x => x.Type == "Mem" && x.CustomerId == CustomerId && x.ProductId == ProductId);
                var clientList = _customerProdDal.GetAll(x => x.ProductId == ProductId).Result.ToList();
                foreach (var item in cpuList)
                {
                    var freeUsage = Convert.ToInt32(item.VALUE1.Replace(" ", "").Split('/')[2]);

                    if (freeUsage < cpuConfig.WarningRange && freeUsage > cpuConfig.ErrorRange)
                    {

                        foreach (var client in clientList)

                        {
                            listNotify.Add(new SysUsageNotify()
                            {
                                FuncId = FunctionId,
                                Desc = item.SERVER + " için free Usage değeri" + cpuConfig.WarningRange + " altına düşmüştür.",
                                Case = (int)SysUsageEnumCase.LimitAsimi,
                                Date = DateTime.Now,
                                Level = (int)Level.warning,
                                CustomerProductId = GetCustomerProductId(Convert.ToInt32(client.ClientId)),
                                Statu = 0
                            });
                        }

                    }

                    if (freeUsage < cpuConfig.ErrorRange)
                    {
                        foreach (var client in clientList)

                        {
                            listNotify.Add(new SysUsageNotify()
                            {
                                FuncId = FunctionId,
                                Desc = item.SERVER + " için CPU free Usage değeri" + cpuConfig.WarningRange + " altına düşmüştür.",
                                Case = (int)SysUsageEnumCase.LimitAsimi,
                                Date = DateTime.Now,
                                Level = (int)Level.error,
                                CustomerProductId = GetCustomerProductId(Convert.ToInt32(client.ClientId)),
                                Statu = 0
                            });
                        }
                    }

                }

                var machinelist = memoryList.GroupBy(x => new { x.SERVER }).Select(x => new { server = x.Key.SERVER });

                foreach (var machine in machinelist)
                {
                    var physicalMem = memoryList.FirstOrDefault(x => x.SERVER == machine.server && x.DESCR1 == "Physical");
                    var freeMem = memoryList.FirstOrDefault(x => x.SERVER == machine.server && x.DESCR1 == "Free (Value)");
                    if (
                        (Convert.ToInt32(physicalMem?.VALUE1) * memConfig.WarningRange / 100 > Convert.ToInt32(freeMem?.VALUE1) &&
                         Convert.ToInt32(freeMem?.VALUE1) > Convert.ToInt32(physicalMem?.VALUE1) * memConfig.ErrorRange / 100))
                    {
                        foreach (var client in clientList)
                        {
                            listNotify.Add(new SysUsageNotify()
                            {
                                FuncId = FunctionId,
                                Desc = machine.server + " için Memory free Usage değeri" + cpuConfig.WarningRange + " altına düşmüştür.",
                                Case = (int)SysUsageEnumCase.LimitAsimi,
                                Date = DateTime.Now,
                                Level = (int)Level.warning,
                                CustomerProductId = GetCustomerProductId(Convert.ToInt32(client.ClientId)),
                                Statu = 0
                            });
                        }
                    }

                    if (Convert.ToInt32(freeMem?.VALUE1) <
                        Convert.ToInt32(physicalMem?.VALUE1) * memConfig.ErrorRange / 100)
                    {
                        foreach (var client in clientList)
                        {
                            listNotify.Add(new SysUsageNotify()
                            {
                                FuncId = FunctionId,
                                Desc = machine.server + " için Memory free Usage değeri" + cpuConfig.ErrorRange + " altına düşmüştür.",
                                Case = (int)SysUsageEnumCase.LimitAsimi,
                                Date = DateTime.Now,
                                Level = (int)Level.error,
                                CustomerProductId = GetCustomerProductId(Convert.ToInt32(client.ClientId)),
                                Statu = 0
                            });
                        }
                    }
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return listNotify;
        }

        private int GetCustomerProductId(int clientId)
        {
            return _customerProdDal.Get(x => x.CustomerId == CustomerId && x.ProductId == ProductId && x.ClientId == clientId).CustomerProductId;
        }
    }
}
