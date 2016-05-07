using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data;
using DAL;
using System.Data.SqlClient;

namespace BLL
{
    public class BLLImportTradeExcel
    {
        public CResult DeleteTradeDataTempInfo()
        {
            CResult CResult = new CResult();
            String Query = @"TRUNCATE TABLE TBL_TRANSACTION_INSTRUMENT_BUY_SELL_DAILY_EXCEL_TEMP";
            try
            {
                DatabaseManager DatabaseManager = new DatabaseManager();
                CResult = DatabaseManager.ExecuteSQLQuery(Query, null, true, CommandType.Text);
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

        public CResult BulkInsertTradeDataTempInfo(DataTable dt)
        {
            CResult CResult = new CResult();
            CResult = DeleteTradeDataTempInfo();
            if (CResult.IsSuccess)
            {
                String Query = @"TBL_TRANSACTION_INSTRUMENT_BUY_SELL_DAILY_EXCEL_TEMP";
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

        public CResult InsertTradeDataTempInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_INSTRUMENT_BUY_SELL_DAILY_EXCEL_TEMP";
            try
            {
                SqlParameter[] objList = new SqlParameter[3];
                objList[0] = new SqlParameter("@SECURITY_EXCHANGE_ID", TypeCasting.ToInt16(oParams["SECURITY_EXCHANGE_ID"]));
                objList[1] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime( oParams["TRANSACTION_DATE"]));
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

        public CResult DeleteTradeDataTempInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_DELETE_TRANSACTION_INSTRUMENT_BUY_SELL_DAILY";
            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@SECURITY_EXCHANGE_ID", TypeCasting.ToInt16(oParams["SECURITY_EXCHANGE_ID"]));
                objList[1] = new SqlParameter("@DELETED_BY", "99");

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
