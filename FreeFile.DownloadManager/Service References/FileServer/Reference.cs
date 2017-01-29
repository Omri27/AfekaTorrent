﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FreeFile.DownloadManager.FileServer {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Peer", Namespace="http://schemas.datacontract.org/2004/07/FreeFilesServerConsole.EF")]
    [System.SerializableAttribute()]
    public partial class Peer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CommentsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FreeFile.DownloadManager.FileServer.File[] FilesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PeerHostNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid PeerIDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Comments {
            get {
                return this.CommentsField;
            }
            set {
                if ((object.ReferenceEquals(this.CommentsField, value) != true)) {
                    this.CommentsField = value;
                    this.RaisePropertyChanged("Comments");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FreeFile.DownloadManager.FileServer.File[] Files {
            get {
                return this.FilesField;
            }
            set {
                if ((object.ReferenceEquals(this.FilesField, value) != true)) {
                    this.FilesField = value;
                    this.RaisePropertyChanged("Files");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PeerHostName {
            get {
                return this.PeerHostNameField;
            }
            set {
                if ((object.ReferenceEquals(this.PeerHostNameField, value) != true)) {
                    this.PeerHostNameField = value;
                    this.RaisePropertyChanged("PeerHostName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid PeerID {
            get {
                return this.PeerIDField;
            }
            set {
                if ((this.PeerIDField.Equals(value) != true)) {
                    this.PeerIDField = value;
                    this.RaisePropertyChanged("PeerID");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="File", Namespace="http://schemas.datacontract.org/2004/07/FreeFilesServerConsole.EF")]
    [System.SerializableAttribute()]
    public partial class File : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid FileIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FileNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FileSizeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FileTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FreeFile.DownloadManager.FileServer.Peer PeerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PeerHostNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid PeerIDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid FileID {
            get {
                return this.FileIDField;
            }
            set {
                if ((this.FileIDField.Equals(value) != true)) {
                    this.FileIDField = value;
                    this.RaisePropertyChanged("FileID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FileName {
            get {
                return this.FileNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FileNameField, value) != true)) {
                    this.FileNameField = value;
                    this.RaisePropertyChanged("FileName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FileSize {
            get {
                return this.FileSizeField;
            }
            set {
                if ((this.FileSizeField.Equals(value) != true)) {
                    this.FileSizeField = value;
                    this.RaisePropertyChanged("FileSize");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FileType {
            get {
                return this.FileTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.FileTypeField, value) != true)) {
                    this.FileTypeField = value;
                    this.RaisePropertyChanged("FileType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FreeFile.DownloadManager.FileServer.Peer Peer {
            get {
                return this.PeerField;
            }
            set {
                if ((object.ReferenceEquals(this.PeerField, value) != true)) {
                    this.PeerField = value;
                    this.RaisePropertyChanged("Peer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PeerHostName {
            get {
                return this.PeerHostNameField;
            }
            set {
                if ((object.ReferenceEquals(this.PeerHostNameField, value) != true)) {
                    this.PeerHostNameField = value;
                    this.RaisePropertyChanged("PeerHostName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid PeerID {
            get {
                return this.PeerIDField;
            }
            set {
                if ((this.PeerIDField.Equals(value) != true)) {
                    this.PeerIDField = value;
                    this.RaisePropertyChanged("PeerID");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FileServer.FilesService")]
    public interface FilesService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FilesService/AddFiles", ReplyAction="http://tempuri.org/FilesService/AddFilesResponse")]
        void AddFiles(Entities.File[] FilesList, Entities.Peer peer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FilesService/AddPeer", ReplyAction="http://tempuri.org/FilesService/AddPeerResponse")]
        void AddPeer(FreeFile.DownloadManager.FileServer.Peer Peer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FilesService/SearchAvaiableFiles", ReplyAction="http://tempuri.org/FilesService/SearchAvaiableFilesResponse")]
        Entities.File[] SearchAvaiableFiles(string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FilesService/GetAllFiles", ReplyAction="http://tempuri.org/FilesService/GetAllFilesResponse")]
        Entities.File[] GetAllFiles();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface FilesServiceChannel : FreeFile.DownloadManager.FileServer.FilesService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FilesServiceClient : System.ServiceModel.ClientBase<FreeFile.DownloadManager.FileServer.FilesService>, FreeFile.DownloadManager.FileServer.FilesService {
        
        public FilesServiceClient() {
        }
        
        public FilesServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FilesServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FilesServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FilesServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddFiles(Entities.File[] FilesList, Entities.Peer peer) {
            base.Channel.AddFiles(FilesList, peer);
        }
        
        public void AddPeer(FreeFile.DownloadManager.FileServer.Peer Peer) {
            base.Channel.AddPeer(Peer);
        }
        
        public Entities.File[] SearchAvaiableFiles(string fileName) {
            return base.Channel.SearchAvaiableFiles(fileName);
        }
        
        public Entities.File[] GetAllFiles() {
            return base.Channel.GetAllFiles();
        }
    }
}
