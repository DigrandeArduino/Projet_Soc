﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//
//     Les changements apportés à ce fichier peuvent provoquer un comportement incorrect et seront perdus si
//     le code est regénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="JCDecauxItem", Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheServer")]
    public partial class JCDecauxItem : object
    {
        
        private ServiceReference1.Station[] itemField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.Station[] item
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
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Station", Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheServer")]
    public partial class Station : object
    {
        
        private int available_bike_standsField;
        
        private int available_bikesField;
        
        private int bike_standsField;
        
        private string contract_nameField;
        
        private string nameField;
        
        private int numberField;
        
        private ServiceReference1.Position positionField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int available_bike_stands
        {
            get
            {
                return this.available_bike_standsField;
            }
            set
            {
                this.available_bike_standsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int available_bikes
        {
            get
            {
                return this.available_bikesField;
            }
            set
            {
                this.available_bikesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int bike_stands
        {
            get
            {
                return this.bike_standsField;
            }
            set
            {
                this.bike_standsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string contract_name
        {
            get
            {
                return this.contract_nameField;
            }
            set
            {
                this.contract_nameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.Position position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Position", Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheServer")]
    public partial class Position : object
    {
        
        private double latField;
        
        private double lngField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double lat
        {
            get
            {
                return this.latField;
            }
            set
            {
                this.latField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double lng
        {
            get
            {
                return this.lngField;
            }
            set
            {
                this.lngField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllData", ReplyAction="http://tempuri.org/IService1/GetAllDataResponse")]
        System.Threading.Tasks.Task<ServiceReference1.JCDecauxItem> GetAllDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetContract", ReplyAction="http://tempuri.org/IService1/GetContractResponse")]
        System.Threading.Tasks.Task<ServiceReference1.JCDecauxItem> GetContractAsync(string Contract);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCoordinate", ReplyAction="http://tempuri.org/IService1/GetCoordinateResponse")]
        System.Threading.Tasks.Task<double[]> GetCoordinateAsync(string Adresse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/FindStation", ReplyAction="http://tempuri.org/IService1/FindStationResponse")]
        System.Threading.Tasks.Task<ServiceReference1.Station> FindStationAsync(string adresse, bool searchBike, bool isCoord);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface IService1Channel : ServiceReference1.IService1, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ServiceReference1.IService1>, ServiceReference1.IService1
    {
        
        /// <summary>
        /// Implémentez cette méthode partielle pour configurer le point de terminaison de service.
        /// </summary>
        /// <param name="serviceEndpoint">Point de terminaison à configurer</param>
        /// <param name="clientCredentials">Informations d'identification du client</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public Service1Client() : 
                base(Service1Client.GetDefaultBinding(), Service1Client.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IService1.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(EndpointConfiguration endpointConfiguration) : 
                base(Service1Client.GetBindingForEndpoint(endpointConfiguration), Service1Client.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(Service1Client.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(Service1Client.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.JCDecauxItem> GetAllDataAsync()
        {
            return base.Channel.GetAllDataAsync();
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.JCDecauxItem> GetContractAsync(string Contract)
        {
            return base.Channel.GetContractAsync(Contract);
        }
        
        public System.Threading.Tasks.Task<double[]> GetCoordinateAsync(string Adresse)
        {
            return base.Channel.GetCoordinateAsync(Adresse);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.Station> FindStationAsync(string adresse, bool searchBike, bool isCoord)
        {
            return base.Channel.FindStationAsync(adresse, searchBike, isCoord);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IService1))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Le point de terminaison nommé \'{0}\' est introuvable.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IService1))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:8733/Design_Time_Addresses/RoutingBikes/ServiceSoap/");
            }
            throw new System.InvalidOperationException(string.Format("Le point de terminaison nommé \'{0}\' est introuvable.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return Service1Client.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IService1);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return Service1Client.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IService1);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IService1,
        }
    }
}
