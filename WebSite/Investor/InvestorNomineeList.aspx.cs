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

public partial class Investor_InvestorNomineeList : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetClearMessage();
            GetInvestorNomineeList();
        }
    }
    private void SetClearMessage()
    {
        this.divErrMesg.Visible = false;
        this.divInfoMsg.Visible = false;
        lblErrMsg.Text = String.Empty;
        lblMsg.Text = String.Empty;
    }

    private void GetInvestorNomineeList()
    {
        CResult CResult = new CResult();
        BLLInvestorNominee BLLInvestorNominee = new BLLInvestorNominee();
        CResult = BLLInvestorNominee.GetInvestorNomineeInfo("0","0" );
        if (CResult.IsSuccess)
        {
            gvNominee.DataSource = CResult.Data;
            gvNominee.DataBind();
        }
        else
        {
            divErrMesg.Visible = true;
            lblErrMsg.Text = CResult.Message;
        }
    }

    protected void nominee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataTable dtRelation;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            string st = "";
            if (this.Page_Update)
                e.Row.Cells[2].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='InvestorNominee.aspx?id=" + drv["ID"].ToString() + "'>Edit</a>";
            else
                e.Row.Cells[2].Text = "&nbsp;";

            if (this.Page_Delete)
                e.Row.Cells[3].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='InvestorNomineeList.aspx?action=Delete&id=" + drv["ID"].ToString() + "' onclick='return confirm(\"Are you sure you wish to delete this record?\")'>Delete</a>";
            else
                e.Row.Cells[3].Text = "&nbsp;";
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
}
