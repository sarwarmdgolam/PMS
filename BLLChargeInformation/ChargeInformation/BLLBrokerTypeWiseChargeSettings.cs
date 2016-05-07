using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLBrokerTypeWiseChargeSettings
    {
        public CResult InsertBrokerTypewiseChargeInfo(Dictionary<String, String> oParam)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_BROKER_TYPEWISE_CHARGE_INFO";
            try
            {
                SqlParameter[] objList = new SqlParameter[13];
                objList[0] = new SqlParameter("@CHARGE_TYPE_ID", TypeCasting.ToInt32( oParam["CHARGE_TYPE_ID"]));
                objList[1] = new SqlParameter("@TYPEWISE_VALUE_ID", TypeCasting.ToInt64( oParam["TYPEWISE_VALUE_ID"]));
                objList[2] = new SqlParameter("@CHARGE_ID", TypeCasting.ToInt32(oParam["CHARGE_ID"]));
                objList[3] = new SqlParameter("@CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["CHARGE_AMOUNT"]));
                objList[4] = new SqlParameter("@MIN_CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["MIN_CHARGE_AMOUNT"]));
                objList[5] = new SqlParameter("@ISPERCENTAGE", TypeCasting.ToBoolean(oParam["ISPERCENTAGE"]));
                objList[6] = new SqlParameter("@ISSLAB", TypeCasting.ToBoolean(oParam["ISSLAB"]));
                objList[7] = new SqlParameter("@CDBL_CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["CDBL_CHARGE_AMOUNT"]));
                objList[8] = new SqlParameter("@CDBL_MIN_CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["CDBL_MIN_CHARGE_AMOUNT"]));
                objList[9] = new SqlParameter("@ACTIVATION_DATE", TypeCasting.ToDateTime(oParam["ACTIVATION_DATE"]));
                objList[10] = new SqlParameter("@ISACTIVE", TypeCasting.ToBoolean(oParam["ISACTIVE"]));
                objList[11] = new SqlParameter("@Created_By", 99);

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

        public CResult UpdateBrokerTypewiseChargeInfo(Dictionary<String, String> oParam)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_UPDATE_BROKER_TYPEWISE_CHARGE_INFO]";
            try
            {
                SqlParameter[] objList = new SqlParameter[13];
                
                objList[0] = new SqlParameter("@CHARGE_TYPE_ID", TypeCasting.ToInt32(oParam["CHARGE_TYPE_ID"]));
                objList[1] = new SqlParameter("@TYPEWISE_VALUE_ID", TypeCasting.ToInt64(oParam["TYPEWISE_VALUE_ID"]));
                objList[2] = new SqlParameter("@CHARGE_ID", TypeCasting.ToInt32(oParam["CHARGE_ID"]));
                objList[3] = new SqlParameter("@CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["CHARGE_AMOUNT"]));
                objList[4] = new SqlParameter("@MIN_CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["MIN_CHARGE_AMOUNT"]));
                objList[5] = new SqlParameter("@ISPERCENTAGE", TypeCasting.ToBoolean(oParam["ISPERCENTAGE"]));
                objList[6] = new SqlParameter("@ISSLAB", TypeCasting.ToBoolean(oParam["ISSLAB"]));
                objList[7] = new SqlParameter("@CDBL_CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["CDBL_CHARGE_AMOUNT"]));
                objList[8] = new SqlParameter("@CDBL_MIN_CHARGE_AMOUNT", TypeCasting.ToDecimal(oParam["CDBL_MIN_CHARGE_AMOUNT"]));
                objList[9] = new SqlParameter("@ACTIVATION_DATE", TypeCasting.ToDateTime(oParam["ACTIVATION_DATE"]));
                objList[10] = new SqlParameter("@ISACTIVE", TypeCasting.ToBoolean(oParam["ISACTIVE"]));
                objList[11] = new SqlParameter("@UPDATED_BY", 99);
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

        public CResult DeleteBrokerTypewiseChargeInfo(String ID)
        {
            CResult CResult = new CResult();
            String Query = @"[SP_DELETE_BROKER_TYPEWISE_CHARGE_INFO]";
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

        public CResult InsertBrokerTypewiseChargeSlabInfo(Dictionary<String, String> oParam)
        {
            CResult CResult = new CResult();
            String Query = @"SP_INSERT_BROKER_TYPEWISE_CHARGE_SLAB_INFO";
            try
            {
                SqlParameter[] objList = new SqlParameter[6];
                objList[0] = new SqlParameter("@TYPEWISE_CHARGE_ID", TypeCasting.ToInt64(oParam["TYPEWISE_CHARGE_ID"]));
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

        public CResult GetBrokerTypewiseChargeInfo(String ID, String CHARGE_F_NAME)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_BROKER_TYPEWISE_CHARGE_INFO";

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

        public CResult GetBrokerTypewiseChargeSlabInfo(String TYPEWISE_CHARGE_ID)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_BROKER_TYPEWISE_CHARGE_INFO_SLAB";

            try
            {
                SqlParameter[] objList = new SqlParameter[1];
                objList[0] = new SqlParameter("@TYPEWISE_CHARGE_ID", TypeCasting.ToInt64(TYPEWISE_CHARGE_ID));

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

        public CResult GetDDLChargeSettingsBySelectedType(String ID)
        {
            CResult CResult = new CResult();
            String Query = @"SP_GET_TYPEWISE_CHARGE_SETTINGS_VALUE";

            try
            {
                SqlParameter[] objList = new SqlParameter[1];
                objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));

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
