using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLLAccountsManagement
{
    public class BLLBankManagement
    {
        public CResult InsertBankInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_INSERT_BANK_INFO]";

            try
            {
                SqlParameter[] objList = new SqlParameter[3];
                objList[0] = new SqlParameter("@BANK_S_NAME", oParams["BANK_S_NAME"]);
                objList[1] = new SqlParameter("@BANK_F_NAME", oParams["BANK_F_NAME"]);
                objList[2] = new SqlParameter("@CREATED_BY", 9);

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

        public CResult InsertBankBranchInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_INSERT_BANK_INFO]";

            try
            {
                SqlParameter[] objList = new SqlParameter[3];
                objList[0] = new SqlParameter("@BANK_S_NAME", oParams["BANK_S_NAME"]);
                objList[1] = new SqlParameter("@BANK_F_NAME", oParams["BANK_F_NAME"]);
                objList[2] = new SqlParameter("@CREATED_BY", 9);

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

        

        public CResult UpdateBankInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_UPDATE_BANK_INFO]";

            try
            {
                SqlParameter[] objList = new SqlParameter[4];
                objList[0] = new SqlParameter("@BANK_S_NAME", oParams["BANK_S_NAME"]);
                objList[1] = new SqlParameter("@BANK_F_NAME", oParams["BANK_F_NAME"]);
                objList[2] = new SqlParameter("@ID", TypeCasting.ToInt64(oParams["ID"]));
                objList[3] = new SqlParameter("@UPDATED_BY", 9);

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

        public CResult GetBankInfo(String ID)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_GET_BANK_INFO]";
            try
            {
                SqlParameter[] objList = new SqlParameter[1];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));

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


        public CResult GetBankBranchInfo(String ID,String BankId)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_GET_BANK_INFO]";
            try
            {
                SqlParameter[] objList = new SqlParameter[1];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));

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
