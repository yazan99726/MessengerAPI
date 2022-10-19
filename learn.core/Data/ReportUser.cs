using Messenger.core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace learn.core.Data
{
    public class ReportUser
    {
        [Key]
        public int ReportUserId { get; set; }
        public int UserReportedId { get; set; }
        public string ReportText { get; set; }
        public int Status { get; set; }
        public DateTime ReportDate { get; set; }
        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual Userr Userr { get; set; }
    }
}
