using SapAgent.ExternalServices.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PrdSystemList;

namespace SapAgent.ExternalServices.Concrete
{
    public class SystemListClientWrapperWithMockData : ISystemListClientWrapper
    {

        public async Task<ZaygbcsysMsxxlistV6Rf[]> GetData()
        {
            return new ZaygbcsysRfcsSystlstResponse1
            {
                ZaygbcsysRfcsSystlstResponse = new ZaygbcsysRfcsSystlstResponse
                {
                    EtSysList = new[] {
                        new ZaygbcsysMsxxlistV6Rf{
                            Name="AYGERPAPP1_AEP_00",
                            Host="AYGERPAPP1",
                            Serv="sapdp00",
                            Msgtypes=new byte[1],
                            Hostadr=new byte[1],
                            Servno=new byte[1],
                            State=new byte[1],
                            Hostnamelong="AYGERPAPP1",
                            HostaddrV4Str="212.115.15.123",
                            HostaddrV6Str="212.115.15.123",
                            Sysservice0=new byte[1],
                            Sysservice1=new byte[1],
                            Sysservice2=new byte[1],
                            Sysservice3=new byte[1],
                            Services="Diyal. Artl. Gncl. Upd2 Kyrk. ICM",
                            Servstr="3200",
                            Status="Active"
                        },
                        new ZaygbcsysMsxxlistV6Rf{
                            Name="",
                            Host="",
                            Serv="",
                            Msgtypes=new byte[1],
                            Hostadr=new byte[1],
                            Servno=new byte[1],
                            State=new byte[1],
                            Hostnamelong="AYGERPPR1",
                            HostaddrV4Str="212.115.15.105",
                            HostaddrV6Str="212.115.15.105",
                            Sysservice0=new byte[1],
                            Sysservice1=new byte[1],
                            Sysservice2=new byte[1],
                            Sysservice3=new byte[1],
                            Services="Diyal. Artl. Gncl. Upd2 Kyrk. ICM",
                            Servstr="3200",
                            Status="Active"
                        },
                        new ZaygbcsysMsxxlistV6Rf{
                            Name="",
                            Host="",
                            Serv="",
                            Msgtypes=new byte[1],
                            Hostadr=new byte[1],
                            Servno=new byte[1],
                            State=new byte[1],
                            Hostnamelong="AYGERPPR2",
                            HostaddrV4Str="212.115.15.108",
                            HostaddrV6Str="212.115.15.108",
                            Sysservice0=new byte[1],
                            Sysservice1=new byte[1],
                            Sysservice2=new byte[1],
                            Sysservice3=new byte[1],
                            Services="Diyal. Artl. Gncl. Upd2 Kyrk. ICM",
                            Servstr="3200",
                            Status="Active"
                        },
                        new ZaygbcsysMsxxlistV6Rf{
                            Name="",
                            Host="",
                            Serv="",
                            Msgtypes=new byte[1],
                            Hostadr=new byte[1],
                            Servno=new byte[1],
                            State=new byte[1],
                            Hostnamelong="AYGERPPRD",
                            HostaddrV4Str="212.115.15.99",
                            HostaddrV6Str="212.115.15.99",
                            Sysservice0=new byte[1],
                            Sysservice1=new byte[1],
                            Sysservice2=new byte[1],
                            Sysservice3=new byte[1],
                            Services="Diyal. Artl. Gncl. Upd2 Kyrk. ICM",
                            Servstr="3200",
                            Status="Active"
                        }
                    }
                }
            }.ZaygbcsysRfcsSystlstResponse.EtSysList;
        }
    }
}
