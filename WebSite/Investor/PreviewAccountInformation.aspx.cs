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

public partial class Investor_PreviewAccountInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDropDownControlData();
        }
    }

    private void GetDropDownControlData()
    {

        //Populate ddl_ACC_TYPE_ID
        ddl_ACC_TYPE_ID.DataTextField = "Text";
        ddl_ACC_TYPE_ID.DataValueField = "Value";
        ddl_ACC_TYPE_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.TradeAccountType).Data;
        ddl_ACC_TYPE_ID.DataBind();

        ddl_ACC_TYPE_ID.SelectedValue = "1";
        ddl_ACC_TYPE_ID.Enabled = false;


        //Populate ddl_ACCOUNT_STATUS_ID
        ddlBusinessNature.DataTextField = "Text";
        ddlBusinessNature.DataValueField = "Value";
        ddlBusinessNature.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.CustomerBusinessNature).Data;
        ddlBusinessNature.DataBind();

        //Populate ddl_ACCOUNT_STATUS_ID
        ddl_ACCOUNT_STATUS_ID.DataTextField = "Text";
        ddl_ACCOUNT_STATUS_ID.DataValueField = "Value";
        ddl_ACCOUNT_STATUS_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BOAccountStatus).Data;
        ddl_ACCOUNT_STATUS_ID.DataBind();

        //Populate Bank
        ddlBank.DataTextField = "Text";
        ddlBank.DataValueField = "Value";
        ddlBank.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.Bank).Data;
        ddlBank.DataBind();

        //Populate ddl_BANK_ACC_TP_ID
        ddl_BANK_ACC_TP_ID.DataTextField = "Text";
        ddl_BANK_ACC_TP_ID.DataValueField = "Value";
        ddl_BANK_ACC_TP_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BankAccountType).Data;
        ddl_BANK_ACC_TP_ID.DataBind();

        //Populate Bank Branch
        ddlBankBranch.DataTextField = "Text";
        ddlBankBranch.DataValueField = "Value";
        ddlBankBranch.DataSource = BLLCommonEntity.GetBankBranch(ddlBank.SelectedValue).Data;
        ddlBankBranch.DataBind();
    }

    private void GetAccountPersonalInfoByID(String ID)
    {
        if (String.IsNullOrEmpty(ID)) return;

        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        CResult CResult = new CResult();
        CResult = BLLAccountOpen.GetAccountInfo(ID, "", "", "");
        if (CResult.IsSuccess && CResult.Data.Rows.Count > 0)
        {
            SetAccountPersonalInfo(CResult.Data.Rows[0]);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void SetAccountPersonalInfo(DataRow oRow)
    {
        try
        {
            txt_INVESTOR_CODE.Text = oRow["INVESTOR_CODE"].ToString();
            ddl_ACC_TYPE_ID.SelectedValue = oRow["ACC_TYPE_ID"].ToString();
            txtTINNo.Text = oRow["TIN_NO"].ToString();
            ddlBusinessNature.SelectedValue = oRow["BUSINESSNATURE_ID"].ToString();
            txtTradeLicenseNo.Text = oRow["TRADELICENSENO"].ToString();
            txtIncorporationDate.Text = TypeCasting.DateToString(oRow["INCORPORATIONDATE"].ToString());
            txtRegistrationNo.Text = oRow["REGISTRATIONNO"].ToString();
            txtCorporateName.Text = oRow["CORPORATENAME"].ToString();
            txtCorporatedOfficeAddress.Text = oRow["CorporatedOfficeAddress"].ToString();
            txtCompanyMDName.Text = oRow["CORPORATEMDNAME"].ToString();
            txtCorporateOpeningDate.Text = TypeCasting.DateToString(oRow["OPENING_DT"].ToString());

            txtExistingBOCode.Text = oRow["BO_CODE"].ToString();
            txtExistingBOAcc.Text = oRow["FIRST_JOIN_HOLDER_NAME"].ToString();
            txtExistingBOAccDP.Text = oRow["EXISTINGBOACCDP"].ToString();
            txtExistingBOBroker.Text = oRow["EXISTINGBOBROKER"].ToString();

            ddlBusinessNature.SelectedValue = oRow["BUSINESSNATURE_ID"].ToString();
            txtCorporatedOfficeAddress.Text = oRow["CorporatedOfficeAddress"].ToString();
            txtCompanyMDName.Text = oRow["CORPORATEMDNAME"].ToString();

            txtCorporatePhoneOffice.Text = oRow["PHONE"].ToString();
            txtCorporatePhoneCell.Text = oRow["MOBILE"].ToString();
            txtCorporateFaxNo.Text = oRow["FAX"].ToString();
            txtCorporateEmail.Text = oRow["EMAIL"].ToString();
            txtTradeLicenseNo.Text = oRow["TRADELICENSENO"].ToString();
            txtTINNo.Text = oRow["TIN_NO"].ToString();
            txtRegistrationNo.Text = oRow["REGISTRATIONNO"].ToString();

            ddl_ACCOUNT_STATUS_ID.SelectedValue = oRow["ACCOUNT_STATUS_ID"].ToString();


            ddlBank.SelectedValue = oRow["BANK_ID"].ToString();

            //Populate Bank Branch
            ddlBankBranch.DataTextField = "Text";
            ddlBankBranch.DataValueField = "Value";
            ddlBankBranch.DataSource = BLLCommonEntity.GetBankBranch(ddlBank.SelectedValue).Data;
            ddlBankBranch.DataBind();

            ddlBankBranch.SelectedValue = oRow["BANK_BRANCH_ID"].ToString();
            ddl_BANK_ACC_TP_ID.SelectedValue = oRow["BANK_ACC_TP_ID"].ToString();
            txt_BANK_ACC_NO.Text = oRow["BANK_ACC_NO"].ToString();
            txtRoutingNo.Text = oRow["ROUTING_NO"].ToString();

            txt_INTRODUCER_CODE.Text = oRow["INTRODUCER_CODE"].ToString();

            txt_INTRODUCER_NAME.Text = oRow["INTRODUCER_NAME"].ToString();

            txt_INTRODUCER_CONTACT_NO.Text = oRow["INTRODUCER_CONTACT_NO"].ToString();

            txt_SPECIAL_INSTRUCTION.Text = oRow["SPECIAL_INSTRUCTION"].ToString();
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    protected void btn_Preview_Click(object sender, EventArgs e)
    {
        try
        {
            if (!String.IsNullOrEmpty(txtSearchInvestor.InvestorID))
            {
                GetAccountPersonalInfoByID(txtSearchInvestor.InvestorID);
            }
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }
}
