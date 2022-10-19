using Messenger.core.Data;
using Messenger.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.Repoisitory
{
    public interface ILoginRepository
    {
        public List<Login> GetAllLog();
        public bool InsertLog(UserLogDTO userLog);
        public bool UpdateLog(Login userLog);
        public Log Auth(Login login);

        public Login getById(int UserId);
        public Login getLogByEmail(string email);
        public bool UpdateVerificationCode(UserLogDTO userLog);
        public string ChangeCurrentPassword(UserChangeCurrPass userChangeCurrPass);
    }
}
