using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace learn.infra.Service
{
    public class MessageGroupservice : IMessageGroupservice
    {
        private readonly IMessageGroupRepoisitory MessageGroupRepoisitory;
        public MessageGroupservice(IMessageGroupRepoisitory MessageGroupRepoisitory)
        {
            this.MessageGroupRepoisitory = MessageGroupRepoisitory;
        }
        public int CreateMessageGroup(MessageGroup ins)
        {
           return MessageGroupRepoisitory.CreateMessageGroup(ins);
        }

        public string DeleteMessageGroup(int id)
        {
            return MessageGroupRepoisitory.DeleteMessageGroup(id);  
        }

        public List<MessageGroup> GetAllMessageGroup()
        {
            return MessageGroupRepoisitory.GetAllMessageGroup();
        }

        public async Task<IList<MessageGroup>> GetMessageGroupForUser(int id)
        { 
            var res = await MessageGroupRepoisitory.GetMessageGroupForUser(id);
            return res;
        }

        public MessageGroup GetMessageGroupById(int id)
        {
            return MessageGroupRepoisitory.GetMessageGroupById(id);
        }

        public string UpDateMessageGroup(MessageGroup upd)
        {
            return MessageGroupRepoisitory.UpDateMessageGroup(upd);
        }
    }
}
