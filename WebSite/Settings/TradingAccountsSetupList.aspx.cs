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

public partial class Settings_TradingAccountsSetupList : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("Add New", "~/Settings/TradingAccountsSetup.aspx");
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadEntity();
        }
    }

    private void LoadEntity()
    {
        BLLTradingAccountType BLLTradingAccountType = new BLLTradingAccountType();
        CResult CResult = new CResult();
        CResult = BLLTradingAccountType.GetTradingAccountType("0");
        if (CResult.IsSuccess)
        {
            gvEntity.DataSource = CResult.Data;
            gvEntity.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }


    #region Grid Events

    protected void gvEntity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            e.Row.Cells[2].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='TradingAccountsSetup.aspx?ID=" + drv["ID"].ToString() + "'>Edit</a>";
            e.Row.Cells[3].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='TradingAccountsSetupList.aspx?action=Delete&ID=" + drv["ID"].ToString() + "' onclick='return confirm(\"Are you sure you wish to delete this Data?\")'>Delete</a>";
        }
    }

    protected void gvEntity_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEntity.PageIndex = e.NewPageIndex;
        LoadEntity();
    }

    #endregion Grid Events

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        //LinkButton lnkDelete = sender as LinkButton;
        //string CompanyInfoID = Convert.ToString(gvEntity.DataKeys[((GridViewRow)lnkDelete.NamingContainer).RowIndex].Value);
        //CompanyInformationManagement objCompanyManagement = new CompanyInformationManagement();
        //int returnValue = Convert.ToInt32(objCompanyManagement.DeleteCompanyInfo(Convert.ToInt32(CompanyInfoID), SessionManagement.LoggedInUserId));
        //GetCompanyInformation();
    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        LoadEntity(); 
    }
}
