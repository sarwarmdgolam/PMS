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
using System.Collections.Generic;
using BLL;
using Common;

public partial class Settings_TradingAccountsSetup : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("View List", "~/Settings/TradingAccountsSetupList.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDropDownControlData();

            hdnID.Value = Request.QueryString["ID"];
            if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                //GetInvestorImposedChargeByID();
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.UPDATE);
            }
            else
            {
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.INSERT);
            }
        }
    }

    private void GetDropDownControlData()
    {
        //Populate ddlTransactionMode
        ddlWithdrawBasisON.DataTextField = "Text";
        ddlWithdrawBasisON.DataValueField = "Value";
        ddlWithdrawBasisON.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.WithdrawLimitBasisOn).Data;
        ddlWithdrawBasisON.DataBind();
    }

    private void ControlSelectionMode(Common.ApplicationEnums.UIOperationMode Mode)
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

    private void SetEntity(DataTable EntityInfo)
    {
        try
        {
            hdnID.Value = EntityInfo.Rows[0]["ID"].ToString();
            txtShortName.Text = EntityInfo.Rows[0]["ACC_TYPE_S_NAME"].ToString();
            txtFullName.Text = EntityInfo.Rows[0]["ACC_TYPE_F_NAME"].ToString();
            txtLoanRatio.Text = EntityInfo.Rows[0]["LOAN_RATIO"].ToString();
            txtMaxAllocatedLoan.Text = EntityInfo.Rows[0]["MAX_ALLOCATED_LOAN"].ToString();
            ddlWithdrawBasisON.SelectedValue = EntityInfo.Rows[0]["WITHDRAW_LIMIT_BASIS_ID"].ToString();
            txtOpeiningDeposit.Text = EntityInfo.Rows[0]["OPENING_DEPOSIT_AMOUNT"].ToString();
            txtMinLedgerBal.Text = EntityInfo.Rows[0]["MINIMUM_LEDGER_BAL_AMOUNT"].ToString();
            txtTriggerCallBal.Text = EntityInfo.Rows[0]["TRIGGER_CALL"].ToString();
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    private Dictionary<String, String> GetEntity()
    {
        Dictionary<String, String> oParam = new Dictionary<string, string>();
        oParam["ID"] = hdnID.Value;
        oParam["ACC_TYPE_S_NAME"] = txtShortName.Text;
        oParam["ACC_TYPE_F_NAME"] = txtFullName.Text;
        oParam["LOAN_RATIO"] = txtLoanRatio.Text;
        oParam["MAX_ALLOCATED_LOAN"] = txtMaxAllocatedLoan.Text;
        oParam["WITHDRAW_LIMIT_BASIS_ID"] = ddlWithdrawBasisON.SelectedValue;
        oParam["OPENING_DEPOSIT_AMOUNT"] = txtOpeiningDeposit.Text;
        oParam["MINIMUM_LEDGER_BAL_AMOUNT"] = txtMinLedgerBal.Text;
        oParam["TRIGGER_CALL"] = txtTriggerCallBal.Text;
        return oParam;
    }

    private bool ValidateInsertEntity()
    {
        if (!Page.IsValid) return false;
        return true;
    }

    private bool ValidateUpdateEntity()
    {
        if (!Page.IsValid) return false;

        if (String.IsNullOrEmpty(hdnID.Value))
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Warning, "No data found to Update.");
        }
        return true;
    }

    private void InsertEntity()
    {
        if (!ValidateInsertEntity()) return;

        BLLTradingAccountType BLLTradingAccountType = new BLLTradingAccountType();
        CResult CResult = new CResult();
        CResult = BLLTradingAccountType.InsertTradingAccountType(GetEntity());

        if (CResult.AffectedRows > 0)
        {
            ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.REFRESH);
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void UpdateEntity()
    {
        if (!ValidateUpdateEntity()) return;

        BLLTradingAccountType BLLTradingAccountType = new BLLTradingAccountType();
        CResult CResult = new CResult();
        CResult = BLLTradingAccountType.UpdateTradingAccountType(GetEntity());

        if (CResult.AffectedRows > 0)
        {
            ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.REFRESH);
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Updated.");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        InsertEntity();
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        UpdateEntity();
    }

    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Settings/TradingAccountsSetup.aspx");
    }
}
