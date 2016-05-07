using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Model;
using Common;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class BLLPriceManagement
    {
        public CResult DeleteMarketClosingPriceTempInfo()
        {
            CResult CResult = new CResult();
            String Query = @"TRUNCATE TABLE TBL_TRANSACTION_MARKET_CLOSING_PRICE_TEMP";
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

        public CResult InsertMarketClosingPriceInfoTemp(DataTable dt)
        {
            CResult CResult = new CResult();
            CResult = DeleteMarketClosingPriceTempInfo();
            if (CResult.IsSuccess)
            {
                String Query = @"TBL_TRANSACTION_MARKET_CLOSING_PRICE_TEMP";
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

        public CResult InsertMarketClosingPriceInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_MARKET_CLOSING_PRICE";
            try
            {
                SqlParameter[] objList = new SqlParameter[3];
                objList[0] = new SqlParameter("@SECURITY_EXCHANGE_ID", oParams["SECURITY_EXCHANGE_ID"]);
                objList[1] = new SqlParameter("@TRANSACTION_DATE", oParams["TRANSACTION_DATE"]);
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
    }
}
