
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
    
public partial class Peer
{

    public Peer()
    {

        this.Files = new HashSet<File>();

    }


    public System.Guid PeerID { get; set; }

    public string PeerHostName { get; set; }

    public string Comments { get; set; }



    public virtual ICollection<File> Files { get; set; }

}

}
