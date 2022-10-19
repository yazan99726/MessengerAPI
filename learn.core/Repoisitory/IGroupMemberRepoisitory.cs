using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace learn.core.Repoisitory
{
    public interface IGroupMemberRepoisitory
    {
        public bool InsertGroupMember(GroupMember groupMember);
        public List<GroupMember> GetGroupMember();
        public bool UpdateGroupMember(GroupMember groupMember);
        public bool DeleteGroupMember(int id);
        public List<GroupMember> GetGroupMemberById(int id);

        public Task<IList<GroupMember>> GetGroupMemberForMessageGroup(int MessageGroup_id);
    }
}
