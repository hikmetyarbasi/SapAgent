using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using PrdSystemUsage;
using SapAgent.ExternalServices.Abstract;

namespace SapAgent.ExternalServices.Concrete
{
    public class SystemUsageClientWrapper : ISystemUsageClientWrapper
    {
        private readonly zaygbcsys_ws_sysusage _client;

        public SystemUsageClientWrapper()
        {
            _client = (new zaygbcsys_ws_sysusageClient(new CustomBinding()
            {
                SendTimeout = new TimeSpan(0, 0, 2, 30),
                CloseTimeout = new TimeSpan(0, 0, 2, 30),
                OpenTimeout = new TimeSpan(0, 0, 2, 30),
                ReceiveTimeout = new TimeSpan(0, 0, 2, 30),
                Name = "prd",
                Namespace = "SapAgentApi.SystemUsage",
                Elements = { new TextMessageEncodingBindingElement() { WriteEncoding = Encoding.UTF8, MessageVersion = MessageVersion.Soap11, ReaderQuotas = XmlDictionaryReaderQuotas.Max }, new HttpTransportBindingElement() { MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue } }
            }, new EndpointAddress(new Uri("http://aygerpprd.aygsapdom.local:8000/sap/bc/srt/wsdl/flv_10002A111AD1/bndg_url/sap/bc/srt/rfc/sap/zaygbcsys_ws_sysusage/400/zaygbcsys_ws_sysusage/zaygbcsys_ws_sysusage_bn?sap-client=400"))));
        }

        public async Task<ZaygbssysSysusageRf[]> GetData()
        {
            try
            {
                var data = await _client.ZaygbcsysRfcsSysusageAsync(new ZaygbcsysRfcsSysusageRequest());
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
