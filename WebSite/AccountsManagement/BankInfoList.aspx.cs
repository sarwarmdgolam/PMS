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
using BLLAccountsManagement;

public partial class AccountsManagement_BankInfoList : System.Web.UI.Page
{
    bool Trader_Edit = true;
    bool Trader_Delete = true;

    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageTitle ( "Bank info");
        Master.ShowPageNavigationURL("Add New", "~/AccountsManagement/BankInfo.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetBankInfo();
        }
    }

    private void GetBankInfo()
    {
        BLLBankManagement BLLBankManagement1 = new BLLBankManagement();
        CResult CResult = new CResult();
        CResult = BLLBankManagement1.GetBankInfo("0");
        if (CResult.IsSuccess)
        {
            gvBankInfo.DataSource = CResult.Data;
            gvBankInfo.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    protected void gvBankInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            string st;

            if (this.Trader_Edit)
            {
                e.Row.Cells[2].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='BankInfo.aspx?ID=" + drv["ID"].ToString() + "'>Edit</a>";
            }

            if (this.Trader_Delete)
            {
                e.Row.Cells[3].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='BankInfoList.aspx?action=Delete&ID=" + drv["ID"].ToString() + "' onclick='return confirm(\"Are you sure you wish to delete this record?\")'>Delete</a>";
            }

        }
    }

    protected void gvBankInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBankInfo.PageIndex = e.NewPageIndex;
        GetBankInfo();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetBankInfo();
    }
}
