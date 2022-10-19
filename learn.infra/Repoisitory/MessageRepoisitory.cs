using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.Repoisitory;
using Messenger.core.Data;
using Messenger.core.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn.infra.Repoisitory
{
    public class MessageRepoisitory : IMessageRepoisitory
    {
        private readonly IDBContext dBContext;
        public MessageRepoisitory(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public string CreateMessage(Message message)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@SSenderId", message.SenderId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@TText ", message.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@MMessageDate ", message.MessageDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@MMessageGroupId ", message.MessageGroupId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@MMESSAGETYPE ", message.MessageType, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync("MessageCRUD_Package.MessageCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
            {

                return "NotInserted";
            }
            else
            {
                return "Inserted";
            }
        }

        public string DeleteMessage(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud ", "D", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("MMessageId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.Execute("MessageCRUD_Package .MessageCRUD", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return "Notdelete";
            }
            else
            {
                return "deleted";
            }
        }

        public List<Message> GetAllMessage()
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Message> result = dBContext.dbConnection.Query<Message>("MessageCRUD_Package.MessageCRUD", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<IList<Message>> GetAllMessageForMessageGroup(int messageGroup_id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@MessageGroup_ID", messageGroup_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await dBContext.dbConnection.QueryAsync<Message, MessageGroup,Userr, Message >("Chat_Package.GetMessageForMessageGroup", (message, messageGroup, user) =>
            {
                message.MessageGroup = message.MessageGroup ?? new MessageGroup();
                message.MessageGroup = messageGroup;
                message.User = message.User ?? new Userr();
                message.User = user;


                return message;
            },

            splitOn: "MessageGroupId,userId",
            param: parameter,
            commandType: CommandType.StoredProcedure
            );
            return result.ToList();
            
        }

        public Message GetMessageById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("MMessageId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Message> result = dBContext.dbConnection.Query<Message>("MessageCRUD_Package.getById", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public string UpDateMessage(Message message)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@MMessageId", message.MessageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@SSenderId", message.SenderId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@TText ", message.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@MMessageDate ", message.MessageDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@MMessageGroupId ", message.MessageGroupId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@MMESSAGETYPE ", message.MessageType, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync("MessageCRUD_Package.MessageCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
            {

                return "NotUpDate";
            }
            else
            {
                return "UpDate";
            }
        }

        public async Task<IList<Message>> SearchMessageBetweenTwoDate(SearchMessageBetweenDate messageBetweenDate)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@MessageGroup_ID", messageBetweenDate.messageGroupId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@StartDate", messageBetweenDate.StartDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            parameter.Add("@EndDate", messageBetweenDate.EndDate, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = await dBContext.dbConnection.QueryAsync<Message, MessageGroup, Userr, Message>("Chat_Package.SearchMessageBetweenDate", (message, messageGroup, user) =>
            {
                message.MessageGroup = message.MessageGroup ?? new MessageGroup();
                message.MessageGroup = messageGroup;
                message.User = message.User ?? new Userr();
                message.User = user;


                return message;
            },

            splitOn: "MessageGroupId,userId",
            param: parameter,
            commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
    }
}
