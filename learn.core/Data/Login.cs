using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.Data
{
    public class Login
    {
        public int LoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int User_Id { get; set; }
        public int RoleId { get; set; }
        public string userName { get; set; }
        public string verificationCode { get; set; }
    }
}
