using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Common;

namespace BLL
{
    public class BLLCompanyInformation
    {
        public CResult InsertCompanyInfo(Dictionary<String, String> oParams )
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_COMPANY_INFO";
            try
            {
                SqlParameter[] objList = new SqlParameter[17];
                objList[0] = new SqlParameter("@COMPANY_NAME", oParams["COMPANY_NAME"]);
                objList[1] = new SqlParameter("@ISIN", oParams["ISIN"]);
                objList[2] = new SqlParameter("@SECURITYCODE", oParams["SECURITYCODE"]);
                objList[3] = new SqlParameter("@CLOSING_PRICE", TypeCasting.ToDecimal(oParams["CLOSING_PRICE"]));
                objList[4] = new SqlParameter("@CATEGORY_ID", TypeCasting.ToInt32(oParams["CATEGORY_ID"]));
                objList[5] = new SqlParameter("@INSTRUMENT_SECTOR_ID", TypeCasting.ToInt32(oParams["INSTRUMENT_SECTOR_ID"]));
                objList[6] = new SqlParameter("@AUTHORIZE_CAPITAL", TypeCasting.ToDecimal(oParams["AUTHORIZE_CAPITAL"]));
                objList[7] = new SqlParameter("@PAID_UP_CAPITAL", TypeCasting.ToDecimal(oParams["PAID_UP_CAPITAL"]));
                objList[8] = new SqlParameter("@RESERVE_CAPITAL", TypeCasting.ToDecimal(oParams["RESERVE_CAPITAL"]));
                objList[9] = new SqlParameter("@INST_TYPE_ID", TypeCasting.ToInt32(oParams["INST_TYPE_ID"]));
                objList[10] = new SqlParameter("@FACE_VALUE", TypeCasting.ToDecimal(oParams["FACE_VALUE"]));
                objList[11] = new SqlParameter("@IS_MARGINABLE", TypeCasting.ToBoolean(oParams["IS_MARGINABLE"]));
                objList[12] = new SqlParameter("@EPS", TypeCasting.ToDecimal(oParams["EPS"]));
                objList[13] = new SqlParameter("@NAV", TypeCasting.ToDecimal(oParams["NAV"]));
                objList[14] = new SqlParameter("@IS_OTC", TypeCasting.ToBoolean(oParams["IS_OTC"]));
                objList[15] = new SqlParameter("@IS_ACTIVE", TypeCasting.ToBoolean(oParams["IS_ACTIVE"]));
                objList[16] = new SqlParameter("@CREATED_BY", 99);

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

        public CResult UpdateCompanyInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_UPDATE_COMPANY_INFO";
            try
            {
                SqlParameter[] objList = new SqlParameter[18];
                objList[0] = new SqlParameter("@COMPANY_NAME", oParams["COMPANY_NAME"]);
                objList[1] = new SqlParameter("@ISIN", oParams["ISIN"]);
                objList[2] = new SqlParameter("@SECURITYCODE", oParams["SECURITYCODE"]);
                objList[3] = new SqlParameter("@CLOSING_PRICE", TypeCasting.ToDecimal(oParams["CLOSING_PRICE"]));
                objList[4] = new SqlParameter("@CATEGORY_ID", TypeCasting.ToInt32(oParams["CATEGORY_ID"]));
                objList[5] = new SqlParameter("@INSTRUMENT_SECTOR_ID", TypeCasting.ToInt32(oParams["INSTRUMENT_SECTOR_ID"]));
                objList[6] = new SqlParameter("@AUTHORIZE_CAPITAL", TypeCasting.ToDecimal(oParams["AUTHORIZE_CAPITAL"]));
                objList[7] = new SqlParameter("@PAID_UP_CAPITAL", TypeCasting.ToDecimal(oParams["PAID_UP_CAPITAL"]));
                objList[8] = new SqlParameter("@RESERVE_CAPITAL", TypeCasting.ToDecimal(oParams["RESERVE_CAPITAL"]));
                objList[9] = new SqlParameter("@INST_TYPE_ID", TypeCasting.ToInt32(oParams["INST_TYPE_ID"]));
                objList[10] = new SqlParameter("@FACE_VALUE", TypeCasting.ToDecimal(oParams["FACE_VALUE"]));
                objList[11] = new SqlParameter("@IS_MARGINABLE", TypeCasting.ToBoolean(oParams["IS_MARGINABLE"]));
                objList[12] = new SqlParameter("@EPS", TypeCasting.ToDecimal(oParams["EPS"]));
                objList[13] = new SqlParameter("@NAV", TypeCasting.ToDecimal(oParams["NAV"]));
                objList[14] = new SqlParameter("@IS_OTC", TypeCasting.ToBoolean(oParams["IS_OTC"]));
                objList[15] = new SqlParameter("@IS_ACTIVE", TypeCasting.ToBoolean(oParams["IS_ACTIVE"]));
                objList[16] = new SqlParameter("@UPDATED_BY", 99);
                objList[17] = new SqlParameter("@ID", TypeCasting.ToInt32(oParams["ID"]));

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


        public CResult DeleteCompanyInfo(String strID)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_DELETE_SETTINGS_COMPANY_INFO]";
            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@DELETED_BY", 99);
                objList[1] = new SqlParameter("@ID", TypeCasting.ToInt32(strID));

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

        public CResult GetCompanyInfo(String ID, String COMPANY_NAME)
        {
            CResult CResult = new CResult();
            String Query = "SP_GET_COMPANY_INFORMATION";

            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt32(ID));
                objList[1] = new SqlParameter("@COMPANY_NAME", COMPANY_NAME);

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
