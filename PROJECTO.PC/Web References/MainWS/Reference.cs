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
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace PROJECTO.PC.MainWS {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MainSoap", Namespace="http://localhost/")]
    public partial class Main : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback MOTDOperationCompleted;
        
        private System.Threading.SendOrPostCallback LoadProjectsOperationCompleted;
        
        private System.Threading.SendOrPostCallback LoadProjectMembersOperationCompleted;
        
        private System.Threading.SendOrPostCallback LoadMemberInfoOperationCompleted;
        
        private System.Threading.SendOrPostCallback LoadMessagesOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendMessageOperationCompleted;
        
        private System.Threading.SendOrPostCallback MaintenanceOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Main() {
            this.Url = global::PROJECTO.PC.Properties.Settings.Default.PROJECTO_PC_MainWS_Main;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event MOTDCompletedEventHandler MOTDCompleted;
        
        /// <remarks/>
        public event LoadProjectsCompletedEventHandler LoadProjectsCompleted;
        
        /// <remarks/>
        public event LoadProjectMembersCompletedEventHandler LoadProjectMembersCompleted;
        
        /// <remarks/>
        public event LoadMemberInfoCompletedEventHandler LoadMemberInfoCompleted;
        
        /// <remarks/>
        public event LoadMessagesCompletedEventHandler LoadMessagesCompleted;
        
        /// <remarks/>
        public event SendMessageCompletedEventHandler SendMessageCompleted;
        
        /// <remarks/>
        public event MaintenanceCompletedEventHandler MaintenanceCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/MOTD", RequestNamespace="http://localhost/", ResponseNamespace="http://localhost/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string MOTD() {
            object[] results = this.Invoke("MOTD", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void MOTDAsync() {
            this.MOTDAsync(null);
        }
        
        /// <remarks/>
        public void MOTDAsync(object userState) {
            if ((this.MOTDOperationCompleted == null)) {
                this.MOTDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMOTDOperationCompleted);
            }
            this.InvokeAsync("MOTD", new object[0], this.MOTDOperationCompleted, userState);
        }
        
        private void OnMOTDOperationCompleted(object arg) {
            if ((this.MOTDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MOTDCompleted(this, new MOTDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/LoadProjects", RequestNamespace="http://localhost/", ResponseNamespace="http://localhost/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] LoadProjects(string userID) {
            object[] results = this.Invoke("LoadProjects", new object[] {
                        userID});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void LoadProjectsAsync(string userID) {
            this.LoadProjectsAsync(userID, null);
        }
        
        /// <remarks/>
        public void LoadProjectsAsync(string userID, object userState) {
            if ((this.LoadProjectsOperationCompleted == null)) {
                this.LoadProjectsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLoadProjectsOperationCompleted);
            }
            this.InvokeAsync("LoadProjects", new object[] {
                        userID}, this.LoadProjectsOperationCompleted, userState);
        }
        
        private void OnLoadProjectsOperationCompleted(object arg) {
            if ((this.LoadProjectsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LoadProjectsCompleted(this, new LoadProjectsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/LoadProjectMembers", RequestNamespace="http://localhost/", ResponseNamespace="http://localhost/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] LoadProjectMembers(string projectID) {
            object[] results = this.Invoke("LoadProjectMembers", new object[] {
                        projectID});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void LoadProjectMembersAsync(string projectID) {
            this.LoadProjectMembersAsync(projectID, null);
        }
        
        /// <remarks/>
        public void LoadProjectMembersAsync(string projectID, object userState) {
            if ((this.LoadProjectMembersOperationCompleted == null)) {
                this.LoadProjectMembersOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLoadProjectMembersOperationCompleted);
            }
            this.InvokeAsync("LoadProjectMembers", new object[] {
                        projectID}, this.LoadProjectMembersOperationCompleted, userState);
        }
        
        private void OnLoadProjectMembersOperationCompleted(object arg) {
            if ((this.LoadProjectMembersCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LoadProjectMembersCompleted(this, new LoadProjectMembersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/LoadMemberInfo", RequestNamespace="http://localhost/", ResponseNamespace="http://localhost/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] LoadMemberInfo(string memberID, string memberEmail) {
            object[] results = this.Invoke("LoadMemberInfo", new object[] {
                        memberID,
                        memberEmail});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void LoadMemberInfoAsync(string memberID, string memberEmail) {
            this.LoadMemberInfoAsync(memberID, memberEmail, null);
        }
        
        /// <remarks/>
        public void LoadMemberInfoAsync(string memberID, string memberEmail, object userState) {
            if ((this.LoadMemberInfoOperationCompleted == null)) {
                this.LoadMemberInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLoadMemberInfoOperationCompleted);
            }
            this.InvokeAsync("LoadMemberInfo", new object[] {
                        memberID,
                        memberEmail}, this.LoadMemberInfoOperationCompleted, userState);
        }
        
        private void OnLoadMemberInfoOperationCompleted(object arg) {
            if ((this.LoadMemberInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LoadMemberInfoCompleted(this, new LoadMemberInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/LoadMessages", RequestNamespace="http://localhost/", ResponseNamespace="http://localhost/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] LoadMessages(string firstUserID, string secondUserID, string chsnProj) {
            object[] results = this.Invoke("LoadMessages", new object[] {
                        firstUserID,
                        secondUserID,
                        chsnProj});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void LoadMessagesAsync(string firstUserID, string secondUserID, string chsnProj) {
            this.LoadMessagesAsync(firstUserID, secondUserID, chsnProj, null);
        }
        
        /// <remarks/>
        public void LoadMessagesAsync(string firstUserID, string secondUserID, string chsnProj, object userState) {
            if ((this.LoadMessagesOperationCompleted == null)) {
                this.LoadMessagesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLoadMessagesOperationCompleted);
            }
            this.InvokeAsync("LoadMessages", new object[] {
                        firstUserID,
                        secondUserID,
                        chsnProj}, this.LoadMessagesOperationCompleted, userState);
        }
        
        private void OnLoadMessagesOperationCompleted(object arg) {
            if ((this.LoadMessagesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LoadMessagesCompleted(this, new LoadMessagesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/SendMessage", RequestNamespace="http://localhost/", ResponseNamespace="http://localhost/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SendMessage(string messageText, string senderID, string receiverID, string sentTime, string chsnproj) {
            object[] results = this.Invoke("SendMessage", new object[] {
                        messageText,
                        senderID,
                        receiverID,
                        sentTime,
                        chsnproj});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SendMessageAsync(string messageText, string senderID, string receiverID, string sentTime, string chsnproj) {
            this.SendMessageAsync(messageText, senderID, receiverID, sentTime, chsnproj, null);
        }
        
        /// <remarks/>
        public void SendMessageAsync(string messageText, string senderID, string receiverID, string sentTime, string chsnproj, object userState) {
            if ((this.SendMessageOperationCompleted == null)) {
                this.SendMessageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendMessageOperationCompleted);
            }
            this.InvokeAsync("SendMessage", new object[] {
                        messageText,
                        senderID,
                        receiverID,
                        sentTime,
                        chsnproj}, this.SendMessageOperationCompleted, userState);
        }
        
        private void OnSendMessageOperationCompleted(object arg) {
            if ((this.SendMessageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendMessageCompleted(this, new SendMessageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/Maintenance", RequestNamespace="http://localhost/", ResponseNamespace="http://localhost/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Maintenance() {
            object[] results = this.Invoke("Maintenance", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void MaintenanceAsync() {
            this.MaintenanceAsync(null);
        }
        
        /// <remarks/>
        public void MaintenanceAsync(object userState) {
            if ((this.MaintenanceOperationCompleted == null)) {
                this.MaintenanceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMaintenanceOperationCompleted);
            }
            this.InvokeAsync("Maintenance", new object[0], this.MaintenanceOperationCompleted, userState);
        }
        
        private void OnMaintenanceOperationCompleted(object arg) {
            if ((this.MaintenanceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MaintenanceCompleted(this, new MaintenanceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")]
    public delegate void MOTDCompletedEventHandler(object sender, MOTDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MOTDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MOTDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")]
    public delegate void LoadProjectsCompletedEventHandler(object sender, LoadProjectsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LoadProjectsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LoadProjectsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")]
    public delegate void LoadProjectMembersCompletedEventHandler(object sender, LoadProjectMembersCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LoadProjectMembersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LoadProjectMembersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")]
    public delegate void LoadMemberInfoCompletedEventHandler(object sender, LoadMemberInfoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LoadMemberInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LoadMemberInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")]
    public delegate void LoadMessagesCompletedEventHandler(object sender, LoadMessagesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LoadMessagesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LoadMessagesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")]
    public delegate void SendMessageCompletedEventHandler(object sender, SendMessageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendMessageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendMessageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")]
    public delegate void MaintenanceCompletedEventHandler(object sender, MaintenanceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MaintenanceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MaintenanceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591