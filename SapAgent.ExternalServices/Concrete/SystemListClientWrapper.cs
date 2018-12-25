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
        private readonly zaygbcsys_ws_systlst _client;

        public SystemListClientWrapper()
        {
            _client = new zaygbcsys_ws_systlstClient(new CustomBinding()
            {
                SendTimeout = new TimeSpan(0, 0, 2, 30),
                CloseTimeout = new TimeSpan(0, 0, 2, 30),
                OpenTimeout = new TimeSpan(0, 0, 2, 30),
                ReceiveTimeout = new TimeSpan(0, 0, 2, 30),
                Name = "prd",
                Namespace = "SapAgentApi.SystemList",
                Elements = { new TextMessageEncodingBindingElement() { WriteEncoding = Encoding.UTF8, MessageVersion = MessageVersion.Soap11, ReaderQuotas = XmlDictionaryReaderQuotas.Max }, new HttpTransportBindingElement() { MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue } }
            }, new EndpointAddress(new Uri("http://aygerpprd.aygsapdom.local:8000/sap/bc/srt/wsdl/flv_10002A111AD1/bndg_url/sap/bc/srt/rfc/sap/zaygbcsys_ws_systlst/400/zaygbcsys_ws_systlst/zaygbcsys_ws_systlst_bn?sap-client=400")));
        }
        public async Task<ZaygbcsysMsxxlistV6Rf[]> GetData()
        {
            var data = await _client.ZaygbcsysRfcsSystlstAsync(new ZaygbcsysRfcsSystlstRequest());

            return data.ZaygbcsysRfcsSystlstResponse.EtSysList;
        }
    }
}
