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

public partial class Company_Company_Sector_Information : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageTitle("Sector Information");
        Master.ShowPageNavigationURL("View List", "~/Company/Company_Sector_Information_List.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDropDownControlData();
            hdn_ID.Value = Request.QueryString["ID"];

            if (!String.IsNullOrEmpty(hdn_ID.Value))
            {
                ViewCompanySectorInfo(hdn_ID.Value, String.Empty);
            }
        }
    }

    private void GetDropDownControlData()
    {
        //Populate Company Sector type Information
        ddlSectorType.DataTextField = "Text";
        ddlSectorType.DataValueField = "Value";
        ddlSectorType.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.InstrumentSectorType).Data;
        ddlSectorType.DataBind();
    }

    private void ViewCompanySectorInfo(String ID,String SectorType)
    {
        BLLCompanyManagement BLLCompanyManagement = new BLLCompanyManagement();
        CResult CResult = new CResult();
        CResult = BLLCompanyManagement.GetCompanySectorInformation(ID, SectorType);

        if (CResult.IsSuccess)
        {
            SetCompanySectorInformation(CResult.Data);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void SetCompanySectorInformation(DataTable dtSectorInfo)
    {
        hdn_ID.Value = dtSectorInfo.Rows[0]["ID"].ToString();
        txtShortName.Text = dtSectorInfo.Rows[0]["SEC_S_NAME"].ToString();
        txtName.Text = dtSectorInfo.Rows[0]["SEC_F_NAME"].ToString();
        ddlSectorType.SelectedValue = dtSectorInfo.Rows[0]["INST_SECTOR_TYPE_ID"].ToString();
    }


    private Dictionary<String, String> GetCompanySectorInfo()
    {
        Dictionary<String, String> oParams = new Dictionary<string, string>();
        oParams.Add("ID", hdn_ID.Value);
        oParams.Add("SEC_S_NAME", txtShortName.Text);
        oParams.Add("SEC_F_NAME", txtName.Text);
        oParams.Add("INST_SECTOR_TYPE_ID", ddlSectorType.SelectedValue);
        return oParams;
    }

    private bool ValidateInsertCompanySectorInfo()
    {

        return true;
    }

    private void InsertCompanySectorInfo()
    {
        if (!ValidateInsertCompanySectorInfo()) return;

        BLLCompanyManagement BLLCompanyManagement = new BLLCompanyManagement();
        CResult CResult = new CResult();
        Dictionary<String, String> oParams = GetCompanySectorInfo();
        CResult = BLLCompanyManagement.InsertInstrumentSectorInfo(oParams);
        if (CResult.AffectedRows > 0)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void UpdateCompanySectorInfo()
    {
        if (!ValidateInsertCompanySectorInfo()) return;

        BLLCompanyManagement BLLCompanyManagement = new BLLCompanyManagement();
        CResult CResult = new CResult();
        Dictionary<String, String> oParams = GetCompanySectorInfo();
        CResult = BLLCompanyManagement.UpdateInstrumentSectorInfo(oParams);
        if (CResult.AffectedRows>0)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Updated.");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        InsertCompanySectorInfo();
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        UpdateCompanySectorInfo();
    }


    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        this.Page.Response.Redirect("../Company/Company_Sector_Information.aspx");
    }
}
