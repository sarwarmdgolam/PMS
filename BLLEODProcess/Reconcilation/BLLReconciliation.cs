using System;
using System.Collections.Generic;
using System.Text;
using Common;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLReconciliation
    {
        public CResult GetDailyStockReconciliation()
        {
            CResult CResult = new CResult();
            String Query = @"[SP_RECONCILE_DAILY_STOCK_TRANSACTION]";
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

        public CResult GetDailyCashReconciliation()
        {
            CResult CResult = new CResult();
            String Query = @"[SP_RECONCILE_DAILY_CASH_TRANSACTION]";
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
    }
}
