using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Data
{
    public class MessageGroup
    {
        public int MessageGroupId { get; set;}
        public string GroupName { get; set;} 
        public string GroupImg { get; set; }

        public virtual ICollection<GroupMember> GroupMembers { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
