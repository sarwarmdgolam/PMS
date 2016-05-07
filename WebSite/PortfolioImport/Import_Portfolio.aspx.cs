using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class Import_Import_Portfolio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetClearMessage();
        }
    }

    private void SetClearMessage()
    {
        this.divErrMesg.Visible = false;
        this.divInfoMsg.Visible = false;
        lblErrMsg.Text = String.Empty;
    }


    private DataTable ReadExcelFile(string stConnString)
    {
        DataTable excelData = new DataTable("ExcelData");
        using (OleDbConnection connection = new OleDbConnection(@"" + stConnString + ""))
        {
            connection.Open();
            using (OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", connection))
            {
                OleDbDataReader dr;
                dr = command.ExecuteReader(CommandBehavior.CloseConnection);

                excelData.Load(dr);
            }
        }
        return excelData;
    }

    protected void btn_Import_Click(object sender, EventArgs e)
    {
        if (fu_Import.HasFile)
        {
            #region File processing
           
            #region file format
            string _pathext = Path.GetExtension(fu_Import.PostedFile.FileName).ToLower();
            if (!(_pathext == ".xls" || _pathext == ".xlsx"))
            {
                lblErrMsg.Text = "The File Format is Invalid";
                divErrMesg.Visible = true;
                return;
            }
            #endregion file format

            string file_path = Path.Combine(Server.MapPath("~/Upload"), fu_Import.FileName);
            fu_Import.SaveAs(file_path);

            string stConnString = string.Empty;
            if (_pathext == ".xls")
            {
                stConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file_path + ";Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1;\"";

            }
            else if (_pathext == ".xlsx")
            {
                stConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file_path + ";Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1;\"";
            }

            DataTable dtExcel = new DataTable();
            dtExcel = ReadExcelFile(stConnString);

            gv_Portfolio.DataSource = dtExcel;
            gv_Portfolio.DataBind();

            //PopulateDataTableFromUploadedFile(dtExcel);

            #endregion File processing
        }
        else
        {
            lblErrMsg.Text = "Please Select Investor List File";
            divErrMesg.Visible= true;
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        //if (dtExcel != null && dtExcel.Rows.Count > 0)
        //{
        //    DataTable dt = PopulateDataTableFromUploadedFile(dtExcel);
        //    using (SqlConnection destinationConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["application"].ConnectionString))
        //    {
        //        destinationConnection.Open();

        //        //  Delete Pending request

        //        using (SqlCommand command = new SqlCommand("DELETE FROM trd_Investor_list_temp  WHERE Process_st =0", destinationConnection))
        //        {
        //            command.CommandType = CommandType.Text;
        //            command.ExecuteNonQuery();
        //        }

        //        // Set up the bulk copy object. 

        //        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
        //        {
        //            bulkCopy.DestinationTableName = "dbo.trd_Investor_list_temp";

        //            try
        //            {
        //                // Write from the source to the destination.
        //                bulkCopy.WriteToServer(dt);
        //            }
        //            catch (Exception ex)
        //            {
        //                errmsg1.Text = ex.Message;
        //                errmsg1.LS_Show = true;
        //            }
        //        }

        //        // Validate data from back end
        //        using (SqlCommand command = new SqlCommand("psp_validate_OnDemand_Invcharge_list", destinationConnection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            SqlParameter oParam = new SqlParameter("@stMessage", SqlDbType.VarChar, 200, null);
        //            oParam.Direction = ParameterDirection.Output;

        //            command.Parameters.Add(oParam);
        //            command.ExecuteNonQuery();

        //            string st = oParam.Value.ToString();

        //            if (st.Contains("Successfully"))
        //            {
        //                uploadmessage.ForeColor = System.Drawing.Color.Green;
        //            }
        //            else
        //            {
        //                uploadmessage.ForeColor = System.Drawing.Color.Red;
        //            }
        //            uploadmessage.Text = st;
        //            uploadmessage.LS_Show = true;

        //        }
        //    }
        //}
    }
}

