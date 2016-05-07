using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLInvestorNominee
    {
        public CResult InsertInvestorNomineeInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_INVESTOR_NOMINEE_INFO";

            try
            {
                SqlParameter[] objList = new SqlParameter[9];
                objList[0] = new SqlParameter("@INVESTOR_ID",TypeCasting.ToInt64( oParams["INVESTOR_ID"]));
                objList[1] = new SqlParameter("@NOMINEE_NAME", oParams["NOMINEE_NAME"]);
                objList[2] = new SqlParameter("@NOMINEE_ADDRESS", oParams["NOMINEE_ADDRESS"]);
                objList[3] = new SqlParameter("@PHONE_NO", oParams["PHONE_NO"]);
                objList[4] = new SqlParameter("@RELATION_WITH", oParams["RELATION_WITH"]);
                objList[5] = new SqlParameter("@SHARE_PERCENTAGE", oParams["SHARE_PERCENTAGE"]);
                objList[6] = new SqlParameter("@NOMINEE_PHOTO", oParams["NOMINEE_PHOTO"]);
                objList[7] = new SqlParameter("@NOMINEE_SIGNATURE", oParams["NOMINEE_SIGNATURE"]);
                objList[8] = new SqlParameter("@CREATED_BY", 9);

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

        public CResult GetInvestorNomineeInfo(String ID, String Investor_ID)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_INVESTOR_NOMINEE_INFO";
            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));
                objList[1] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt64(Investor_ID));

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
