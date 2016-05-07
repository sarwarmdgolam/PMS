using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLBrokerDefaultChargeInformation
    {
        public CResult InsertBrokerDefaultChargeInfo(Dictionary<String, String> oParam)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_BROKER_DEFAULT_CHARGE_INFO";
            try
            {
                SqlParameter[] objList = new SqlParameter[13];
                objList[0] = new SqlParameter("@CHARGE_S_NAME", oParam["CHARGE_S_NAME"]);
                objList[1] = new SqlParameter("@CHARGE_F_NAME", oParam["CHARGE_F_NAME"]);
                objList[2] = new SqlParameter("@CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["CHARGE_AMOUNT"]));
                objList[3] = new SqlParameter("@MIN_CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["MIN_CHARGE_AMOUNT"]));
                objList[4] = new SqlParameter("@ISPERCENTAGE", TypeCasting.ToBoolean(oParam["ISPERCENTAGE"]));
                objList[5] = new SqlParameter("@ISSLAB", TypeCasting.ToBoolean(oParam["ISSLAB"]));
                objList[6] = new SqlParameter("@CDBL_CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["CDBL_CHARGE_AMOUNT"]));
                objList[7] = new SqlParameter("@CDBL_MIN_CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["CDBL_MIN_CHARGE_AMOUNT"]));
                objList[8] = new SqlParameter("@ACTIVATION_DATE", TypeCasting.ToDateTime(oParam["ACTIVATION_DATE"]));
                objList[9] = new SqlParameter("@ISACTIVE", TypeCasting.ToBoolean(oParam["ISACTIVE"]));
                objList[10] = new SqlParameter("@Created_By", 99);
                objList[11] = new SqlParameter("@FEESCHARGE_TYPE_ID", TypeCasting.ToInt32( oParam["FEESCHARGE_TYPE_ID"]));
                

                SqlParameter ID = new SqlParameter();
                ID.Direction = ParameterDirection.Output;
                ID.SqlDbType = SqlDbType.BigInt;
                ID.ParameterName = "ID";
                ID.Value = "0";
                objList[12] = ID;

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

        public CResult UpdateBrokerDefaultChargeInfo(Dictionary<String, String> oParam)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_UPDATE_BROKER_DEFAULT_CHARGE_INFO]";
            try
            {
                SqlParameter[] objList = new SqlParameter[13];
                objList[0] = new SqlParameter("@CHARGE_S_NAME", oParam["CHARGE_S_NAME"]);
                objList[1] = new SqlParameter("@CHARGE_F_NAME", oParam["CHARGE_F_NAME"]);
                objList[2] = new SqlParameter("@CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["CHARGE_AMOUNT"]));
                objList[3] = new SqlParameter("@MIN_CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["MIN_CHARGE_AMOUNT"]));
                objList[4] = new SqlParameter("@ISPERCENTAGE", TypeCasting.ToBoolean(oParam["ISPERCENTAGE"]));
                objList[5] = new SqlParameter("@ISSLAB", TypeCasting.ToBoolean(oParam["ISSLAB"]));
                objList[6] = new SqlParameter("@CDBL_CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["CDBL_CHARGE_AMOUNT"]));
                objList[7] = new SqlParameter("@CDBL_MIN_CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["CDBL_MIN_CHARGE_AMOUNT"]));
                objList[8] = new SqlParameter("@ACTIVATION_DATE", TypeCasting.ToDateTime(oParam["ACTIVATION_DATE"]));
                objList[9] = new SqlParameter("@ISACTIVE", TypeCasting.ToBoolean(oParam["ISACTIVE"]));
                objList[10] = new SqlParameter("@USER_ID", 99);
                objList[11] = new SqlParameter("@FEESCHARGE_TYPE_ID", TypeCasting.ToInt32(oParam["FEESCHARGE_TYPE_ID"]));
                objList[12] = new SqlParameter("@ID", TypeCasting.ToInt32(oParam["ID"]));

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

        public CResult DefaultBrokerDefaultChargeInfo(String ID)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_DELETE_BROKER_DEFAULT_CHARGE_INFO]";
            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@USER_ID", 99);
                objList[1] = new SqlParameter("@ID", TypeCasting.ToInt32(ID));

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

        public CResult InsertBrokerDefaultChargeSlabInfo(Dictionary<String, String> oParam)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_BROKER_DEFAULT_CHARGE_SLAB_INFO";
            try
            {
                SqlParameter[] objList = new SqlParameter[6];
                objList[0] = new SqlParameter("@DEFAULT_CHARGE_ID", TypeCasting.ToInt64(oParam["DEFAULT_CHARGE_ID"]));
                objList[1] = new SqlParameter("@START_AMOUNT", TypeCasting.ToDecimal(oParam["START_AMOUNT"]));
                objList[2] = new SqlParameter("@END_AMOUNT", TypeCasting.ToDecimal(oParam["END_AMOUNT"]));
                objList[3] = new SqlParameter("@CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["CHARGE_AMOUNT"]));
                objList[4] = new SqlParameter("@ISPERCENTAGE", TypeCasting.ToBoolean(oParam["ISPERCENTAGE"]));
                objList[5] = new SqlParameter("@CREATED_BY", 99);
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

        public CResult GetBrokerDefaultChargeInfo(String ID, String CHARGE_F_NAME)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_BROKER_DEFAULT_CHARGE_INFO";

            try
            {
                SqlParameter[] objList = new SqlParameter[2];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));
                objList[1] = new SqlParameter("@CHARGE_F_NAME", CHARGE_F_NAME);
                
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

        public CResult GetBrokerDefaultChargeSlabInfo(String DEFAULT_CHARGE_ID)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_BROKER_DEFAULT_CHARGE_INFO_SLAB";

            try
            {
                SqlParameter[] objList = new SqlParameter[1];
                objList[0] = new SqlParameter("@DEFAULT_CHARGE_ID", TypeCasting.ToInt64(DEFAULT_CHARGE_ID));

                DatabaseManager DatabaseManager = new DatabaseManager();
                CResult= DatabaseManager.ExecuteSQLQuery(Query, objList, false, CommandType.StoredProcedure);
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
