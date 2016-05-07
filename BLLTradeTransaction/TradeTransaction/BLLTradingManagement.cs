using System;
using System.Collections.Generic;
using System.Text;
using Common;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class BLLTradingManagement
    {
        public CResult GetImportTradeManuallyByExchange(String TRANSACTION_DATE, String SECURITY_EXCHANGE_ID)
        {
            CResult CResult = new CResult();
            String Query = String.Empty;
            DatabaseManager DatabaseManager = new DatabaseManager();
            try
            {
                Query = @"
                        SELECT
                        EX.EXCHANGE_SHORT_NAME
                        ,SUM(IBS.QUANTITY*IBS.UNIT_PRICE) TURNOVER
                        ,COUNT(IBS.ID) TOTAL_HOWLA_NO
                        FROM 
                        [TBL_TRANSACTION_INSTRUMENT_BUY_SELL_DAILY_TEMP] IBS
                        INNER JOIN TBL_SETTINGS_SECURITY_EXCHANGE EX ON EX.ID=IBS.SECURITY_EXCHANGE_ID
                        WHERE
                        IBS.ISDELETED=0
                        AND IBS.TRANSACTION_DATE=@TRANSACTION_DATE
                        AND IBS.SECURITY_EXCHANGE_ID=@SECURITY_EXCHANGE_ID
                        GROUP BY EX.EXCHANGE_SHORT_NAME
                        ORDER BY EX.EXCHANGE_SHORT_NAME 
                        ";
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(TRANSACTION_DATE));
                objList[1] = new SqlParameter("@SECURITY_EXCHANGE_ID", TypeCasting.ToInt16(SECURITY_EXCHANGE_ID));

                CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, false, CommandType.Text);
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

        public CResult ApproveImportTradeManuallyByExchange(String TRANSACTION_DATE, String SECURITY_EXCHANGE_ID)
        {
            CResult CResult = new CResult();
            String Query = String.Empty;
            DatabaseManager DatabaseManager = new DatabaseManager();
            try
            {
                Query = @"SP_PROCESS_APPROVE_TRADE__TRANSACTION";
                SqlParameter[] objList = new SqlParameter[3];
                objList[0] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(TRANSACTION_DATE));
                objList[1] = new SqlParameter("@SECURITY_EXCHANGE_ID", TypeCasting.ToInt16(SECURITY_EXCHANGE_ID));
                objList[2] = new SqlParameter("@CREATED_BY", 99);

                CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, false, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

        public CResult ExecuteSettlementProcess(String TRANSACTION_DATE)
        {
            CResult CResult = new CResult();
            String Query = String.Empty;
            DatabaseManager DatabaseManager = new DatabaseManager();
            try
            {
                Query = @"SP_PROCESS_INSTRUMENT_TRADE_SETTLEMENT";
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(TRANSACTION_DATE));
                objList[1] = new SqlParameter("@CREATED_BY", 99);

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
