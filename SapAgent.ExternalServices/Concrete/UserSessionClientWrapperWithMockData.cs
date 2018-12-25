﻿using System.Threading.Tasks;
using SapAgent.ExternalServices.Abstract;
using PrdUserSession;

namespace SapAgent.ExternalServices.Concrete
{
    public class UserSessionClientWrapperWithMockData : IUserSessionClientWrapper
    {

        public async Task<ZaygbssysUsersessRf[]> GetData()
        {
            return new ZaygbcsysRfcsUsersesResponse1
            {
                ZaygbcsysRfcsUsersesResponse = new ZaygbcsysRfcsUsersesResponse
                {
                    EfErrMessage = "",
                    EtUsrSessList = new[] {

                        new ZaygbssysUsersessRf{
                            SessionType="RFC",
                            ExtStype="Senkron RFC",
                            ExtState="",
                            ExtTime="15.10.2018 14:21:00",
                            ExtTrace="Kpl.",
                            LineCol="",
                            Ipaddr="",
                            Selected="",
                            TotalMemKb=3725,
                            TotalMemBruttoKb=4238,
                            TotalMemHeapKb=0,
                            TotalMemHyperKb=54,
                            TotalMemAbapKb=3103,
                            ApplInfo="R=10 T=S S=AYGERPTEST_AET_00 I=SAPLSMON F=GET_CCM_DATA C=400 U=FFUMITB",
                            ActProgram="SAPMSSY1",
                            SecurityContext="",
                            LogonHdl=13,
                            LogonId=12600,
                            SessionHdl=0,
                            SessionKey="T13_U12600_M0",
                            Tenant="400",
                            UserName="FFUMITB",
                            Application="",
                            LocationInfo="DESKTOP-BC3ORR6",
                            Sessions=1,
                            RfcHdl="15049370",
                            RfcTypeLong="Dahili",
                            ServerName="AYGERPTEST_AET_00",
                            Trace=new byte(),
                            LogonPrivilege="",
                            Priority="Yüksek",
                            OpenTasks=0,
                            WebsocketHandle="",
                            SapGuiVersion="730",
                            PagingBlocks=0,
                            RequestTime=1539602460,
                            State="Oturum açıldı",
                            ClientIpAddr="172.16.10.4"
                        },
                        new ZaygbssysUsersessRf{
                            SessionType="GUI",
                            ExtStype="",
                            ExtState="",
                            ExtTime="15.10.2018 14:24:31",
                            ExtTrace="Kpl.",
                            LineCol="",
                            Ipaddr="",
                            Selected="",
                            TotalMemKb=115682,
                            TotalMemBruttoKb=127601,
                            TotalMemHeapKb=0,
                            TotalMemHyperKb=52,
                            TotalMemAbapKb=73245,
                            ApplInfo="",
                            ActProgram="WB_MNGR_START_FROM_TOOL_ACCESS",
                            SecurityContext="",
                            LogonHdl=18,
                            LogonId=11351,
                            SessionHdl=3,
                            SessionKey="T18_U11351_M3",
                            Tenant="400",
                            UserName="FFHALUKI",
                            Application="ZEF001N",
                            LocationInfo="KSN70003958",
                            Sessions=4,
                            RfcHdl="",
                            RfcTypeLong="",
                            ServerName="AYGERPTEST_AET_00",
                            Trace=new byte(),
                            LogonPrivilege="",
                            Priority="Yüksek",
                            OpenTasks=0,
                            WebsocketHandle="",
                            SapGuiVersion="740",
                            PagingBlocks=91,
                            RequestTime=1539602671,
                            State="Oturum açıldı",
                            ClientIpAddr="195.87.6.143"
                        },
                        new ZaygbssysUsersessRf{
                            SessionType="GUI",
                            ExtStype="",
                            ExtState="",
                            ExtTime="15.10.2018 14:24:10",
                            ExtTrace="Kpl.",
                            LineCol="",
                            Ipaddr="",
                            Selected="",
                            TotalMemKb=64017,
                            TotalMemBruttoKb=71078,
                            TotalMemHeapKb=0,
                            TotalMemHyperKb=76,
                            TotalMemAbapKb=39716,
                            ApplInfo="<Debugger>",
                            ActProgram="RSTPDAMAIN",
                            SecurityContext="",
                            LogonHdl=12,
                            LogonId=10669,
                            SessionHdl=3,
                            SessionKey="T12_U10669_M3",
                            Tenant="400",
                            UserName="FFUMITB",
                            Application="SESSION_MANAGER",
                            LocationInfo="DESKTOP-BC3ORR6",
                            Sessions=4,
                            RfcHdl="",
                            RfcTypeLong="",
                            ServerName="AYGERPTEST_AET_00",
                            Trace=new byte(),
                            LogonPrivilege="",
                            Priority="Yüksek",
                            OpenTasks=0,
                            WebsocketHandle="",
                            SapGuiVersion="730",
                            PagingBlocks=171,
                            RequestTime=1539602650,
                            State="Oturum açıldı",
                            ClientIpAddr="172.16.10.4"
                        },
                        new ZaygbssysUsersessRf{
                            SessionType="GUI",
                            ExtStype="",
                            ExtState="",
                            ExtTime="15.10.2018 14:24:33",
                            ExtTrace="Kpl.",
                            LineCol="",
                            Ipaddr="",
                            Selected="",
                            TotalMemKb=23692,
                            TotalMemBruttoKb=28853,
                            TotalMemHeapKb=0,
                            TotalMemHyperKb=762,
                            TotalMemAbapKb=13995,
                            ApplInfo="",
                            ActProgram="RS_TESTFRAME_CALL",
                            SecurityContext="",
                            LogonHdl=28,
                            LogonId=7270,
                            SessionHdl=0,
                            SessionKey="T28_U7270_M0",
                            Tenant="400",
                            UserName="10804784",
                            Application="SE37",
                            LocationInfo="NBEMREK01",
                            Sessions=1,
                            RfcHdl="",
                            RfcTypeLong="",
                            ServerName="AYGERPTEST_AET_00",
                            Trace=new byte(),
                            LogonPrivilege="",
                            Priority="Yüksek",
                            OpenTasks=0,
                            WebsocketHandle="",
                            SapGuiVersion="750",
                            PagingBlocks=12,
                            RequestTime=1539602673,
                            State="Oturum açıldı",
                            ClientIpAddr="10.34.10.59"
                        },
                        new ZaygbssysUsersessRf{
                            SessionType="RFC",
                            ExtStype="Senkron RFC",
                            ExtState="",
                            ExtTime="15.10.2018 14:21:30",
                            ExtTrace="Kpl.",
                            LineCol="",
                            Ipaddr="",
                            Selected="",
                            TotalMemKb=1994,
                            TotalMemBruttoKb=4238,
                            TotalMemHeapKb=0,
                            TotalMemHyperKb=54,
                            TotalMemAbapKb=1921,
                            ApplInfo="R=196 T=S S=AYGERPTEST_AET_00 I=/SSF/SLIB F=/SSF/CALL_SUBROUTINE_RFC C=400 U=SOLMAN",
                            ActProgram="SAPMSSY1",
                            SecurityContext="",
                            LogonHdl=11,
                            LogonId=6313,
                            SessionHdl=0,
                            SessionKey="T11_U6313_M0",
                            Tenant="400",
                            UserName="SOLMAN",
                            Application="",
                            LocationInfo="AYGERPTEST",
                            Sessions=1,
                            RfcHdl="00735246",
                            RfcTypeLong="Dahili",
                            ServerName="AYGERPTEST_AET_00",
                            Trace=new byte(),
                            LogonPrivilege="",
                            Priority="Orta",
                            OpenTasks=0,
                            WebsocketHandle="",
                            SapGuiVersion="0",
                            PagingBlocks=0,
                            RequestTime=1539602490,
                            State="Oturum açıldı",
                            ClientIpAddr=""
                        }, new ZaygbssysUsersessRf{
                            SessionType="RFC",
                            ExtStype="Senkron RFC",
                            ExtState="",
                            ExtTime="15.10.2018 14:24:32",
                            ExtTrace="Kpl.",
                            LineCol="",
                            Ipaddr="",
                            Selected="",
                            TotalMemKb=3650,
                            TotalMemBruttoKb=4238,
                            TotalMemHeapKb=0,
                            TotalMemHyperKb=54,
                            TotalMemAbapKb=2937,
                            ApplInfo="R=1032 T=S S=AYGERPTEST I= F=/SDF/IS_PROXY C= U=",
                            ActProgram="SAPMSSY1",
                            SecurityContext="",
                            LogonHdl=34,
                            LogonId=6295,
                            SessionHdl=0,
                            SessionKey="T34_U6295_M0",
                            Tenant="400",
                            UserName="SOLMAN",
                            Application="",
                            LocationInfo="AYGERPTEST",
                            Sessions=1,
                            RfcHdl="00659737",
                            RfcTypeLong="Harici",
                            ServerName="AYGERPTEST_AET_00",
                            Trace=new byte(),
                            LogonPrivilege="",
                            Priority="Orta",
                            OpenTasks=0,
                            WebsocketHandle="",
                            SapGuiVersion="0",
                            PagingBlocks=2,
                            RequestTime=1539602672,
                            State="Oturum açıldı",
                            ClientIpAddr=""
                        }, new ZaygbssysUsersessRf{
                            SessionType="GUI",
                            ExtStype="",
                            ExtState="",
                            ExtTime="15.10.2018 14:09:57",
                            ExtTrace="Kpl.",
                            LineCol="",
                            Ipaddr="",
                            Selected="",
                            TotalMemKb=93157,
                            TotalMemBruttoKb=107426,
                            TotalMemHeapKb=0,
                            TotalMemHyperKb=52,
                            TotalMemAbapKb=56833,
                            ApplInfo="",
                            ActProgram="WB_MNGR_START_FROM_TOOL_ACCESS",
                            SecurityContext="",
                            LogonHdl=20,
                            LogonId=6181,
                            SessionHdl=5,
                            SessionKey="T20_U6181_M5",
                            Tenant="400",
                            UserName="FFFATIHG",
                            Application="ZSDFYT002B",
                            LocationInfo="LENOVO",
                            Sessions=6,
                            RfcHdl="",
                            RfcTypeLong="",
                            ServerName="AYGERPTEST_AET_00",
                            Trace=new byte(),
                            LogonPrivilege="",
                            Priority="Yüksek",
                            OpenTasks=0,
                            WebsocketHandle="",
                            SapGuiVersion="730",
                            PagingBlocks=70,
                            RequestTime=1539601797,
                            State="Oturum açıldı",
                            ClientIpAddr="195.87.6.143"
                        }
                    }
                }
            }.ZaygbcsysRfcsUsersesResponse.EtUsrSessList;
        }
    }
}
