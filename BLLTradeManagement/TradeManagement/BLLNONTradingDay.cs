using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;
using DAL;
using Common;

namespace BLL
{
    public class BLLNONTradingDay
    {
        public CResult InsertNonTradingDay(String SECURITY_EXCHANGE_ID, String TRANSACTION_DATE_FROM, String TRANSACTION_DATE_TO, String NON_TRADING_DAY_TYPE_ID, String DETAILS, String NON_TRADING_DAY)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_NON_TRADING_DAY";
            try
            {
                SqlParameter[] objList = new SqlParameter[7];
                objList[0] = new SqlParameter("@TRANSACTION_DATE_FROM", TypeCasting.ToDateTime(TRANSACTION_DATE_FROM));
                objList[1] = new SqlParameter("@TRANSACTION_DATE_TO", TypeCasting.ToDateTime(TRANSACTION_DATE_TO));
                objList[2] = new SqlParameter("@NON_TRADING_DAY_TYPE_ID", TypeCasting.ToInt64(NON_TRADING_DAY_TYPE_ID));
                objList[3] = new SqlParameter("@NON_TRADING_DAY", NON_TRADING_DAY);
                objList[4] = new SqlParameter("@DETAILS", DETAILS);
                objList[5] = new SqlParameter("@CREATED_BY", 99);
                objList[6] = new SqlParameter("@SECURITY_EXCHANGE_ID", TypeCasting.ToInt16(SECURITY_EXCHANGE_ID));

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

        public CResult GetNonTradingDay(String ID, String SECURITY_EXCHANGE_ID, String NON_TRADING_DAY_TYPE_ID, String TRANSACTION_DATE_FROM, String TRANSACTION_DATE_TO)
        {
            CResult CResult = new CResult();
            String Query = @"SP_Get_Non_Trading_Day";

            try
            {
                SqlParameter[] objList = new SqlParameter[5];
                objList[0] = new SqlParameter("@SECURITY_EXCHANGE_ID", TypeCasting.ToInt32(SECURITY_EXCHANGE_ID));
                objList[1] = new SqlParameter("@NON_TRADING_DAY_TYPE_ID", TypeCasting.ToInt32(NON_TRADING_DAY_TYPE_ID));
                objList[2] = new SqlParameter("@TRANSACTION_DATE_FROM", TypeCasting.ToDateTime(TRANSACTION_DATE_FROM));
                objList[3] = new SqlParameter("@TRANSACTION_DATE_TO", TypeCasting.ToDateTime(TRANSACTION_DATE_TO));
                objList[4] = new SqlParameter("@ID", TypeCasting.ToInt32(ID));

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

        public CResult UpdateNonTradingDay(String SECURITY_EXCHANGE_ID, String TRANSACTION_DATE, String ID, String NON_TRADING_DAY_TYPE_ID, String DETAILS, String NON_TRADING_DAY)
        {
            CResult CResult = new CResult();
            String Query = @"SP_UPDATE_NON_TRADING_DAY";
            try
            {
                SqlParameter[] objList = new SqlParameter[7];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt32(ID));
                objList[1] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(TRANSACTION_DATE));
                objList[2] = new SqlParameter("@NON_TRADING_DAY_TYPE_ID", TypeCasting.ToInt64(NON_TRADING_DAY_TYPE_ID));
                objList[3] = new SqlParameter("@NON_TRADING_DAY", NON_TRADING_DAY);
                objList[4] = new SqlParameter("@DETAILS", DETAILS);
                objList[5] = new SqlParameter("@CREATED_BY", 99);
                objList[6] = new SqlParameter("@SECURITY_EXCHANGE_ID", TypeCasting.ToInt16(SECURITY_EXCHANGE_ID));
               
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

        public CResult DeleteNonTradingDay(String ID)
        {
            CResult CResult = new CResult();
            String Query = @"SP_DELETE_NON_TRADING_DAY";
            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt32(ID));
                objList[1] = new SqlParameter("@CREATED_BY", 99);

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
