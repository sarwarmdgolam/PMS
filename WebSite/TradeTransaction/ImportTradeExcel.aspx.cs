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
using Common;
using BLL;
using Microsoft.VisualBasic.FileIO;

public partial class TradeTransaction_ImportTradeExcel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtTradingDate.Text = TypeCasting.DateToString(Util.SystemDate());
            GetDropDownControlData();
        }
    }

    private void GetDropDownControlData()
    {
        //Populate Security Exchange
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
                    if (fieldData[0] != "0" && !String.IsNullOrEmpty(fieldData[0]))
                    {
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
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return csvData;
    }

    private void UploadTradeData()
    {
        CResult CResult = new CResult();
        try
        {
            String csv_file_path = Path.Combine(Server.MapPath("~/UploadablFile"), fuImportTrade.FileName);
            fuImportTrade.SaveAs(csv_file_path);
            DataTable csvData = GetDataTabletFromCSVFile(csv_file_path);

            //Insert into temp table
            BLLImportTradeExcel BLLImportTradeExcel = new BLLImportTradeExcel();
            CResult = BLLImportTradeExcel.BulkInsertTradeDataTempInfo(csvData);
            if (CResult.IsSuccess)
            {
                (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully uploaded.");

                //Load Data Grid View
                gv_Portfolio.DataSource = csvData;
                gv_Portfolio.DataBind();
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

    private void InsertUploadedTradeData()
    {
        CResult CResult = new CResult();
        try
        {
            BLLImportTradeExcel BLLImportTradeExcel = new BLLImportTradeExcel();
            Dictionary<String, String> oParam = new Dictionary<string, string>();
            oParam["SECURITY_EXCHANGE_ID"] = ddlSecurityExchange.SelectedValue;
            oParam["TRANSACTION_DATE"] = txtTradingDate.Text;

            CResult = BLLImportTradeExcel.InsertTradeDataTempInfo(oParam);
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

    private void DeleteUploadedTradeData()
    {
        CResult CResult = new CResult();
        try
        {
            BLLImportTradeExcel BLLImportTradeExcel = new BLLImportTradeExcel();
            Dictionary<String, String> oParam = new Dictionary<string, string>();
            oParam["SECURITY_EXCHANGE_ID"] = ddlSecurityExchange.SelectedValue;
            oParam["TRANSACTION_DATE"] = txtTradingDate.Text;

            CResult = BLLImportTradeExcel.DeleteTradeDataTempInfo(oParam);
            if (CResult.IsSuccess)
            {
                (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Deleted.");
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

    protected void btn_Import_Click(object sender, EventArgs e)
    {
        if (fuImportTrade.HasFile)
        {
            UploadTradeData();
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;

        if (!ValidateInsertUploadedClosingPrice()) return;
        InsertUploadedTradeData();
    }


    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        DeleteUploadedTradeData();
    }
    
}

