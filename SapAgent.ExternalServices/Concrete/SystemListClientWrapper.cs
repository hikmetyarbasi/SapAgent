using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using SapAgent.ExternalServices.Abstract;
using System.Threading.Tasks;
using System.Xml;
using PrdSystemList;

namespace SapAgent.ExternalServices.Concrete
{
    public class SystemListClientWrapper : ISystemListClientWrapper
    {
        private readonly zaygbcsys_ws_systlstClient _client;

        public SystemListClientWrapper()
        {

            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            EndpointAddress endpoint = new EndpointAddress("http://AYGERPPRD.AYGAZNET.LOCAL:8000/sap/bc/srt/rfc/sap/zaygbcsys_ws_systlst/400/zaygbcsys_ws_systlst/zaygbcsys_ws_systlst_bn");

            _client = new zaygbcsys_ws_systlstClient(binding, endpoint);
            _client.ClientCredentials.UserName.UserName = "Rfc_etalep";
            _client.ClientCredentials.UserName.Password = "Temp2010";
        }
        public async Task<ZaygbcsysMsxxlistV6Rf[]> GetData()
        {
            var data = await _client.ZaygbcsysRfcsSystlstAsync(new ZaygbcsysRfcsSystlst());

            return data.ZaygbcsysRfcsSystlstResponse.EtSysList;
        }
    }
}
