﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     //
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrdSystemUsage
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style", ConfigurationName="PrdSystemUsage.zaygbcsys_ws_sysusage")]
    public interface zaygbcsys_ws_sysusage
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:sap-com:document:sap:soap:functions:mc-style:zaygbcsys_ws_sysusage:ZaygbcsysR" +
            "fcsSysusageRequest", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<PrdSystemUsage.ZaygbcsysRfcsSysusageResponse1> ZaygbcsysRfcsSysusageAsync(PrdSystemUsage.ZaygbcsysRfcsSysusageRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZaygbcsysRfcsSysusage
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class CcmSnapAll
    {
        
        private string serverField;
        
        private string itemField;
        
        private string sectionField;
        
        private string descr1Field;
        
        private string value1Field;
        
        private string unit1Field;
        
        private string descr2Field;
        
        private string value2Field;
        
        private string unit2Field;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string Server
        {
            get
            {
                return this.serverField;
            }
            set
            {
                this.serverField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string Section
        {
            get
            {
                return this.sectionField;
            }
            set
            {
                this.sectionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string Descr1
        {
            get
            {
                return this.descr1Field;
            }
            set
            {
                this.descr1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string Value1
        {
            get
            {
                return this.value1Field;
            }
            set
            {
                this.value1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string Unit1
        {
            get
            {
                return this.unit1Field;
            }
            set
            {
                this.unit1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public string Descr2
        {
            get
            {
                return this.descr2Field;
            }
            set
            {
                this.descr2Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        public string Value2
        {
            get
            {
                return this.value2Field;
            }
            set
            {
                this.value2Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=8)]
        public string Unit2
        {
            get
            {
                return this.unit2Field;
            }
            set
            {
                this.unit2Field = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZaygbssysSysusageRf
    {
        
        private string serverField;
        
        private CcmSnapAll[] tCpuField;
        
        private CcmSnapAll[] tMemField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string Server
        {
            get
            {
                return this.serverField;
            }
            set
            {
                this.serverField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public CcmSnapAll[] TCpu
        {
            get
            {
                return this.tCpuField;
            }
            set
            {
                this.tCpuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public CcmSnapAll[] TMem
        {
            get
            {
                return this.tMemField;
            }
            set
            {
                this.tMemField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZaygbcsysRfcsSysusageResponse
    {
        
        private ZaygbssysSysusageRf[] etSnapshotsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ZaygbssysSysusageRf[] EtSnapshots
        {
            get
            {
                return this.etSnapshotsField;
            }
            set
            {
                this.etSnapshotsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ZaygbcsysRfcsSysusageRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style", Order=0)]
        public PrdSystemUsage.ZaygbcsysRfcsSysusage ZaygbcsysRfcsSysusage;
        
        public ZaygbcsysRfcsSysusageRequest()
        {
        }
        
        public ZaygbcsysRfcsSysusageRequest(PrdSystemUsage.ZaygbcsysRfcsSysusage ZaygbcsysRfcsSysusage)
        {
            this.ZaygbcsysRfcsSysusage = ZaygbcsysRfcsSysusage;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ZaygbcsysRfcsSysusageResponse1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style", Order=0)]
        public PrdSystemUsage.ZaygbcsysRfcsSysusageResponse ZaygbcsysRfcsSysusageResponse;
        
        public ZaygbcsysRfcsSysusageResponse1()
        {
        }
        
        public ZaygbcsysRfcsSysusageResponse1(PrdSystemUsage.ZaygbcsysRfcsSysusageResponse ZaygbcsysRfcsSysusageResponse)
        {
            this.ZaygbcsysRfcsSysusageResponse = ZaygbcsysRfcsSysusageResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public interface zaygbcsys_ws_sysusageChannel : PrdSystemUsage.zaygbcsys_ws_sysusage, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public partial class zaygbcsys_ws_sysusageClient : System.ServiceModel.ClientBase<PrdSystemUsage.zaygbcsys_ws_sysusage>, PrdSystemUsage.zaygbcsys_ws_sysusage
    {
        
        public zaygbcsys_ws_sysusageClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PrdSystemUsage.ZaygbcsysRfcsSysusageResponse1> PrdSystemUsage.zaygbcsys_ws_sysusage.ZaygbcsysRfcsSysusageAsync(PrdSystemUsage.ZaygbcsysRfcsSysusageRequest request)
        {
            return base.Channel.ZaygbcsysRfcsSysusageAsync(request);
        }
        
        public System.Threading.Tasks.Task<PrdSystemUsage.ZaygbcsysRfcsSysusageResponse1> ZaygbcsysRfcsSysusageAsync(PrdSystemUsage.ZaygbcsysRfcsSysusage ZaygbcsysRfcsSysusage)
        {
            PrdSystemUsage.ZaygbcsysRfcsSysusageRequest inValue = new PrdSystemUsage.ZaygbcsysRfcsSysusageRequest();
            inValue.ZaygbcsysRfcsSysusage = ZaygbcsysRfcsSysusage;
            return ((PrdSystemUsage.zaygbcsys_ws_sysusage)(this)).ZaygbcsysRfcsSysusageAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
    }
}
