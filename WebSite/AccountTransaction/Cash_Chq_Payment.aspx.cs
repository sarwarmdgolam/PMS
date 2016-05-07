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
using BLL;
using System.Collections.Generic;

public partial class Transaction_Cash_Chq_Payment : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("View List", "~/AccountTransaction/Cash_Chq_Payment_List.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                this.txtPaymentDate.Text = this.txtChequeDate.Text = this.txtValueDate.Text = TypeCasting.DateToString(Util.SystemDate());
                GetDropDownControlData();

                //Load Payment Info 
                String ID = Request.QueryString["ID"];
                if (!String.IsNullOrEmpty(ID))
                {
                    GetCashChqPaymentInfo(ID, String.Empty, String.Empty, String.Empty, String.Empty);
                    ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.UPDATE);
                }
                else
                {
                    ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.INSERT);
                }

                //set voucher no
                SetVoucherNO();
            }
            catch (Exception ex)
            {
                (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);

            }
        }
    }

    #region Methods
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
        Int64 Voucher_NO = Convert.ToInt64(BLLCommonEntity.GetMaxVoucherNo(ApplicationEnums.VoucherType.TBL_CASH_CHQ_PAYMENT_VOUCHER_NO));
        txtPreviousVoucherNo.Text = Voucher_NO.ToString();
        Voucher_NO = Voucher_NO + 1;
        txtVoucherNumber.Text = Voucher_NO.ToString();
    }

    private void GetCashChqPaymentInfo(String ID, String INVESTOR_ID, String Voucher_no, String From_Date, String To_Date)
    {
        try
        {
            BLLCashChqPayment BLLCashChqPayment = new BLLCashChqPayment();
            CResult CResult = new CResult();
            CResult = BLLCashChqPayment.GetCashChqPaymentInfo(ID, INVESTOR_ID, Voucher_no, From_Date, To_Date);

            if (CResult.IsSuccess)
            {
                SetCashChqPaymentInfo(CResult.Data);
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

    private void SetCashChqPaymentInfo(DataTable PaymentInfo)
    {
        try
        {
            hdnID.Value = PaymentInfo.Rows[0]["ID"].ToString();
            hdnInvestorID.Value = PaymentInfo.Rows[0]["INVESTOR_ID"].ToString();
            txtAmount.Text = PaymentInfo.Rows[0]["AMOUNT"].ToString();
            txtChequeDate.Text = TypeCasting.DateToString(PaymentInfo.Rows[0]["CHEQUE_DT"].ToString());
            txtChequeNo.Text = PaymentInfo.Rows[0]["CHEQUE_NO"].ToString();
            txtDocRefNumber.Text = PaymentInfo.Rows[0]["DOCREFNUMBER"].ToString();
            txtInvestorCode.Text = PaymentInfo.Rows[0]["INVESTOR_CODE"].ToString();
            txtInvestorName.Text = PaymentInfo.Rows[0]["FIRST_JOIN_HOLDER_NAME"].ToString();
            txtPreviousVoucherNo.Text = PaymentInfo.Rows[0]["PREV_VOUCHER_NO"].ToString();
            txtRemarks.Text = PaymentInfo.Rows[0]["REMARKS"].ToString();
            txtPaymentDate.Text = PaymentInfo.Rows[0]["TRANSACTION_DATE"].ToString();
            txtValueDate.Text = TypeCasting.DateToString(PaymentInfo.Rows[0]["VALUE_DT"].ToString());
            txtVoucherNumber.Text = PaymentInfo.Rows[0]["VOUCHER_NO"].ToString();
            ddlBank.SelectedValue = PaymentInfo.Rows[0]["BANK_ID"].ToString();
            ddlBankBranch.SelectedValue = PaymentInfo.Rows[0]["BANK_BRANCH_ID"].ToString();
            ddlOperatingBranch.SelectedValue = PaymentInfo.Rows[0]["BRANCH_ID"].ToString();
            ddlTransactionMode.SelectedValue = PaymentInfo.Rows[0]["TRANSACTION_MODE_ID"].ToString();

            LoadBranchWisePaymentGL();
            ddlPaymentGL.SelectedValue = PaymentInfo.Rows[0]["PAYMENT_GL_ACC_ID"].ToString();
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);

        }
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

        //Populate Bank Branch
        ddlBankBranch.DataTextField = "Text";
        ddlBankBranch.DataValueField = "Value";
        ddlBankBranch.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BankBranch).Data;
        ddlBankBranch.DataBind();

        //Populate operating branch
        ddlOperatingBranch.DataTextField = "Text";
        ddlOperatingBranch.DataValueField = "Value";
        ddlOperatingBranch.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BrokerBranch).Data;
        ddlOperatingBranch.DataBind();




    }

    private void LoadBranchWisePaymentGL()
    {
        //Populate Payment Gl
        BLLCashChqPayment BLLCashChqPayment = new BLLCashChqPayment();
        CResult CResult = new CResult();
        CResult = BLLCashChqPayment.GetDropDownControlData(ddlOperatingBranch.SelectedValue);
        if (CResult.IsSuccess)
        {
            ddlPaymentGL.DataTextField = "Text";
            ddlPaymentGL.DataValueField = "Value";
            ddlPaymentGL.DataSource = CResult.Data;
            ddlPaymentGL.DataBind();
        }
    }

    private bool ValidateInsertCashChqPaymentInfo()
    {
        if (!Page.IsValid) return false;

        if (!Page_Create)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Warning, "Dont have enough Permission.");

           
            return false;
        }

        return true;
    }

    private bool ValidateUpdateCashChqPaymentInfo()
    {
        if (!Page.IsValid) return false;

        if (!Page_Update)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Warning, "Dont have enough Permission.");

            return false;
        }

        return true;
    }

    private void InsertCashChqPaymentInfo()
    {
        if (!ValidateInsertCashChqPaymentInfo()) return;

        BLLCashChqPayment BLLCashChqPayment = new BLLCashChqPayment();
        CResult CResult = new CResult();
        Dictionary<String, String> oParam = GetCashChqPaymentInfo();
        CResult = BLLCashChqPayment.InsertCashChqPaymentInfo(oParam);

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

    private void UpdateCashChqPaymentInfo()
    {
        if (!ValidateUpdateCashChqPaymentInfo()) return;

        BLLCashChqPayment BLLCashChqPayment = new BLLCashChqPayment();
        CResult CResult = new CResult();
        Dictionary<String, String> oParam = GetCashChqPaymentInfo();
        CResult = BLLCashChqPayment.UpdateCashChqPaymentInfo(oParam);

        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Updated.");

        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);


           
        }
    }

    private Dictionary<String, String> GetCashChqPaymentInfo()
    {
        Dictionary<String, String> oParam = new Dictionary<string, string>();

        oParam.Add("ID", hdnID.Value);
        oParam.Add("VOUCHER_NO", txtVoucherNumber.Text);
        oParam.Add("INVESTOR_ID", hdnInvestorID.Value);
        oParam.Add("TRANSACTION_MODE_ID", ddlTransactionMode.SelectedValue);
        oParam.Add("CHEQUE_NO", txtChequeNo.Text);
        oParam.Add("CHEQUE_DT", txtChequeDate.Text);
        oParam.Add("VALUE_DT", txtValueDate.Text);
        oParam.Add("BANK_ID", ddlBank.SelectedValue);
        oParam.Add("BANK_BRANCH_ID", ddlBankBranch.SelectedValue);
        oParam.Add("PAYMENT_GL_ACC_ID", ddlPaymentGL.SelectedValue);
        oParam.Add("AMOUNT", txtAmount.Text);
        oParam.Add("TRANSACTION_DATE", txtPaymentDate.Text);
        oParam.Add("PAYMENT_REF_NO", txtDocRefNumber.Text);
        oParam.Add("BRANCH_ID", ddlOperatingBranch.SelectedValue);
        oParam.Add("ACCOUNT_NO", txtAccount.Text);
        oParam.Add("REMARKS", txtRemarks.Text);
        oParam.Add("ISFULLBALANCE", chkIsFull.Checked.ToString());
        oParam.Add("DOCREFNUMBER", txtDocRefNumber.Text);


        return oParam;
    }
    
    #endregion
    
    #region Events
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        InsertCashChqPaymentInfo();
    }

    protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlOperatingBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!String.Equals(ddlOperatingBranch.SelectedValue, "0"))
            LoadBranchWisePaymentGL();
    }

    protected void chkIsFull_CheckedChanged(object sender, EventArgs e)
    {
    }

    protected void ddlTransactionMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTransactionMode.SelectedItem.Text.ToUpper().Contains("CASH"))
        {
            txtChequeDate.Text = string.Empty;
            txtChequeNo.Text = string.Empty;
            txtChequeNo.ReadOnly = true;

            ddlBank.SelectedIndex = 0;
            ddlBankBranch.SelectedIndex = 0;

            ddlBank.Enabled = false;
            ddlBankBranch.Enabled = false;
            txtAccount.Focus();
        }
        else
        {
            txtChequeNo.ReadOnly = false;
            String SystemDate = String.Format("{0:dd-MMM-yyyy}", Util.SystemDate());
            //this.tbxCurDate.Text = SystemDate;
            this.txtChequeDate.Text = SystemDate;

            ddlBank.Enabled = true;
            ddlBankBranch.Enabled = true;
            txtChequeDate.Focus();
        }
    }

    protected void txtInvestorCode_TextChanged(object sender, EventArgs e)
    {
        String Investor_Code = ((TextBox)sender).Text.Trim();
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        CResult CResult = new CResult();
        CResult = BLLAccountOpen.GetAccountInfo("", Investor_Code, "", "");
        if (CResult.Data.Rows.Count > 0)
        {
            hdnInvestorID.Value = CResult.Data.Rows[0]["ID"].ToString();
            txtInvestorName.Text = CResult.Data.Rows[0]["FIRST_JOIN_HOLDER_NAME"].ToString();
            txtLedgerBalabce.Text = CResult.Data.Rows[0]["LEDGER_BALANCE"].ToString();
            txtAvailaleBalance.Text = CResult.Data.Rows[0]["CURRENT_BAL"].ToString();
            txtImmatiredBalance.Text = CResult.Data.Rows[0]["UNMATURE_SALE_BAL"].ToString();
            txtUnclearChqBalance.Text = CResult.Data.Rows[0]["UN_CLEAR_CHQ_BAL"].ToString();
            txtInterestReceivable.Text = CResult.Data.Rows[0]["ACCRUED_INTEREST"].ToString();
        }

    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        UpdateCashChqPaymentInfo();
    }

    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        Response.Redirect("../AccountTransaction/Cash_Chq_Payment.aspx");

    }
    #endregion
}
