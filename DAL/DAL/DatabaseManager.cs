using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Common;
/// <summary>
/// Summary description for DatabaseManager
/// </summary>
/// 
namespace DAL
{
    public class DatabaseManager
    {
        public  CResult ExecuteSQLQuery(String sql, SqlParameter[] objList, bool IsExecuteNonQuery, CommandType oCommandType)
        {
            CResult CResult = new CResult();
            SqlConnection oConn = new SqlConnection(ConfigurationSettings.AppSettings["appconnectionStrings"].ToString());
            SqlCommand oComd = new SqlCommand();

            try
            {
                oConn.Open();
                oComd.Connection = oConn;
                oComd.CommandType = oCommandType;
                oComd.CommandText = sql;
                if (objList != null && objList.Length > 0)
                    oComd.Parameters.AddRange(objList);

                if (IsExecuteNonQuery)
                {
                    CResult.AffectedRows = oComd.ExecuteNonQuery();
                    if (oComd.Parameters.Contains("ID")) 
                    {
                        if (!String.IsNullOrEmpty(oComd.Parameters["ID"].SqlValue.ToString()))
                        {
                            CResult.ID = Convert.ToInt64( oComd.Parameters["ID"].SqlValue.ToString());
                        }
                    }
                    
                    CResult.IsSuccess = true;
                }
                else
                {
                    SqlDataReader oReader = oComd.ExecuteReader();
                    CResult.Data.Load(oReader);
                    oReader.Close();
                    CResult.IsSuccess = true;
                }
            }
            catch (SqlException ex)
            {
                CResult.Message = ex.Message;
            }
            finally
            {
                if (oComd != null)
                {
                    oComd.Connection.Close();
                    oComd.Dispose();
                }
                if (oConn != null && oConn.State != ConnectionState.Closed) oConn.Close();
            }
            
            return CResult;
        }

        public CResult ExecuteSQLQuerySecurityDB(String sql, SqlParameter[] objList, bool IsExecuteNonQuery, CommandType oCommandType)
        {
            CResult CResult = new CResult();
            SqlConnection oConn = new SqlConnection(ConfigurationSettings.AppSettings["securityconnectionStrings"].ToString());
            SqlCommand oComd = new SqlCommand();

            try
            {
                oConn.Open();
                oComd.Connection = oConn;
                oComd.CommandType = oCommandType;
                oComd.CommandText = sql;
                if (objList != null && objList.Length > 0)
                    oComd.Parameters.AddRange(objList);

                if (IsExecuteNonQuery)
                {
                    CResult.AffectedRows = oComd.ExecuteNonQuery();
                    if (oComd.Parameters.Contains("ID"))
                    {
                        if (!String.IsNullOrEmpty(oComd.Parameters["ID"].SqlValue.ToString()))
                        {
                            CResult.ID = Convert.ToInt64(oComd.Parameters["ID"].SqlValue.ToString());
                        }
                    }

                    CResult.IsSuccess = true;
                }
                else
                {
                    SqlDataReader oReader = oComd.ExecuteReader();
                    CResult.Data.Load(oReader);
                    oReader.Close();
                    CResult.IsSuccess = true;
                }
            }
            catch (SqlException ex)
            {
                CResult.Message = ex.Message;
            }
            finally
            {
                if (oComd != null)
                {
                    oComd.Connection.Close();
                    oComd.Dispose();
                }
                if (oConn != null && oConn.State != ConnectionState.Closed) oConn.Close();
            }

            return CResult;
        }

        public  CResult ExecuteSQLQuery(SqlCommand oComd, string sql, SqlParameter[] objList, bool IsExecuteNonQuery, CommandType oCommandType)
        {
            CResult CResult = new CResult();
            try
            {
                oComd.CommandType = oCommandType;
                oComd.CommandText = sql;
                if (objList != null && objList.Length > 0)
                    oComd.Parameters.AddRange(objList);

                if (IsExecuteNonQuery)
                {
                    CResult.AffectedRows = oComd.ExecuteNonQuery();
                }
                else
                {
                    SqlDataReader oReader = oComd.ExecuteReader();
                    CResult.Data.Load(oReader);
                    oReader.Close();
                }
                CResult.IsSuccess = true;
            }
            catch (SqlException ex)
            {
                CResult.Message = ex.Message;
            }
            return CResult;
        }
        public CResult ExecuteSQLBulkCopy(String sqlTable, DataTable dt)
        {
            CResult CResult = new CResult();
            SqlConnection oConn = new SqlConnection(ConfigurationSettings.AppSettings["appconnectionStrings"].ToString());

            try
            {
                if (dt.Rows.Count > 0) // if Datatable filled with data
                {
                    // insert into temp table using sqlbulkcopy 
                    using (SqlBulkCopy bulkcopy = new SqlBulkCopy(oConn))
                    {
                        bulkcopy.DestinationTableName = sqlTable;
                        bulkcopy.BatchSize = dt.Rows.Count;
                        oConn.Open();
                        bulkcopy.WriteToServer(dt);
                        bulkcopy.Close();
                        CResult.AffectedRows = dt.Rows.Count;
                        CResult.IsSuccess = true;
                    }
                }
                else
                {
                    CResult.IsSuccess = false;
                }
            }
            catch (SqlException ex)
            {
                CResult.Message = ex.Message;
            }
            finally
            {
                if (oConn != null && oConn.State != ConnectionState.Closed) oConn.Close();
            }

            return CResult;
        }
    
    }
}