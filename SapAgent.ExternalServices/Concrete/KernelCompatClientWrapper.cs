using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PrdKernalCompat;
using PrdSystemFile;
using SapAgent.ExternalServices.Abstract;

namespace SapAgent.ExternalServices.Concrete
{
    public class KernelCompatClientWrapper : IKernelCompatClientWrapper
    {
        private readonly ZAYGBCSYS_WS_KERNELCOMPATClient _client;
        public KernelCompatClientWrapper()
        {
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            EndpointAddress endpoint = new EndpointAddress("http://AYGERPPRD.AYGAZNET.LOCAL:8000/sap/bc/srt/rfc/sap/zaygbcsys_ws_kernelcompat/400/zaygbcsys_ws_kernelcompat/zaygbcsys_ws_kernelcompat_bn");

            _client = new ZAYGBCSYS_WS_KERNELCOMPATClient(binding, endpoint);
            _client.ClientCredentials.UserName.UserName = "Rfc_etalep";
            _client.ClientCredentials.UserName.Password = "Temp2010";
        }
        public async Task<ZaygbcsysKernelstatRf> GetData()
        {
            var data = await _client.ZaygbcsysRfcsKernelcompatAsync(new ZaygbcsysRfcsKernelcompat());

            return data.ZaygbcsysRfcsKernelcompatResponse.EsKernelcompat.SKernelinfo;
        }
    }
}
