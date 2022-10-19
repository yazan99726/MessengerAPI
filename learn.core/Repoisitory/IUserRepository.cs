using Messenger.core.Data;
using Messenger.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.Repoisitory
{
    public interface IUserRepository
    {
        public List<Userr> GetAllUsers();
        public bool InsertUser(UserLogDTO userLog);
        public bool DeleteUser(int UserId);
        public bool UpdateUser(Userr user);
        public Userr GetUserById(int userId);
        public Userr GetUserByUserName(string userName);
        public bool IsBlocked(Userr user);
        public bool UnBlock(Userr user);
        public bool activationChange(Userr user);

    }
}
