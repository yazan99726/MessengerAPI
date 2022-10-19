using Dapper;
using learn.core.Data;
using learn.core.domain;
using Messenger.core.Data;
using Messenger.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.infra.Repoisitory
{
    public class FrindRepository : IFrindRepository
    {
        private readonly IDBContext dbContext;

        public FrindRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddFrind(Frinds frind)
        {
            var p = new DynamicParameters();
            p.Add("@crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Frind_Id", frind.Frindid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ReceiveId", frind.Userreceiveid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@FStatus", frind.Status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Add_Date", frind.Adddate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@uId", frind.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("FrindsCrud_Package.FrindsCrud", p, commandType: CommandType.StoredProcedure);
        }

        public void BlockFriend(int id)
        {
            var p = new DynamicParameters();
            p.Add("@id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("FrindsCrud_Package.BlockFriend", p, commandType: CommandType.StoredProcedure);
        }

        public void confirmFriend(int id)
        {
            var p = new DynamicParameters();
            p.Add("@id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("FrindsCrud_Package.confirmFriend", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteFrind(int friendId)
        {
            var p = new DynamicParameters();
            p.Add("@crud", "D", dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Frind_Id", friendId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("FrindsCrud_Package.FrindsCrud", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<IList<Frinds>> GetAllFrinds(int userId)
        {
            var p = new DynamicParameters();
            p.Add("@crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@uId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await dbContext.dbConnection.QueryAsync<Frinds, Userr, Frinds>("FrindsCrud_Package.FrindsCrud", (frinds, users) =>
            {
                frinds.User = frinds.User ?? new Userr();
                frinds.User =users;
                return frinds;
            },
            splitOn: "User_Id",
            param:p,
            commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }

        public Frinds GetFrindById(int userId, int reciveId)
        {
            var p = new DynamicParameters();
            p.Add("@ReceiveId", reciveId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@uId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.Query<Frinds>("FrindsCrud_Package.getById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateFrind(Frinds frind)
        {
            var p = new DynamicParameters();
            p.Add("@crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Frind_Id", frind.Frindid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ReceiveId", frind.Userreceiveid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@FStatus", frind.Status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Add_Date", frind.Adddate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@uId", frind.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("FrindsCrud_Package.FrindsCrud", p, commandType: CommandType.StoredProcedure);
        }
    }
}
