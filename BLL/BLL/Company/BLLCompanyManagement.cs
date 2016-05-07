using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLCompanyManagement
    {

        #region INSTRUMENT SECTOR

        public CResult InsertInstrumentSectorInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_INSTRUMENT_SECTOR";
            try
            {
                SqlParameter[] objList = new SqlParameter[4];
                objList[0] = new SqlParameter("@SEC_S_NAME", oParams["SEC_S_NAME"]);
                objList[1] = new SqlParameter("@SEC_F_NAME", oParams["SEC_F_NAME"]);
                objList[2] = new SqlParameter("@INST_SECTOR_TYPE", oParams["INST_SECTOR_TYPE"]);
                objList[3] = new SqlParameter("@CREATED_BY", 99);
              
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
        
        public CResult UpdateInstrumentSectorInfo(Dictionary<String, String> oParams)
        {
            CResult CResult = new CResult();
            String Query = @"SP_UPDATE_INSTRUMENT_SECTOR";
            try
            {
                SqlParameter[] objList = new SqlParameter[5];
                objList[0] = new SqlParameter("@SEC_S_NAME", oParams["SEC_S_NAME"]);
                objList[1] = new SqlParameter("@SEC_F_NAME", oParams["SEC_F_NAME"]);
                objList[2] = new SqlParameter("@INST_SECTOR_TYPE", oParams["INST_SECTOR_TYPE"]);
                objList[3] = new SqlParameter("@ID", TypeCasting.ToInt16(oParams["ID"]));
                objList[4] = new SqlParameter("@UPDATED_BY", 99);

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

        public CResult GetCompanySectorInformation(String ID,String INST_SECTOR_TYPE)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_Company_Sector_Information";

            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@ID",TypeCasting.ToInt16(ID) );
                objList[1] = new SqlParameter("@INST_SECTOR_TYPE", INST_SECTOR_TYPE);

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
        #endregion
    }
}
