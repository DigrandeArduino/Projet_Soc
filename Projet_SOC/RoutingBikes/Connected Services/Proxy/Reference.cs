﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoutingBikes.Proxy {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Proxy.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataFromCache", ReplyAction="http://tempuri.org/IService1/GetDataFromCacheResponse")]
        ProxyCacheServer.JCDecauxItem GetDataFromCache(string CacheItemName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataFromCache", ReplyAction="http://tempuri.org/IService1/GetDataFromCacheResponse")]
        System.Threading.Tasks.Task<ProxyCacheServer.JCDecauxItem> GetDataFromCacheAsync(string CacheItemName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllStation", ReplyAction="http://tempuri.org/IService1/GetAllStationResponse")]
        ProxyCacheServer.JCDecauxItem GetAllStation();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllStation", ReplyAction="http://tempuri.org/IService1/GetAllStationResponse")]
        System.Threading.Tasks.Task<ProxyCacheServer.JCDecauxItem> GetAllStationAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetOneContract", ReplyAction="http://tempuri.org/IService1/GetOneContractResponse")]
        ProxyCacheServer.JCDecauxItem GetOneContract(string CacheItemName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetOneContract", ReplyAction="http://tempuri.org/IService1/GetOneContractResponse")]
        System.Threading.Tasks.Task<ProxyCacheServer.JCDecauxItem> GetOneContractAsync(string CacheItemName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : RoutingBikes.Proxy.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<RoutingBikes.Proxy.IService1>, RoutingBikes.Proxy.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ProxyCacheServer.JCDecauxItem GetDataFromCache(string CacheItemName) {
            return base.Channel.GetDataFromCache(CacheItemName);
        }
        
        public System.Threading.Tasks.Task<ProxyCacheServer.JCDecauxItem> GetDataFromCacheAsync(string CacheItemName) {
            return base.Channel.GetDataFromCacheAsync(CacheItemName);
        }
        
        public ProxyCacheServer.JCDecauxItem GetAllStation() {
            return base.Channel.GetAllStation();
        }
        
        public System.Threading.Tasks.Task<ProxyCacheServer.JCDecauxItem> GetAllStationAsync() {
            return base.Channel.GetAllStationAsync();
        }
        
        public ProxyCacheServer.JCDecauxItem GetOneContract(string CacheItemName) {
            return base.Channel.GetOneContract(CacheItemName);
        }
        
        public System.Threading.Tasks.Task<ProxyCacheServer.JCDecauxItem> GetOneContractAsync(string CacheItemName) {
            return base.Channel.GetOneContractAsync(CacheItemName);
        }
    }
}
