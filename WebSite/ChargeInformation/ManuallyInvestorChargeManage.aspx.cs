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
using Common;
using System.Collections.Generic;
using BLL;

public partial class ChargeInformation_ManuallyInvestorChargeManage : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("View List", "~/ChargeInformation/ManuallyInvestorChargeManageList.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtTransactionDate.Text =TypeCasting.DateToString(Util.SystemDate());
            GetDropDownControlData();

            hdnID.Value = Request.QueryString["ID"];
            if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                GetInvestorImposedChargeByID();
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.UPDATE);
            }
            else
            {
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.INSERT);
            }
        }
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
    
    private void GetDropDownControlData()
    {
        //Populate ddlTransactionMode
        ddlChargeInformation.DataTextField = "Text";
        ddlChargeInformation.DataValueField = "Value";
        ddlChargeInformation.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.ChargeInformation).Data;
        ddlChargeInformation.DataBind();
        ddlChargeInformation.Items.RemoveAt(0);

    }

    private void SetInvestorImposedCharge(DataTable CollectionInfo)
    {
        try
        {
            hdnID.Value = CollectionInfo.Rows[0]["ID"].ToString();
            hdnInvestorID.Value = CollectionInfo.Rows[0]["INVESTOR_ID"].ToString();
            ddlChargeInformation.SelectedValue = CollectionInfo.Rows[0]["CHARGE_ID"].ToString();
            txtChargeAmount.Text = CollectionInfo.Rows[0]["AMOUNT"].ToString();
            txtDocRefNo.Text = CollectionInfo.Rows[0]["DOCREFNUMBER"].ToString();
            txtInvestorCode.Text = CollectionInfo.Rows[0]["INVESTOR_CODE"].ToString();
            txtInvestorName.Text = CollectionInfo.Rows[0]["FIRST_JOIN_HOLDER_NAME"].ToString();
            txtRemarks.Text = CollectionInfo.Rows[0]["REMARKS"].ToString();
            txtTransactionDate.Text = TypeCasting.DateToString(CollectionInfo.Rows[0]["TRANSACTION_DATE"].ToString());
            rbtnTransactionMode.SelectedValue = CollectionInfo.Rows[0]["TRANSACTION_MODE"].ToString();

        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    private void GetInvestorImposedChargeByID()
    {
        BLLChargeApply BLLChargeApply = new BLLChargeApply();
        CResult CResult = new CResult();
        CResult = BLLChargeApply.GetInvestorAppliedChargeInfo(GetInvestorImposedCharge());

        if (CResult.IsSuccess)
        {
            SetInvestorImposedCharge(CResult.Data);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private Dictionary<String, String> GetInvestorImposedCharge()
    {
        Dictionary<String, String> oParam = new Dictionary<string, string>();
        oParam["ID"] = hdnID.Value;
        oParam["TRANSACTION_DATE"] = txtTransactionDate.Text;
        oParam["INVESTOR_ID"] = hdnInvestorID.Value;
        oParam["CHARGE_ID"] = ddlChargeInformation.SelectedValue;
        oParam["TRANSACTION_MODE"] = rbtnTransactionMode.SelectedValue;
        oParam["AMOUNT"] = txtChargeAmount.Text;
        oParam["REMARKS"] = txtRemarks.Text;
        oParam["DOCREFNUMBER"] = txtDocRefNo.Text;
        return oParam;
    }

    private bool ValidateInsertInvestorChargeImpose()
    {
        if (!Page.IsValid) return false;
        return true;
    }

    private bool ValidateUpdateInvestorChargeImpose()
    {
        if (!Page.IsValid) return false;

        if (String.IsNullOrEmpty(hdnID.Value))
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Warning, "No data found to update.");
            return false;
        }
        return true;
    }

    private void InsertCashChqCollection()
    {
        if (!ValidateInsertInvestorChargeImpose()) return;

        BLLChargeApply BLLChargeApply = new BLLChargeApply();
        CResult CResult = new CResult();
        CResult = BLLChargeApply.InsertChargeImposeOnInvestor(GetInvestorImposedCharge());

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

    private void UpdateCashChqCollection()
    {
        if (!ValidateUpdateInvestorChargeImpose()) return;

        BLLChargeApply BLLChargeApply = new BLLChargeApply();
        CResult CResult = new CResult();
        CResult = BLLChargeApply.InsertChargeImposeOnInvestor(GetInvestorImposedCharge());

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

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        InsertCashChqCollection();
    }

    protected void txtInvestorCode_TextChanged(object sender, EventArgs e)
    {
        String Investor_Code = txtInvestorCode.Text.Trim();
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        BLLAccountOpen.GetInvestorNameByCode(ref Investor_Code);
        hdnInvestorID.Value = Investor_Code.Split('=')[0];
        if (hdnInvestorID.Value == "0") txtInvestorCode.Text = String.Empty;
        txtInvestorName.Text = Investor_Code.Split('=')[1];
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        UpdateCashChqCollection();
    }

    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        Response.Redirect("../AccountTransaction/Cash_Chq_Collection.aspx");
    }

    protected void btn_SearchInvestor_Click(object sender, EventArgs e)
    {
        txtInvestorCode_TextChanged(null, null);
    }

}
