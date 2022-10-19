using Dapper;
using learn.core.Data;
using learn.core.domain;
using Messenger.core.Data;
using Messenger.core.DTO;
using Messenger.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.infra.Repoisitory
{
    //
    public class DtoRepository : IDtoRepository
    {
        private readonly IDBContext dbContext;
        

        public DtoRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CreateMessageGroupAndGroupMember> createMessageGroupAndMember(CreateMessageGroupAndGroupMember groupAndGroupMember)
        {
            MessageGroup messageGroup = new MessageGroup();
            messageGroup = groupAndGroupMember.messageGroup;
            List<GroupMember> members = groupAndGroupMember.groupMembers;

            var parameter = new DynamicParameters();
            parameter.Add("crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("GGroupName", messageGroup.GroupName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("GGroupImg", messageGroup.GroupImg, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = await dbContext.dbConnection.QueryAsync<int>("MessageGroupCRUD_Package.MessageGroupCRUD", parameter, commandType: CommandType.StoredProcedure);
            parameter = new DynamicParameters();
            foreach (var item in members)
            {
                item.JoinDate = DateTime.UtcNow;
                item.MessageGroupId = result.First();

                
                parameter.Add("crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("JJoinDate", item.JoinDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                parameter.Add("LLeftDate", item.LeftDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                parameter.Add("MMessageGroupId", item.MessageGroupId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("UUser_Id", item.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var member = dbContext.dbConnection.ExecuteAsync("GroupMemberCRUD_Package.GroupMemberCRUD", parameter, commandType: CommandType.StoredProcedure);

            }

            return groupAndGroupMember;
        }

        public GetAllNumberOfFriends getAllNumberOfFriends(int userId)
        {
            GetAllNumberOfFriends getAllNumberOfFriends = new GetAllNumberOfFriends();
            var p = new DynamicParameters();
            p.Add("@crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@UserId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.Query<Frinds>("FrindsCrud_Package.FrindsCrud", p, commandType: CommandType.StoredProcedure).ToList();
            getAllNumberOfFriends.frinds = result.Where(f=>f.Status==1).ToList();
            getAllNumberOfFriends.numOfFriends = result.Where(f=>f.Status==1).ToList().Count;
            return getAllNumberOfFriends;
        }
    }
}
