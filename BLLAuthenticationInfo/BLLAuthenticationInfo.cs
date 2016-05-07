using System;
using System.Collections.Generic;
using System.Text;
using Common;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BLLAuthenticationInfo
    {
        public CResult GetUserLoginInfo(String UserName, String Password)
        {
            CResult CResult = new CResult();
            DatabaseManager DatabaseManager = new DatabaseManager();
            String Query = @"SP_GET_USER_AUTHENTICATION_INFO";
            SqlParameter[] objList = new SqlParameter[2];
            objList[0] = new SqlParameter("@USERID", UserName);
            objList[1] = new SqlParameter("@PASSWORD", Password);
            try
            {
                CResult = DatabaseManager.ExecuteSQLQuerySecurityDB(Query, objList, false, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

        public CResult GetMenuInfo(String UserID)
        {
            CResult CResult = new CResult();
            DatabaseManager DatabaseManager = new DatabaseManager();
            SqlParameter[] objList = new SqlParameter[1];
            objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(UserID));
            String Query = @"SP_GET_APPLICATION_MENU_BY_USER_ID";
            try
            {
                CResult = DatabaseManager.ExecuteSQLQuerySecurityDB(Query, objList, false, CommandType.StoredProcedure);
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
