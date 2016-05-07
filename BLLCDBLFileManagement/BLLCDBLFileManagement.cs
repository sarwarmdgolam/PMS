using System;
using System.Collections.Generic;
using System.Text;
using Common;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BLLCDBLFileManagement
    {
        public CResult GetCDBLFilesInfo()
        {
            CResult CResult = new CResult();
            String Query = @"SELECT * FROM dbo.TBL_SETTINGS_CDBL_FILE CF WHERE CF.ISDELETED=0";

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

        public CResult DeleteCDBLUploadedTableTempInfo(String FILE_NAME)
        {
            CResult CResult = new CResult();
            String Query = @"SP_DELETE_CDBL_UPLOADED_TABLE_TEMP";
            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@FILE_NAME", FILE_NAME);
                objList[1] = new SqlParameter("@CREATED_BY", "99");

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

        public CResult InsertCDBLUploadedDataIntoTempTbl(DataTable dt,String CDBLFileName)
        {
            CResult CResult = new CResult();
            String Query = String.Empty;
            switch (CDBLFileName)
            {
                case "17DP64UX":
                    Query = "TBL_TEMP_CDBL_CORPORATE_ACTION_RECEIVABLE";
                    break;
                case "17DP70UX":
                    Query = "TBL_TEMP_CDBL_CORPORATE_ACTION_RECEIVED";
                    break;
            }

            CResult = DeleteCDBLUploadedTableTempInfo(CDBLFileName);
            if (CResult.IsSuccess)
            {            
              try
                {
                    DatabaseManager DatabaseManager = new DatabaseManager();
                    CResult = DatabaseManager.ExecuteSQLBulkCopy(Query, dt);
                }
                catch (Exception ex)
                {
                    CResult.IsSuccess = false;
                    CResult.Message = ex.Message;
                }
            }
            return CResult;
        }

        public CResult InsertCDBLUploadedDataFromTempTbl(String FILE_NAME, String TRANSACTION_DATE_FROM, String TRANSACTION_DATE_TO)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_CDBL_UPLOADED_DATA_FROM_TEMP_TBL";
            try
            {
                SqlParameter[] objList = new SqlParameter[4];
                objList[0] = new SqlParameter("@FILE_NAME", FILE_NAME);
                objList[1] = new SqlParameter("@TRANSACTION_DATE_FROM", TypeCasting.ToDateTime(TRANSACTION_DATE_FROM) );
                objList[2] = new SqlParameter("@TRANSACTION_DATE_TO", TypeCasting.ToDateTime(TRANSACTION_DATE_TO));
                objList[3] = new SqlParameter("@CREATED_BY", "99");

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

        public CResult ApproveCDBLUploadedData(String FILE_NAME, String IS_APPROVED, String TRANSACTION_DATE_FROM, String TRANSACTION_DATE_TO)
        {
            CResult CResult = new CResult();
            String Query = @"SP_APPROVE_CDBL_UPLOADED_UNAPPROVED_DATA";
            try
            {
                SqlParameter[] objList = new SqlParameter[5];
                objList[0] = new SqlParameter("@FILE_NAME", FILE_NAME);
                objList[1] = new SqlParameter("@IS_APPROVED", TypeCasting.ToBoolean(IS_APPROVED));
                objList[2] = new SqlParameter("@TRANSACTION_DATE_FROM", TypeCasting.ToDateTime(TRANSACTION_DATE_FROM));
                objList[3] = new SqlParameter("@TRANSACTION_DATE_TO", TypeCasting.ToDateTime(TRANSACTION_DATE_TO));
                objList[4] = new SqlParameter("@CREATED_BY", "99");

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

        public CResult ProcessCDBLUploadedData(String FILE_NAME, String TRANSACTION_DATE)
        {
            CResult CResult = new CResult();
            String Query = @"SP_PROCESS_CDBL_UPLOADED_APPROVED_DATA";
            try
            {
                SqlParameter[] objList = new SqlParameter[3];
                objList[0] = new SqlParameter("@FILE_NAME", FILE_NAME);
                objList[1] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(TRANSACTION_DATE));
                objList[2] = new SqlParameter("@CREATED_BY", "99");

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

        public CResult GetCDBLUploadedData(String FILE_NAME, String IS_APPROVED, String TRANSACTION_DATE_FROM, String TRANSACTION_DATE_TO)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_CDBL_UPLOADEDDATA_INFO";
            try
            {
                SqlParameter[] objList = new SqlParameter[5];
                objList[0] = new SqlParameter("@FILE_NAME", FILE_NAME);
                objList[1] = new SqlParameter("@IS_APPROVED", TypeCasting.ToBoolean(IS_APPROVED));
                objList[2] = new SqlParameter("@TRANSACTION_DATE_FROM", TypeCasting.ToDateTime(TRANSACTION_DATE_FROM));
                objList[3] = new SqlParameter("@TRANSACTION_DATE_TO", TypeCasting.ToDateTime(TRANSACTION_DATE_TO));
                objList[4] = new SqlParameter("@CREATED_BY", "99");

                DatabaseManager DatabaseManager = new DatabaseManager();
                CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, false, CommandType.StoredProcedure);
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
