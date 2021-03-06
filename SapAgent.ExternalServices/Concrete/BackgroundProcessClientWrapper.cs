﻿using PrdBackgroundProcess;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Extensions.Configuration;
using PrdCheckDumps;
using SapAgent.ExternalServices.Abstract;
using ZaygbcsysRfcsBckgprcRequest = PrdBackgroundProcess.ZaygbcsysRfcsBckgprcRequest;
using ZAYGBCSYS_WS_BCKGPRC = PrdBackgroundProcess.ZAYGBCSYS_WS_BCKGPRC;
using ZaygbcsysRfcsBckgprc = PrdBackgroundProcess.ZaygbcsysRfcsBckgprc;
using ZaygbcsysBtcselect = PrdBackgroundProcess.ZaygbcsysBtcselect;
using ZaygbssysTbtcjobBkRfChar = PrdBackgroundProcess.ZaygbssysTbtcjobBkRfChar;

namespace SapAgent.ExternalServices.Concrete
{

    public class BackgroundProcessClientWrapper : IBackgroundProcessClientWrapper
    {
        private readonly ZAYGBCSYS_WS_BCKGPRC _backProcessClient;
        public BackgroundProcessClientWrapper()
        {
            var client = new ZaygbssysTbtcjobBkRf(new CustomBinding()
            {
                SendTimeout = new TimeSpan(0, 0, 2, 30),
                CloseTimeout = new TimeSpan(0, 0, 2, 30),
                OpenTimeout = new TimeSpan(0, 0, 2, 30),
                ReceiveTimeout = new TimeSpan(0, 0, 2, 30),
                Name = "prd",
                Namespace = "SapAgentApi.BackgroundProcess",
                Elements =
                {
                    new TextMessageEncodingBindingElement() { WriteEncoding = Encoding.UTF8, MessageVersion = MessageVersion.Default, ReaderQuotas = XmlDictionaryReaderQuotas.Max },
                    new HttpTransportBindingElement() { MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue,AuthenticationScheme = AuthenticationSchemes.Basic}
                }
            }, 
                new EndpointAddress(new Uri("http://AYGERPPRD.AYGSAPDOM.LOCAL:8000/sap/bc/srt/rfc/sap/zaygbcsys_ws_bckgprc/400/zaygbcsys_ws_bckgprc/zaygbcsys_ws_bckgprc_bn"))
                );

            client.ClientCredentials.UserName.UserName = "Rfc_etalep";
            client.ClientCredentials.UserName.Password = "Temp2010";
            this._backProcessClient = client;
        }

        public async Task<ZaygbssysTbtcjobBkRfChar[]> GetData()
        {
            try
            {
                var data = await _backProcessClient.ZaygbcsysRfcsBckgprcAsync(
                    new ZaygbcsysRfcsBckgprcRequest()
                {
                    ZaygbcsysRfcsBckgprc =new ZaygbcsysRfcsBckgprc()
                    {
                        IsJobselParams = new ZaygbcsysBtcselect()
                    }
                });
                return data.ZaygbcsysRfcsBckgprcResponse.EtJoblist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
