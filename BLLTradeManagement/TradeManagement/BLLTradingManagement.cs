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
        public CResult GetImportTradeManuallyByExchange()
        {
            CResult CResult = new CResult();
            String Query = String.Empty;
            DatabaseManager DatabaseManager = new DatabaseManager();
            try
            {
                Query = @"SP_GET_UNAPPROVED_TRADE_INFORMATION";
                CResult = DatabaseManager.ExecuteSQLQuery(Query, null, false, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

        public CResult ApproveImportTradeManuallyByExchange(String TRANSACTION_DATE)
        {
            CResult CResult = new CResult();
            String Query = String.Empty;
            DatabaseManager DatabaseManager = new DatabaseManager();
            try
            {
                Query = @"SP_APPROVE_DAILY_TRADE__TRANSACTION";
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

        public CResult ReverseSettlementProcess(String TRANSACTION_DATE)
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
