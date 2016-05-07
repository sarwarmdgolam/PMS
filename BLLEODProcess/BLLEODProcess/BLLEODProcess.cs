using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
   public class BLLEODProcess
   {
       public CResult GetPossibleDayStartDate()
       {
           CResult CResult = new CResult();
           String Query = @"SP_GET_POSSIBLE_BOD_DATE";
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

        public CResult ProcessDayStart(String TRANSACTION_DATE)
        {
            CResult CResult = new CResult();
            String Query = @"SP_PROCESS_DAY_START";
            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(TRANSACTION_DATE));
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

        public CResult ProcessDayEnd(String TRANSACTION_DATE)
        {
            CResult CResult = new CResult();
            String Query = @"SP_PROCESS_DAY_END";
            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(TRANSACTION_DATE));
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
