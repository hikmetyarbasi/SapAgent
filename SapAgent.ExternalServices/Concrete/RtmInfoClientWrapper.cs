using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PrdKernalCompat;
using PrdRtmInfo;
using SapAgent.ExternalServices.Abstract;

namespace SapAgent.ExternalServices.Concrete
{
    public class RtmInfoClientWrapper : IRtmInfoClientWrapper
    {
        private ZAYGBCSYS_WS_RTMINFOClient _client;
        public RtmInfoClientWrapper()
        {
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            EndpointAddress endpoint = new EndpointAddress("http://AYGERPPRD.AYGAZNET.LOCAL:8000/sap/bc/srt/rfc/sap/zaygbcsys_ws_rtminfo/400/zaygbcsys_ws_rtminfo/zaygbcsys_ws_rtminfo_bn");

            _client = new ZAYGBCSYS_WS_RTMINFOClient(binding, endpoint);
            _client.ClientCredentials.UserName.UserName = "Rfc_etalep";
            _client.ClientCredentials.UserName.Password = "Temp2010";
        }

        public async Task<ZaygbcsysRtminfoRf[]> GetData()
        {
            var data = await _client.ZaygbcsysRfcsRtminfoAsync(new ZaygbcsysRfcsRtminfo());
            return data.ZaygbcsysRfcsRtminfoResponse.EtRtinfo;
        }
    }
}
