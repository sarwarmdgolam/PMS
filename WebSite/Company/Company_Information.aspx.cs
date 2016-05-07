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

public partial class Company_Company_Information : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;

    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("View List", "~/Company/Company_Information_List.aspx");
    }

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDropDownControlData();
            hdn_ID.Value =Request.QueryString["ID"];

            if (!String.IsNullOrEmpty(hdn_ID.Value))
            {
                GetCompanyInfo(hdn_ID.Value, String.Empty);
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.UPDATE);
            }
            else
            {
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.INSERT);
            }
        }
    } 
    #endregion

    #region Methods

    private void ControlSelectionMode(Common.ApplicationEnums.UIOperationMode Mode)
    {
        switch (Mode)
        {
            case Common.ApplicationEnums.UIOperationMode.INSERT:
                btn_Save.Enabled = true;
                btn_Update.Enabled = false;
                break;
            case Common.ApplicationEnums.UIOperationMode.UPDATE:
                btn_Save.Enabled = false;
                btn_Update.Enabled = true;
                break;
            case Common.ApplicationEnums.UIOperationMode.REFRESH:
                btn_Save.Enabled = false;
                btn_Update.Enabled = false;
                break;
        }
    }


    private void GetDropDownControlData()
    {
        //Populate Company Information
        ddlInstrumentSector.DataTextField = "Text";
        ddlInstrumentSector.DataValueField = "Value";
        ddlInstrumentSector.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.InstrumentSectorInfo).Data;
        ddlInstrumentSector.DataBind();

        //Populate Security Exchange
        ddlInstrumentType.DataTextField = "Text";
        ddlInstrumentType.DataValueField = "Value";
        ddlInstrumentType.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.InstrumentType).Data;
        ddlInstrumentType.DataBind();

        //Populate Transaction Mode
        ddlCategory.DataTextField = "Text";
        ddlCategory.DataValueField = "Value";
        ddlCategory.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.Category).Data;
        ddlCategory.DataBind();

    }

    private Dictionary<String, String> GetCompanyInfo()
    {
        Dictionary<String, String> oParams = new Dictionary<string, string>();
        oParams.Add("ID", hdn_ID.Value);
        oParams.Add("COMPANY_NAME", txt_Company_Name.Text);
        oParams.Add("ISIN", txt_ISIN.Text);
        oParams.Add("SECURITYCODE", txt_Security_Code.Text);
        oParams.Add("CLOSING_PRICE", txt_Closing_Price.Text);
        oParams.Add("CATEGORY_ID", ddlCategory.SelectedValue );
        oParams.Add("INSTRUMENT_SECTOR_ID", ddlInstrumentSector.SelectedValue);
        oParams.Add("AUTHORIZE_CAPITAL", txtAuthorizeCapital.Text);
        oParams.Add("PAID_UP_CAPITAL", txtPaidUPCapital.Text);
        oParams.Add("RESERVE_CAPITAL", txtReserveCapital.Text);
        oParams.Add("INST_TYPE_ID", ddlInstrumentType.SelectedValue );
        oParams.Add("FACE_VALUE", txtFaceValue.Text );
        oParams.Add("IS_MARGINABLE", chkMarginable.Checked.ToString());
        oParams.Add("EPS",txtEPS.Text);
        oParams.Add("NAV", txtNAV.Text);
        oParams.Add("IS_OTC", chkIsOTC.Checked.ToString());
        oParams.Add("IS_ACTIVE",chkIsActive.Checked.ToString());

        return oParams;
    }

    private void InsertCompanyInfo()
    {
        if (!ValidateInsertCompanyInfo()) return;


        BLLCompanyInformation BLLCompanyInformation = new BLLCompanyInformation();
        CResult CResult = new CResult();
        Dictionary<String, String> oParams = GetCompanyInfo();
        CResult = BLLCompanyInformation.InsertCompanyInfo(oParams);
        if (CResult.IsSuccess)
        {
            ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.REFRESH);
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton,"Successfully Saved.");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void UpdateCompanyInfo()
    {
        if (!ValidateUpdateCompanyInfo()) return;

        BLLCompanyInformation BLLCompanyInformation = new BLLCompanyInformation();
        CResult CResult = new CResult();
        Dictionary<String, String> oParams = GetCompanyInfo();
        CResult = BLLCompanyInformation.UpdateCompanyInfo(oParams);
        if (CResult.IsSuccess)
        {
            ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.REFRESH);
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Updated.");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void SetCompanyInfo(DataTable CompanyInfo)
    {
        try
        {
            hdn_ID.Value = CompanyInfo.Rows[0]["ID"].ToString();
            txt_Company_Name.Text = CompanyInfo.Rows[0]["COMPANY_NAME"].ToString();
            txt_Security_Code.Text = CompanyInfo.Rows[0]["SECURITYCODE"].ToString();
            txt_ISIN.Text = CompanyInfo.Rows[0]["ISIN"].ToString();
            txt_Closing_Price.Text = CompanyInfo.Rows[0]["CLOSING_PRICE"].ToString();
            ddlInstrumentSector.SelectedValue = CompanyInfo.Rows[0]["INSTRUMENT_SECTOR_ID"].ToString();
            txtAuthorizeCapital.Text = CompanyInfo.Rows[0]["AUTHORIZE_CAPITAL"].ToString();
            txtPaidUPCapital.Text = CompanyInfo.Rows[0]["PAID_UP_CAPITAL"].ToString();
            txtReserveCapital.Text = CompanyInfo.Rows[0]["RESERVE_CAPITAL"].ToString();
            ddlInstrumentType.SelectedValue = CompanyInfo.Rows[0]["INST_TYPE_ID"].ToString();
            txtFaceValue.Text = CompanyInfo.Rows[0]["FACE_VALUE"].ToString();
            ddlCategory.SelectedValue = CompanyInfo.Rows[0]["CATEGORY_ID"].ToString();
            txtEPS.Text = CompanyInfo.Rows[0]["EPS"].ToString();
            txtNAV.Text = CompanyInfo.Rows[0]["NAV"].ToString();
            chkIsActive.Checked = TypeCasting.ToBoolean(CompanyInfo.Rows[0]["IS_ACTIVE"].ToString());
            chkIsOTC.Checked = TypeCasting.ToBoolean(CompanyInfo.Rows[0]["IS_OTC"].ToString());
            chkMarginable.Checked = TypeCasting.ToBoolean(CompanyInfo.Rows[0]["IS_MARGINABLE"].ToString());
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    private void GetCompanyInfo(String ID,String Name)
    {
        BLLCompanyInformation BLLCompanyInformation = new BLLCompanyInformation();
        CResult CResult = new CResult();
        CResult = BLLCompanyInformation.GetCompanyInfo(ID, Name);

        if (CResult.IsSuccess)
        {
            SetCompanyInfo(CResult.Data);   
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private bool ValidateInsertCompanyInfo()
    {
        if (!Page.IsValid) return false;

        if (!Page_Create)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Warning, "Dont have enough Permission.");
            return false;
        }
        return true;
    }

    private bool ValidateUpdateCompanyInfo()
    {
        if (!Page.IsValid) return false;

        if (!Page_Update)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Warning, "Dont have enough Permission.");
            return false;
        }
        return true;
    }
    #endregion

    #region Control Events
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        InsertCompanyInfo();
    } 
    #endregion

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        UpdateCompanyInfo();
    }
    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        this.Page.Response.Redirect("../Company/Company_Information.aspx");
    }
}
