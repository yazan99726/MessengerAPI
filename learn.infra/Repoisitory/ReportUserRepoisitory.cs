using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.Repoisitory;
using Messenger.core.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    public class ReportUserRepoisitory : IReportUserRepoisitory
    {
        private readonly IDBContext dBContext;

        public ReportUserRepoisitory(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public bool DeleteReportUser(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud", "D", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("RReportUserId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync("ReportUserCRUD_Package.ReportUserCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        public List<ReportUser> GetReportUsers()
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<ReportUser> result = dBContext.dbConnection.Query<ReportUser>("ReportUserCRUD_Package.ReportUserCRUD", parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }


        public ReportUser GetReportUsersById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("RReportUserId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ReportUser> result = dBContext.dbConnection.Query<ReportUser>("ReportUserCRUD_Package.getById", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public GetAllReportByUserName GetReportUsersByName(string name)
        {
            var parameter = new DynamicParameters();
            parameter.Add("RUserName", name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<GetAllReportByUserName> result = dBContext.dbConnection.Query<GetAllReportByUserName>("ReportUserCRUD_Package.GetReportUsersByName", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public bool InsertReportUser(ReportUser report)
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("UUserReportedId", report.UserReportedId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("RReportText", report.ReportText, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("SStatus", report.Status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("RReportDate", report.ReportDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("UUser_Id", report.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync("ReportUserCRUD_Package.ReportUserCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdateReportUser(ReportUser report)
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add("RReportUserId", report.ReportUserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("UUserReportedId", report.UserReportedId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("RReportText", report.ReportText, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("SStatus", report.Status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("RReportDate", report.ReportDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("UUser_Id", report.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync("ReportUserCRUD_Package.ReportUserCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool acceptingReportUser(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("RReportUserId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync("ReportUserCRUD_Package.acceptingReportUser", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            else
                return true;
        }

        public bool rejectreport(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("RReportUserId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync("ReportUserCRUD_Package.rejectreport", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            else
                return true;
        }

        public List<GetAllReportByUserName> GetAllByusername()
        {
            IEnumerable<GetAllReportByUserName> result = dBContext.dbConnection.Query<GetAllReportByUserName>("ReportUserCRUD_Package.GetAllByusername", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}