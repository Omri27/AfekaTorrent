using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class User
    {
        public System.Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SharedFolder { get; set; }
        public string DownloadFolder { get; set; }
    }
}
