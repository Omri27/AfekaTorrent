//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServerConsole.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.File = new HashSet<File>();
        }
    
        public System.Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SharedFolder { get; set; }
        public string DownloadFolder { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsActive { get; set; }
        public string Roles { get; set; }
    
        public virtual ICollection<File> File { get; set; }
    }
}
