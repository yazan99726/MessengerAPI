using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using Messenger.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace learn.infra.Service
{
    public class Messageservice : IMessageservice
    {
        private readonly IMessageRepoisitory MessageRepoisitory;
        public Messageservice(IMessageRepoisitory MessageRepoisitory)
        {
            this.MessageRepoisitory = MessageRepoisitory;
        }
        public string CreateMessage(Message ins)
        {
           return MessageRepoisitory.CreateMessage(ins);    
        }

        public string DeleteMessage(int id)
        {
            return MessageRepoisitory.DeleteMessage(id);
        }

        public List<Message> GetAllMessage()
        {
            return MessageRepoisitory.GetAllMessage();
        }

        public async Task<IList<Message>> GetAllMessageForMessageGroup(int messageGroup_id)
        {
            return await MessageRepoisitory.GetAllMessageForMessageGroup(messageGroup_id);
        }

        public Message GetMessageById(int id)
        {
            return MessageRepoisitory.GetMessageById(id);
        }

        public string UpDateMessage(Message upd)
        {
            return MessageRepoisitory.UpDateMessage(upd);
        }

        public async Task<IList<Message>> SearchMessageBetweenTwoDate(SearchMessageBetweenDate messageBetweenDate)
        {
            return await MessageRepoisitory.SearchMessageBetweenTwoDate(messageBetweenDate);
        }
    }
}
