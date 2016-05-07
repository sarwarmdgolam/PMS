using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLImportTradeManually
    {
        public CResult GetImportTradeManuallyControl()
        {
            DataSet dsControls = new DataSet();
            CResult CResult = new CResult();
            String Query = String.Empty;
            DatabaseManager DatabaseManager = new DatabaseManager();
            try
            {
                // Investor Code; Manually inserfted
                Query = @"SELECT 0 Value,'--Select--' Text 
                UNION 
                SELECT DISTINCT IPI.ID,IPI.INVESTOR_CODE 
                FROM TBL_TRANSACTION_INSTRUMENT_BUY_SELL_DAILY_TEMP IBS
                INNER JOIN TBL_INVESTOR_PERSONAL_INFO IPI ON IPI.ID=IBS.INVESTOR_ID AND IPI.ISDELETED=0
                WHERE
                IBS.ISDELETED=0
                ORDER BY Text ";
                CResult = DatabaseManager.ExecuteSQLQuery(Query, null, false, CommandType.Text);
                dsControls.Tables.Add(CResult.Data);

                CResult.Object = (object)dsControls;
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

       
        public CResult InsertImportTradeManually(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"
            INSERT INTO dbo.TBL_TRANSACTION_INSTRUMENT_BUY_SELL_DAILY_TEMP
           (SECURITY_EXCHANGE_ID
           ,MARKET_TYPE_ID
           ,ORDER_REF_NO
           ,INVESTOR_ID
           ,COMPANY_ID
           ,TRANSACTION_MODE_ID
           ,QUANTITY
           ,UNIT_PRICE
           ,COMM_PERCENT
           ,COMM_AMOUNT
           ,HOWLA_AMOUNT
           ,TRANSACTION_AMOUNT
           ,AIT_AMOUNT
           ,TRADER_ID
           ,ISCOMPULSORY_SPOT
           ,HOWLA_REF_NO
           ,EXEC_TIME
           ,TRANSACTION_DATE
           ,FILL_TYPE
           ,FOREIGN_FLAG
           ,CATEGORY_ID
           ,CREATED_BY
           ,CREATE_DT
           ,ISDELETED
           )
           VALUES
           (
           @SECURITY_EXCHANGE_ID
           ,@MARKET_TYPE_ID
           ,@ORDER_REF_NO
           ,@INVESTOR_ID
           ,@COMPANY_ID
           ,@TRANSACTION_MODE_ID
           ,@QUANTITY
           ,@UNIT_PRICE
           ,@COMM_PERCENT
           ,@COMM_AMOUNT
           ,@HOWLA_AMOUNT
           ,@TRANSACTION_AMOUNT
           ,@AIT_AMOUNT
           ,@TRADER_ID
           ,@ISCOMPULSORY_SPOT
           ,@HOWLA_REF_NO
           ,@EXEC_TIME
           ,@TRANSACTION_DATE
           ,@FILL_TYPE
           ,@FOREIGN_FLAG
           ,@CATEGORY_ID
           ,@CREATED_BY
           ,GETDATE()
           ,0
           )
          ";
            try
            {
                SqlParameter[] objList = new SqlParameter[22];
                objList[0] = new SqlParameter("@SECURITY_EXCHANGE_ID", TypeCasting.ToInt32(oParams["SECURITY_EXCHANGE_ID"]));
                objList[1] = new SqlParameter("@MARKET_TYPE_ID", TypeCasting.ToInt32(oParams["MARKET_TYPE_ID"]));
                objList[2] = new SqlParameter("@ORDER_REF_NO", oParams["ORDER_REF_NO"]);
                objList[3] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt32(oParams["INVESTOR_ID"]));
                objList[4] = new SqlParameter("@COMPANY_ID", TypeCasting.ToInt32(oParams["COMPANY_ID"]));
                objList[5] = new SqlParameter("@TRANSACTION_MODE_ID", TypeCasting.ToInt32(oParams["TRANSACTION_MODE_ID"]));
                objList[6] = new SqlParameter("@QUANTITY", TypeCasting.ToInt64(oParams["QUANTITY"]));
                objList[7] = new SqlParameter("@UNIT_PRICE", TypeCasting.ToDecimal(oParams["UNIT_PRICE"]));
                objList[8] = new SqlParameter("@COMM_PERCENT", TypeCasting.ToDecimal(oParams["COMM_PERCENT"]));
                objList[9] = new SqlParameter("@COMM_AMOUNT", TypeCasting.ToDecimal(oParams["COMM_AMOUNT"]));
                objList[10] = new SqlParameter("@HOWLA_AMOUNT", TypeCasting.ToInt32(oParams["HOWLA_AMOUNT"]));
                objList[11] = new SqlParameter("@TRANSACTION_AMOUNT", TypeCasting.ToDecimal(oParams["TRANSACTION_AMOUNT"]));
                objList[12] = new SqlParameter("@AIT_AMOUNT", TypeCasting.ToDecimal(oParams["AIT_AMOUNT"]));
                objList[13] = new SqlParameter("@TRADER_ID", TypeCasting.ToInt32(oParams["TRADER_ID"]));
                objList[14] = new SqlParameter("@ISCOMPULSORY_SPOT", TypeCasting.ToDecimal(oParams["ISCOMPULSORY_SPOT"]));
                objList[15] = new SqlParameter("@HOWLA_REF_NO", oParams["HOWLA_REF_NO"]);
                objList[16] = new SqlParameter("@EXEC_TIME", oParams["EXEC_TIME"]);
                objList[17] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(oParams["TRANSACTION_DATE"]));
                objList[18] = new SqlParameter("@FILL_TYPE", oParams["FILL_TYPE"]);
                objList[19] = new SqlParameter("@FOREIGN_FLAG", oParams["FOREIGN_FLAG"]);
                objList[20] = new SqlParameter("@CATEGORY_ID", TypeCasting.ToInt32(oParams["CATEGORY_ID"]));
                objList[21] = new SqlParameter("@CREATED_BY", 99);

                DatabaseManager DatabaseManager = new DatabaseManager();
                CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, true, CommandType.Text);
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

        public CResult UpdateImportTradeManually(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"UPDATE dbo.TBL_TRANSACTION_INSTRUMENT_BUY_SELL_DAILY_TEMP
            SET
            SECURITY_EXCHANGE_ID=@SECURITY_EXCHANGE_ID
           ,MARKET_TYPE_ID=@MARKET_TYPE_ID
           ,ORDER_REF_NO=@ORDER_REF_NO
           ,INVESTOR_ID=@INVESTOR_ID
           ,COMPANY_ID=@COMPANY_ID
           ,TRANSACTION_MODE_ID=@TRANSACTION_MODE_ID              
           ,QUANTITY=@QUANTITY
           ,UNIT_PRICE=@UNIT_PRICE
           ,COMM_PERCENT=@COMM_PERCENT
           ,COMM_AMOUNT=@COMM_AMOUNT
           ,HOWLA_AMOUNT=@HOWLA_AMOUNT
           ,TRANSACTION_AMOUNT=@TRANSACTION_AMOUNT
           ,AIT_AMOUNT=@AIT_AMOUNT
           ,TRADER_ID=@TRADER_ID
           ,ISCOMPULSORY_SPOT=@ISCOMPULSORY_SPOT
           ,HOWLA_REF_NO=@HOWLA_REF_NO
           ,EXEC_TIME=@EXEC_TIME
           ,TRANSACTION_DATE=@TRANSACTION_DATE
           ,FILL_TYPE=@FILL_TYPE
           ,FOREIGN_FLAG=@FOREIGN_FLAG
           ,CATEGORY_ID=@CATEGORY_ID
           ,UPDATED_BY=@UPDATED_BY
           ,UPDATE_DT=GETDATE()
            WHERE
                ID=@ID
            ";
            try
            {
                SqlParameter[] objList = new SqlParameter[23];
                objList[0] = new SqlParameter("@SECURITY_EXCHANGE_ID", TypeCasting.ToInt32(oParams["SECURITY_EXCHANGE_ID"]));
                objList[1] = new SqlParameter("@MARKET_TYPE_ID", TypeCasting.ToInt32(oParams["MARKET_TYPE_ID"]));
                objList[2] = new SqlParameter("@ORDER_REF_NO", oParams["ORDER_REF_NO"]);
                objList[3] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt32(oParams["INVESTOR_ID"]));
                objList[4] = new SqlParameter("@COMPANY_ID", TypeCasting.ToInt32(oParams["COMPANY_ID"]));
                objList[5] = new SqlParameter("@TRANSACTION_MODE_ID", TypeCasting.ToInt32(oParams["TRANSACTION_MODE_ID"]));
                objList[6] = new SqlParameter("@QUANTITY", TypeCasting.ToInt64(oParams["QUANTITY"]));
                objList[7] = new SqlParameter("@UNIT_PRICE", TypeCasting.ToDecimal(oParams["UNIT_PRICE"]));
                objList[8] = new SqlParameter("@COMM_PERCENT", TypeCasting.ToDecimal(oParams["COMM_PERCENT"]));
                objList[9] = new SqlParameter("@COMM_AMOUNT", TypeCasting.ToDecimal(oParams["COMM_AMOUNT"]));
                objList[10] = new SqlParameter("@HOWLA_AMOUNT", TypeCasting.ToInt32(oParams["HOWLA_AMOUNT"]));
                objList[11] = new SqlParameter("@TRANSACTION_AMOUNT", TypeCasting.ToDecimal(oParams["TRANSACTION_AMOUNT"]));
                objList[12] = new SqlParameter("@AIT_AMOUNT", TypeCasting.ToDecimal(oParams["AIT_AMOUNT"]));
                objList[13] = new SqlParameter("@TRADER_ID", TypeCasting.ToInt32(oParams["TRADER_ID"]));
                objList[14] = new SqlParameter("@ISCOMPULSORY_SPOT", TypeCasting.ToDecimal(oParams["ISCOMPULSORY_SPOT"]));
                objList[15] = new SqlParameter("@HOWLA_REF_NO", oParams["HOWLA_REF_NO"]);
                objList[16] = new SqlParameter("@EXEC_TIME", oParams["EXEC_TIME"]);
                objList[17] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(oParams["TRANSACTION_DATE"]));
                objList[18] = new SqlParameter("@FILL_TYPE", oParams["FILL_TYPE"]);
                objList[19] = new SqlParameter("@FOREIGN_FLAG", oParams["FOREIGN_FLAG"]);
                objList[20] = new SqlParameter("@CATEGORY_ID", TypeCasting.ToInt32(oParams["CATEGORY_ID"]));
                objList[21] = new SqlParameter("@UPDATED_BY", 99);
                objList[22] = new SqlParameter("@ID", TypeCasting.ToInt32(oParams["ID"]));

                DatabaseManager DatabaseManager = new DatabaseManager();
                CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, true, CommandType.Text);
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

        public CResult DeleteImportTradeManually(String ID)
        {
            CResult CResult = new CResult();
            String Query = @"UPDATE TBL_TRANSACTION_INSTRUMENT_BUY_SELL_DAILY_TEMP
            SET
            IsDeleted=1
            ,Deleted_By=@Deleted_By 
            ,Delete_Dt=GETDATE()
            WHERE
            IS_APPROVED != 1
            AND ID=@ID
           ";

            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));
                objList[2] = new SqlParameter("@Deleted_By", 99);

                DatabaseManager DatabaseManager = new DatabaseManager();
                CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, true, CommandType.Text);
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

        public CResult GetImportTradeManually(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_ManuallyImportTradeTransaction";
            try
            {
                SqlParameter[] objList = new SqlParameter[3];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(oParams["ID"]));
                objList[1] = new SqlParameter("@Investor_ID", TypeCasting.ToInt64(oParams["Investor_ID"]));
                objList[2] = new SqlParameter("@SECURITY_EXCHANGE_ID", TypeCasting.ToInt32(oParams["SECURITY_EXCHANGE_ID"]));

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
