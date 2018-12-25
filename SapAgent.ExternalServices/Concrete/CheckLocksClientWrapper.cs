using PrdCheckLocks;
using SapAgent.ExternalServices.Abstract;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SapAgent.ExternalServices.Concrete
{
    public class CheckLocksClientWrapper : ICheckLocksClientWrapper
    {
        private readonly zaygbcsys_ws_chklocks _checkLocksClient;

        public CheckLocksClientWrapper()
        {
            _checkLocksClient = new zaygbcsys_ws_chklocksClient(new CustomBinding()
            {
                SendTimeout = new TimeSpan(0, 0, 2, 30),
                CloseTimeout = new TimeSpan(0, 0, 2, 30),
                OpenTimeout = new TimeSpan(0, 0, 2, 30),
                ReceiveTimeout = new TimeSpan(0, 0, 2, 30),
                Name = "prd",
                Namespace = "SapAgentApi.CheckLock",
                Elements = { new TextMessageEncodingBindingElement() { WriteEncoding = Encoding.UTF8, MessageVersion = MessageVersion.Soap11, ReaderQuotas = XmlDictionaryReaderQuotas.Max }, new HttpTransportBindingElement() { MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue } }
            }, new EndpointAddress(new Uri("http://aygerpprd.aygsapdom.local:8000/sap/bc/srt/wsdl/flv_10002A111AD1/bndg_url/sap/bc/srt/rfc/sap/zaygbcsys_ws_chklocks/400/zaygbcsys_ws_chklocks/zaygbcsys_ws_chklocks_bn?sap-client=400")));
        }
        public async Task<ZaygbcsysLocksRf[]> GetData()
        {
            try
            {
                var data = await _checkLocksClient.ZaygbcsysRfcsLocksAsync(new ZaygbcsysRfcsLocksRequest());
                return data.ZaygbcsysRfcsLocksResponse.EtLockList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
