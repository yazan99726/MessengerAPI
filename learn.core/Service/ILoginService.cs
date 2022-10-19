using Messenger.core.Data;
using Messenger.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.Service
{
    public interface ILoginService
    {
        public List<Login> GetAllLog();
        public bool InsertLog(UserLogDTO userLog);
        public bool UpdateLog(Login userLog);
        public string Authentication_jwt(Login login);
        public bool restPassword(Login login);
        public Login getLogByEmail(string email);
        public bool UpdateVerificationCode(UserLogDTO userLog);
        public string ChangeCurrentPassword(UserChangeCurrPass userChangeCurrPass);

    }
}
