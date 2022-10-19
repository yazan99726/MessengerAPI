using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace learn.core.Repoisitory
{
    public interface IMessageGroupRepoisitory
    {

        public List<MessageGroup> GetAllMessageGroup();
        public MessageGroup GetMessageGroupById(int id);
        public int CreateMessageGroup(MessageGroup ins);
        public string UpDateMessageGroup(MessageGroup upd);
        public string DeleteMessageGroup(int id);

        public Task<IList<MessageGroup>> GetMessageGroupForUser(int id);
    }
}
