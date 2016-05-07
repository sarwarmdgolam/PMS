using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLDBManagement
    {
        public CResult GetDatabaseList()
        {
            CResult CResult = new CResult();
            String Query = @"SELECT NAME FROM SYS.DATABASES ORDER BY NAME";
            try
            {
                DatabaseManager DatabaseManager = new DatabaseManager();
                CResult = DatabaseManager.ExecuteSQLQuery(Query, null, false, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

        public CResult BackupDatabase(String DATABASE_NAME, String DESTINATION_PATH, String REMARKS)
        {
            CResult CResult = new CResult();
            String Query = @"SP_DBMANAGER_BACKUP_DATABASE";
            try
            {
                SqlParameter[] objList = new SqlParameter[4];
                objList[0] = new SqlParameter("@DATABASE_NAME", DATABASE_NAME);
                objList[1] = new SqlParameter("@DESTINATION_PATH", DESTINATION_PATH);
                objList[2] = new SqlParameter("@REMARKS", REMARKS);
                
                objList[3] = new SqlParameter("@CREATED_BY", 99);

                DatabaseManager DatabaseManager = new DatabaseManager();
                CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, true, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

        public CResult RestoreDatabase(String DATABASE_NAME, String SOURCE_PATH)
        {
            CResult CResult = new CResult();
            String Query = @"SP_DBMANAGER_RESTORE_DATABASE";
            try
            {
                SqlParameter[] objList = new SqlParameter[3];
                objList[0] = new SqlParameter("@DATABASE_NAME", DATABASE_NAME);
                objList[1] = new SqlParameter("@SOURCE_PATH", SOURCE_PATH);
                objList[2] = new SqlParameter("@CREATED_BY", 99);

                DatabaseManager DatabaseManager = new DatabaseManager();
                CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, true, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

    }
}
