﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientApp.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetStatus", ReplyAction="http://tempuri.org/IService/GetStatusResponse")]
        string GetStatus(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetStatus", ReplyAction="http://tempuri.org/IService/GetStatusResponse")]
        System.Threading.Tasks.Task<string> GetStatusAsync(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Query", ReplyAction="http://tempuri.org/IService/QueryResponse")]
        bool Query(System.Guid id, string cityName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Query", ReplyAction="http://tempuri.org/IService/QueryResponse")]
        System.Threading.Tasks.Task<bool> QueryAsync(System.Guid id, string cityName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : ClientApp.ServiceReference.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<ClientApp.ServiceReference.IService>, ClientApp.ServiceReference.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetStatus(string address) {
            return base.Channel.GetStatus(address);
        }
        
        public System.Threading.Tasks.Task<string> GetStatusAsync(string address) {
            return base.Channel.GetStatusAsync(address);
        }
        
        public bool Query(System.Guid id, string cityName) {
            return base.Channel.Query(id, cityName);
        }
        
        public System.Threading.Tasks.Task<bool> QueryAsync(System.Guid id, string cityName) {
            return base.Channel.QueryAsync(id, cityName);
        }
    }
}
