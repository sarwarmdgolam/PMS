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

public partial class CDBLFileManagement_ProcessCAManagement : System.Web.UI.Page
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
          txtTransactionDate.Text=   txtRecordDate.Text = TypeCasting.DateToString(Util.SystemDate());
           GetDropDownControlData();
           PageOperationMode(ApplicationEnums.UIOperationMode.REFRESH);
        }
    }

    private void PageOperationMode(Common.ApplicationEnums.UIOperationMode Mode)
    {
        switch (Mode)
        {
            case Common.ApplicationEnums.UIOperationMode.INSERT:
                btn_Process.Visible = true;
                btn_Refresh.Visible = true;
                break;
            case Common.ApplicationEnums.UIOperationMode.REFRESH:
                btn_Process.Visible = false;
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
        obj.Add("TRANSACTION_DATE", txtTransactionDate.Text);
        return obj;
    }

    private bool ValidateEntityInsertion()
    {
        if (!Page.IsValid) return false;
        return true;
    }

    private void ProcessCorporateAction()
    {
        if (!ValidateEntityInsertion()) return;

        BLLCorporateActionManagement BLLCorporateActionManagement = new BLLCorporateActionManagement();
        CResult CResult = new CResult();
        CResult = BLLCorporateActionManagement. ProcessCorporateActionReceiveInfo(GetEntityValues());

        if (CResult.AffectedRows > 0)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Processed.");    
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);    
        }
    }

    private void GetCorporateAction()
    {
        BLLCorporateActionManagement BLLCorporateActionManagement = new BLLCorporateActionManagement();
        CResult CResult = new CResult();
        CResult = BLLCorporateActionManagement.GetApproveCorporateActionInfo(GetEntityValues());

        if (CResult.IsSuccess)
        {
            GridView1.DataSource = CResult.Data;
            GridView1.DataBind();
            PageOperationMode(ApplicationEnums.UIOperationMode.INSERT);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetCorporateAction();
    }
    protected void btn_Process_Click(object sender, EventArgs e)
    {
        ProcessCorporateAction();
    }

    protected void btn_Refresh_Click(object sender, EventArgs e)
    {
        Response.Redirect("../CDBLFileManagement/ProcessCAManagement.aspx");
    }

}
