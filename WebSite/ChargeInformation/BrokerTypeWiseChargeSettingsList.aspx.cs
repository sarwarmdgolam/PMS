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

public partial class ChargeInformation_BrokerTypeWiseChargeSettingsList : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("Add New", "~/ChargeInformation/BrokerTypeWiseChargeSettings.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetGridviewControlData();
        }
        //Delete Item
        if (String.Equals(Request.QueryString["Action"], "Delete") && !String.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            DeleteBrokerDefaultChargeInfo(Request.QueryString["ID"].Trim());
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetGridviewControlData();
    }

    private void DeleteBrokerDefaultChargeInfo(String ID )
    {
        CResult CResult = new CResult();
        BLLBrokerTypeWiseChargeSettings BLLBrokerTypeWiseChargeSettings = new BLLBrokerTypeWiseChargeSettings();
        CResult = BLLBrokerTypeWiseChargeSettings.DeleteBrokerTypewiseChargeInfo(ID);

        if (CResult.AffectedRows > 0)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Deleted.");

            //Clear gridview data
            GetGridviewControlData();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }


    private void GetGridviewControlData()
    {
        BLLBrokerTypeWiseChargeSettings BLLBrokerTypeWiseChargeSettings = new BLLBrokerTypeWiseChargeSettings();
        CResult CResult = new CResult();
        CResult = BLLBrokerTypeWiseChargeSettings.GetBrokerTypewiseChargeInfo("0", txtSearchText.Text.Trim());
        if (CResult.IsSuccess)
        {
            dgvChargeInformation.DataSource = CResult.Data;
            dgvChargeInformation.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }
    protected void dgvChargeInformation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (Page_Read)
                e.Row.Cells[9].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='BrokerTypeWiseChargeSettings.aspx?ID=" + drv["ID"].ToString() + "'>Edit</a>";
            else
                e.Row.Cells[9].Text = "&nbsp;";

            if (Page_Delete)
                e.Row.Cells[10].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='BrokerTypeWiseChargeSettingsList.aspx?action=Delete&ID=" + drv["ID"].ToString() + "' onclick='return confirm(\"Are you sure you wish to delete this Data?\")'>Delete</a>";
            else
                e.Row.Cells[10].Text = "&nbsp;";
        }
    }
    protected void dgvChargeInformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvChargeInformation.PageIndex = e.NewPageIndex;
        GetGridviewControlData();
    }
}
