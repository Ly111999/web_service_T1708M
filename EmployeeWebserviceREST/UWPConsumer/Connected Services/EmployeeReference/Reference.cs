﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 15.0.28307.137
// 
namespace UWPConsumer.EmployeeReference {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/EmployeeWebserviceREST")]
    public partial class Employee : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int empIDField;
        
        private string firstNameField;
        
        private string lastNameField;
        
        private int ageField;
        
        private string addressField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int empID {
            get {
                return this.empIDField;
            }
            set {
                if ((this.empIDField.Equals(value) != true)) {
                    this.empIDField = value;
                    this.RaisePropertyChanged("empID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string firstName {
            get {
                return this.firstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.firstNameField, value) != true)) {
                    this.firstNameField = value;
                    this.RaisePropertyChanged("firstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string lastName {
            get {
                return this.lastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.lastNameField, value) != true)) {
                    this.lastNameField = value;
                    this.RaisePropertyChanged("lastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public int age {
            get {
                return this.ageField;
            }
            set {
                if ((this.ageField.Equals(value) != true)) {
                    this.ageField = value;
                    this.RaisePropertyChanged("age");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string address {
            get {
                return this.addressField;
            }
            set {
                if ((object.ReferenceEquals(this.addressField, value) != true)) {
                    this.addressField = value;
                    this.RaisePropertyChanged("address");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeReference.IEmployee")]
    public interface IEmployee {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployee/GetProductList", ReplyAction="http://tempuri.org/IEmployee/GetProductListResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<UWPConsumer.EmployeeReference.Employee>> GetProductListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployee/AddEmployee", ReplyAction="http://tempuri.org/IEmployee/AddEmployeeResponse")]
        System.Threading.Tasks.Task<bool> AddEmployeeAsync(UWPConsumer.EmployeeReference.Employee employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployee/PutEmployee", ReplyAction="http://tempuri.org/IEmployee/PutEmployeeResponse")]
        System.Threading.Tasks.Task<bool> PutEmployeeAsync(UWPConsumer.EmployeeReference.Employee employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployee/DeleteEmployee", ReplyAction="http://tempuri.org/IEmployee/DeleteEmployeeResponse")]
        System.Threading.Tasks.Task<bool> DeleteEmployeeAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmployeeChannel : UWPConsumer.EmployeeReference.IEmployee, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmployeeClient : System.ServiceModel.ClientBase<UWPConsumer.EmployeeReference.IEmployee>, UWPConsumer.EmployeeReference.IEmployee {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public EmployeeClient() : 
                base(EmployeeClient.GetDefaultBinding(), EmployeeClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IEmployee.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public EmployeeClient(EndpointConfiguration endpointConfiguration) : 
                base(EmployeeClient.GetBindingForEndpoint(endpointConfiguration), EmployeeClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public EmployeeClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(EmployeeClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public EmployeeClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(EmployeeClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public EmployeeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<UWPConsumer.EmployeeReference.Employee>> GetProductListAsync() {
            return base.Channel.GetProductListAsync();
        }
        
        public System.Threading.Tasks.Task<bool> AddEmployeeAsync(UWPConsumer.EmployeeReference.Employee employee) {
            return base.Channel.AddEmployeeAsync(employee);
        }
        
        public System.Threading.Tasks.Task<bool> PutEmployeeAsync(UWPConsumer.EmployeeReference.Employee employee) {
            return base.Channel.PutEmployeeAsync(employee);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteEmployeeAsync(int id) {
            return base.Channel.DeleteEmployeeAsync(id);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IEmployee)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IEmployee)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:56245/EmployeeNew.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return EmployeeClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IEmployee);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return EmployeeClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IEmployee);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_IEmployee,
        }
    }
}
