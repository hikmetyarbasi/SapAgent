﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     //
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrdCheckLocks
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style", ConfigurationName="PrdCheckLocks.zaygbcsys_ws_chklocks")]
    public interface zaygbcsys_ws_chklocks
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:sap-com:document:sap:soap:functions:mc-style:zaygbcsys_ws_chklocks:ZaygbcsysR" +
            "fcsLocksRequest", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<PrdCheckLocks.ZaygbcsysRfcsLocksResponse1> ZaygbcsysRfcsLocksAsync(PrdCheckLocks.ZaygbcsysRfcsLocksRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZaygbcsysRfcsLocks
    {
        
        private string ifClientField;
        
        private string ifEnqArgField;
        
        private string ifForUserField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string IfClient
        {
            get
            {
                return this.ifClientField;
            }
            set
            {
                this.ifClientField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string IfEnqArg
        {
            get
            {
                return this.ifEnqArgField;
            }
            set
            {
                this.ifEnqArgField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string IfForUser
        {
            get
            {
                return this.ifForUserField;
            }
            set
            {
                this.ifForUserField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZaygbcsysLocksRf
    {
        
        private string gclientField;
        
        private string gthostField;
        
        private string gunameField;
        
        private string gdsptimeField;
        
        private string gmodeField;
        
        private string gnameField;
        
        private string gargField;
        
        private string gusrField;
        
        private string gusrvbField;
        
        private int guseField;
        
        private int gusevbField;
        
        private string gobjField;
        
        private string gsourceTypeField;
        
        private string gsourceIdField;
        
        private string gsourceComponentField;
        
        private string gtdateField;
        
        private string gttimeField;
        
        private string backedField;
        
        private int lockDurationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string Gclient
        {
            get
            {
                return this.gclientField;
            }
            set
            {
                this.gclientField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string Gthost
        {
            get
            {
                return this.gthostField;
            }
            set
            {
                this.gthostField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string Guname
        {
            get
            {
                return this.gunameField;
            }
            set
            {
                this.gunameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string Gdsptime
        {
            get
            {
                return this.gdsptimeField;
            }
            set
            {
                this.gdsptimeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string Gmode
        {
            get
            {
                return this.gmodeField;
            }
            set
            {
                this.gmodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string Gname
        {
            get
            {
                return this.gnameField;
            }
            set
            {
                this.gnameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public string Garg
        {
            get
            {
                return this.gargField;
            }
            set
            {
                this.gargField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        public string Gusr
        {
            get
            {
                return this.gusrField;
            }
            set
            {
                this.gusrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=8)]
        public string Gusrvb
        {
            get
            {
                return this.gusrvbField;
            }
            set
            {
                this.gusrvbField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=9)]
        public int Guse
        {
            get
            {
                return this.guseField;
            }
            set
            {
                this.guseField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=10)]
        public int Gusevb
        {
            get
            {
                return this.gusevbField;
            }
            set
            {
                this.gusevbField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=11)]
        public string Gobj
        {
            get
            {
                return this.gobjField;
            }
            set
            {
                this.gobjField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=12)]
        public string GsourceType
        {
            get
            {
                return this.gsourceTypeField;
            }
            set
            {
                this.gsourceTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=13)]
        public string GsourceId
        {
            get
            {
                return this.gsourceIdField;
            }
            set
            {
                this.gsourceIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=14)]
        public string GsourceComponent
        {
            get
            {
                return this.gsourceComponentField;
            }
            set
            {
                this.gsourceComponentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=15)]
        public string Gtdate
        {
            get
            {
                return this.gtdateField;
            }
            set
            {
                this.gtdateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=16)]
        public string Gttime
        {
            get
            {
                return this.gttimeField;
            }
            set
            {
                this.gttimeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=17)]
        public string Backed
        {
            get
            {
                return this.backedField;
            }
            set
            {
                this.backedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=18)]
        public int LockDuration
        {
            get
            {
                return this.lockDurationField;
            }
            set
            {
                this.lockDurationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZaygbcsysRfcsLocksResponse
    {
        
        private ZaygbcsysLocksRf[] etLockListField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ZaygbcsysLocksRf[] EtLockList
        {
            get
            {
                return this.etLockListField;
            }
            set
            {
                this.etLockListField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ZaygbcsysRfcsLocksRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style", Order=0)]
        public PrdCheckLocks.ZaygbcsysRfcsLocks ZaygbcsysRfcsLocks;
        
        public ZaygbcsysRfcsLocksRequest()
        {
        }
        
        public ZaygbcsysRfcsLocksRequest(PrdCheckLocks.ZaygbcsysRfcsLocks ZaygbcsysRfcsLocks)
        {
            this.ZaygbcsysRfcsLocks = ZaygbcsysRfcsLocks;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ZaygbcsysRfcsLocksResponse1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style", Order=0)]
        public PrdCheckLocks.ZaygbcsysRfcsLocksResponse ZaygbcsysRfcsLocksResponse;
        
        public ZaygbcsysRfcsLocksResponse1()
        {
        }
        
        public ZaygbcsysRfcsLocksResponse1(PrdCheckLocks.ZaygbcsysRfcsLocksResponse ZaygbcsysRfcsLocksResponse)
        {
            this.ZaygbcsysRfcsLocksResponse = ZaygbcsysRfcsLocksResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public interface zaygbcsys_ws_chklocksChannel : PrdCheckLocks.zaygbcsys_ws_chklocks, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public partial class zaygbcsys_ws_chklocksClient : System.ServiceModel.ClientBase<PrdCheckLocks.zaygbcsys_ws_chklocks>, PrdCheckLocks.zaygbcsys_ws_chklocks
    {
        
        public zaygbcsys_ws_chklocksClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PrdCheckLocks.ZaygbcsysRfcsLocksResponse1> PrdCheckLocks.zaygbcsys_ws_chklocks.ZaygbcsysRfcsLocksAsync(PrdCheckLocks.ZaygbcsysRfcsLocksRequest request)
        {
            return base.Channel.ZaygbcsysRfcsLocksAsync(request);
        }
        
        public System.Threading.Tasks.Task<PrdCheckLocks.ZaygbcsysRfcsLocksResponse1> ZaygbcsysRfcsLocksAsync(PrdCheckLocks.ZaygbcsysRfcsLocks ZaygbcsysRfcsLocks)
        {
            PrdCheckLocks.ZaygbcsysRfcsLocksRequest inValue = new PrdCheckLocks.ZaygbcsysRfcsLocksRequest();
            inValue.ZaygbcsysRfcsLocks = ZaygbcsysRfcsLocks;
            return ((PrdCheckLocks.zaygbcsys_ws_chklocks)(this)).ZaygbcsysRfcsLocksAsync(inValue);
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
