using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DAL;
using System.Data;
using Common;

namespace BLL
{
    public class BLLCashChqCollection
    {

        public CResult InsertCashChqInfo(Dictionary<String, String> oParam)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_CASHCHQCOLLECTIONINFO";
            try
            {
                SqlParameter[] objList = new SqlParameter[14];
                objList[0] = new SqlParameter("@VOUCHER_NO", TypeCasting.ToInt64(oParam["VOUCHER_NO"]));
                objList[1] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(oParam["TRANSACTION_DATE"]));
                objList[2] = new SqlParameter("@INVESTOR_ID", oParam["INVESTOR_ID"]);
                objList[3] = new SqlParameter("@Transaction_mode_ID", TypeCasting.ToInt16(oParam["TRANSACTION_MODE_ID"]));
                objList[4] = new SqlParameter("@Cheque_No", TypeCasting.ToInt64(oParam["CHEQUE_NO"]));
                objList[5] = new SqlParameter("@CHEQUE_DATE", TypeCasting.ToDateTime(oParam["CHEQUE_DATE"]));
                objList[6] = new SqlParameter("@Amount", TypeCasting.ToDecimal(oParam["AMOUNT"]));
                objList[7] = new SqlParameter("@BANK_ID", TypeCasting.ToInt16(oParam["BANK_ID"]));
                objList[8] = new SqlParameter("@BANKBRANCH_ID", TypeCasting.ToInt16(oParam["BANKBRANCH_ID"]));
                objList[9] = new SqlParameter("@VALUE_DATE", TypeCasting.ToDateTime(oParam["VALUE_DATE"]));
                objList[10] = new SqlParameter("@Branch_ID", TypeCasting.ToInt16(oParam["BRANCH_ID"]));
                objList[11] = new SqlParameter("@Remarks", oParam["REMARKS"]);
                objList[12] = new SqlParameter("@DOCREFNUMBER", oParam["DOCREFNUMBER"]);
                objList[13] = new SqlParameter("@Created_By", 99);
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

        public CResult UpdateCashChqInfo(Dictionary<String, String> oParam)
        {
            CResult CResult = new CResult();
            String Query = @"SP_UPDATE_CASHCHQCOLLECTIONINFO";

            try
            {
                SqlParameter[] objList = new SqlParameter[15];
                objList[0] = new SqlParameter("@Voucher_no", TypeCasting.ToInt64(oParam["VOUCHER_NO"]));
                objList[1] = new SqlParameter("@Transaction_Date", TypeCasting.ToDateTime(oParam["TRANSACTION_DATE"]));
                objList[2] = new SqlParameter("@INVESTOR_ID", oParam["INVESTOR_ID"]);
                objList[3] = new SqlParameter("@Transaction_mode_ID", TypeCasting.ToInt16(oParam["TRANSACTION_MODE_ID"]));
                objList[4] = new SqlParameter("@Cheque_No", TypeCasting.ToInt64(oParam["CHEQUE_NO"]));
                objList[5] = new SqlParameter("@CHEQUE_DATE", TypeCasting.ToDateTime(oParam["CHEQUE_DATE"]));
                objList[6] = new SqlParameter("@Amount", TypeCasting.ToDecimal(oParam["AMOUNT"]));
                objList[7] = new SqlParameter("@Branch_ID", TypeCasting.ToInt16(oParam["BRANCH_ID"]));
                objList[8] = new SqlParameter("@Remarks", oParam["REMARKS"]);
                objList[9] = new SqlParameter("@BANK_ID", TypeCasting.ToInt16(oParam["BANK_ID"]));
                objList[10] = new SqlParameter("@BANKBRANCH_ID", TypeCasting.ToInt16(oParam["BANKBRANCH_ID"]));
                objList[11] = new SqlParameter("@VALUE_DATE", TypeCasting.ToDateTime(oParam["VALUE_DATE"]));
                objList[12] = new SqlParameter("@UPDATED_BY", 99);
                objList[13] = new SqlParameter("@ID", TypeCasting.ToInt64(oParam["ID"]));
                objList[14] = new SqlParameter("@DOCREFNUMBER", oParam["DOCREFNUMBER"]);

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

        public CResult DeleteCashChqInfo(String ID)
        {
            CResult CResult = new CResult();
            String Query = @"SP_DELETE_TRANSACTION_CASH_CHQ_COLLECTION";

            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@ID",TypeCasting.ToInt64( ID));
                objList[1] = new SqlParameter("@Deleted_By", 99);

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

        public CResult GetCashChqCollectionInfo(String ID, String INVESTOR_ID, String Voucher_no, String From_Date, String To_Date)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_CASHCHQCOLLECTIONINFO";

            try
            {
                SqlParameter[] objList = new SqlParameter[5];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));
                objList[1] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt64(INVESTOR_ID));
                objList[2] = new SqlParameter("@Voucher_no", TypeCasting.ToInt64(Voucher_no));
                objList[3] = new SqlParameter("@FROM_DATE", TypeCasting.ToDateTime(From_Date));
                objList[4] = new SqlParameter("@TO_DATE", TypeCasting.ToDateTime(To_Date));

                DatabaseManager DatabaseManager = new DatabaseManager();
                CResult= DatabaseManager.ExecuteSQLQuery(Query, objList, false, CommandType.StoredProcedure);
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
