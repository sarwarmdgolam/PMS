using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLChartOfAccount
    {

        public CResult InsertChartOfAccountsInfo(Dictionary<String, String> oParam)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_CHART_OF_ACCOUNTS";
            try
            {
                SqlParameter[] objList = new SqlParameter[14];
                objList[0] = new SqlParameter("@BRANCH_ID", TypeCasting.ToInt32(oParam["BRANCH_ID"]));
                objList[1] = new SqlParameter("@GENERAL_LEDGER_NO", TypeCasting.ToInt64(oParam["GENERAL_LEDGER_NO"]));
                objList[2] = new SqlParameter("@ACC_REF_NO", oParam["ACC_REF_NO"]);
                objList[3] = new SqlParameter("@GENERAL_LEDGER_NAME", oParam["GENERAL_LEDGER_NAME"]);
                objList[4] = new SqlParameter("@GL_LEVEL", TypeCasting.ToInt16(oParam["GL_LEVEL"]));
                objList[5] = new SqlParameter("@DR_CR", oParam["DR_CR"]);
                objList[6] = new SqlParameter("@GENERAL_LEDGER_PARENT_NO", TypeCasting.ToInt64(oParam["GENERAL_LEDGER_PARENT_NO"]));
                objList[7] = new SqlParameter("@IS_POST_FLAG", TypeCasting.ToBoolean(oParam["IS_POST_FLAG"]));
                objList[8] = new SqlParameter("@IS_ACTIVE", TypeCasting.ToBoolean(oParam["IS_ACTIVE"]));
                objList[9] = new SqlParameter("@GL_OPEING_DATE", TypeCasting.ToDateTime(oParam["GL_OPEING_DATE"]));
                objList[10] = new SqlParameter("@OPENING_BAL", TypeCasting.ToDecimal(oParam["OPENING_BAL"]));
                objList[11] = new SqlParameter("@CURRENT_BAL", TypeCasting.ToDecimal(oParam["CURRENT_BAL"]));
                objList[12] = new SqlParameter("@CLOSING_BAL", TypeCasting.ToDecimal(oParam["CLOSING_BAL"]));
                objList[13] = new SqlParameter("@CREATED_BY", 99);
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

        public CResult GETChartOfAccountsByGLNO(String GLNO)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_CHART_OF_ACCOUNTS_BY_GLNO";
            try
            {
                SqlParameter[] objList = new SqlParameter[1];
                objList[0] = new SqlParameter("@GLNO", GLNO);

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

        public CResult GETChartOfAccountsTreeView()
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_CHART_OF_ACCOUNTS_TREEVIEW";
            try
            {
                DatabaseManager DatabaseManager = new DatabaseManager();
                CResult = DatabaseManager.ExecuteSQLQuery(Query, null, false, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CResult.IsSuccess = false;
                CResult.Message = ex.Message;
            }
            return CResult;
        }

        public CResult GETChartOfAccountsTreeViewChildNode(String PARENTNODE, String LEVEL)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_CHART_OF_ACCOUNTS_TREEVIEW_CHILDNODE";
            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@PARENTNODE", PARENTNODE);
                objList[1] = new SqlParameter("@LEVEL", TypeCasting.ToInt64(LEVEL));

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
