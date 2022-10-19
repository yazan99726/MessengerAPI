using Messenger.core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace learn.core.Data
{
    public class GroupMember
    {
        [Key]
        public int GroupMemberId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LeftDate { get; set; }
        public int MessageGroupId { get; set; }
        public int User_Id { get; set; }

        [ForeignKey("MessageGroupId")]
        public virtual MessageGroup MessageGroup { get; set; }
        
        [ForeignKey("User_Id")]
        public virtual Userr User { get; set; }
    }
}
