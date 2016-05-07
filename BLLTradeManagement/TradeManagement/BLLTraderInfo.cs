using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLLTradeManagement
{
    public class BLLTraderInfo
    {
        public CResult InsertTraderInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_INSERT_TRADER_INFO]";

            try
            {
                SqlParameter[] objList = new SqlParameter[7];
                objList[0] = new SqlParameter("@TRADER_CODE", oParams["TRADER_CODE"]);
                objList[1] = new SqlParameter("@BRANCH_ID", TypeCasting.ToInt64(oParams["BRANCH_ID"]));
                objList[2] = new SqlParameter("@SECURITY_EXCHANGE_ID", TypeCasting.ToInt64(oParams["SECURITY_EXCHANGE_ID"]));
                objList[3] = new SqlParameter("@EMPLOYEE_ID", TypeCasting.ToInt64(oParams["EMPLOYEE_ID"]));
                objList[4] = new SqlParameter("@CARD_REF_NO", oParams["CARD_REF_NO"]);
                objList[5] = new SqlParameter("@IS_ACTIVE", oParams["IS_ACTIVE"]);
                objList[6] = new SqlParameter("@CREATED_BY", 9);

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

        public CResult UpdateTraderInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_UPDATE_TRADER_INFO]";

            try
            {
                SqlParameter[] objList = new SqlParameter[8];
                objList[0] = new SqlParameter("@TRADER_CODE", oParams["TRADER_CODE"]);
                objList[1] = new SqlParameter("@BRANCH_ID", TypeCasting.ToInt64(oParams["BRANCH_ID"]));
                objList[2] = new SqlParameter("@SECURITY_EXCHANGE_ID", TypeCasting.ToInt64(oParams["SECURITY_EXCHANGE_ID"]));
                objList[3] = new SqlParameter("@EMPLOYEE_ID", TypeCasting.ToInt64(oParams["EMPLOYEE_ID"]));
                objList[4] = new SqlParameter("@CARD_REF_NO", oParams["CARD_REF_NO"]);
                objList[5] = new SqlParameter("@IS_ACTIVE", oParams["IS_ACTIVE"]);
                objList[6] = new SqlParameter("@ID", TypeCasting.ToInt64(oParams["ID"]));
                objList[7] = new SqlParameter("@UPDATED_BY", 9);

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

        public CResult GetTraderInfo(String ID, String strTRADER_CODE)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_GET_TRADER_INFO]";
            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));
                objList[1] = new SqlParameter("@TRADER_CODE", strTRADER_CODE);

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
