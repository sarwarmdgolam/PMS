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

public partial class Company_Company_Sector_Information_List : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;

    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("Add New", "~/Company/Company_Sector_Information.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDropDownControlData();
            GetCompanySectorInformation();
        }
    }


    private void GetDropDownControlData()
    {
        //Populate Company Sector type Information
        ddlMarketSectorType.DataTextField = "Text";
        ddlMarketSectorType.DataValueField = "Value";
        ddlMarketSectorType.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.InstrumentSectorType).Data;
        ddlMarketSectorType.DataBind();
    }

    protected void ddlMarketSector_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        if (ddlMarketSectorType.SelectedIndex > -1)
            GetCompanySectorInformation();
    }

    #region Grid Events

    protected void dgvMarketSector_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (this.Page_Update)
                e.Row.Cells[3].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='Company_Sector_Information.aspx?ID=" + drv["ID"].ToString() + "'>Edit</a>";
            else
                e.Row.Cells[3].Text = "&nbsp;";

            if (this.Page_Delete)
                e.Row.Cells[4].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='Company_Sector_Information_List.aspx?action=Delete&ID=" + drv["ID"].ToString() + "' onclick='return confirm(\"Are you sure you wish to delete this Data?\")'>Delete</a>";
            else
                e.Row.Cells[4].Text = "&nbsp;";

        }
    }

    protected void dgvMarketSector_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       
        dgvMarketSector.PageIndex = e.NewPageIndex;
        GetCompanySectorInformation();
    }

    private void GetCompanySectorInformation()
    {
        BLLCompanyManagement BLLCompanyManagement = new BLLCompanyManagement();
        CResult CResult = new CResult();
        CResult = BLLCompanyManagement. GetCompanySectorInformation("0", ddlMarketSectorType.SelectedValue);
        if (CResult.IsSuccess)
        {
            dgvMarketSector.DataSource = CResult.Data;
            dgvMarketSector.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);

        }
    }


    #endregion Grid Events
}
