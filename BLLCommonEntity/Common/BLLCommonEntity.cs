using System;
using System.Collections.Generic;
using System.Text;
using Common;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public static class BLLCommonEntity
    {
        public static CResult GetCommonEntityData(ApplicationEnums.EntityEnum EntityName)
        {
            CResult CResult = new CResult();
            DatabaseManager DatabaseManager = new DatabaseManager();
            String Query = @"SP_Get_CommonEntityData";
            try
            {
                SqlParameter[] objList = new SqlParameter[1];
                objList[0] = new SqlParameter("@EntityName", EntityName.ToString());
                CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, false, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

        public static CResult GetCommonEntityData(String EntityName)
        {
            CResult CResult = new CResult();
            DatabaseManager DatabaseManager = new DatabaseManager();
            String Query = @"SP_Get_CommonEntityData";
            try
            {
                SqlParameter[] objList = new SqlParameter[1];
                objList[0] = new SqlParameter("@EntityName", EntityName.ToString());
                CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, false, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

        public static CResult GetAccountsBalance(String ID)
        {
            CResult CResult = new CResult();
            DatabaseManager DatabaseManager = new DatabaseManager();
            String Query = @"SELECT * FROM TBL_INVESTOR_PORTFOLIO_BALANCE_INFO WHERE ISDELETED=0 AND ID=@ID";
            SqlParameter[] objList = new SqlParameter[1];
            objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));
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

        public static CResult GetBankBranch(String ID)
        {
            CResult CResult = new CResult();
            DatabaseManager DatabaseManager = new DatabaseManager();
            String Query = @"SELECT 0 Value,'--Select--' Text UNION SELECT ID,BRANCH_NAME FROM TBL_ACCOUNTS_BANK_BRANCH_INFO WHERE ISDELETED=0 AND BANK_ID=@ID";
            SqlParameter[] objList = new SqlParameter[1];
            objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));
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

        public static String GetMaxVoucherNo(ApplicationEnums.VoucherType VoucherType)
        {
            String Voucher_NO = String.Empty;
            CResult CResult = new CResult();
            DatabaseManager DatabaseManager = new DatabaseManager();
            String Query = @"SELECT * FROM [TBL_SETTINGS_VOUCHER_SEQUENCE_NO]";
            try
            {
                CResult = DatabaseManager.ExecuteSQLQuery(Query, null, false, CommandType.Text);
                Voucher_NO = CResult.Data.Rows[0][VoucherType.ToString()].ToString();
            }
            catch (Exception ex)
            {
                Voucher_NO = ex.Message;
            }
            return Voucher_NO;
        }

        public static CResult GetUserLoginInfo(String UserName,String Password)
        {
            CResult CResult = new CResult();
            DatabaseManager DatabaseManager = new DatabaseManager();
            String Query = @"select * from 
                            loginuser
                            where username=@username and password=@password and menu_id is not null
                            order by module_name ,menu_id 
                            ";
            SqlParameter[] objList = new SqlParameter[2];
            objList[0] = new SqlParameter("@username", UserName);
            objList[1] = new SqlParameter("@password", Password);
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

        public static CResult GetMenuInfo(String UserName, String Password)
        {
            CResult CResult = new CResult();
            DatabaseManager DatabaseManager = new DatabaseManager();
            String Query = @"select menu_id, menu_name, menu_parent_id, menu_url from menuMaster order by menu_order  ";
            //SqlParameter[] objList = new SqlParameter[2];
            //objList[0] = new SqlParameter("@username", UserName);
            //objList[1] = new SqlParameter("@password", Password);
            try
            {
                CResult = DatabaseManager.ExecuteSQLQuery(Query, null, false, CommandType.Text);
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
