using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.DTO
{
    public class GetAllReportByUserName
    {
        public int ReportUserId { get; set; }
        public int UserReportedId { get; set; }
        public string UserNameReport { get; set; }
        public string ReportText { get; set; }
        public int Status { get; set; }
        public DateTime ReportDate { get; set; }
        public int User_Id { get; set; }
        public string  UserName { get; set; }
    
    }
}
