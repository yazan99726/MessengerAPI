using learn.core.Data;
using Messenger.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace learn.core.Repoisitory
{
    public interface IMessageRepoisitory
    {
        public List<Message> GetAllMessage();
        public Message GetMessageById(int id);
        public string CreateMessage(Message ins);
        public string UpDateMessage(Message upd);
        public string DeleteMessage(int id);

        public Task<IList<Message>> GetAllMessageForMessageGroup(int messageGroup_id);
        public Task<IList<Message>> SearchMessageBetweenTwoDate(SearchMessageBetweenDate messageBetweenDate);

    }
}
