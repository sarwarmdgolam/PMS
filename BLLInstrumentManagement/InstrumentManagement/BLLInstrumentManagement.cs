using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLInstrumentManagement
    {
        public CResult GETINSERTINSTTRANSACTIONINFO(String ID, String Investor_ID, String From_Date, String To_Date)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_MANUALLY_INST_RCV_DEL";
            try
            {
                SqlParameter[] objList = new SqlParameter[4];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));
                objList[1] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt64(Investor_ID));
                objList[2] = new SqlParameter("@FROM_DATE", TypeCasting.ToDateTime(From_Date));
                objList[3] = new SqlParameter("@TO_DATE", TypeCasting.ToDateTime(To_Date));

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

        public CResult INSERTINSTTRANSACTIONMASTER(Dictionary<String, String> oParam)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_INST_TRANSACTION_MASTER";
            try
            {
                SqlParameter[] objList = new SqlParameter[8];
                objList[0] = new SqlParameter("@VOUCHER_NO", TypeCasting.ToInt64(oParam["VOUCHER_NO"]));
                objList[1] = new SqlParameter("@VOUCHER_REF_NO", oParam["VOUCHER_REF_NO"]);
                objList[2] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt64(oParam["INVESTOR_ID"]));
                objList[3] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(oParam["TRANSACTION_DATE"]));
                objList[4] = new SqlParameter("@TRANSACTION_MODE_ID", TypeCasting.ToInt16(oParam["TRANSACTION_MODE_ID"]));
                objList[5] = new SqlParameter("@Remarks", oParam["REMARKS"]);
                objList[6] = new SqlParameter("@CREATED_BY", 99);

                SqlParameter ID = new SqlParameter();
                ID.Direction = ParameterDirection.Output;
                ID.SqlDbType = SqlDbType.BigInt;
                ID.ParameterName = "ID";
                ID.Value = "0";
                objList[7] = ID;
                DatabaseManager DatabaseManager = new DatabaseManager();
                CResult= DatabaseManager.ExecuteSQLQuery(Query, objList, true, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

        public CResult INSERTINSTTRANSACTIONDETAILS(String MASTER_ID)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_INST_TRANSACTION_DETAILS";
            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@MASTER_ID", TypeCasting.ToInt64(MASTER_ID));
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

        public CResult INSERTINSTTRANSACTIONDETAILSTEMP(Dictionary<String, String> oParam)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_INST_TRANSACTION_DETAILS_TEMP_INFO";
            try
            {
                SqlParameter[] objList = new SqlParameter[7];
                objList[0] = new SqlParameter("@MASTER_ID", TypeCasting.ToInt64(oParam["MASTER_ID"]));
                objList[1] = new SqlParameter("@COMPANY_ID", TypeCasting.ToInt64(oParam["COMPANY_ID"]));
                objList[2] = new SqlParameter("@REF_TRANSACTION_MODE_ID", TypeCasting.ToInt16(oParam["REF_TRANSACTION_MODE_ID"]));
                objList[3] = new SqlParameter("@FOLIO_NO", oParam["FOLIO_NO"]);
                objList[4] = new SqlParameter("@QUANTITY", TypeCasting.ToInt64(oParam["QUANTITY"]));
                objList[5] = new SqlParameter("@TOTAL_AMOUNT", TypeCasting.ToDecimal(oParam["TOTAL_AMOUNT"]));
                objList[6] = new SqlParameter("@CREATED_BY", 99);

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
