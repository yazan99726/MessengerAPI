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
    public class HomeRepoisitory : IHomeRepoisitory
    {
        private readonly IDBContext dbContext;

        public HomeRepoisitory(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool DeleteHome(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@crud", "D", dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("@HHomeId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.dbConnection.ExecuteAsync
                ("HomeCRUD_Package.HomeCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public List<Home> GetHome()
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Home> result = dbContext.dbConnection.Query<Home>
                ("HomeCRUD_Package.HomeCRUD", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Home GetHomeById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@HHomeId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Home> result = dbContext.dbConnection.Query<Home>
                ("HomeCRUD_Package.getById", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool InsertHome(Home home)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("@crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@LlapImg", home.lapImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@CchatAppImg", home.chatAppImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@MmobileImg", home.mobileImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@QQRcodeImg", home.QRcodeImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@UuserCustamizerImg", home.userCustamizerImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@FfutcherImg", home.futcherImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@RRTLImg", home.RTLImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@FFilesImg", home.FilesImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@NNoteImg", home.NoteImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@RRemiderImg", home.RemiderImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@SsomeFutchersImg", home.someFutchersImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@DDarkLightImg", home.DarkLightImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@AaudioImg", home.audioImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
             ("@SSendStickerImg", home.SendStickerImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@CChatHistoryContactImg", home.ChatHistoryContactImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
             ("@VViewStatusImg", home.ViewStatusImg, dbType: DbType.String, direction: ParameterDirection.Input);
         
            var result = dbContext.dbConnection.ExecuteAsync
                ("HomeCRUD_Package.HomeCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public bool UpdateHome(Home home)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("@crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@HHomeId", home.HomeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("@LlapImg", home.lapImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@CchatAppImg", home.chatAppImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@MmobileImg", home.mobileImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@QQRcodeImg", home.QRcodeImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@UuserCustamizerImg", home.userCustamizerImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@FfutcherImg", home.futcherImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@RRTLImg", home.RTLImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@FFilesImg", home.FilesImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@NNoteImg", home.NoteImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@RRemiderImg", home.RemiderImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@SsomeFutchersImg", home.someFutchersImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@DDarkLightImg", home.DarkLightImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@AaudioImg", home.audioImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
             ("@SSendStickerImg", home.SendStickerImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@CChatHistoryContactImg", home.ChatHistoryContactImg, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
             ("@VViewStatusImg", home.ViewStatusImg, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dbContext.dbConnection.ExecuteAsync
                ("HomeCRUD_Package.HomeCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }
    }
}
