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
using System.Text;

public partial class Company_Company_Information_List : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("Add New", "~/Company/Company_Information.aspx");
    }
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetCompanyInformation();
        }
        //Delete Item
        if (String.Equals(Request.QueryString["Action"], "Delete") && !String.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            DeleteCompanyInformation(Request.QueryString["ID"].Trim());
        }
    }

    private void GetCompanyInformation()
    {
        BLLCompanyInformation BLLCompanyInformation = new BLLCompanyInformation();
        CResult CResult = new CResult();
        CResult = BLLCompanyInformation.GetCompanyInfo("0", txt_Company_Name.Text.Trim());
        if (CResult.IsSuccess)
        {
            dgvCompanyInformation.DataSource = CResult.Data;
            dgvCompanyInformation.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }
    
    #region Grid Events

    protected void dgvCompanyInformation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            StringBuilder st = new StringBuilder();

            st.Append("<b>Name: </b> " + drv["COMPANY_NAME"] + "<br /><br />"
                    + "<b>Securitycode: </b> " + drv["SECURITYCODE"] + "<br /><br />"
                    + "<b>ISIN: </b> " + drv["ISIN"] + "<br /><br />"
                    + "<b>Closing Price: </b> " + drv["CLOSING_PRICE"] + "<br /><br />"
                    + "<b>Sector Type: </b> " + drv["INST_SEC_F_NAME"] + "<br /><br />"
                    );
            e.Row.Cells[0].Text = st.ToString();

            st = new StringBuilder();
            st.Append("<b>Authorise Capital: </b> " + drv["AUTHORIZE_CAPITAL"].ToString() + "<br /><br />"
                 + "<b>Paid-Up Capital: </b> " + drv["PAID_UP_CAPITAL"].ToString() + "<br /><br />"
                 + "<b>Reserve Capital: </b> " + drv["RESERVE_CAPITAL"] + "<br /><br />"
                 + "<b>Face Value: </b> " + drv["FACE_VALUE"] + "<br /><br />"
                 + "<b>EPS: </b> " + drv["EPS"] + "<br /><br />"
                );
            e.Row.Cells[1].Text = st.ToString();

            e.Row.Cells[2].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='Company_Information.aspx?ID=" + drv["ID"].ToString() + "'>Edit</a>";
            e.Row.Cells[3].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='Company_Information_List.aspx?action=Delete&ID=" + drv["ID"].ToString() + "' onclick='return confirm(\"Are you sure you wish to delete this Data?\")'>Delete</a>";

        }
    }

    protected void dgvCompanyInformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvCompanyInformation.PageIndex = e.NewPageIndex;
        GetCompanyInformation();
    }

    #endregion Grid Events

    private void DeleteCompanyInformation(String strID)
    {
        BLLCompanyInformation BLLCompanyInformation1 = new BLLCompanyInformation();
        CResult CResult = new CResult();
        CResult = BLLCompanyInformation1.DeleteCompanyInfo(strID);

        if (CResult.IsSuccess)
        {
            GetCompanyInformation();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);

        }
    }


    protected void btn_Search_Click(object sender, EventArgs e)
    {
        GetCompanyInformation();
    }
    
}
