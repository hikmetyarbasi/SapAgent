using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PrdSystemUsage;
using SapAgent.ExternalServices.Abstract;

namespace SapAgent.ExternalServices.Concrete
{
    public class SystemUsageClientWrapperWithMockData : ISystemUsageClientWrapper
    {
       

        public async Task<ZaygbssysSysusageRf[]> GetData()
        {
            return new ZaygbcsysRfcsSysusageResponse1()
            {
                ZaygbcsysRfcsSysusageResponse = new ZaygbcsysRfcsSysusageResponse()
                {
                    EtSnapshots = new[]
                    {
                       new ZaygbssysSysusageRf()
                       {
                           TCpu = new []
                           {
                               new CcmSnapAll()
                               {
                                 Server  = "AYGERPTEST_AET_00",
                                 Item = "11",
                                 Section = "CPU",
                                 Descr1 = "Average processes waiting (  5 min)",
                                 Value1 = " 1 / 2 /97",
                                 Unit1 = "%",
                                 Descr2 = "0",
                                 Value2 = "",
                                 Unit2 = ""
                               } ,
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU Single",
                                   Value1 = " 1 / 2 /97",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                               Server  = "AYGERPTEST_AET_00",
                               Item = "14",
                               Section = "CPU Single",
                               Descr1 = "CPU   1  Usr/Sys/Idle",
                               Value1 = " 0 / 1 /99",
                               Unit1 = "%",
                               Descr2 = "",
                               Value2 = "",
                               Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   2  Usr/Sys/Idle",
                                   Value1 = " 1 / 1 /98",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   3  Usr/Sys/Idle",
                                   Value1 = " 1 / 2 /97",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   4  Usr/Sys/Idle",
                                   Value1 = " 1 / 1 /98",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   5  Usr/Sys/Idle",
                                   Value1 = " 2 / 1 /97",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   6  Usr/Sys/Idle",
                                   Value1 = " 1 / 2 /98",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   7  Usr/Sys/Idle",
                                   Value1 = " 0 / 1 /99",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   8  Usr/Sys/Idle",
                                   Value1 = " 2 / 5 /93",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   9  Usr/Sys/Idle",
                                   Value1 = " 2 / 5 /93",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               }
                           },
                           TMem = new []
                           {
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "11",
                                   Section = "CPU",
                                   Descr1 = "Average processes waiting (  5 min)",
                                   Value1 = "0",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   0  Usr/Sys/Idle",
                                   Value1 = " 1 / 2 /97",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   1  Usr/Sys/Idle",
                                   Value1 = " 0 / 1 /99",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   2  Usr/Sys/Idle",
                                   Value1 = " 1 / 1 /98",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   3  Usr/Sys/Idle",
                                   Value1 = " 1 / 2 /97",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   4  Usr/Sys/Idle",
                                   Value1 = " 1 / 1 /98",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   5  Usr/Sys/Idle",
                                   Value1 = " 2 / 1 /97",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   6  Usr/Sys/Idle",
                                   Value1 = " 1 / 2 /98",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   7  Usr/Sys/Idle",
                                   Value1 = " 0 / 1 /99",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   8  Usr/Sys/Idle",
                                   Value1 = " 2 / 5 /93",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                               new CcmSnapAll()
                               {
                                   Server  = "AYGERPTEST_AET_00",
                                   Item = "14",
                                   Section = "CPU Single",
                                   Descr1 = "CPU   9  Usr/Sys/Idle",
                                   Value1 = " 2 / 5 /93",
                                   Unit1 = "%",
                                   Descr2 = "",
                                   Value2 = "",
                                   Unit2 = ""
                               },
                           },
                           Server = ""
                       },
                        new ZaygbssysSysusageRf()
                        {
                            TCpu = new []
                            {
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "11",
                                    Section = "CPU",
                                    Descr1 = "Average processes waiting (  5 min)",
                                    Value1 = " 1 / 2 /97",
                                    Unit1 = "%",
                                    Descr2 = "0",
                                    Value2 = "",
                                    Unit2 = ""
                                } ,
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU Single",
                                    Value1 = " 1 / 2 /97",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   1  Usr/Sys/Idle",
                                    Value1 = " 0 / 1 /99",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   2  Usr/Sys/Idle",
                                    Value1 = " 1 / 1 /98",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   3  Usr/Sys/Idle",
                                    Value1 = " 1 / 2 /97",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   4  Usr/Sys/Idle",
                                    Value1 = " 1 / 1 /98",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   5  Usr/Sys/Idle",
                                    Value1 = " 2 / 1 /97",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   6  Usr/Sys/Idle",
                                    Value1 = " 1 / 2 /98",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   7  Usr/Sys/Idle",
                                    Value1 = " 0 / 1 /99",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   8  Usr/Sys/Idle",
                                    Value1 = " 2 / 5 /93",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   9  Usr/Sys/Idle",
                                    Value1 = " 2 / 5 /93",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                }
                            },
                            TMem = new []
                            {
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "11",
                                    Section = "CPU",
                                    Descr1 = "Average processes waiting (  5 min)",
                                    Value1 = "0",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   0  Usr/Sys/Idle",
                                    Value1 = " 1 / 2 /97",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   1  Usr/Sys/Idle",
                                    Value1 = " 0 / 1 /99",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   2  Usr/Sys/Idle",
                                    Value1 = " 1 / 1 /98",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   3  Usr/Sys/Idle",
                                    Value1 = " 1 / 2 /97",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   4  Usr/Sys/Idle",
                                    Value1 = " 1 / 1 /98",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   5  Usr/Sys/Idle",
                                    Value1 = " 2 / 1 /97",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   6  Usr/Sys/Idle",
                                    Value1 = " 1 / 2 /98",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   7  Usr/Sys/Idle",
                                    Value1 = " 0 / 1 /99",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   8  Usr/Sys/Idle",
                                    Value1 = " 2 / 5 /93",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                                new CcmSnapAll()
                                {
                                    Server  = "AYGERPTEST_AET_00",
                                    Item = "14",
                                    Section = "CPU Single",
                                    Descr1 = "CPU   9  Usr/Sys/Idle",
                                    Value1 = " 2 / 5 /93",
                                    Unit1 = "%",
                                    Descr2 = "",
                                    Value2 = "",
                                    Unit2 = ""
                                },
                            },
                            Server = ""
                        }
                   }
                }
            }.ZaygbcsysRfcsSysusageResponse.EtSnapshots;
        }
    }
}
