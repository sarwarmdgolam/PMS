using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLCorporateActionManagement
    {


        public CResult InsertCorporateAction(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_CDBL_CORPORATE_ACTION_RECEIVABLE_MANUALLY";
            try
            {
                SqlParameter[] objList = new SqlParameter[11];
                objList[0] = new SqlParameter("@COMPANY_ID", TypeCasting.ToInt32(oParams["COMPANY_ID"]));
                objList[1] = new SqlParameter("@CORPORATE_ACTION_TYPE_ID", TypeCasting.ToInt32(oParams["CORPORATE_ACTION_TYPE_ID"]));
                objList[2] = new SqlParameter("@RECORD_DATE", TypeCasting.ToDateTime(oParams["RECORD_DATE"]));
                objList[3] = new SqlParameter("@EFFECTIVE_DATE", TypeCasting.ToDateTime(oParams["EFFECTIVE_DATE"]));
                objList[4] = new SqlParameter("@PAR_RATIO", TypeCasting.ToDecimal(oParams["PAR_RATIO"]));
                objList[5] = new SqlParameter("@BEN_RATIO", TypeCasting.ToDecimal(oParams["BEN_RATIO"]));
                objList[6] = new SqlParameter("@DEBIT_CREDIT", oParams["DEBIT_CREDIT"]);
                objList[7] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(oParams["TRANSACTION_DATE"]));
                objList[8] = new SqlParameter("@REMARKS", oParams["REMARKS"]);
                objList[9] = new SqlParameter("@CREATED_BY", "99");
                objList[10] = new SqlParameter("@PUF_RATIO", TypeCasting.ToDecimal(oParams["PUF_RATIO"]));

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

        public CResult InsertCorporateActionFromHoldings(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_CDBL_CORPORATE_ACTION_RECEIVABLE_FROM_HOLDINGS";
            try
            {
                SqlParameter[] objList = new SqlParameter[4];
                objList[0] = new SqlParameter("@COMPANY_ID", TypeCasting.ToInt32(oParams["COMPANY_ID"]));
                objList[1] = new SqlParameter("@CORPORATE_ACTION_TYPE_ID", TypeCasting.ToInt32(oParams["CORPORATE_ACTION_TYPE_ID"]));
                objList[2] = new SqlParameter("@RECORD_DATE", TypeCasting.ToDateTime(oParams["RECORD_DATE"]));
                objList[3] = new SqlParameter("@CREATED_BY", "99");

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

        public CResult DeleteCorporateActionFromHoldings(String ID)
        {
            CResult CResult = new CResult();
            String Query = @"SP_DELETE_CDBL_CORPORATE_ACTION_RECEIVABLE_MANUALLY";
            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt32(ID));
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

        public CResult GetUnapproveCorporateActionInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_CDBL_UNAPPROVED_CORPORATE_ACTION_RECEIVABLE_MANUALLY";

            try
            {
                SqlParameter[] objList = new SqlParameter[4];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(oParams["ID"]));
                objList[1] = new SqlParameter("@COMPANY_ID", TypeCasting.ToInt64(oParams["COMPANY_ID"]));
                objList[2] = new SqlParameter("@CORPORATE_ACTION_TYPE_ID", TypeCasting.ToInt16(oParams["CORPORATE_ACTION_TYPE_ID"]));
                objList[3] = new SqlParameter("@RECORD_DATE", TypeCasting.ToDateTime(oParams["RECORD_DATE"]));

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

        public CResult GetApproveCorporateActionInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_CDBL_APPROVED_CORPORATE_ACTION_RECEIVABLE_MANUALLY";

            try
            {
                SqlParameter[] objList = new SqlParameter[4];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(oParams["ID"]));
                objList[1] = new SqlParameter("@COMPANY_ID", TypeCasting.ToInt64(oParams["COMPANY_ID"]));
                objList[2] = new SqlParameter("@CORPORATE_ACTION_TYPE_ID", TypeCasting.ToInt16(oParams["CORPORATE_ACTION_TYPE_ID"]));
                objList[3] = new SqlParameter("@RECORD_DATE", TypeCasting.ToDateTime(oParams["RECORD_DATE"]));

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

        public CResult ApproveCorporateActionInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_APPROVE_CDBL_CORPORATE_ACTION_RECEIVABLE_MANUALLY";

            try
            {
                SqlParameter[] objList = new SqlParameter[5];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(oParams["ID"]));
                objList[1] = new SqlParameter("@COMPANY_ID", TypeCasting.ToInt64(oParams["COMPANY_ID"]));
                objList[2] = new SqlParameter("@CORPORATE_ACTION_TYPE_ID", TypeCasting.ToInt16(oParams["CORPORATE_ACTION_TYPE_ID"]));
                objList[3] = new SqlParameter("@RECORD_DATE", TypeCasting.ToDateTime(oParams["RECORD_DATE"]));
                objList[4] = new SqlParameter("@CREATED_BY", "99");

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

        public CResult GetCorporateActionInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_CDBL_CORPORATE_ACTION_RECEIVABLE_MANUALLY";

            try
            {
                SqlParameter[] objList = new SqlParameter[3];
                objList[0] = new SqlParameter("@COMPANY_ID", TypeCasting.ToInt64(oParams["COMPANY_ID"]));
                objList[1] = new SqlParameter("@CORPORATE_ACTION_TYPE_ID", TypeCasting.ToInt16(oParams["CORPORATE_ACTION_TYPE_ID"]));
                objList[2] = new SqlParameter("@RECORD_DATE", TypeCasting.ToDateTime(oParams["RECORD_DATE"]));

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

        public CResult GetCorporateActionFromHoldings(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_CDBL_CORPORATE_ACTION_RECEIVABLE_FROM_HOLDINGS";

            try
            {
                SqlParameter[] objList = new SqlParameter[3];
                objList[0] = new SqlParameter("@COMPANY_ID", TypeCasting.ToInt64(oParams["COMPANY_ID"]));
                objList[1] = new SqlParameter("@CORPORATE_ACTION_TYPE_ID", TypeCasting.ToInt16(oParams["CORPORATE_ACTION_TYPE_ID"]));
                objList[2] = new SqlParameter("@RECORD_DATE", TypeCasting.ToDateTime(oParams["RECORD_DATE"]));

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

        public CResult ProcessCorporateActionReceiveInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_PROCESS_CDBL_CORPORATE_ACTION_RECEIVE_MANUALLY";

            try
            {
                SqlParameter[] objList = new SqlParameter[5];
                objList[0] = new SqlParameter("@COMPANY_ID", TypeCasting.ToInt64(oParams["COMPANY_ID"]));
                objList[1] = new SqlParameter("@CORPORATE_ACTION_TYPE_ID", TypeCasting.ToInt16(oParams["CORPORATE_ACTION_TYPE_ID"]));
                objList[2] = new SqlParameter("@RECORD_DATE", TypeCasting.ToDateTime(oParams["RECORD_DATE"]));
                objList[3] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(oParams["TRANSACTION_DATE"]));
                objList[4] = new SqlParameter("@CREATED_BY", "99");

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
