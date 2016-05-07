using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data.SqlClient;
using System.Data;
using DAL;

namespace BLL
{
    public class BLLTradingAccountType
    {
        public CResult InsertTradingAccountType(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_TRADING_ACCOUNT_TYPE";
            try
            {
                SqlParameter[] objList = new SqlParameter[9];
                objList[0] = new SqlParameter("@ACC_TYPE_S_NAME", CCommon.DictionaryValue(oParams, "ACC_TYPE_S_NAME"));
                objList[1] = new SqlParameter("@ACC_TYPE_F_NAME", CCommon.DictionaryValue(oParams, "ACC_TYPE_F_NAME"));
                objList[2] = new SqlParameter("@LOAN_RATIO", CCommon.DictionaryValue(oParams, "LOAN_RATIO"));
                objList[3] = new SqlParameter("@MAX_ALLOCATED_LOAN", CCommon.DictionaryValue(oParams, "MAX_ALLOCATED_LOAN"));
                objList[4] = new SqlParameter("@WITHDRAW_LIMIT_BASIS_ID", CCommon.DictionaryValue(oParams, "WITHDRAW_LIMIT_BASIS_ID"));
                objList[5] = new SqlParameter("@OPENING_DEPOSIT_AMOUNT", CCommon.DictionaryValue(oParams, "OPENING_DEPOSIT_AMOUNT"));
                objList[6] = new SqlParameter("@MINIMUM_LEDGER_BAL_AMOUNT", CCommon.DictionaryValue(oParams, "MINIMUM_LEDGER_BAL_AMOUNT"));
                objList[7] = new SqlParameter("@TRIGGER_CALL", CCommon.DictionaryValue(oParams, "TRIGGER_CALL"));
                objList[8] = new SqlParameter("@CREATED_BY", "99");

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

        public CResult UpdateTradingAccountType(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_UPDATE_TRADING_ACCOUNT_TYPE";
            try
            {
                SqlParameter[] objList = new SqlParameter[10];
                objList[0] = new SqlParameter("@ACC_TYPE_S_NAME", CCommon.DictionaryValue(oParams, "ACC_TYPE_S_NAME"));
                objList[1] = new SqlParameter("@ACC_TYPE_F_NAME", CCommon.DictionaryValue(oParams, "ACC_TYPE_F_NAME"));
                objList[2] = new SqlParameter("@LOAN_RATIO", CCommon.DictionaryValue(oParams, "LOAN_RATIO"));
                objList[3] = new SqlParameter("@MAX_ALLOCATED_LOAN", CCommon.DictionaryValue(oParams, "MAX_ALLOCATED_LOAN"));
                objList[4] = new SqlParameter("@WITHDRAW_LIMIT_BASIS_ID", CCommon.DictionaryValue(oParams, "WITHDRAW_LIMIT_BASIS_ID"));
                objList[5] = new SqlParameter("@OPENING_DEPOSIT_AMOUNT", CCommon.DictionaryValue(oParams, "OPENING_DEPOSIT_AMOUNT"));
                objList[6] = new SqlParameter("@MINIMUM_LEDGER_BAL_AMOUNT", CCommon.DictionaryValue(oParams, "MINIMUM_LEDGER_BAL_AMOUNT"));
                objList[7] = new SqlParameter("@TRIGGER_CALL", CCommon.DictionaryValue(oParams, "TRIGGER_CALL"));
                objList[8] = new SqlParameter("@ID", CCommon.DictionaryValue(oParams, "ID"));
                objList[9] = new SqlParameter("@CREATED_BY", "99");

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

        public CResult DeleteTradingAccountType(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_DELETE_TRADING_ACCOUNT_TYPE";
            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@ID", CCommon.DictionaryValue(oParams, "ID"));
                objList[1] = new SqlParameter("@CREATED_BY", "99");

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
        
        public CResult GetTradingAccountType(String ID)
        {
            CResult CResult = new CResult();
            String Query = @"SP_Get_TRADING_ACCOUNT_TYPE";
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
