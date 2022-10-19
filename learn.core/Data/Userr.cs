using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.Data
{
    public class Userr
    {
        public int UserId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string ProFileImg { get; set; }
        public string Gender { get; set; }
        public int IsBlocked { get; set; }
        public int IsActive { get; set; }
        public string UserBio { get; set; }
        public string userName { get; set; }
    }
}
