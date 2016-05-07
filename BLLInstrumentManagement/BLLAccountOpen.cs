
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DAL;
using Model;
using System.Collections;
using Common;

namespace BLL
{
    public class BLLAccountOpen
    {
        public CResult InsertAccountInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_INVESTOR_PERSONAL_INFO";

            try
            {
                SqlParameter[] objList = new SqlParameter[59];
                objList[0] = new SqlParameter("@INVESTOR_CODE", CCommon.DictionaryValue(oParams, "INVESTOR_CODE"));
                objList[1] = new SqlParameter("@BO_CODE", CCommon.DictionaryValue(oParams, "BO_CODE"));
                objList[2] = new SqlParameter("@FIRST_JOIN_HOLDER_NAME", CCommon.DictionaryValue(oParams, "FIRST_JOIN_HOLDER_NAME"));
                objList[3] = new SqlParameter("@SEC_JOIN_HOLDER_NAME", CCommon.DictionaryValue(oParams, "SEC_JOIN_HOLDER_NAME"));
                objList[4] = new SqlParameter("@FATHER_NAME", CCommon.DictionaryValue(oParams, "FATHER_NAME"));
                objList[5] = new SqlParameter("@MOTHER_NAME", CCommon.DictionaryValue(oParams, "MOTHER_NAME"));
                objList[6] = new SqlParameter("@BRANCH_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "BRANCH_ID")));
                objList[7] = new SqlParameter("@OPERATION_TYPE_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "OPERATION_TYPE_ID")));
                objList[8] = new SqlParameter("@INVESTOR_TYPE_ID", TypeCasting.ToInt64(CCommon.DictionaryValue(oParams, "INVESTOR_TYPE_ID")));
                objList[9] = new SqlParameter("@ACC_TYPE_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "ACC_TYPE_ID")));
                objList[10] = new SqlParameter("@PARENT_ID", TypeCasting.ToInt64(CCommon.DictionaryValue(oParams, "PARENT_ID")));
                objList[11] = new SqlParameter("@SUB_ACCOUNT_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "SUB_ACCOUNT_ID")));
                objList[12] = new SqlParameter("@OPENING_DT", TypeCasting.ToDateTime(CCommon.DictionaryValue(oParams, "OPENING_DT")));
                objList[13] = new SqlParameter("@PRESENT_ADDRESS", CCommon.DictionaryValue(oParams, "PRESENT_ADDRESS"));
                objList[14] = new SqlParameter("@PARMANENT_ADDRESS", CCommon.DictionaryValue(oParams, "PARMANENT_ADDRESS"));
                objList[15] = new SqlParameter("@PHONE", CCommon.DictionaryValue(oParams, "PHONE"));
                objList[16] = new SqlParameter("@MOBILE", CCommon.DictionaryValue(oParams, "MOBILE"));
                objList[17] = new SqlParameter("@FAX", CCommon.DictionaryValue(oParams, "FAX"));
                objList[18] = new SqlParameter("@EMAIL", CCommon.DictionaryValue(oParams, "EMAIL"));
                objList[19] = new SqlParameter("@GENDER", CCommon.DictionaryValue(oParams, "GENDER"));
                objList[20] = new SqlParameter("@VOTER_ID_NO", CCommon.DictionaryValue(oParams, "VOTER_ID_NO"));
                objList[21] = new SqlParameter("@INTRODUCER_CODE", CCommon.DictionaryValue(oParams, "INTRODUCER_CODE"));
                objList[22] = new SqlParameter("@INTRODUCER_NAME", CCommon.DictionaryValue(oParams, "INTRODUCER_NAME"));
                objList[23] = new SqlParameter("@INTRODUCER_CONTACT_NO", CCommon.DictionaryValue(oParams, "INTRODUCER_CONTACT_NO"));
                objList[24] = new SqlParameter("@SPECIAL_INSTRUCTION", CCommon.DictionaryValue(oParams, "SPECIAL_INSTRUCTION"));
                objList[25] = new SqlParameter("@OCCUPATION", CCommon.DictionaryValue(oParams, "OCCUPATION"));
                objList[26] = new SqlParameter("@DISTRICT_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "DISTRICT_ID")));
                objList[27] = new SqlParameter("@COUNTRY_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "COUNTRY_ID")));
                objList[28] = new SqlParameter("@PASSPORT_NO", CCommon.DictionaryValue(oParams, "PASSPORT_NO"));
                objList[29] = new SqlParameter("@TIN_NO", CCommon.DictionaryValue(oParams, "TIN_NO"));
                objList[30] = new SqlParameter("@BIRTH_DT", TypeCasting.DateToString(CCommon.DictionaryValue(oParams, "BIRTH_DT")));
                objList[31] = new SqlParameter("@ACCOUNT_STATUS_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "ACCOUNT_STATUS_ID")));
                objList[32] = new SqlParameter("@BANK_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "BANK_ID")));
                objList[33] = new SqlParameter("@BANK_BRANCH_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "BANK_BRANCH_ID")));
                objList[34] = new SqlParameter("@BANK_ACC_TP_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "BANK_ACC_TP_ID")));
                objList[35] = new SqlParameter("@BANK_ACC_NO", CCommon.DictionaryValue(oParams, "BANK_ACC_NO"));
                objList[36] = new SqlParameter("@TRADER_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "TRADER_ID")));
                objList[37] = new SqlParameter("@INTEREST_CAL_ON", CCommon.DictionaryValue(oParams, "INTEREST_CAL_ON"));
                objList[38] = new SqlParameter("@IS_PAYIN", TypeCasting.ToBoolean(CCommon.DictionaryValue(oParams, "IS_PAYIN")));
                objList[39] = new SqlParameter("@IS_PAYOUT", TypeCasting.ToBoolean(CCommon.DictionaryValue(oParams, "IS_PAYOUT")));
                objList[40] = new SqlParameter("@LOAN_RATIO", TypeCasting.ToDecimal(CCommon.DictionaryValue(oParams, "LOAN_RATIO")));
                objList[41] = new SqlParameter("@CREATED_BY", 99);

                SqlParameter ID = new SqlParameter();
                ID.Direction = ParameterDirection.Output;
                ID.SqlDbType = SqlDbType.BigInt;
                ID.ParameterName = "ID";
                ID.Value = TypeCasting.ToInt64(oParams["ID"]);
                objList[42] = ID;

                //objList[42] = new SqlParameter("@ID", TypeCasting.ToInt64(oParams["ID"]));

                objList[43] = new SqlParameter("@SMS_SERVICE_ST", TypeCasting.ToBoolean(CCommon.DictionaryValue(oParams, "SMS_SERVICE_ST")));
                objList[44] = new SqlParameter("@EMAIL_SERVICE_ST", TypeCasting.ToBoolean(CCommon.DictionaryValue(oParams, "EMAIL_SERVICE_ST")));
                objList[45] = new SqlParameter("@BUSINESSNATURE_ID", TypeCasting.ToInt32(CCommon.DictionaryValue(oParams, "BUSINESSNATURE_ID")));
                objList[46] = new SqlParameter("@TRADELICENSENO", CCommon.DictionaryValue(oParams, "TRADELICENSENO"));
                objList[47] = new SqlParameter("@INCORPORATIONDATE", TypeCasting.ToDateTime(CCommon.DictionaryValue(oParams, "INCORPORATIONDATE")));
                objList[48] = new SqlParameter("@REGISTRATIONNO", CCommon.DictionaryValue(oParams, "REGISTRATIONNO"));
                objList[49] = new SqlParameter("@CORPORATENAME", CCommon.DictionaryValue(oParams, "CORPORATENAME"));
                objList[50] = new SqlParameter("@CorporatedOfficeAddress", CCommon.DictionaryValue(oParams, "CorporatedOfficeAddress"));
                objList[51] = new SqlParameter("@CORPORATEMDNAME", CCommon.DictionaryValue(oParams, "CORPORATEMDNAME"));
                objList[52] = new SqlParameter("@EXISTINGBOACCDP", CCommon.DictionaryValue(oParams, "EXISTINGBOACCDP"));
                objList[53] = new SqlParameter("@EXISTINGBOBROKER", CCommon.DictionaryValue(oParams, "EXISTINGBOBROKER"));

                objList[54] = new SqlParameter("@FJH_PHOTO_PATH", CCommon.DictionaryValue(oParams, "FJH_PHOTO_PATH"));
                objList[55] = new SqlParameter("@SJH_PHOTO_PATH", CCommon.DictionaryValue(oParams, "SJH_PHOTO_PATH"));
                objList[56] = new SqlParameter("@FJH_SIGNATURE_PATH", CCommon.DictionaryValue(oParams, "FJH_SIGNATURE_PATH"));
                objList[57] = new SqlParameter("@SJH_SIGNATURE_PATH", CCommon.DictionaryValue(oParams, "SJH_SIGNATURE_PATH"));

                objList[58] = new SqlParameter("@ROUTING_NO", CCommon.DictionaryValue(oParams, "ROUTING_NO"));

                

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

        public CResult UpdateAccountInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_UPDATE_INVESTOR_PERSONAL_INFO";

            try
            {
                SqlParameter[] objList = new SqlParameter[59];
                objList[0] = new SqlParameter("@INVESTOR_CODE", CCommon.DictionaryValue(oParams, "INVESTOR_CODE"));
                objList[1] = new SqlParameter("@BO_CODE", CCommon.DictionaryValue(oParams, "BO_CODE"));
                objList[2] = new SqlParameter("@FIRST_JOIN_HOLDER_NAME", CCommon.DictionaryValue(oParams, "FIRST_JOIN_HOLDER_NAME"));
                objList[3] = new SqlParameter("@SEC_JOIN_HOLDER_NAME", CCommon.DictionaryValue(oParams, "SEC_JOIN_HOLDER_NAME"));
                objList[4] = new SqlParameter("@FATHER_NAME", CCommon.DictionaryValue(oParams, "FATHER_NAME"));
                objList[5] = new SqlParameter("@MOTHER_NAME", CCommon.DictionaryValue(oParams, "MOTHER_NAME"));
                objList[6] = new SqlParameter("@BRANCH_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "BRANCH_ID")));
                objList[7] = new SqlParameter("@OPERATION_TYPE_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "OPERATION_TYPE_ID")));
                objList[8] = new SqlParameter("@INVESTOR_TYPE_ID", TypeCasting.ToInt64(CCommon.DictionaryValue(oParams, "INVESTOR_TYPE_ID")));
                objList[9] = new SqlParameter("@ACC_TYPE_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "ACC_TYPE_ID")));
                objList[10] = new SqlParameter("@PARENT_ID", TypeCasting.ToInt64(CCommon.DictionaryValue(oParams, "PARENT_ID")));
                objList[11] = new SqlParameter("@SUB_ACCOUNT_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "SUB_ACCOUNT_ID")));
                objList[12] = new SqlParameter("@OPENING_DT", TypeCasting.ToDateTime(CCommon.DictionaryValue(oParams, "OPENING_DT")));
                objList[13] = new SqlParameter("@PRESENT_ADDRESS", CCommon.DictionaryValue(oParams, "PRESENT_ADDRESS"));
                objList[14] = new SqlParameter("@PARMANENT_ADDRESS", CCommon.DictionaryValue(oParams, "PARMANENT_ADDRESS"));
                objList[15] = new SqlParameter("@PHONE", CCommon.DictionaryValue(oParams, "PHONE"));
                objList[16] = new SqlParameter("@MOBILE", CCommon.DictionaryValue(oParams, "MOBILE"));
                objList[17] = new SqlParameter("@FAX", CCommon.DictionaryValue(oParams, "FAX"));
                objList[18] = new SqlParameter("@EMAIL", CCommon.DictionaryValue(oParams, "EMAIL"));
                objList[19] = new SqlParameter("@GENDER", CCommon.DictionaryValue(oParams, "GENDER"));
                objList[20] = new SqlParameter("@VOTER_ID_NO", CCommon.DictionaryValue(oParams, "VOTER_ID_NO"));
                objList[21] = new SqlParameter("@INTRODUCER_CODE", CCommon.DictionaryValue(oParams, "INTRODUCER_CODE"));
                objList[22] = new SqlParameter("@INTRODUCER_NAME", CCommon.DictionaryValue(oParams, "INTRODUCER_NAME"));
                objList[23] = new SqlParameter("@INTRODUCER_CONTACT_NO", CCommon.DictionaryValue(oParams, "INTRODUCER_CONTACT_NO"));
                objList[24] = new SqlParameter("@SPECIAL_INSTRUCTION", CCommon.DictionaryValue(oParams, "SPECIAL_INSTRUCTION"));
                objList[25] = new SqlParameter("@OCCUPATION", CCommon.DictionaryValue(oParams, "OCCUPATION"));
                objList[26] = new SqlParameter("@DISTRICT_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "DISTRICT_ID")));
                objList[27] = new SqlParameter("@COUNTRY_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "COUNTRY_ID")));
                objList[28] = new SqlParameter("@PASSPORT_NO", CCommon.DictionaryValue(oParams, "PASSPORT_NO"));
                objList[29] = new SqlParameter("@TIN_NO", CCommon.DictionaryValue(oParams, "TIN_NO"));
                objList[30] = new SqlParameter("@BIRTH_DT", TypeCasting.DateToString(CCommon.DictionaryValue(oParams, "BIRTH_DT")));
                objList[31] = new SqlParameter("@ACCOUNT_STATUS_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "ACCOUNT_STATUS_ID")));
                objList[32] = new SqlParameter("@BANK_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "BANK_ID")));
                objList[33] = new SqlParameter("@BANK_BRANCH_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "BANK_BRANCH_ID")));
                objList[34] = new SqlParameter("@BANK_ACC_TP_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "BANK_ACC_TP_ID")));
                objList[35] = new SqlParameter("@BANK_ACC_NO", CCommon.DictionaryValue(oParams, "BANK_ACC_NO"));
                objList[36] = new SqlParameter("@TRADER_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "TRADER_ID")));
                objList[37] = new SqlParameter("@INTEREST_CAL_ON", CCommon.DictionaryValue(oParams, "INTEREST_CAL_ON"));
                objList[38] = new SqlParameter("@IS_PAYIN", TypeCasting.ToBoolean(CCommon.DictionaryValue(oParams, "IS_PAYIN")));
                objList[39] = new SqlParameter("@IS_PAYOUT", TypeCasting.ToBoolean(CCommon.DictionaryValue(oParams, "IS_PAYOUT")));
                objList[40] = new SqlParameter("@LOAN_RATIO", TypeCasting.ToDecimal(CCommon.DictionaryValue(oParams, "LOAN_RATIO")));
                objList[41] = new SqlParameter("@UPDATED_BY", 99);
                objList[42] = new SqlParameter("@ID", TypeCasting.ToInt64(oParams["ID"]));
                objList[43] = new SqlParameter("@SMS_SERVICE_ST", TypeCasting.ToBoolean(CCommon.DictionaryValue(oParams, "SMS_SERVICE_ST")));
                objList[44] = new SqlParameter("@EMAIL_SERVICE_ST", TypeCasting.ToBoolean(CCommon.DictionaryValue(oParams, "EMAIL_SERVICE_ST")));
                objList[45] = new SqlParameter("@BUSINESSNATURE_ID", TypeCasting.ToInt32(CCommon.DictionaryValue(oParams, "BUSINESSNATURE_ID")));
                objList[46] = new SqlParameter("@TRADELICENSENO", CCommon.DictionaryValue(oParams, "TRADELICENSENO"));
                objList[47] = new SqlParameter("@INCORPORATIONDATE", TypeCasting.ToDateTime(CCommon.DictionaryValue(oParams, "INCORPORATIONDATE")));
                objList[48] = new SqlParameter("@REGISTRATIONNO", CCommon.DictionaryValue(oParams, "REGISTRATIONNO"));
                objList[49] = new SqlParameter("@CORPORATENAME", CCommon.DictionaryValue(oParams, "CORPORATENAME"));
                objList[50] = new SqlParameter("@CorporatedOfficeAddress", CCommon.DictionaryValue(oParams, "CorporatedOfficeAddress"));
                objList[51] = new SqlParameter("@CORPORATEMDNAME", CCommon.DictionaryValue(oParams, "CORPORATEMDNAME"));
                objList[52] = new SqlParameter("@EXISTINGBOACCDP", CCommon.DictionaryValue(oParams, "EXISTINGBOACCDP"));
                objList[53] = new SqlParameter("@EXISTINGBOBROKER", CCommon.DictionaryValue(oParams, "EXISTINGBOBROKER"));

                objList[54] = new SqlParameter("@FJH_PHOTO_PATH", CCommon.DictionaryValue(oParams, "FJH_PHOTO_PATH"));
                objList[55] = new SqlParameter("@SJH_PHOTO_PATH", CCommon.DictionaryValue(oParams, "SJH_PHOTO_PATH"));
                objList[56] = new SqlParameter("@FJH_SIGNATURE_PATH", CCommon.DictionaryValue(oParams, "FJH_SIGNATURE_PATH"));
                objList[57] = new SqlParameter("@SJH_SIGNATURE_PATH", CCommon.DictionaryValue(oParams, "SJH_SIGNATURE_PATH"));

                objList[58] = new SqlParameter("@ROUTING_NO", CCommon.DictionaryValue(oParams, "ROUTING_NO"));


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

        public CResult GetAccountInfo(String ID, String Investor_code, String Name, String Bo_Code)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_INVESTOR_PERSONAL_INFO";
            try
            {
                SqlParameter[] objList = new SqlParameter[4];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));
                objList[1] = new SqlParameter("@INVESTOR_CODE", TypeCasting.ToString( Investor_code));
                objList[2] = new SqlParameter("@FIRST_JOIN_HOLDER_NAME", TypeCasting.ToString( Name));
                objList[3] = new SqlParameter("@BO_CODE", TypeCasting.ToString( Bo_Code));

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

        public void GetInvestorNameByCode(ref String  Investor )
        {
            String Query = @"SP_GET_INVESTOR_PERSONAL_INFO_BY_CODE";
            try
            {
                SqlParameter[] objList = new SqlParameter[1];
                objList[0] = new SqlParameter("@INVESTOR_CODE", Investor);
                CResult CResult = new CResult();
                DatabaseManager DatabaseManager = new DatabaseManager();
                CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, false, CommandType.StoredProcedure);
                if (CResult.IsSuccess)
                {
                    if (CResult.Data.Rows.Count == 0)
                    {
                        Investor = "0=Invalid/Closed Account.";
                    }
                    else
                    {
                        Investor = CResult.Data.Rows[0]["NAME"].ToString() ;
                    }
                }
            }
            catch (Exception ex)
            {
                Investor = "0="+ex.Message.Substring(0,150);
            }
        }

        public CResult InsertAuthorizedSignature(List<Dictionary<String, String>> oParamsList)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_INVESTOR_AUTHORIZED_SIGNATORIES";
            int AffectedRows = 0;

            try
            {
                foreach (Dictionary<String, String> oParams in oParamsList)
                {
                    SqlParameter[] objList = new SqlParameter[8];
                    objList[0] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt16(CCommon.DictionaryValue(oParams, "INVESTOR_ID")));
                    objList[1] = new SqlParameter("@NAME", CCommon.DictionaryValue(oParams, "NAME"));
                    objList[2] = new SqlParameter("@DESIGNATION", CCommon.DictionaryValue(oParams, "DESIGNATION"));
                    objList[3] = new SqlParameter("@PHONE", CCommon.DictionaryValue(oParams, "PHONE"));
                    objList[4] = new SqlParameter("@EMAIL", CCommon.DictionaryValue(oParams, "EMAIL"));
                    objList[5] = new SqlParameter("@PHOTO_PATH", CCommon.DictionaryValue(oParams, "PHOTO_PATH"));
                    objList[6] = new SqlParameter("@SIGNATURE_PATH", CCommon.DictionaryValue(oParams, "SIGNATURE_PATH"));
                    objList[7] = new SqlParameter("@CREATED_BY", 99);

                    DatabaseManager DatabaseManager = new DatabaseManager();
                    CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, true, CommandType.StoredProcedure);
                    if (CResult.AffectedRows > 0)
                        AffectedRows++;
                }
                CResult.AffectedRows = AffectedRows;
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

        public CResult GetAuthorizedSignature(String Investor_ID)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_INVESTOR_AUTHORIZED_SIGNATORIES";
            try
            {
                SqlParameter[] objList = new SqlParameter[1];
                objList[0] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt64(Investor_ID));

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

        public CResult DeleteAuthorizedSignature(String Investor_ID)
        {
            CResult CResult = new CResult();
            String Query = @"SP_DELETE_INVESTOR_AUTHORIZED_SIGNATORIES";
            try
            {
                SqlParameter[] objList = new SqlParameter[1];
                objList[0] = new SqlParameter("@INVESTOR_ID", TypeCasting.ToInt64(Investor_ID));

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

