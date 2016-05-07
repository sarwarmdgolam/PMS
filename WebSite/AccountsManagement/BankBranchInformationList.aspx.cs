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
using BLLAccountsManagement;

public partial class AccountsManagement_BankBranchInformationList : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;

    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("Add New", "~/AccountsManagement/BankBranchInformation.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDropDownControlData();
        }
    }


    private void GetDropDownControlData()
    {
        //Populate Company Sector type Information
        ddlBank.DataTextField = "Text";
        ddlBank.DataValueField = "Value";
        ddlBank.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.Bank).Data;
        ddlBank.DataBind();
    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        GetBankBranchInformation();
    }

    

    #region Grid Events

    protected void dgvBankBranch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (this.Page_Update)
                e.Row.Cells[2].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='BankBranchInformation.aspx?ID=" + drv["ID"].ToString() + "'>Edit</a>";
            else
                e.Row.Cells[2].Text = "&nbsp;";

            if (this.Page_Delete)
                e.Row.Cells[3].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='BankBranchInformationList.aspx?action=Delete&ID=" + drv["ID"].ToString() + "' onclick='return confirm(\"Are you sure you wish to delete this Data?\")'>Delete</a>";
            else
                e.Row.Cells[3].Text = "&nbsp;";

        }
    }

    protected void dgvBankBranch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvBankBranch.PageIndex = e.NewPageIndex;
        GetBankBranchInformation();
    }

    private void GetBankBranchInformation()
    {
        BLLBankManagement BLLBankManagement1 = new BLLBankManagement();
        CResult CResult = new CResult();
        CResult = BLLBankManagement1.GetBankBranchInfo("0", ddlBank.SelectedValue);
        if (CResult.IsSuccess)
        {
            dgvBankBranch.DataSource = CResult.Data;
            dgvBankBranch.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);

        }
    }


    #endregion Grid Events
}
