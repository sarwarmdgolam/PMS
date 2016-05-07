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
using BLLTradeManagement;

public partial class TradeManagement_TraderInfoList : System.Web.UI.Page
{
    bool Trader_Edit = true;
    bool Trader_Delete = true;

    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageTitle ( "Trader info");
        Master.ShowPageNavigationURL("Add New", "~/TradeManagement/TraderInfo.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetTraderInfo();
        }
    }

    private void GetTraderInfo()
    {
        BLLTraderInfo BLLTraderInfo1 = new BLLTraderInfo();
        CResult CResult = new CResult();
        CResult = BLLTraderInfo1.GetTraderInfo("0", txtTraderCode.Text);
        if (CResult.IsSuccess)
        {
            gvTraderInfo.DataSource = CResult.Data;
            gvTraderInfo.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    protected void gvTraderInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            string st;

            if (this.Trader_Edit)
            {
                e.Row.Cells[2].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='TraderInfo.aspx?ID=" + drv["ID"].ToString() + "'>Edit</a>";
            }

            if (this.Trader_Delete)
            {
                e.Row.Cells[3].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='TraderInfoList.aspx?action=Delete&ID=" + drv["ID"].ToString() + "' onclick='return confirm(\"Are you sure you wish to delete this record?\")'>Delete</a>";
            }

        }
    }

    protected void gvTraderInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTraderInfo.PageIndex = e.NewPageIndex;
        GetTraderInfo();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetTraderInfo();
    }
}
