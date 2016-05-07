using System;
using System.Collections.Generic;
using System.Text;
using Common;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BLLReportManagement
    {
        public CResult GetReportParameterInfo(String ID)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_REPORT_PARAMETER_BY_MENU_ID";
            try
            {
                SqlParameter[] objList = new SqlParameter[1];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt32(ID) );
                DatabaseManager DatabaseManager = new DatabaseManager();
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
