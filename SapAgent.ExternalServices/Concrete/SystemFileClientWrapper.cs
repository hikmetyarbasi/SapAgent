using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PrdSystemFile;
using PrdSystemList;
using SapAgent.ExternalServices.Abstract;

namespace SapAgent.ExternalServices.Concrete
{
    public class SystemFileClientWrapper: ISystemFileClientWrapper
    {
        private readonly ZAYGBCSYS_WS_SYSFILEClient _client;
        public SystemFileClientWrapper()
        {
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            EndpointAddress endpoint = new EndpointAddress("http://AYGERPPRD.AYGAZNET.LOCAL:8000/sap/bc/srt/rfc/sap/zaygbcsys_ws_sysfile/400/zaygbcsys_ws_sysfile/zaygbcsys_ws_sysfile_bn");

            _client = new ZAYGBCSYS_WS_SYSFILEClient(binding, endpoint);
            _client.ClientCredentials.UserName.UserName = "Rfc_etalep";
            _client.ClientCredentials.UserName.Password = "Temp2010";
        }
        public async Task<ZaygbssysSysfsyRf[]> GetData()
        {
            var data = await _client.ZaygbcsysRfcsSysfileAsync(new ZaygbcsysRfcsSysfile());

            return data.ZaygbcsysRfcsSysfileResponse.EtFsyInfo;
        }
    }
}
