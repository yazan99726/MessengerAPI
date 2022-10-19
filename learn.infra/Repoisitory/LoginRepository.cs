using Dapper;
using learn.core.domain;
using Messenger.core.Data;
using Messenger.core.DTO;
using Messenger.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Messenger.infra.Repoisitory
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDBContext dBContext;

        public LoginRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public Log Auth(Login login)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@EEmail", login.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@UuserName", login.userName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("@PPassword", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Log> result = dBContext.dbConnection.Query<Log>
                 ("LoginCRUD_Package.Auth", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public string ChangeCurrentPassword(UserChangeCurrPass userChangeCurrPass)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@userId", userChangeCurrPass.userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@PPassword", userChangeCurrPass.oldPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@NewPassword", userChangeCurrPass.NewPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync("LoginCRUD_Package.ChangeCurrentPassword", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return "false";
            return "ture";
        }

        public List<Login> GetAllLog()
        {

            var parameter = new DynamicParameters();
            parameter.Add
                ("@crud", "G", dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Login> result = dBContext.dbConnection.Query<Login>
                ("LoginCRUD_Package.LoginCRUD", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Login getById(int UserId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@UUser_Id", UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Login> result = dBContext.dbConnection.Query<Login>
                ("LoginCRUD_Package.getById", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Login getLogByEmail(string email)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@EEmail", email, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Login> result = dBContext.dbConnection.Query<Login>
                ("LoginCRUD_Package.getByEmail", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool InsertLog(UserLogDTO userLog)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("@crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@EEmail", userLog.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@PPassword", userLog.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("@UUser_Id", userLog.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("@RRoleId", 2, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("@UuserName", userLog.userName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@VverificationCode", userLog.verificationCode, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                ("LoginCRUD_Package.LoginCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public bool UpdateLog(Login userLog)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("@crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@UUser_Id", userLog.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("@EEmail", userLog.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@PPassword", userLog.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@VverificationCode", userLog.verificationCode, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@RRoleId", 2, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("@UuserName", userLog.userName, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                ("LoginCRUD_Package.LoginCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public bool UpdateVerificationCode(UserLogDTO userLog)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@UUser_Id", userLog.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@VverificationCode", userLog.verificationCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync("LoginCRUD_Package.UpdateVerificationCode", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }
    }
}
