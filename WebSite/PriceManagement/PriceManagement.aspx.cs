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
using BLL;
using Common;
using System.IO;
using System.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Text;

public partial class PriceManagement_PriceManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtTradingDate.Text =  TypeCasting.DateToString(Util.SystemDate());
            GetDropDownControlData();
        }
    }
    
    #region Private Methods
   
    private void GetDropDownControlData()
    {
        //Populate ddlTransactionMode
        ddlSecurityExchange.DataTextField = "Text";
        ddlSecurityExchange.DataValueField = "Value";
        ddlSecurityExchange.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.SecurityExchange).Data;
        ddlSecurityExchange.DataBind();
    }

    private DataTable GetDataTabletFromCSVFile(String csv_file_path)
    {
        DataTable csvData = new DataTable();
        try
        {
            using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;
                //read column names
                string[] colFields = csvReader.ReadFields();
                foreach (string column in colFields)
                {
                    DataColumn datecolumn = new DataColumn(column);
                    datecolumn.AllowDBNull = true;
                    csvData.Columns.Add(datecolumn);
                }
                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();
                    //Making empty value as null
                    for (int i = 0; i < fieldData.Length; i++)
                    {
                        if (fieldData[i] == "" || fieldData[i].Contains("--"))
                        {
                            fieldData[i] = "0";
                        }
                        else if (fieldData[i].Contains(","))
                        {
                            String Value = fieldData[i];
                            ValueManupulator.RemoveCommaDelimeter(ref Value);
                            fieldData[i] = Value;
                        }
                    }
                    csvData.Rows.Add(fieldData);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return csvData;
    }

    private void UploadClosingPrice()
    {
        CResult CResult = new CResult();
        try
        {
            String csv_file_path = Path.Combine(Server.MapPath("~/UploadablFile"), FileUpload1.FileName);
            FileUpload1.SaveAs(csv_file_path);
            DataTable csvData = GetDataTabletFromCSVFile(csv_file_path);
           
            //Insert into temp table
            BLLPriceManagement BLLPriceManagement = new BLLPriceManagement();
            CResult = BLLPriceManagement.InsertMarketClosingPriceInfoTemp(csvData);
            if (CResult.IsSuccess)
            {

                (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Uploaded.");
            }
            else
            {

                (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
            }
        }
        catch (Exception ex)
        {

            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    private void InsertUploadedClosingPrice()
    {
        CResult CResult = new CResult();
        try
        {
            BLLPriceManagement BLLPriceManagement = new BLLPriceManagement();
            Dictionary<String, String> oParam = new Dictionary<string, string>();
            oParam["SECURITY_EXCHANGE_ID"] = ddlSecurityExchange.SelectedValue;
            oParam["TRANSACTION_DATE"] = txtTradingDate.Text;

            CResult = BLLPriceManagement.InsertMarketClosingPriceInfo(oParam);
            if (CResult.IsSuccess)
            {
                (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");
            }
            else
            {

                (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
            }
        }
        catch (Exception ex)
        {

            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    private bool ValidateInsertUploadedClosingPrice()
    {
        return true;
    }
    #endregion

    #region Events
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            UploadClosingPrice();
        }
    }
    
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;
        if (!ValidateInsertUploadedClosingPrice()) return;
        InsertUploadedClosingPrice();
    }

    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        this.Page.Response.Redirect("../PriceManagement/PriceManagement.aspx");
    }
    #endregion
    
}
