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
using System.Collections.Generic;

public partial class AccountTransaction_Cash_Chq_Collection : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("View List", "~/AccountTransaction/Cash_Chq_Collection_List.aspx");
    }
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtTransactionDate.Text = this.txtChequeDate.Text = this.txtValueDate.Text = TypeCasting.DateToString(Util.SystemDate());
            GetDropDownControlData();

            String ID=Request.QueryString["ID"];
            if (!String.IsNullOrEmpty(ID))
            {
                GetCashChqCollection(ID, String.Empty, String.Empty, String.Empty, String.Empty);
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.UPDATE);
            }
            else
            {
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.INSERT);
            }
            
            //Set Voucher No
            SetVoucherNO();
        }
    }

    #region User Defined Methods
    private void ControlSelectionMode(Common.ApplicationEnums.UIOperationMode Mode)
    {
        switch (Mode)
        {
            case Common.ApplicationEnums.UIOperationMode.INSERT:
                btn_Save.Enabled = true;
                btn_Update.Enabled = false;
                btn_Save2.Enabled = true;
                btn_Update2.Enabled = false;
                break;
            case Common.ApplicationEnums.UIOperationMode.UPDATE:
                btn_Save.Enabled = false;
                btn_Update.Enabled = true;
                btn_Save2.Enabled = false;
                btn_Update2.Enabled = true;
                break;
            case Common.ApplicationEnums.UIOperationMode.REFRESH:
                btn_Save.Enabled = false;
                btn_Update.Enabled = false;
                btn_Save2.Enabled = false;
                btn_Update2.Enabled = false;
                break;
        }
    }

    private void SetVoucherNO()
    {
        Int64 Voucher_NO = Convert.ToInt64(BLLCommonEntity.GetMaxVoucherNo(ApplicationEnums.VoucherType.TBL_CASH_CHQ_COLLECTION_VOUCHER_NO));
        txtPreviousVoucherNo.Text = Voucher_NO.ToString();
        Voucher_NO = Voucher_NO + 1;
        txtVoucherNumber.Text = Voucher_NO.ToString();
    }

    private void GetDropDownControlData()
    {
        //Populate ddlTransactionMode
        ddlTransactionMode.DataTextField = "Text";
        ddlTransactionMode.DataValueField = "Value";
        ddlTransactionMode.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.AccountTransactionMode).Data;
        ddlTransactionMode.DataBind();
        ddlTransactionMode.Items.RemoveAt(0);

        //Populate Bank
        ddlBank.DataTextField = "Text";
        ddlBank.DataValueField = "Value";
        ddlBank.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.Bank).Data;
        ddlBank.DataBind();



        //Populate operating branch
        ddlOperatingBranch.DataTextField = "Text";
        ddlOperatingBranch.DataValueField = "Value";
        ddlOperatingBranch.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BrokerBranch).Data;
        ddlOperatingBranch.DataBind();

    }

    private void SetCashChqCollection(DataTable CollectionInfo)
    {
        try
        {
            hdnID.Value = CollectionInfo.Rows[0]["ID"].ToString();
            hdnInvestorID.Value = CollectionInfo.Rows[0]["INVESTOR_ID"].ToString();
            txtAmount.Text = CollectionInfo.Rows[0]["AMOUNT"].ToString();
            txtChequeDate.Text = TypeCasting.DateToString(CollectionInfo.Rows[0]["CHEQUE_DATE"].ToString());
            txtChequeNo.Text = CollectionInfo.Rows[0]["CHEQUE_NO"].ToString();
            txtDocRefNumber.Text = CollectionInfo.Rows[0]["DOCREFNUMBER"].ToString();
            txtInvestorCode.Text = CollectionInfo.Rows[0]["INVESTOR_CODE"].ToString();
            txtInvestorName.Text = CollectionInfo.Rows[0]["FIRST_JOIN_HOLDER_NAME"].ToString();
            txtPreviousVoucherNo.Text = CollectionInfo.Rows[0]["PREV_VOUCHER_NO"].ToString();
            txtRemarks.Text = CollectionInfo.Rows[0]["REMARKS"].ToString();
            txtTransactionDate.Text =  TypeCasting.DateToString(CollectionInfo.Rows[0]["TRANSACTION_DATE"].ToString());
            txtValueDate.Text = TypeCasting.DateToString(CollectionInfo.Rows[0]["VALUE_DATE"].ToString());
            txtVoucherNumber.Text = CollectionInfo.Rows[0]["VOUCHER_NO"].ToString();
            ddlBank.SelectedValue = CollectionInfo.Rows[0]["BANK_ID"].ToString();
            ddlBankBranch.SelectedValue = CollectionInfo.Rows[0]["BANKBRANCH_ID"].ToString();
            ddlOperatingBranch.SelectedValue = CollectionInfo.Rows[0]["BRANCH_ID"].ToString();
            ddlTransactionMode.SelectedValue = CollectionInfo.Rows[0]["TRANSACTION_MODE_ID"].ToString();

        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    private void GetCashChqCollection(String ID, String INVESTOR_ID, String Voucher_no, String From_Date, String To_Date)
    {
        BLLCashChqCollection BLLCashChqCollection = new BLLCashChqCollection();
        CResult CResult = new CResult();
        CResult = BLLCashChqCollection.GetCashChqCollectionInfo(ID, INVESTOR_ID, Voucher_no, From_Date, To_Date);

        if (CResult.IsSuccess)
        {
            SetCashChqCollection(CResult.Data);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private Dictionary<String, String> GetCashChqCollection()
    {
        Dictionary<String, String> oParam = new Dictionary<string, string>();
        oParam["ID"] = hdnID.Value;
        oParam["VOUCHER_NO"] = txtVoucherNumber.Text;
        oParam["TRANSACTION_DATE"] = txtTransactionDate.Text;
        oParam["INVESTOR_ID"] = hdnInvestorID.Value;
        oParam["TRANSACTION_MODE_ID"] = ddlTransactionMode.SelectedValue;
        oParam["CHEQUE_NO"] = txtChequeNo.Text;
        oParam["CHEQUE_DATE"] = txtChequeDate.Text;
        oParam["AMOUNT"] = txtAmount.Text;
        oParam["BRANCH_ID"] = ddlOperatingBranch.SelectedValue;
        oParam["REMARKS"] = txtRemarks.Text;
        oParam["BANK_ID"] = ddlBank.SelectedValue;
        oParam["BANKBRANCH_ID"] = ddlBankBranch.Text;
        oParam["VALUE_DATE"] = txtValueDate.Text;
        oParam["DOCREFNUMBER"] = txtDocRefNumber.Text;
        return oParam;
    }

    private bool ValidateInsertCashChqCollection()
    {
        // Check page input validation
        if (!Page.IsValid) return false;

        if (!Page_Create)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Warning, "Dont have enough Permission.");
            return false;
        }

        //to do: operation permission
        return true;
    }

    private bool ValidateUpdateCashChqCollection()
    {
        // Check page input validation
        if (!Page.IsValid) return false;

        if (!Page_Update)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Warning, "Dont have enough Permission.");
            return false;
        }
        //to do: operation permission
        return true;
    }

    private void InsertCashChqCollection()
    {
        if (!ValidateInsertCashChqCollection()) return;

        BLLCashChqCollection BLLCashChqCollection = new BLLCashChqCollection();
        CResult CResult = new CResult();
        CResult = BLLCashChqCollection.InsertCashChqInfo(GetCashChqCollection());

        if (CResult.AffectedRows>0)
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
        if (!ValidateUpdateCashChqCollection()) return;

        BLLCashChqCollection BLLCashChqCollection = new BLLCashChqCollection();
        CResult CResult = new CResult();
        CResult = BLLCashChqCollection.UpdateCashChqInfo(GetCashChqCollection());

        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Updated.");

           
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    } 
    #endregion

    #region Control Events
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        InsertCashChqCollection();
    }

    protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Populate Bank Branch
        ddlBankBranch.DataTextField = "Text";
        ddlBankBranch.DataValueField = "Value";
        ddlBankBranch.DataSource = BLLCommonEntity.GetBankBranch(ddlBank.SelectedValue).Data;
        ddlBankBranch.DataBind();
    }

    protected void ddlTransactionMode_SelectedIndexChanged(object sender, EventArgs e)
    {

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
        txtInvestorCode_TextChanged(null,null);
    }
    
    #endregion
    
}
