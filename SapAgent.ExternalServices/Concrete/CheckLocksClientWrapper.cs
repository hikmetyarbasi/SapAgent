using PrdCheckLocks;
using SapAgent.ExternalServices.Abstract;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SapAgent.ExternalServices.Concrete
{
    public class CheckLocksClientWrapper : ICheckLocksClientWrapper
    {
        private readonly zaygbcsys_ws_chklocksClient _checkLocksClient;

        public CheckLocksClientWrapper()
        {

            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            EndpointAddress endpoint = new EndpointAddress("http://AYGERPPRD.AYGAZNET.LOCAL:8000/sap/bc/srt/rfc/sap/zaygbcsys_ws_chklocks/400/zaygbcsys_ws_chklocks_bn/zaygbcsys_ws_chklocks_bn");

            _checkLocksClient = new zaygbcsys_ws_chklocksClient(binding, endpoint);
            _checkLocksClient.ClientCredentials.UserName.UserName = "Rfc_etalep";
            _checkLocksClient.ClientCredentials.UserName.Password = "Temp2010";
        }
        public async Task<ZaygbcsysLocksRf[]> GetData()
        {
            try
            {
               return  _checkLocksClient.ZaygbcsysRfcsLocksAsync(new ZaygbcsysRfcsLocks
               {
                   IfClient = "", IfEnqArg = "", IfForUser = "" 

               }).GetAwaiter().GetResult().ZaygbcsysRfcsLocksResponse.EtLockList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
