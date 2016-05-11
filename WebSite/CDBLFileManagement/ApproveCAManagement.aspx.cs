using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common;
using BLL;
using System.Text;

public partial class CDBLFileManagement_ApproveCAManagement : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        //Master.ShowPageNavigationURL("View List", "~/Investor/Account_Open_List_Advisory.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtRecordDate.Text = TypeCasting.DateToString(Util.SystemDate());
            GetDropDownControlData();
            PageOperationMode(ApplicationEnums.UIOperationMode.REFRESH);
        }
    }

    private void PageOperationMode(Common.ApplicationEnums.UIOperationMode Mode)
    {
        switch (Mode)
        {
            case Common.ApplicationEnums.UIOperationMode.INSERT:
                btn_Save.Visible = true;
                btn_Approve.Visible = true;
                btn_Refresh.Visible = true;
                break;
            case Common.ApplicationEnums.UIOperationMode.REFRESH:
                btn_Save.Visible = false;
                btn_Approve.Visible = false;
                btn_Refresh.Visible = false;
                break;
        }
    }

    private void GetDropDownControlData()
    {
        //Populate ddlTransactionMode
        ddlCompany.DataTextField = "Text";
        ddlCompany.DataValueField = "Value";
        ddlCompany.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.CompanyInformation).Data;
        ddlCompany.DataBind();

        //Populate Bank
        ddlActionType.DataTextField = "Text";
        ddlActionType.DataValueField = "Value";
        ddlActionType.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.CorporateActionType).Data;
        ddlActionType.DataBind();
    }

    private Dictionary<String, String> GetEntityValues()
    {
        Dictionary<String, String> obj = new Dictionary<string, string>();
        obj.Add("ID", "0");
        obj.Add("COMPANY_ID", ddlCompany.SelectedValue);
        obj.Add("CORPORATE_ACTION_TYPE_ID", ddlActionType.SelectedValue);
        obj.Add("RECORD_DATE", txtRecordDate.Text);
        obj.Add("INVESTOR_ID", GetSelectedInvestorCode());
        return obj;
    }

    private String GetSelectedInvestorCode()
    {
        StringBuilder strInvList = new StringBuilder();
        foreach (GridViewRow oRow in GridView1.Rows)
        {
            CheckBox IsApprove = (CheckBox)oRow.Cells[0].FindControl("chk_Select_Single");
            if (IsApprove.Checked)
            {
                strInvList.Append(GridView1.DataKeys[i++].Value.ToString());
            }
        }
        return strInvList.ToString();
    }

    private bool ValidateEntityInsertion()
    {
        if (!Page.IsValid) return false;
        return true;
    }

    private void InsertCorporateAction()
    {
        if (!ValidateEntityInsertion()) return;

        BLLCorporateActionManagement BLLCorporateActionManagement = new BLLCorporateActionManagement();
        CResult CResult = new CResult();
        CResult = BLLCorporateActionManagement.InsertCorporateActionFromHoldings(GetEntityValues());

        if (CResult.AffectedRows > 0)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void ApproveCorporateAction()
    {
        if (!ValidateEntityInsertion()) return;

        BLLCorporateActionManagement BLLCorporateActionManagement = new BLLCorporateActionManagement();
        CResult CResult = new CResult();
        CResult = BLLCorporateActionManagement.ApproveCorporateActionInfo(GetEntityValues());

        if (CResult.AffectedRows > 0)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Approved.");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private DataTable GetCorporateActionFromHoldings()
    {
        DataTable DataTable = new DataTable();
        BLLCorporateActionManagement BLLCorporateActionManagement = new BLLCorporateActionManagement();
        CResult CResult = new CResult();
        CResult = BLLCorporateActionManagement.GetCorporateActionFromHoldings(GetEntityValues());

        if (CResult.IsSuccess)
        {
            DataTable= CResult.Data;
            PageOperationMode(ApplicationEnums.UIOperationMode.INSERT);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
        return DataTable;
    }

    private void GenerateExcelFile(DataTable DataTable)
    {
        StringBuilder csvContent = GenerateDataContent(DataTable);
        try
        {
            Response.Clear();
            Response.ContentType = "Text/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + DateTime.Now.ToString() + "_" + "CorporateAction" + ".csv\"");
            Response.Write(csvContent.ToString());
        }
        finally
        {
            Response.End();
        }
    }

    private StringBuilder GenerateDataContent(DataTable DataTable)
    {
        StringBuilder csvContent = new StringBuilder();
        csvContent.AppendLine("CA Type,Security Code,Investor Code,BO Code,Current Holdings,Ben Ratio,Quantity");
        foreach (DataRow oRow in DataTable.Rows)
        {
            csvContent.AppendLine(oRow["TYPE_F_NAME"].ToString() + "," + oRow["INSTRUMENT_NAME"].ToString() + "," + oRow["INVESTOR_CODE"].ToString() + "," + oRow["BO_CODE"].ToString() + "," + oRow["LEDGER_QUANTITY"].ToString() + "," + oRow["BEN_RATIO"].ToString() + "," + oRow["TOTAL_ENTITLEMENT"].ToString());
        }
        return csvContent;
    }

    protected void btnDownloadCA_Click(object sender, EventArgs e)
    {
        DataTable DataTable = GetCorporateActionFromHoldings();
        GenerateExcelFile(DataTable);
    }

    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        DataTable DataTable = GetCorporateActionFromHoldings();

        GridView1.DataSource = DataTable;
        GridView1.DataBind();

        lblTotal.Text = "Total: "+DataTable.Compute("Sum(TOTAL_ENTITLEMENT)", "").ToString();
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        InsertCorporateAction();
    }

    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        ApproveCorporateAction();
    }

    protected void btn_Refresh_Click(object sender, EventArgs e)
    {
        Response.Redirect("../CDBLFileManagement/ApproveCAManagement.aspx");
    }

    protected void chk_Select_All_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow oRow in GridView1.Rows)
        {
            CheckBox IsApprove = (CheckBox)oRow.Cells[0].FindControl("chk_Select_Single");
            IsApprove.Checked = ((CheckBox)sender).Checked;
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (ddlActionType.SelectedItem.Text == "RIGHT")
            e.Row.Cells[0].Visible = true;
        else
            e.Row.Cells[0].Visible = false;
    }
}
