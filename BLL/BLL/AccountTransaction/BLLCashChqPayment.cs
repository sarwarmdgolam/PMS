using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Model;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace BLL
{
    public class BLLCashChqPayment
    {

        public  CResult GetDropDownControlData(String BRANCH_ID)
        {
            CResult CResult = new CResult();
            DatabaseManager DatabaseManager = new DatabaseManager();
            String Query = @"SELECT 0 Value,'--Select--' Text UNION SELECT ID,BANK_ACCOUNT_NO 'Text' FROM TBL_ACCOUNTS_GL_MAPPING WHERE ISDELETED=0 AND (@BRANCH_ID=0 OR BRANCH_ID=@BRANCH_ID) ORDER BY 'Text' ";
            SqlParameter[] objList = new SqlParameter[1];
            objList[0] = new SqlParameter("@BRANCH_ID", TypeCasting.ToInt16(BRANCH_ID));
            try
            {
                CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, false, CommandType.Text);
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

       

        public CResult InsertCashChqPaymentInfo (Dictionary<String, String> oParam)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_CASHCHQPAYMENTINFO";

            try
            {
                SqlParameter[] objList = new SqlParameter[18];
                objList[0] = new SqlParameter("@Voucher_no", TypeCasting.ToInt64(oParam["VOUCHER_NO"]));
                objList[1] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt64(oParam["INVESTOR_ID"]));
                objList[2] = new SqlParameter("@TRANSACTION_MODE_ID", TypeCasting.ToInt64(oParam["TRANSACTION_MODE_ID"]));
                objList[3] = new SqlParameter("@CHEQUE_NO", oParam["CHEQUE_NO"]);
                objList[4] = new SqlParameter("@CHEQUE_DT", TypeCasting.ToDateTime(oParam["CHEQUE_DT"]));
                objList[5] = new SqlParameter("@BANK_ID", TypeCasting.ToInt64(oParam["BANK_ID"]));
                objList[6] = new SqlParameter("@BANK_BRANCH_ID", TypeCasting.ToInt16(oParam["BANK_BRANCH_ID"]));
                objList[7] = new SqlParameter("@PAYMENT_GL_ACC", oParam["PAYMENT_GL_ACC"]);
                objList[8] = new SqlParameter("@AMOUNT", TypeCasting.ToDecimal(oParam["AMOUNT"]));
                objList[9] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(oParam["TRANSACTION_DATE"]));
                objList[10] = new SqlParameter("@PAYMENT_REF_NO", oParam["PAYMENT_REF_NO"]);
                objList[11] = new SqlParameter("@BRANCH_ID", TypeCasting.ToInt64(oParam["BRANCH_ID"]));
                objList[12] = new SqlParameter("@ACCOUNT_NO", oParam["ACCOUNT_NO"]);
                objList[13] = new SqlParameter("@REMARKS", oParam["REMARKS"]);
                objList[14] = new SqlParameter("@CREATED_BY", 99);
                objList[15] = new SqlParameter("@ISFULLBALANCE", TypeCasting.ToBoolean(oParam["ISFULLBALANCE"]));
                objList[16] = new SqlParameter("@VALUE_DT", TypeCasting.ToDateTime(oParam["VALUE_DT"]));
                objList[17] = new SqlParameter("@DOCREFNUMBER", oParam["DOCREFNUMBER"]);

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


        public CResult UpdateCashChqPaymentInfo(Dictionary<String, String> oParam)
        {
            CResult CResult = new CResult();
            String Query = @"SP_UPDATE_CASHCHQPAYMENTINFO";

            try
            {
                SqlParameter[] objList = new SqlParameter[19];
                objList[0] = new SqlParameter("@Voucher_no", TypeCasting.ToInt64(oParam["VOUCHER_NO"]));
                objList[1] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt64(oParam["INVESTOR_ID"]));
                objList[2] = new SqlParameter("@TRANSACTION_MODE_ID", TypeCasting.ToInt64(oParam["TRANSACTION_MODE_ID"]));
                objList[3] = new SqlParameter("@CHEQUE_NO", oParam["CHEQUE_NO"]);
                objList[4] = new SqlParameter("@CHEQUE_DT", TypeCasting.ToDateTime(oParam["CHEQUE_DT"]));
                objList[5] = new SqlParameter("@BANK_ID", TypeCasting.ToInt64(oParam["BANK_ID"]));
                objList[6] = new SqlParameter("@BANK_BRANCH_ID", TypeCasting.ToInt16(oParam["BANK_BRANCH_ID"]));
                objList[7] = new SqlParameter("@PAYMENT_GL_ACC", oParam["PAYMENT_GL_ACC"]);
                objList[8] = new SqlParameter("@AMOUNT", TypeCasting.ToDecimal(oParam["AMOUNT"]));
                objList[9] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(oParam["TRANSACTION_DATE"]));
                objList[10] = new SqlParameter("@PAYMENT_REF_NO", oParam["PAYMENT_REF_NO"]);
                objList[11] = new SqlParameter("@BRANCH_ID", TypeCasting.ToInt64(oParam["BRANCH_ID"]));
                objList[12] = new SqlParameter("@ACCOUNT_NO", oParam["ACCOUNT_NO"]);
                objList[13] = new SqlParameter("@REMARKS", oParam["REMARKS"]);
                objList[14] = new SqlParameter("@UPDATED_BY", 99);
                objList[15] = new SqlParameter("@ID", TypeCasting.ToInt32(oParam["ID"]));
                objList[16] = new SqlParameter("@ISFULLBALANCE", TypeCasting.ToBoolean(oParam["ISFULLBALANCE"]));
                objList[17] = new SqlParameter("@VALUE_DT", TypeCasting.ToDateTime(oParam["VALUE_DT"]));
                objList[18] = new SqlParameter("@DOCREFNUMBER", oParam["DOCREFNUMBER"]);

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


        public CResult DeleteCashChqPaymentInfo(String ID)
        {
            CResult CResult = new CResult();
            String Query = @"UPDATE TBL_CASH_CHQ_PAYMENT
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


        public CResult GetCashChqPaymentInfo(String ID, String INVESTOR_ID, String VOUCHER_NO, String From_Dt, String To_Dt)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_CASHCHQPAYMENTINFO";

            try
            {
                SqlParameter[] objList = new SqlParameter[5];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));
                objList[1] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt64(INVESTOR_ID));
                objList[2] = new SqlParameter("@VOUCHER_NO", TypeCasting.ToInt64(VOUCHER_NO));
                objList[3] = new SqlParameter("@FROM_DATE", TypeCasting.ToDateTime(From_Dt));
                objList[4] = new SqlParameter("@TO_DATE", TypeCasting.ToDateTime(To_Dt));

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
