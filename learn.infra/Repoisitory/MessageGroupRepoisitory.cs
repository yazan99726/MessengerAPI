using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.Repoisitory;
using Messenger.core.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn.infra.Repoisitory
{
    public class MessageGroupRepoisitory : IMessageGroupRepoisitory
    {
        private readonly IDBContext dBContext;
        public MessageGroupRepoisitory(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public int CreateMessageGroup(MessageGroup ins)
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud","C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("GGroupName", ins.GroupName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("GGroupImg", ins.GroupImg, dbType: DbType.String, direction: ParameterDirection.Input);
            //parameter.Add("my_id_param", dbType:DbType.Int32, direction: ParameterDirection.Output);

            
            var result = dBContext.dbConnection.Query<int>("MessageGroupCRUD_Package.MessageGroupCRUD", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
            
            
        }

        public string DeleteMessageGroup(int id)
        {
            //
            var parameter = new DynamicParameters();
            parameter.Add("crud ", "D", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("MMessageGroupId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.Execute("MessageGroupCRUD_Package.MessageGroupCRUD", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return "Notdelete";
            }
            else
            {
                return "deleted";
            }
        }

        public List<MessageGroup> GetAllMessageGroup()
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<MessageGroup> result = dBContext.dbConnection.Query<MessageGroup>("MessageGroupCRUD_Package.MessageGroupCRUD", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<IList<MessageGroup>> GetMessageGroupForUser(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await dBContext.dbConnection.QueryAsync<MessageGroup, GroupMember,Message,Userr, MessageGroup>("Chat_Package.Chat", (messageGroup, groupMember, message, user) =>
            {
                messageGroup.GroupMembers = messageGroup.GroupMembers ?? new List<GroupMember>();
                messageGroup.GroupMembers.Add(groupMember);
                messageGroup.Messages = messageGroup.Messages ?? new List<Message>();
                messageGroup.Messages.Add(message);
                messageGroup.Messages = messageGroup.Messages.Distinct().ToList();
                messageGroup.GroupMembers.First().User = user?? new Userr();
                messageGroup.GroupMembers.First().User = user;
                return messageGroup;
            },
            splitOn: "MessageGroupId,GroupMemberId,MessageId,userId",
            param: parameter,
            commandType: CommandType.StoredProcedure
            );

            var value = result.Distinct().AsList<MessageGroup>()
                .GroupBy(x => x.MessageGroupId)
                .Select(o =>
                {
                    MessageGroup messageGroup = o.First();
                    messageGroup.GroupMembers = o.Distinct().Select(t => t.GroupMembers.Single()).Select(groupMember => new GroupMember
                    {
                        MessageGroupId = groupMember.MessageGroupId,
                        GroupMemberId = groupMember.GroupMemberId,
                        JoinDate = groupMember.JoinDate,
                        LeftDate = groupMember.LeftDate,
                        User_Id = groupMember.User_Id,
                        User = groupMember.User
                    }).Distinct().ToList();
                    messageGroup.GroupMembers = messageGroup.GroupMembers.GroupBy(x => x.GroupMemberId).Select(y => y.First()).ToList();
                    if (messageGroup.Messages.First() !=null)
                    {
                        messageGroup.Messages = o.Distinct().Select(t => t.Messages.Single()).Select(message => new Message
                        {
                            MessageGroupId = message.MessageGroupId,
                            MessageId = message.MessageId,
                            MessageDate = message.MessageDate,
                            Text = message.Text,
                            SenderId = message.SenderId,
                            MessageType = message.MessageType,

                        }).Distinct().ToList();
                        messageGroup.Messages = messageGroup.Messages.GroupBy(x => x.MessageId).Select(y => y.First()).ToList();
                    }
                   
                    return messageGroup;
                }).ToList();
            var distinctItems = value.Select(x=>x.Messages.GroupBy(x => x.MessageId).Select(y => y.First()));
            var ord = value.ToList();


            return value.ToList();
        }

        public MessageGroup GetMessageGroupById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("MMessageGroupId ", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<MessageGroup> result = dBContext.dbConnection.Query<MessageGroup>("MessageGroupCRUD_Package.getById", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public string UpDateMessageGroup(MessageGroup upd)
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add("MMessageGroupId", upd.MessageGroupId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("GGroupName", upd.GroupName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("GGroupImg", upd.GroupImg, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync("MessageGroupCRUD_Package.MessageGroupCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
            {

                return "NotUpDate";
            }
            else
            {
                return "UpDate";
            }
        }

        
    }
}
