using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SapAgent.ExternalServices.Abstract;
using PrdUserSession;

namespace SapAgent.ExternalServices.Concrete
{
    public class UserSessionClientWrapper:IUserSessionClientWrapper
    {
        private zaygbcsys_ws_userses _userSessionClient;

        public UserSessionClientWrapper()
        {
            _userSessionClient = new zaygbcsys_ws_usersesClient(new CustomBinding()
            {
                SendTimeout = new TimeSpan(0, 0, 2, 30),
                CloseTimeout = new TimeSpan(0, 0, 2, 30),
                OpenTimeout = new TimeSpan(0, 0, 2, 30),
                ReceiveTimeout = new TimeSpan(0, 0, 2, 30),
                Name = "prd",
                Namespace = "SapAgentApi.UserSession",
                Elements = { new TextMessageEncodingBindingElement() { WriteEncoding = Encoding.UTF8, MessageVersion = MessageVersion.Soap11, ReaderQuotas = XmlDictionaryReaderQuotas.Max }, new HttpTransportBindingElement() { MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue } }
            }, new EndpointAddress(new Uri("http://aygerpprd.aygsapdom.local:8000/sap/bc/srt/wsdl/flv_10002A111AD1/bndg_url/sap/bc/srt/rfc/sap/zaygbcsys_ws_userses/400/zaygbcsys_ws_userses/zaygbcsys_ws_userses_bn?sap-client=400")));
        }
        public async Task<ZaygbssysUsersessRf[]> GetData()
        {
            try
            {
                var data = await _userSessionClient.ZaygbcsysRfcsUsersesAsync(new ZaygbcsysRfcsUsersesRequest());
                return data.ZaygbcsysRfcsUsersesResponse.EtUsrSessList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
