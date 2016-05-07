using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLCashChqPaymentManagement
    {
        public CResult GetUnApprovedCashChqPaymentInfo(String Transaction_Date)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_CASH_CHQ_UNAPPROVED_PAYMENT";
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

        public CResult ApprovedCashChqPaymentInfo(List<String> oParamList)
        {
            CResult CResult = new CResult();
            int AffectedRows = 0;
            foreach (String ID in oParamList)
            {
                String Query = @"SP_APPROVE_CASH_CHQ_PAYMENT";
                try
                {
                    SqlParameter[] objList = new SqlParameter[2];
                    objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));
                    objList[1] = new SqlParameter("@CREATE_BY", 99);
                    DatabaseManager DatabaseManager = new DatabaseManager();
                    CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, true, CommandType.StoredProcedure);
                    if (CResult.AffectedRows>0)
                    {
                        AffectedRows = AffectedRows + CResult.AffectedRows;
                    }
                }
                catch (Exception ex)
                {
                    CResult.IsSuccess = false;
                    CResult.Message = ex.Message;
                }
            }
            CResult.AffectedRows = AffectedRows;
            return CResult;
        }
    }
}
