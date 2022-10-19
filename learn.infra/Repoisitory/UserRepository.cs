using Dapper;
using learn.core.domain;
using Messenger.core.Data;
using Messenger.core.DTO;
using Messenger.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Messenger.infra.Repoisitory
{
    public class UserRepository : IUserRepository
    {
        private readonly IDBContext dBContext;

        public UserRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public bool DeleteUser(int UserId)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@crud", "D", dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("@UUserId", UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("UserrCRUD_Package.UserrCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public List<Userr> GetAllUsers()
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Userr> result = dBContext.dbConnection.Query<Userr>
                ("UserrCRUD_Package.UserrCRUD", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Userr GetUserById(int userId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@UUserId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Userr> result = dBContext.dbConnection.Query<Userr>
                ("UserrCRUD_Package.getById", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Userr GetUserByUserName(string userName)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@UuserName", userName, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Userr> result = dBContext.dbConnection.Query<Userr>
                ("UserrCRUD_Package.getByUserName", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool InsertUser(UserLogDTO userLog)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("@crud","C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@FFname", userLog.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@LLname", userLog.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("@PProFileImg", userLog.ProFileImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@GGender", userLog.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@IIsBlocked", 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("@IIsActive", 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
              ("@UuserName", userLog.userName, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                ("UserrCRUD_Package.UserrCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public bool UpdateUser(Userr user)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("UUserId", user.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("FFname", user.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("LLname", user.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("PProFileImg", user.ProFileImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("GGender", user.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@IIsBlocked", user.IsBlocked, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("@IIsActive", user.IsActive, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
              ("UUserBio", user.UserBio, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@UuserName", user.userName, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dBContext.dbConnection.ExecuteAsync
                ("UserrCRUD_Package.UserrCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public bool IsBlocked(Userr user)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@UUserId", user.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync("UserrCRUD_Package.IsBlocked", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }

        public bool activationChange(Userr user)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@UUserId", user.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@IIsActive", user.IsActive, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync("UserrCRUD_Package.activationChange", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }
        public bool UnBlock(Userr user)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@UUserId", user.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync("UserrCRUD_Package.UnBlock", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }
    }
}
