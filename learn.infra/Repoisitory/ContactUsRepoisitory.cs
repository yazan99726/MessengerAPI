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
    public class ContactUsRepoisitory : IContactUsRepoisitory
    {
        private readonly IDBContext dBContext;

        public ContactUsRepoisitory(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public bool DeleteContact(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@crud", "D", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("@CcontactUsId", id, dbType: DbType.Int32, direction: ParameterDirection.Input); 
            var result = dBContext.dbConnection.ExecuteAsync
                ("contactUsCRUD_Package.contactUsCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public contactUs GetAboutById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@CcontactUsId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<contactUs> result = dBContext.dbConnection.Query<contactUs>
                ("contactUsCRUD_Package.getById", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<contactUs> GetContact()
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<contactUs> result = dBContext.dbConnection.Query<contactUs>
                ("contactUsCRUD_Package.contactUsCRUD", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool InsertContact(contactUs contact)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("@crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@FfullName", contact.fullName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@EEmail", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
             ("@Mmessage", contact.message, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                ("contactUsCRUD_Package.contactUsCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public bool UpdateContact(contactUs contact)
        {

            var parameter = new DynamicParameters();
            parameter.Add
               ("@crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("@CcontactUsId", contact.contactUsId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("@FfullName", contact.fullName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@EEmail", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
             ("@Mmessage", contact.message, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                ("contactUsCRUD_Package.contactUsCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }
    }
}
