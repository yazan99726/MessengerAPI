using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.DTO
{
    public class UserChangeCurrPass
    {
        public int userId { get; set; }
        public string oldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
