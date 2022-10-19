using Messenger.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Data
{
    public class Frinds
    {
        public int Frindid { get; set; }
        public int Userreceiveid { get; set; }
        public int Status { get; set; }
        public DateTime Adddate { get; set; }
        public int? User_Id { get; set; }

        public virtual Userr User { get; set; }
    }
}
