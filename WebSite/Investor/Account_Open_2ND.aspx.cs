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
using Model;
using BLL;
using System.Collections.Generic;
using Common;

public partial class Investor_Account_Open_2ND : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;

    #region Page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetClearMessage();
           
            txt_OPENING_DT.Text  = txtIncorporationDate .Text= txtCorporateOpeningDate.Text= TypeCasting.DateToString(Util.SystemDate());
            GetDropDownControlData();
            SetAccountPersonalInfoByID(Request.QueryString["ID"]);
        }
    }
    #endregion

    private void SetClearMessage()
    {
        divAdvisoryAccount.Visible = false;
        this.divErrMesg.Visible = false;
        this.divInfoMsg.Visible = false;
        lblErrMsg.Text = String.Empty;
        lblMsg.Text = String.Empty;
    }

    private void GetDropDownControlData()
    {
        //Populate ddl_OPERATION_TYPE_ID
        ddl_OPERATION_TYPE_ID.DataTextField = "Text";
        ddl_OPERATION_TYPE_ID.DataValueField = "Value";
        ddl_OPERATION_TYPE_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BOAccountOperationType).Data;
        ddl_OPERATION_TYPE_ID.DataBind();

        //Populate ddl_INVESTOR_TYPE_ID
        ddl_INVESTOR_TYPE_ID.DataTextField = "Text";
        ddl_INVESTOR_TYPE_ID.DataValueField = "Value";
        ddl_INVESTOR_TYPE_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BOInvestorType).Data;
        ddl_INVESTOR_TYPE_ID.DataBind();

        //Populate ddl_ACC_TYPE_ID
        ddl_ACC_TYPE_ID.DataTextField = "Text";
        ddl_ACC_TYPE_ID.DataValueField = "Value";
        ddl_ACC_TYPE_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.TradeAccountType).Data;
        ddl_ACC_TYPE_ID.DataBind();

        //Populate ddl_SUB_ACCOUNT_ID
        ddl_SUB_ACCOUNT_ID.DataTextField = "Text";
        ddl_SUB_ACCOUNT_ID.DataValueField = "Value";
        ddl_SUB_ACCOUNT_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.SubAccount).Data;
        ddl_SUB_ACCOUNT_ID.DataBind();

        //Populate ddl_PARENT_ID
        ddl_PARENT_ID.DataTextField = "Text";
        ddl_PARENT_ID.DataValueField = "Value";
        ddl_PARENT_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.ParentAccount).Data;
        ddl_PARENT_ID.DataBind();

        //Populate ddl_TRADER_ID
        ddl_TRADER_ID.DataTextField = "Text";
        ddl_TRADER_ID.DataValueField = "Value";
        ddl_TRADER_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.Trader).Data;
        ddl_TRADER_ID.DataBind();

        //Populate ddl_BANK_ACC_TP_ID
        ddl_BANK_ACC_TP_ID.DataTextField = "Text";
        ddl_BANK_ACC_TP_ID.DataValueField = "Value";
        ddl_BANK_ACC_TP_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BankAccountType).Data;
        ddl_BANK_ACC_TP_ID.DataBind();

        //Populate ddl_BANK_BRANCH_ID
        ddl_BANK_BRANCH_ID.DataTextField = "Text";
        ddl_BANK_BRANCH_ID.DataValueField = "Value";
        ddl_BANK_BRANCH_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BankBranch).Data;
        ddl_BANK_BRANCH_ID.DataBind();

        //Populate ddl_BANK_BRANCH_ID
        ddl_BANK_ID.DataTextField = "Text";
        ddl_BANK_ID.DataValueField = "Value";
        ddl_BANK_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.Bank).Data;
        ddl_BANK_ID.DataBind();

        //Populate ddl_COUNTRY_ID
        ddl_COUNTRY_ID.DataTextField = "Text";
        ddl_COUNTRY_ID.DataValueField = "Value";
        ddl_COUNTRY_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.Country).Data;
        ddl_COUNTRY_ID.DataBind();

        //Populate ddl_DISTRICT_ID
        ddl_DISTRICT_ID.DataTextField = "Text";
        ddl_DISTRICT_ID.DataValueField = "Value";
        ddl_DISTRICT_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.District).Data;
        ddl_DISTRICT_ID.DataBind();

        //Populate ddl_BRANCH_ID
        ddl_BRANCH_ID.DataTextField = "Text";
        ddl_BRANCH_ID.DataValueField = "Value";
        ddl_BRANCH_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BrokerBranch).Data;
        ddl_BRANCH_ID.DataBind();

        //Populate ddl_ACCOUNT_STATUS_ID
        ddl_ACCOUNT_STATUS_ID.DataTextField = "Text";
        ddl_ACCOUNT_STATUS_ID.DataValueField = "Value";
        ddl_ACCOUNT_STATUS_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BOAccountStatus).Data;
        ddl_ACCOUNT_STATUS_ID.DataBind();

        //Populate ddl_ACCOUNT_STATUS_ID
        ddlBusinessNature.DataTextField = "Text";
        ddlBusinessNature.DataValueField = "Value";
        ddlBusinessNature.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.CustomerBusinessNature).Data;
        ddlBusinessNature.DataBind();
    }

    private Dictionary<String, String> GetAccountPersonalInfo()
    {
        Dictionary<String, String> oParams = new Dictionary<string, string>();
        try
        {
            oParams.Add("ID", hdn_ID.Value);
            oParams.Add("INVESTOR_CODE", txt_INVESTOR_CODE.Text);
            oParams.Add("BO_CODE", String.IsNullOrEmpty(txt_BO_CODE.Text)?txtExistingBOCode.Text:txt_BO_CODE.Text);
            oParams.Add("FIRST_JOIN_HOLDER_NAME",String.IsNullOrEmpty(txt_FIRST_JOIN_HOLDER_NAME.Text)?txtExistingBOAcc.Text: txt_FIRST_JOIN_HOLDER_NAME.Text);
            oParams.Add("SEC_JOIN_HOLDER_NAME", txt_SEC_JOIN_HOLDER_NAME.Text);
            oParams.Add("FATHER_NAME", txt_FATHER_NAME.Text);
            oParams.Add("MOTHER_NAME", txt_MOTHER_NAME.Text);
            oParams.Add("BRANCH_ID", ddl_BRANCH_ID.SelectedValue);
            oParams.Add("OPERATION_TYPE_ID", ddl_OPERATION_TYPE_ID.SelectedValue);
            oParams.Add("INVESTOR_TYPE_ID", ddl_INVESTOR_TYPE_ID.SelectedValue);
            oParams.Add("ACC_TYPE_ID", ddl_ACC_TYPE_ID.SelectedValue);
            oParams.Add("PARENT_ID", ddl_PARENT_ID.SelectedValue);
            oParams.Add("SUB_ACCOUNT_ID", ddl_SUB_ACCOUNT_ID.SelectedValue);
            oParams.Add("OPENING_DT", String.IsNullOrEmpty(txt_OPENING_DT.Text)?txtCorporateOpeningDate.Text: txt_OPENING_DT.Text);

            oParams.Add("PRESENT_ADDRESS", txt_PRESENT_ADDRESS.Text);
            oParams.Add("PARMANENT_ADDRESS", txt_PARMANENT_ADDRESS.Text);
            oParams.Add("PHONE",String.IsNullOrEmpty(txt_PHONE.Text)?txtCorporatePhoneOffice.Text: txt_PHONE.Text);
            oParams.Add("MOBILE", String.IsNullOrEmpty(txt_MOBILE.Text)?txtCorporatePhoneCell.Text:txt_MOBILE.Text);
            oParams.Add("FAX", String.IsNullOrEmpty(txt_FAX.Text)?txtCorporateFaxNo.Text:txt_FAX.Text);
            oParams.Add("EMAIL", String.IsNullOrEmpty(txt_EMAIL.Text)?txtCorporateEmail.Text:txt_EMAIL.Text);
            oParams.Add("GENDER", ddl_GENDER.SelectedValue);
            oParams.Add("VOTER_ID_NO", txt_VOTER_ID_NO.Text);
            oParams.Add("INTRODUCER_CODE", txt_INTRODUCER_CODE.Text);
            oParams.Add("INTRODUCER_NAME", txt_INTRODUCER_NAME.Text);
            oParams.Add("INTRODUCER_CONTACT_NO", txt_INTRODUCER_CONTACT_NO.Text);
            oParams.Add("SPECIAL_INSTRUCTION", txt_SPECIAL_INSTRUCTION.Text);
            oParams.Add("OCCUPATION", txt_Occupation.Text);
            oParams.Add("DISTRICT_ID", ddl_DISTRICT_ID.SelectedValue);

            oParams.Add("COUNTRY_ID", ddl_COUNTRY_ID.SelectedValue);
            oParams.Add("PASSPORT_NO", txt_PASSPORT_NO.Text);
            oParams.Add("TIN_NO", txtTINNo.Text);
            oParams.Add("BIRTH_DT", txt_BIRTH_DT.Text);
            oParams.Add("ACCOUNT_STATUS_ID", ddl_ACCOUNT_STATUS_ID.SelectedValue);
            oParams.Add("BANK_ID", ddl_BANK_ID.SelectedValue);
            oParams.Add("BANK_BRANCH_ID", ddl_BANK_BRANCH_ID.SelectedValue);
            oParams.Add("BANK_ACC_TP_ID", ddl_BANK_ACC_TP_ID.SelectedValue);
            oParams.Add("BANK_ACC_NO", txt_BANK_ACC_NO.Text);
            oParams.Add("TRADER_ID", ddl_TRADER_ID.SelectedValue);
            oParams.Add("INTEREST_CAL_ON", txt_INTEREST_CAL_ON.Text);
            oParams.Add("SMS_SERVICE_ST", chk_Is_SMS_service.Checked.ToString());
            oParams.Add("EMAIL_SERVICE_ST", chk_Is_Email_service.Checked.ToString());
            oParams.Add("IS_PAYIN", chk_IS_PAYIN.Checked.ToString());
            oParams.Add("IS_PAYOUT", chk_IS_PAYOUT.Checked.ToString());
            oParams.Add("LOAN_RATIO", txt_LOAN_RATIO.Text);

            oParams.Add("BUSINESSNATURE_ID", ddlBusinessNature.SelectedValue);
            oParams.Add("TRADELICENSENO", txtTradeLicenseNo.Text);
            oParams.Add("INCORPORATIONDATE", txtIncorporationDate.Text);
            oParams.Add("REGISTRATIONNO", txtRegistrationNo.Text);
            oParams.Add("CORPORATENAME", txtCorporateName.Text);
            oParams.Add("CorporatedOfficeAddress", txtCorporatedOfficeAddress.Text);
            oParams.Add("CORPORATEMDNAME", txtCompanyMDName.Text);

            oParams.Add("EXISTINGBOACCDP", txtExistingBOAccDP.Text);
            oParams.Add("EXISTINGBOBROKER", txtExistingBOBroker.Text);
           

            oParams.Add("CREATED_BY", "0");
        }
        catch (Exception ex)
        {
            divErrMesg.Visible = true;
            lblErrMsg.Text = ex.Message;
        }
        return oParams;
    }


    private void SetAccountPersonalInfo(DataRow oRow)
    {
        try
        {
            hdn_ID.Value = oRow["ID"].ToString();
            txt_INVESTOR_CODE.Text = oRow["INVESTOR_CODE"].ToString();
            txt_BO_CODE.Text = oRow["BO_CODE"].ToString();
            txt_FIRST_JOIN_HOLDER_NAME.Text = oRow["FIRST_JOIN_HOLDER_NAME"].ToString();
            txt_SEC_JOIN_HOLDER_NAME.Text = oRow["SEC_JOIN_HOLDER_NAME"].ToString();
            txt_FATHER_NAME.Text = oRow["FATHER_NAME"].ToString();
            txt_MOTHER_NAME.Text = oRow["MOTHER_NAME"].ToString();
            ddl_BRANCH_ID.SelectedValue = oRow["BRANCH_ID"].ToString();
            ddl_OPERATION_TYPE_ID.SelectedValue = oRow["OPERATION_TYPE_ID"].ToString();
            ddl_INVESTOR_TYPE_ID.SelectedValue = oRow["INVESTOR_TYPE_ID"].ToString();
            ddl_ACC_TYPE_ID.SelectedValue = oRow["ACC_TYPE_ID"].ToString();
            ddl_PARENT_ID.SelectedValue = oRow["PARENT_ID"].ToString();
            ddl_SUB_ACCOUNT_ID.SelectedValue = oRow["SUB_ACCOUNT_ID"].ToString();

            txt_OPENING_DT.Text = TypeCasting.DateToString( oRow["OPENING_DT"].ToString());
            txt_PRESENT_ADDRESS.Text = oRow["PRESENT_ADDRESS"].ToString();
            txt_PARMANENT_ADDRESS.Text = oRow["PARMANENT_ADDRESS"].ToString();
            txt_PHONE.Text = oRow["PHONE"].ToString();
            txt_MOBILE.Text = oRow["MOBILE"].ToString();
            txt_FAX.Text = oRow["FAX"].ToString();
            txt_EMAIL.Text = oRow["EMAIL"].ToString();

            ddl_GENDER.SelectedValue = oRow["GENDER"].ToString();

            txt_VOTER_ID_NO.Text = oRow["VOTER_ID_NO"].ToString();
            txt_INTRODUCER_CODE.Text = oRow["INTRODUCER_CODE"].ToString();
            txt_INTRODUCER_NAME.Text = oRow["INTRODUCER_NAME"].ToString();
            txt_INTRODUCER_CONTACT_NO.Text = oRow["INTRODUCER_CONTACT_NO"].ToString();
            txt_SPECIAL_INSTRUCTION.Text = oRow["SPECIAL_INSTRUCTION"].ToString();
            txt_Occupation.Text = oRow["OCCUPATION"].ToString();
            ddl_DISTRICT_ID.SelectedValue = oRow["DISTRICT_ID"].ToString();
            ddl_COUNTRY_ID.SelectedValue = oRow["COUNTRY_ID"].ToString();

            txt_PASSPORT_NO.Text = oRow["PASSPORT_NO"].ToString();
            txtTINNo.Text = oRow["TIN_NO"].ToString();
            txt_BIRTH_DT.Text = TypeCasting.DateToString(oRow["BIRTH_DT"].ToString());
            ddl_ACCOUNT_STATUS_ID.SelectedValue = oRow["ACCOUNT_STATUS_ID"].ToString();
            ddl_BANK_ID.SelectedValue = oRow["BANK_ID"].ToString();
            ddl_BANK_BRANCH_ID.SelectedValue = oRow["BANK_BRANCH_ID"].ToString();
            ddl_BANK_ACC_TP_ID.SelectedValue = oRow["BANK_ACC_TP_ID"].ToString();
            txt_BANK_ACC_NO.Text = oRow["BANK_ACC_NO"].ToString();
            ddl_TRADER_ID.SelectedValue = oRow["TRADER_ID"].ToString();
            txt_INTEREST_CAL_ON.Text = oRow["INTEREST_CAL_ON"].ToString();

            chk_IS_PAYIN.Checked = Convert.ToBoolean(oRow["IS_PAYIN"].ToString());
            chk_IS_PAYOUT.Checked = Convert.ToBoolean(oRow["IS_PAYOUT"].ToString());
            txt_LOAN_RATIO.Text = oRow["LOAN_RATIO"].ToString();


            ddlBusinessNature.SelectedValue = oRow["BUSINESSNATURE_ID"].ToString();
            txtTradeLicenseNo.Text= oRow["TRADELICENSENO"].ToString();
            txtIncorporationDate.Text= TypeCasting.DateToString(oRow["INCORPORATIONDATE"].ToString());
            txtRegistrationNo.Text= oRow["REGISTRATIONNO"].ToString();
            txtCorporateName.Text= oRow["CORPORATENAME"].ToString();
            txtCorporatedOfficeAddress.Text= oRow["CorporatedOfficeAddress"].ToString();
            txtCompanyMDName.Text= oRow["CORPORATEMDNAME"].ToString();
            txtCorporateOpeningDate.Text = TypeCasting.DateToString(oRow["OPENING_DT"].ToString());

            txtExistingBOCode.Text = oRow["BO_CODE"].ToString();
            txtExistingBOAcc.Text = oRow["FIRST_JOIN_HOLDER_NAME"].ToString();
            txtExistingBOAccDP.Text = oRow["EXISTINGBOACCDP"].ToString();
            txtExistingBOBroker.Text = oRow["EXISTINGBOBROKER"].ToString();
        }
        catch (Exception ex)
        {
            divErrMesg.Visible = true;
            lblErrMsg.Text = ex.Message;
        }
    }

    private void InsertAccountInfo()
    {
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        CResult CResult = new CResult();
        Dictionary<String, String> oParams = GetAccountPersonalInfo();

        CResult = BLLAccountOpen.InsertAccountInfo(oParams);
        if (CResult.IsSuccess)
        {
            divInfoMsg.Visible = true;
            lblMsg.Text = "Successfully Saved.";
        }
        else
        {
            divErrMesg.Visible = true;
            lblErrMsg.Text = CResult.Message;
        }
    }

    private void UpdateAccountInfo()
    {
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        CResult CResult = new CResult();
        Dictionary<String, String> oParams = GetAccountPersonalInfo();

        CResult = BLLAccountOpen.UpdateAccountInfo(oParams);
        if (CResult.IsSuccess)
        {
            divInfoMsg.Visible = true;
            lblMsg.Text = "Successfully Updated.";
        }
        else
        {
            divErrMesg.Visible = true;
            lblErrMsg.Text = CResult.Message;
        }
    }

    private void SetAccountPersonalInfoByID(String ID)
    {
        if (String.IsNullOrEmpty(ID)) return;

        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        CResult CResult = new CResult();
        CResult = BLLAccountOpen.GetAccountInfo(ID, "", "", "");
        if (CResult.IsSuccess && CResult.Data.Rows.Count>0)
        {
            SetAccountPersonalInfo(CResult.Data.Rows[0]);
        }
        else
        {
            divErrMesg.Visible = true;
            lblErrMsg.Text = CResult.Message;
        }
    }

    private bool ValidateInsertAccountInfo()
    {
        if (!Page_Create)
        {
            divErrMesg.Visible = true;
            lblErrMsg.Text = "Dont have enough Permission.";
            return false;
        }
        if (!Page.IsValid)
        {
            return false;
        }
        return true;
    }

    private bool ValidateUpdateAccountInfo()
    {
        if (!Page_Update)
        {
            divErrMesg.Visible = true;
            lblErrMsg.Text = "Dont have enough Permission.";
            return false;
        }
        if (!Page.IsValid)
        {
            return false;
        }
        return true;
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        SetClearMessage();
        if (!ValidateInsertAccountInfo()) return;

        InsertAccountInfo();
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        SetClearMessage();
        if (!ValidateUpdateAccountInfo()) return;

        UpdateAccountInfo();
    }

    protected void chkIsFull_CheckedChanged(object sender, EventArgs e)
    {
       
    }

    protected void btn_Clear_Click(object sender,EventArgs e)
    {
        this.Page.Response.Redirect("../Investor/Account_Open.aspx");
    }

    protected void ddl_ACC_TYPE_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (String.Equals(ddl_ACC_TYPE_ID.SelectedValue, "1"))
        {
            divAdvisoryAccount.Visible = true;
        }
        else
        {
            divAdvisoryAccount.Visible = false;
        }
    }
}
