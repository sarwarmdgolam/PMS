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

public partial class Investor_AuthorizedSignatoryList : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;

    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageTitle("Authorized signatory");
        Master.ShowPageNavigationURL("Add new", "~/Investor/AuthorizedSignatory.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hdnInvestor_ID.Value = "0";
            GetAuthorizedSignatoryList();
        }
    }
    
    private void GetAuthorizedSignatoryList()
    {
        CResult CResult = new CResult();
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        CResult = BLLAccountOpen.GetAuthorizedSignature(hdnInvestor_ID.Value);
        if (CResult.IsSuccess)
        {
            gvNominee.DataSource = CResult.Data;
            gvNominee.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    protected void nominee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            string st = "";
            if (this.Page_Update)
                e.Row.Cells[4].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='AuthorizedSignatory.aspx?id=" + drv["ID"].ToString() + "'>Edit</a>";
            else
                e.Row.Cells[4].Text = "&nbsp;";

            if (this.Page_Delete)
                e.Row.Cells[5].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='AuthorizedSignatoryList.aspx?action=Delete&id=" + drv["ID"].ToString() + "' onclick='return confirm(\"Are you sure you wish to delete this record?\")'>Delete</a>";
            else
                e.Row.Cells[5].Text = "&nbsp;";
        }
    }
    protected void nominee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //this.lblErrMsg.Text = "";
        //this.lblMsg.Text = "";
        //this.divErrMesg.Visible = false;
        //this.divInfoMsg.Visible = false;

        //gvNominee.PageIndex = e.NewPageIndex;
        //LoadNomineeGrid();
    }
    protected void btn_Preview_Click(object sender, EventArgs e)
    {
        try
        {
            if (!String.IsNullOrEmpty(txtSearchInvestor.InvestorID))
            {
                hdnInvestor_ID.Value = txtSearchInvestor.InvestorID;
                GetAuthorizedSignatoryList();
            }
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }
}
