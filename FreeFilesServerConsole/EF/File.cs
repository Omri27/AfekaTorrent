//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FreeFilesServerConsole.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class File
    {
        public System.Guid FileID { get; set; }
        public string FileName { get; set; }
        public System.Guid PeerID { get; set; }
        public int FileSize { get; set; }
        public string FileType { get; set; }
        public string PeerHostName { get; set; }
    
        public virtual Peer Peer { get; set; }
    }
}
