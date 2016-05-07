using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Model;
using System.Data.SqlClient;
using System.Data;
using Common;

namespace BLL
{
    public class BLLSettlementSchedule
    {

        public CResult InsertSettlementSchedule
              ( String SECURITY_EXCHANGE_ID
               ,String MARKET_TYPE_ID
               ,String CATEGORY_ID
               ,String BUY_SETTLEMENT
               ,String BUY_CLEAR
               ,String SALEABLE_DAYS
               ,String SELL_SETTLEMENT
               ,String SELL_CLEAR
               ,String BUYABLE_DAYS
               ,String IS_ACTIVE
             )
        {
            CResult CResult = new CResult();
            String Query = @"INSERT INTO dbo.TBL_SETTLEMENT_SCHEDULE
                           (SECURITY_EXCHANGE_ID
                           ,MARKET_TYPE_ID
                           ,CATEGORY_ID
                           ,BUY_SETTLEMENT
                           ,BUY_CLEAR
                           ,SALEABLE_DAYS
                           ,SELL_SETTLEMENT
                           ,SELL_CLEAR
                           ,BUYABLE_DAYS
                           ,IS_ACTIVE
                           ,CREATED_BY
                           ,CREATE_DT
                           ,ISDELETED
                           )
                     VALUES
                           (
                           @SECURITY_EXCHANGE_ID
                           ,@MARKET_TYPE_ID
                           ,@CATEGORY_ID
                           ,@BUY_SETTLEMENT
                           ,@BUY_CLEAR
                           ,@SALEABLE_DAYS
                           ,@SELL_SETTLEMENT
                           ,@SELL_CLEAR
                           ,@BUYABLE_DAYS
                           ,@IS_ACTIVE
                           ,@CREATED_BY
                           ,GETDATE()
                           ,0
                           )
                         ";
            try
            {
                SqlParameter[] objList = new SqlParameter[10];
                objList[0] = new SqlParameter("@SECURITY_EXCHANGE_ID", TypeCasting.ToInt64(SECURITY_EXCHANGE_ID));
                objList[1] = new SqlParameter("@MARKET_TYPE_ID", TypeCasting.ToInt64(MARKET_TYPE_ID));
                objList[2] = new SqlParameter("@CATEGORY_ID", TypeCasting.ToInt64(CATEGORY_ID));
                objList[3] = new SqlParameter("@BUY_SETTLEMENT", TypeCasting.ToDecimal(BUY_SETTLEMENT));
                objList[4] = new SqlParameter("@BUY_CLEAR", TypeCasting.ToDecimal(BUY_CLEAR));
                objList[5] = new SqlParameter("@SALEABLE_DAYS", TypeCasting.ToDecimal(SALEABLE_DAYS));
                objList[6] = new SqlParameter("@SELL_SETTLEMENT", TypeCasting.ToDecimal(SELL_SETTLEMENT));
                objList[7] = new SqlParameter("@SELL_CLEAR", TypeCasting.ToDecimal(SELL_CLEAR));
                objList[8] = new SqlParameter("@BUYABLE_DAYS", TypeCasting.ToDecimal(BUYABLE_DAYS));
                objList[9] = new SqlParameter("@IS_ACTIVE", TypeCasting.ToBoolean(IS_ACTIVE));
                objList[8] = new SqlParameter("@CREATED_BY", 99);

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


        public CResult UpdateSettlementSchedule
        (String ID
         ,String SECURITY_EXCHANGE_ID
         , String MARKET_TYPE_ID
         , String CATEGORY_ID
         , String BUY_SETTLEMENT
         , String BUY_CLEAR
         , String SALEABLE_DAYS
         , String SELL_SETTLEMENT
         , String SELL_CLEAR
         , String BUYABLE_DAYS
         , String IS_ACTIVE
       )
        {
            CResult CResult = new CResult();
            String Query = @"UPDATE dbo.TBL_SETTLEMENT_SCHEDULE
                           SECURITY_EXCHANGE_ID=@SECURITY_EXCHANGE_ID
                           ,MARKET_TYPE_ID=@MARKET_TYPE_ID
                           ,CATEGORY_ID=@CATEGORY_ID
                           ,BUY_SETTLEMENT=@BUY_SETTLEMENT
                           ,BUY_CLEAR=@BUY_CLEAR
                           ,SALEABLE_DAYS=@SALEABLE_DAYS
                           ,SELL_SETTLEMENT=@SELL_SETTLEMENT
                           ,SELL_CLEAR=@SELL_CLEAR
                           ,BUYABLE_DAYS=@BUYABLE_DAYS
                           ,IS_ACTIVE=@IS_ACTIVE
                           ,UPDATED_BY=@UPDATED_BY
                           ,UPDATE_DT=GETDATE()
                         ";
            try
            {
                SqlParameter[] objList = new SqlParameter[12];
                objList[0] = new SqlParameter("@SECURITY_EXCHANGE_ID", TypeCasting.ToInt64(SECURITY_EXCHANGE_ID));
                objList[1] = new SqlParameter("@MARKET_TYPE_ID", TypeCasting.ToInt64(MARKET_TYPE_ID));
                objList[2] = new SqlParameter("@CATEGORY_ID", TypeCasting.ToInt64(CATEGORY_ID));
                objList[3] = new SqlParameter("@BUY_SETTLEMENT", TypeCasting.ToDecimal(BUY_SETTLEMENT));
                objList[4] = new SqlParameter("@BUY_CLEAR", TypeCasting.ToDecimal(BUY_CLEAR));
                objList[5] = new SqlParameter("@SALEABLE_DAYS", TypeCasting.ToDecimal(SALEABLE_DAYS));
                objList[6] = new SqlParameter("@SELL_SETTLEMENT", TypeCasting.ToDecimal(SELL_SETTLEMENT));
                objList[7] = new SqlParameter("@SELL_CLEAR", TypeCasting.ToDecimal(SELL_CLEAR));
                objList[8] = new SqlParameter("@BUYABLE_DAYS", TypeCasting.ToDecimal(BUYABLE_DAYS));
                objList[9] = new SqlParameter("@IS_ACTIVE", TypeCasting.ToBoolean(IS_ACTIVE));
                objList[10] = new SqlParameter("@UPDATED_BY", 99);
                objList[11] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));

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


        public CResult DeleteSettlementSchedule(String ID)
        {
            CResult CResult = new CResult();
            String Query = @"UPDATE TBL_SETTLEMENT_SCHEDULE
            SET
            IsDeleted=1
            ,Deleted_By=@Deleted_By 
            ,Delete_Dt=GETDATE()
            WHERE
            ID=@ID
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

        public CResult GetSettlementSchedule(String ID)
        {
            CResult CResult = new CResult();
            String Query = @"SELECT * FROM TBL_SETTLEMENT_SCHEDULE 
            WHERE 
            (ID = @ID OR @ID=0) 
            AND ISDELETED=0
            ORDER BY VOUCHER_NO";

            try
            {
                SqlParameter[] objList = new SqlParameter[1];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));

                DatabaseManager DatabaseManager = new DatabaseManager();
                CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, false, CommandType.Text);
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
