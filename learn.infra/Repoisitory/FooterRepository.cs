using Dapper;
using learn.core.domain;
using Messenger.core.Data;
using Messenger.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Messenger.infra.Repoisitory
{
    public class FooterRepository : IFooterRepoisitory
    {
        private readonly IDBContext dBContext;

        public FooterRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public bool DeleteFooter(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@crud", "D", dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("@FFooterId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("FooterCRUD_Package.FooterCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public List<Footer> GetFooter()
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Footer> result = dBContext.dbConnection.Query<Footer>
                ("FooterCRUD_Package.FooterCRUD", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Footer GetFooterById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@FFooterId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Footer> result = dBContext.dbConnection.Query<Footer>
                ("FooterCRUD_Package.getById", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool InsertFooter(Footer footer)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("@crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@LlogoImg", footer.logoImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@Ttext", footer.text, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("@Llocation", footer.location, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@PphoneNumber", footer.phoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                ("FooterCRUD_Package.FooterCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public bool UpdateFooter(Footer footer)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("@crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("@FFooterId", footer.FooterId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("@LlogoImg", footer.logoImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@Ttext", footer.text, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("@Llocation", footer.location, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@PphoneNumber", footer.phoneNumber, dbType: DbType.String, direction: ParameterDirection.Input); 
                parameter.Add
               ("@Eemail", footer.email, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("FooterCRUD_Package.FooterCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }
    }
}
