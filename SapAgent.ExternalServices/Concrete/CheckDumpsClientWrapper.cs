using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using PrdCheckDumps;
using SapAgent.ExternalServices.Abstract;

namespace SapAgent.ExternalServices.Concrete
{
    public class CheckDumpsClientWrapper : ICheckDumpsClientWrapper
    {
        private zaygbcsys_ws_chkdumpsClient _checkDumpsClient;

        public CheckDumpsClientWrapper()
        {

            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            binding.MaxBufferSize = 20000000;
            binding.MaxReceivedMessageSize = 20000000;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            EndpointAddress endpoint = new EndpointAddress("http://AYGERPPRD.AYGAZNET.LOCAL:8000/sap/bc/srt/rfc/sap/zaygbcsys_ws_chkdumps/400/zaygbcsys_ws_chkdumps_bn/zaygbcsys_ws_chkdumps_bn");

            var client = new zaygbcsys_ws_chkdumpsClient(binding, endpoint);
            client.ClientCredentials.UserName.UserName = "Rfc_etalep";
            client.ClientCredentials.UserName.Password = "Temp2010";
            this._checkDumpsClient = client;
        }
        public async Task<ZaygbcsysRdumpov[]> GetData()
        {
            try
            {
                var data = _checkDumpsClient.ZaygbcsysRfcsChkdumpsAsync(new ZaygbcsysRfcsChkdumps()
                {
                    IfClient = "",
                    IfDatumFr = "",
                    IfDatumTo = "",
                    IfErrid = "",
                    IfExceptid = "",
                    IfPrgid = "",
                    IfToday = "",
                    IfTrnid = "",
                    IfUname = ""
                }).GetAwaiter().GetResult().ZaygbcsysRfcsChkdumpsResponse.EtDumplist;
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
