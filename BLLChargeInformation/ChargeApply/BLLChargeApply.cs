using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLChargeApply
    {
        public CResult InsertChargeImposeOnInvestor(Dictionary<String, String> oParam)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_INSERT_TRANSACTION_INVESTOR_APPLIED_CHARGE]";
            try
            {
                SqlParameter[] objList = new SqlParameter[8];
                objList[0] = new SqlParameter("@TRANSACTION_DATE",TypeCasting.ToDateTime(oParam["TRANSACTION_DATE"]));
                objList[1] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt32(oParam["INVESTOR_ID"]));
                objList[2] = new SqlParameter("@CHARGE_ID", TypeCasting.ToInt32(oParam["CHARGE_ID"]));
                objList[3] = new SqlParameter("@TRANSACTION_MODE",oParam["TRANSACTION_MODE"]);
                objList[4] = new SqlParameter("@AMOUNT", TypeCasting.ToDecimal(oParam["AMOUNT"]));
                objList[5] = new SqlParameter("@DOCREFNUMBER", oParam["DOCREFNUMBER"]);
                objList[6] = new SqlParameter("@REMARKS",oParam["REMARKS"] );
                objList[7] = new SqlParameter("@Created_By", 99);

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

        public CResult GetUnapprovedInvestorAppliedChargeInfo(Dictionary<String, String> oParam)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_GET_UNAPPROVED_INVESTOR_APPLIED_CHARGE_INFO]";

            try
            {
                SqlParameter[] objList = new SqlParameter[5];
                objList[0] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt32(oParam["INVESTOR_ID"]));
                objList[1] = new SqlParameter("@CHARGE_ID", TypeCasting.ToInt32(oParam["CHARGE_ID"]));
                objList[2] = new SqlParameter("@TRANSACTION_MODE", oParam["TRANSACTION_MODE"]);
                objList[3] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(oParam["TRANSACTION_DATE"]));
                objList[4] = new SqlParameter("@Created_By", 99);

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

        public CResult GetInvestorAppliedChargeInfo(Dictionary<String, String> oParam)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_GET_INVESTOR_APPLIED_CHARGE_INFO]";

            try
            {
                SqlParameter[] objList = new SqlParameter[7];
                objList[0] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt32(oParam["INVESTOR_ID"]));
                objList[1] = new SqlParameter("@CHARGE_ID", TypeCasting.ToInt32(oParam["CHARGE_ID"]));
                objList[2] = new SqlParameter("@TRANSACTION_MODE", oParam["TRANSACTION_MODE"]);
                objList[3] = new SqlParameter("@TRANSACTION_DATE_FROM", TypeCasting.ToDateTime(oParam["TRANSACTION_DATE_FROM"]));
                objList[4] = new SqlParameter("@TRANSACTION_DATE_TO", TypeCasting.ToDateTime(oParam["TRANSACTION_DATE_TO"]));
                objList[5] = new SqlParameter("@ID", TypeCasting.ToInt32(oParam["ID"]));
                objList[6] = new SqlParameter("@Created_By", 99);

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

        public CResult ApproveChargeImposeOnInvestor(Dictionary<String, String> oParam,List<String> oParamList)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_APPROVE_INVESTOR_APPLIED_CHARGE]";
            try
            {
                SqlParameter[] objList = new SqlParameter[7];
                if (TypeCasting.ToBoolean(oParam["IS_ALLITEMSELECTED"]))
                {
                    objList = new SqlParameter[7];
                    objList[0] = new SqlParameter("@ID", 0);
                    objList[1] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt32(oParam["INVESTOR_ID"]));
                    objList[2] = new SqlParameter("@CHARGE_ID", TypeCasting.ToInt32(oParam["CHARGE_ID"]));
                    objList[3] = new SqlParameter("@TRANSACTION_MODE", oParam["TRANSACTION_MODE"]);
                    objList[4] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(oParam["TRANSACTION_DATE"]));
                    objList[5] = new SqlParameter("@IS_ALLITEMSELECTED", TypeCasting.ToBoolean(oParam["IS_ALLITEMSELECTED"]));
                    objList[6] = new SqlParameter("@CREATED_BY", 99);
                }
                else
                {
                    foreach (String ID in oParamList)
                    {
                        objList = new SqlParameter[7];
                        objList[0] = new SqlParameter("@ID", TypeCasting.ToInt32(ID));
                        objList[1] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt32(oParam["INVESTOR_ID"]));
                        objList[2] = new SqlParameter("@CHARGE_ID", TypeCasting.ToInt32(oParam["CHARGE_ID"]));
                        objList[3] = new SqlParameter("@TRANSACTION_MODE", oParam["TRANSACTION_MODE"]);
                        objList[4] = new SqlParameter("@TRANSACTION_DATE", TypeCasting.ToDateTime(oParam["TRANSACTION_DATE"]));
                        objList[5] = new SqlParameter("@IS_ALLITEMSELECTED", TypeCasting.ToBoolean(oParam["IS_ALLITEMSELECTED"]));
                        objList[6] = new SqlParameter("@CREATED_BY", 99);
                    }
                }

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
