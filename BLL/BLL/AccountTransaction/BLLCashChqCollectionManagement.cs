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
        public CResult GetUnApprovedCashChqInfo(String Transaction_Date)
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

    }
}
