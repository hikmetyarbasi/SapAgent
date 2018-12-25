using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PrdBackgroundProcess;
using SapAgent.ExternalServices.Abstract;

namespace SapAgent.ExternalServices.Concrete
{
    public class BackgroundProcessClientWrapperWithMockData : IBackgroundProcessClientWrapper
    {
        public async Task<ZaygbssysTbtcjobBkRf[]> GetData()
        {
            var repsonse = new ZaygbcsysRfcsBckgprcResponse1()
            {
                ZaygbcsysRfcsBckgprcResponse = new ZaygbcsysRfcsBckgprcResponse()
                {
                    EtJoblist = new[]
                    {
                        new ZaygbssysTbtcjobBkRf()
                        {
                            Jobname ="E ARŞIV HATALI IŞLEME",
                            Jobcount = "13083401",
                            Jobgroup = "",
                            Intreport = "%NEWSTEP",
                            Stepcount= 1,
                            Sdlstrtdt = "15.10.2018",
                            Sdlstrttm = new DateTime(),
                            Btcsystem = "",
                            Sdldate = "15.10.2018",
                            Sdltime = new DateTime(),
                            Sdluname = "10805121",
                            Lastchdate = "14.07.2018",
                            Lastchtime = new DateTime(),
                            Lastchname = "FFFETHIY",
                            Reldate = "15.10.2018",
                            Reltime = new DateTime(),
                            Reluname = "SAPSYS",
                            Strtdate = "15.10.2018",
                            Strttime = new DateTime(),
                            Enddate = "15.10.2018",
                            Endtime = new DateTime(),
                            Prdmins = "2",
                            Prdhours = "0",
                            Prddays = "0",
                            Prdweeks = "0",
                            Prdmonths = "0",
                            Periodic = "X",
                            Delanfrep = "",
                            Emergmode = "",
                            Status = "R",
                            Newflag = "C",
                            Authcknam = "JOBFI",
                            Authckman = "400",
                            Succnum = 0,
                            Prednum = 0,
                            Joblog = "JOBLGX13083401X83303",
                            Laststrtdt = "15.10.2018",
                            Laststrttm = new DateTime(),
                            Wpnumber = 77,
                            Wpprocid = 4044,
                            Eventid = "",
                            Eventparm = "",
                            Btcsysreax = "AYGERPPR2",
                            Jobclass = "C",
                            Priority = 0,
                            Eventcount = "",
                            Checkstat = "",
                            Calendarid = "",
                            Prdbehav = "",
                            Execserver = "AYGERPPR2_AEP_00",
                            Eomcorrect = 0,
                            Calcorrect = 0,
                            Reaxserver = "AYGERPPR2_AEP_00",
                            Reclogsys = "",
                            Recobjtype = "",
                            Recobjkey = "",
                            Recdescrib = "",
                            Tgtsrvgrp = "",
                            Progname = "RBDAGAIN",
                            Xpgprog = "",
                            Extcmd = "",
                            Duration = 0,
                            Latency = 56
                        },
                    }
                }

            };
            return repsonse.ZaygbcsysRfcsBckgprcResponse.EtJoblist;
        }
    }
}
