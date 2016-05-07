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
                SqlParameter[] objList = new SqlParameter[18];
                objList[0] = new SqlParameter("@COMPANY_NAME", oParams["COMPANY_NAME"]);
                objList[1] = new SqlParameter("@ISIN", oParams["ISIN"]);
                objList[2] = new SqlParameter("@SECURITYCODE", oParams["SECURITYCODE"]);
                objList[3] = new SqlParameter("@CLOSING_PRICE", TypeCasting.ToDecimal(oParams["CLOSING_PRICE"]));
                objList[4] = new SqlParameter("@CATEGORY_ID", TypeCasting.ToInt32(oParams["CATEGORY_ID"]));
                objList[5] = new SqlParameter("@MAJ_SEC_ID", TypeCasting.ToInt32(oParams["MAJ_SEC_ID"]));
                objList[6] = new SqlParameter("@MIN_SEC_ID", TypeCasting.ToInt32(oParams["MIN_SEC_ID"]));
                objList[7] = new SqlParameter("@AUTHORIZE_CAPITAL", TypeCasting.ToDecimal(oParams["AUTHORIZE_CAPITAL"]));
                objList[8] = new SqlParameter("@PAID_UP_CAPITAL", TypeCasting.ToDecimal(oParams["PAID_UP_CAPITAL"]));
                objList[9] = new SqlParameter("@RESERVE_CAPITAL", TypeCasting.ToDecimal(oParams["RESERVE_CAPITAL"]));
                objList[10] = new SqlParameter("@INST_TYPE_ID", TypeCasting.ToInt32(oParams["INST_TYPE_ID"]));
                objList[11] = new SqlParameter("@FACE_VALUE", TypeCasting.ToDecimal(oParams["FACE_VALUE"]));
                objList[12] = new SqlParameter("@IS_MARGINABLE", TypeCasting.ToBoolean(oParams["IS_MARGINABLE"]));
                objList[13] = new SqlParameter("@EPS", TypeCasting.ToDecimal(oParams["EPS"]));
                objList[14] = new SqlParameter("@NAV", TypeCasting.ToDecimal(oParams["NAV"]));
                objList[15] = new SqlParameter("@IS_OTC", TypeCasting.ToBoolean(oParams["IS_OTC"]));
                objList[16] = new SqlParameter("@IS_ACTIVE", TypeCasting.ToBoolean(oParams["IS_ACTIVE"]));
                objList[17] = new SqlParameter("@CREATED_BY", 99);

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
                SqlParameter[] objList = new SqlParameter[19];
                objList[0] = new SqlParameter("@COMPANY_NAME", oParams["COMPANY_NAME"]);
                objList[1] = new SqlParameter("@ISIN", oParams["ISIN"]);
                objList[2] = new SqlParameter("@SECURITYCODE", oParams["SECURITYCODE"]);
                objList[3] = new SqlParameter("@CLOSING_PRICE", TypeCasting.ToDecimal(oParams["CLOSING_PRICE"]));
                objList[4] = new SqlParameter("@CATEGORY_ID", TypeCasting.ToInt32(oParams["CATEGORY_ID"]));
                objList[5] = new SqlParameter("@MAJ_SEC_ID", TypeCasting.ToInt32(oParams["MAJ_SEC_ID"]));
                objList[6] = new SqlParameter("@MIN_SEC_ID", TypeCasting.ToInt32(oParams["MIN_SEC_ID"]));
                objList[7] = new SqlParameter("@AUTHORIZE_CAPITAL", TypeCasting.ToDecimal(oParams["AUTHORIZE_CAPITAL"]));
                objList[8] = new SqlParameter("@PAID_UP_CAPITAL", TypeCasting.ToDecimal(oParams["PAID_UP_CAPITAL"]));
                objList[9] = new SqlParameter("@RESERVE_CAPITAL", TypeCasting.ToDecimal(oParams["RESERVE_CAPITAL"]));
                objList[10] = new SqlParameter("@INST_TYPE_ID", TypeCasting.ToInt32(oParams["INST_TYPE_ID"]));
                objList[11] = new SqlParameter("@FACE_VALUE", TypeCasting.ToDecimal(oParams["FACE_VALUE"]));
                objList[12] = new SqlParameter("@IS_MARGINABLE", TypeCasting.ToBoolean(oParams["IS_MARGINABLE"]));
                objList[13] = new SqlParameter("@EPS", TypeCasting.ToDecimal(oParams["EPS"]));
                objList[14] = new SqlParameter("@NAV", TypeCasting.ToDecimal(oParams["NAV"]));
                objList[15] = new SqlParameter("@IS_OTC", TypeCasting.ToBoolean(oParams["IS_OTC"]));
                objList[16] = new SqlParameter("@IS_ACTIVE", TypeCasting.ToBoolean(oParams["IS_ACTIVE"]));
                objList[17] = new SqlParameter("@UPDATED_BY", 99);
                objList[18] = new SqlParameter("@ID", TypeCasting.ToInt32(oParams["ID"]));

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

        public CResult GetCompanyInfo(String ID, String COMPANY_NAME)
        {
            CResult CResult = new CResult();
            String Query = @"
                            SELECT 
                            CI.*
                            ,MA.SEC_F_NAME MAJ_SEC_F_NAME
                            ,MI.SEC_F_NAME MINOR_SEC_F_NAME
                            FROM 
                            TBL_COMPANY_INFO CI 
                            LEFT JOIN TBL_INSTRUMENT_SECTOR MA ON MA.ID=CI.MAJ_SEC_ID AND MA.INST_SECTOR_TYPE='major'
                            LEFT JOIN TBL_INSTRUMENT_SECTOR MI ON MI.ID=CI.MIN_SEC_ID AND MA.INST_SECTOR_TYPE='minor'
                            WHERE (CI.ID = @ID OR @ID=0)  
                            AND (@COMPANY_NAME = null or @COMPANY_NAME = 'NA' or CI.COMPANY_NAME LIKE '%'+@COMPANY_NAME+'%')
                            AND CI.ISDELETED=0
                            ORDER BY CI.COMPANY_NAME
                            ";

            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt32(ID));
                objList[1] = new SqlParameter("@COMPANY_NAME", COMPANY_NAME);

                DatabaseManager DatabaseManager = new DatabaseManager();
                CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, false, CommandType.Text);
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
