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

public partial class TradeManagement_NonTradingDayList : System.Web.UI.Page
{
    bool NonTradingDay_Edit = true;
    bool NonTradingDay_Delete = true;

    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("Add New", "~/TradeManagement/NonTradingDay.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Text = TypeCasting.DateToString(Util.SystemDate().AddDays(-7));
            txtToDate.Text = TypeCasting.DateToString(Util.SystemDate().AddDays(7));
            GetDropDownControlData();
            GetNonTradingDayInfo();
        }
    }

    private void GetDropDownControlData()
    {
        //Populate Security Exchange
        ddlSecurityMarket.DataTextField = "Text";
        ddlSecurityMarket.DataValueField = "Value";
        ddlSecurityMarket.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.SecurityExchange).Data;
        ddlSecurityMarket.DataBind();

        //Populate Non Tradin Day Type
        ddlNonTradingType.DataTextField = "Text";
        ddlNonTradingType.DataValueField = "Value";
        ddlNonTradingType.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.NonTradingDayType).Data;
        ddlNonTradingType.DataBind();

    }

    private void GetNonTradingDayInfo()
    {
        BLLNONTradingDay BLLNONTradingDay = new BLLNONTradingDay();
        CResult CResult = new CResult();
        CResult = BLLNONTradingDay.GetNonTradingDay("0",ddlSecurityMarket.SelectedValue,ddlNonTradingType.SelectedValue,txtFromDate.Text,txtToDate.Text);
        if (CResult.IsSuccess)
        {
            gvNonTradingDay.DataSource = CResult.Data;
            gvNonTradingDay.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    protected void gvNonTradingDay_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            string st;

            if (this.NonTradingDay_Edit)
            {
                e.Row.Cells[5].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='NonTradingDay.aspx?ID=" + drv["ID"].ToString() + "'>Edit</a>";
            }

            if (this.NonTradingDay_Delete)
            {
                e.Row.Cells[6].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='NonTradingDayList.aspx?action=Delete&ID=" + drv["ID"].ToString() + "' onclick='return confirm(\"Are you sure you wish to delete this record?\")'>Delete</a>";
            }

        }
    }
    
    protected void gvNonTradingDay_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvNonTradingDay.PageIndex = e.NewPageIndex;
        GetNonTradingDayInfo();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetNonTradingDayInfo();
    }
}
