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

public partial class CDBLFileManagement_CorporateActionManagement : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("View List", "~/CDBLFileManagement/CorporateActionManagementList.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtTransactionDate.Text = txtRecordDate.Text = txtEffectiveDate.Text = TypeCasting.DateToString(Util.SystemDate());
           GetDropDownControlData();

           String ID = Request.QueryString["ID"];
           if (!String.IsNullOrEmpty(ID))
           {
               hdnID.Value = ID;
               GetCorporateAction();
               PageOperationMode(Common.ApplicationEnums.UIOperationMode.UPDATE);
           }
           else
           {
               PageOperationMode(Common.ApplicationEnums.UIOperationMode.INSERT);
           }
            
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
        obj.Add("ID", hdnID.Value);
        obj.Add("COMPANY_ID", ddlCompany.SelectedValue);
        obj.Add("CORPORATE_ACTION_TYPE_ID", ddlActionType.SelectedValue);
        obj.Add("RECORD_DATE", txtRecordDate.Text);
        obj.Add("EFFECTIVE_DATE", txtEffectiveDate.Text);
        obj.Add("PAR_RATIO", txtRatio.Text);
        obj.Add("BEN_RATIO", txtBenRatio.Text);
        obj.Add("PUF_RATIO", txtPufRatio.Text);
        obj.Add("DEBIT_CREDIT", ddlDebitCredit.SelectedValue);
        obj.Add("TRANSACTION_DATE", txtTransactionDate.Text);
        obj.Add("REMARKS", txtRemarks.Text);
        obj.Add("UNIT_PRICE", txtRate.Text);
        return obj;
    }

    private void SetEntityValues(DataRow dr)
    {
        ddlCompany.SelectedValue = dr["COMPANY_ID"].ToString();
        ddlActionType.SelectedValue = dr["CORPORATE_ACTION_TYPE_ID"].ToString();
        txtRecordDate.Text = dr["RECORD_DATE"].ToString();
        txtEffectiveDate.Text = dr["EFFECTIVE_DATE"].ToString();
        txtRatio.Text = dr["PAR_RATIO"].ToString();
        txtBenRatio.Text = dr["BEN_RATIO"].ToString();
        txtPufRatio.Text = dr["PUF_RATIO"].ToString();
        ddlDebitCredit.SelectedValue = dr["DEBIT_CREDIT"].ToString();
        txtTransactionDate.Text = dr["TRANSACTION_DATE"].ToString();
        txtRemarks.Text = dr["REMARKS"].ToString();
        txtRate.Text = dr["UNIT_PRICE"].ToString();
    }

    private bool ValidateEntityInsertion()
    {
        if (!Page.IsValid) return false;
        return true;
    }

    private bool ValidateEntityUpdate()
    {
        if (!Page.IsValid) return false;
        if (String.IsNullOrEmpty(hdnID.Value))
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Warning, "No item found to update.");
            return false;
        }
        return true;

    }

    private void PageOperationMode(Common.ApplicationEnums.UIOperationMode Mode)
    {
        switch (Mode)
        {
            case Common.ApplicationEnums.UIOperationMode.INSERT:
                btn_Save.Enabled = true;
                btn_Update.Enabled = false;
                //btn_Save2.Enabled = true;
                //btn_Update2.Enabled = false;
                break;
            case Common.ApplicationEnums.UIOperationMode.UPDATE:
                btn_Save.Enabled = false;
                btn_Update.Enabled = true;
                //btn_Save2.Enabled = false;
                //btn_Update2.Enabled = true;
                break;
            case Common.ApplicationEnums.UIOperationMode.REFRESH:
                btn_Save.Enabled = false;
                btn_Update.Enabled = false;
                //btn_Save2.Enabled = false;
                //btn_Update2.Enabled = false;
                break;
        }
    }

    private void InsertCorporateAction()
    {
        if (!ValidateEntityInsertion()) return;

        BLLCorporateActionManagement BLLCorporateActionManagement = new BLLCorporateActionManagement();
        CResult CResult = new CResult();
        CResult = BLLCorporateActionManagement.InsertCorporateAction(GetEntityValues());

        if (CResult.AffectedRows > 0)
        {
            PageOperationMode(Common.ApplicationEnums.UIOperationMode.REFRESH);
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");    
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);    
        }
    }

    private void UpdateCorporateAction()
    {
        if (!ValidateEntityUpdate()) return;

        BLLCorporateActionManagement BLLCorporateActionManagement = new BLLCorporateActionManagement();
        CResult CResult = new CResult();
        CResult = BLLCorporateActionManagement.UpdateCorporateAction(GetEntityValues());

        if (CResult.AffectedRows > 0)
        {
            PageOperationMode(Common.ApplicationEnums.UIOperationMode.REFRESH);
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Updated.");
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
        CResult = BLLCorporateActionManagement.GetCorporateActionInfo(GetEntityValues());

        if (CResult.IsSuccess)
        {
            SetEntityValues(CResult.Data.Rows[0]);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        InsertCorporateAction();
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        UpdateCorporateAction();
    }

    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        Response.Redirect("CorporateActionManagement.aspx");
    }
}
