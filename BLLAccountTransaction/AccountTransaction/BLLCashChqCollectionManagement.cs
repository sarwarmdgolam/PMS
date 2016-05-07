using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLCashChqCollectionManagement
    {
        public CResult GetUnApprovedCashChqDepositInfo(String Transaction_Date)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_CASH_CHQ_UNAPPROVED_COLLECTION";
            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(Transaction_Date));
                objList[1] = new SqlParameter("@CREATE_BY", "99");

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

        public CResult ApprovedCashChqDepositInfo(List<String> oParamList)
        {
            CResult CResult = new CResult();
            StringBuilder AffectedRows = new StringBuilder();
            foreach (String ID in oParamList)
            {
                String Query = @"SP_APPROVE_CASH_CHQ_COLLECTION";
                try
                {
                    SqlParameter[] objList = new SqlParameter[2];
                    objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));
                    objList[1] = new SqlParameter("@CREATE_BY", 99);
                    DatabaseManager DatabaseManager = new DatabaseManager();
                    CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, true, CommandType.StoredProcedure);
                    if (!CResult.IsSuccess)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    CResult.IsSuccess = false;
                    CResult.Message = ex.Message;
                }
            }
            return CResult;
        }

        public CResult GetUnClearedCashChqDepositInfo(String Transaction_Date)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_CASH_CHQ_UNCLEARED_COLLECTION";
            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(Transaction_Date));
                objList[1] = new SqlParameter("@CREATE_BY", "99");

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


        public CResult ClearCashChqDepositInfo(List<String> ChequeIDList)
        {
            CResult CResult = new CResult();
            StringBuilder AffectedRows = new StringBuilder();
            foreach (String ID in ChequeIDList)
            {
                String Query = @"SP_PROCESS_CLEAR_CASH_CHQ_COLLECTION";
                try
                {
                    SqlParameter[] objList = new SqlParameter[2];
                    objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));
                    objList[1] = new SqlParameter("@CREATE_BY", 99);
                    DatabaseManager DatabaseManager = new DatabaseManager();
                    CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, true, CommandType.StoredProcedure);
                    if (!CResult.IsSuccess)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    CResult.IsSuccess = false;
                    CResult.Message = ex.Message;
                }
            }
            return CResult;
        }

        public CResult DishonourCashChqDepositInfo(List<String> ChequeIDList)
        {
            CResult CResult = new CResult();
            StringBuilder AffectedRows = new StringBuilder();
            foreach (String ID in ChequeIDList)
            {
                String Query = @"SP_PROCESS_DISHONOUR_CASH_CHQ_COLLECTION";
                try
                {
                    SqlParameter[] objList = new SqlParameter[2];
                    objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));
                    objList[1] = new SqlParameter("@CREATE_BY", 99);
                    DatabaseManager DatabaseManager = new DatabaseManager();
                    CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, true, CommandType.StoredProcedure);
                    if (!CResult.IsSuccess)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    CResult.IsSuccess = false;
                    CResult.Message = ex.Message;
                }
            }
            return CResult;
        }

    }
}
