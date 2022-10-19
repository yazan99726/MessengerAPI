using learn.core.Data;
using Messenger.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface IReportUserRepoisitory
    {
        public bool InsertReportUser(ReportUser report);
        public List<ReportUser> GetReportUsers();
        public bool UpdateReportUser(ReportUser report);
        public bool DeleteReportUser(int id);
        public ReportUser GetReportUsersById(int id);
        public GetAllReportByUserName GetReportUsersByName(string name);
        public bool acceptingReportUser(int id);
        public bool rejectreport(int id);
        public List<GetAllReportByUserName> GetAllByusername();
    }
}
