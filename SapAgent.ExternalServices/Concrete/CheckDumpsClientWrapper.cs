using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using PrdBackgroundProcess;
using PrdCheckDumps;
using SapAgent.ExternalServices.Abstract;

namespace SapAgent.ExternalServices.Concrete
{
    public class CheckDumpsClientWrapper : ICheckDumpsClientWrapper
    {
        private zaygbcsys_ws_chkdumps _checkDumpsClient;

        public CheckDumpsClientWrapper()
        {
            _checkDumpsClient = new zaygbcsys_ws_chkdumpsClient(new CustomBinding()
            {
                SendTimeout = new TimeSpan(0, 0, 2, 30),
                CloseTimeout = new TimeSpan(0, 0, 2, 30),
                OpenTimeout = new TimeSpan(0, 0, 2, 30),
                ReceiveTimeout = new TimeSpan(0, 0, 2, 30),
                Name = "prd",
                Namespace = "SapAgentApi.CheckDumps",
                Elements = { new TextMessageEncodingBindingElement() { WriteEncoding = Encoding.UTF8, MessageVersion = MessageVersion.Soap11, ReaderQuotas = XmlDictionaryReaderQuotas.Max }, new HttpTransportBindingElement() { MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue } }
            }, new EndpointAddress(new Uri("http://aygerpprd.aygsapdom.local:8000/sap/bc/srt/wsdl/flv_10002A111AD1/bndg_url/sap/bc/srt/rfc/sap/zaygbcsys_ws_chkdumps/400/zaygbcsys_ws_chkdumps/zaygbcsys_ws_chkdumps_bn?sap-client=400")))
            ;
        }
        public async Task<Rdumpov[]> GetData()
        {
            try
            {
                var data = await _checkDumpsClient.ZaygbcsysRfcsChkdumpsAsync(new ZaygbcsysRfcsChkdumpsRequest());
                return data.ZaygbcsysRfcsChkdumpsResponse.EtDumplist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
