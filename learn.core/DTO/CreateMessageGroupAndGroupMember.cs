using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.DTO
{
    public class CreateMessageGroupAndGroupMember
    {
        public MessageGroup messageGroup { get; set; }
        public List<GroupMember> groupMembers { get; set; }
    }
}
