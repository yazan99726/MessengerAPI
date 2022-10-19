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
    public class AboutUsRepoisitory : IAboutUsRepoisitory
    {
        private readonly IDBContext dBContext;

        public AboutUsRepoisitory(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public bool DeleteAbout(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@crud", "D", dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("@AaboutUsId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("aboutUsCRUD_Package.aboutUsCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public List<aboutUs> GetAbout()
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<aboutUs> result = dBContext.dbConnection.Query<aboutUs>
                ("aboutUsCRUD_Package.aboutUsCRUD", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public aboutUs GetAboutById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@AaboutUsId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<aboutUs> result = dBContext.dbConnection.Query<aboutUs>
                ("aboutUsCRUD_Package.getById", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool InsertAbout(aboutUs about)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("@crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@Ttext", about.text, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@EEmail", about.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
             ("@IimgPaht", about.imgPaht, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                ("aboutUsCRUD_Package.aboutUsCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public bool UpdateAbout(aboutUs about)
        {

            var parameter = new DynamicParameters();
            parameter.Add
               ("@crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@AaboutUsId", about.aboutUsId, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@Ttext", about.text, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@EEmail", about.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
             ("@IimgPaht", about.imgPaht, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                ("aboutUsCRUD_Package.aboutUsCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }
    }
}
