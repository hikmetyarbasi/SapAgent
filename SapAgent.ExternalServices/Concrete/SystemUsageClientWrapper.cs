using System;
using System.ServiceModel;
using System.Threading.Tasks;
using PrdSystemUsage;
using SapAgent.ExternalServices.Abstract;

namespace SapAgent.ExternalServices.Concrete
{
    public class SystemUsageClientWrapper : ISystemUsageClientWrapper
    {
        private readonly zaygbcsys_ws_sysusageClient _client;

        public SystemUsageClientWrapper()
        {
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            EndpointAddress endpoint = new EndpointAddress("http://AYGERPPRD.AYGAZNET.LOCAL:8000/sap/bc/srt/rfc/sap/zaygbcsys_ws_sysusage/400/zaygbcsys_ws_sysusage/zaygbcsys_ws_sysusage_bn");

            _client = new zaygbcsys_ws_sysusageClient(binding, endpoint);
            _client.ClientCredentials.UserName.UserName = "Rfc_etalep";
            _client.ClientCredentials.UserName.Password = "Temp2010";
        }

        public async Task<ZaygbssysSysusageRf[]> GetData()
        {
            try
            {
                var data = await _client.ZaygbcsysRfcsSysusageAsync(new ZaygbcsysRfcsSysusage());
                return data.ZaygbcsysRfcsSysusageResponse.EtSnapshots;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
