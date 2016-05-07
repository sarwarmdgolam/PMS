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
using Model;
using Common;
using System.Text;

public partial class Investor_Account_Open_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetClearMessage();
            GetInvestorInfo();
        }
    }


    private void SetClearMessage()
    {
        this.divErrMesg.Visible = false;
        this.divInfoMsg.Visible = false;
        lblErrMsg.Text = String.Empty;
    }

    private void GetInvestorInfo()
    {

        String Investor_code = String.Empty;
        String Name = String.Empty;
        String Bo_Code = String.Empty;

        if (String.Equals(ddl_Search_By.SelectedValue, "InvestorCode"))
            Investor_code = txt_Search_Text.Text.Trim();
        else if (String.Equals(ddl_Search_By.SelectedValue, "InvestorName"))
            Name = txt_Search_Text.Text.Trim();
        else if (String.Equals(ddl_Search_By.SelectedValue, "BOCode"))
            Bo_Code = txt_Search_Text.Text.Trim();


        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        CResult CResult = new CResult();
        CResult = BLLAccountOpen.GetAccountInfo("0", Investor_code, Name, Bo_Code);
        if (CResult.IsSuccess)
        {
            gv_Account_List.DataSource = CResult.Data;
            gv_Account_List.DataBind();
        }
        else
        {
            divErrMesg.Visible = true;
            lblErrMsg.Text = CResult.Message;
        }
    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        GetInvestorInfo();
    }

    protected void gv_Account_List_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            StringBuilder   st = new StringBuilder();

            //Investor
            if (string.IsNullOrEmpty(drv["INVESTOR_CODE"].ToString()))
                st.Append("<b>Investor Code:</b> N/A<br /><br />");
            else
                st.Append( "<b>Investor Code:</b> " + drv["INVESTOR_CODE"].ToString() + "<br /><br />");

            if (string.IsNullOrEmpty(drv["BO_CODE"].ToString()))
                 st.Append( "<b>BO Code:</b> N/A<br /><br />");
            else
                 st.Append( "<b>BO Code:</b> " + drv["BO_CODE"].ToString() + "<br /><br />");

            if (string.IsNullOrEmpty(drv["FIRST_JOIN_HOLDER_NAME"].ToString()))
                 st.Append( "<b>First Joint Holder:</b> N/A<br /><br />");
            else
                 st.Append( "<b>First Joint Holder:</b> " + drv["FIRST_JOIN_HOLDER_NAME"].ToString() + "<br /><br />");
            e.Row.Cells[0].Text = st.ToString();

            //Accounts Details
            st = new StringBuilder();
            if (string.IsNullOrEmpty(drv["SEC_JOIN_HOLDER_NAME"].ToString()))
                 st.Append( "<b>Second Joint Holder:</b> N/A<br /><br />");
            else
                 st.Append( "<b>Second Joint Holder:</b> " + drv["SEC_JOIN_HOLDER_NAME"].ToString() + "<br /><br />");
            if (string.IsNullOrEmpty(drv["BIRTH_DT"].ToString()))
                 st.Append( "<b>Date of Birth:</b> N/A<br /><br />");
            else
                 st.Append( "<b>Date of Birth:</b> " + drv["BIRTH_DT"].ToString() + "<br /><br />");
            if (string.IsNullOrEmpty(drv["GENDERNAME"].ToString()))
                 st.Append( "<b>Gender:</b> N/A<br /><br />");
            else
                 st.Append("<b>Gender:</b> " + drv["GENDERNAME"].ToString() + "<br /><br />");
            if (string.IsNullOrEmpty(drv["FATHER_NAME"].ToString()))
                 st.Append( "<b>Father/Husband:</b> N/A<br /><br />");
            else
                 st.Append( "<b>Father/Husband:</b> " + drv["FATHER_NAME"].ToString() + "<br /><br />");
            if (string.IsNullOrEmpty(drv["MOTHER_NAME"].ToString()))
                 st.Append( "<b>Mother's Name:</b> N/A<br /><br />");
            else
                 st.Append( "<b>Mother's Name:</b> " + drv["MOTHER_NAME"].ToString() + "<br /><br />");

            if (string.IsNullOrEmpty(drv["BROKERBRANCHNAME"].ToString()))
                 st.Append( "<b>Operate Branch:</b> N/A<br /><br />");
            else
                 st.Append( "<b>Operate Branch:</b> " + drv["BROKERBRANCHNAME"].ToString() + "<br /><br />");

            if (string.IsNullOrEmpty(drv["ACCOUNTTYPENAME"].ToString()))
                 st.Append( "<b>Account Type:</b> N/A<br /><br />");
            else
                 st.Append( "<b>Account Type:</b> " + drv["ACCOUNTTYPENAME"].ToString() + "<br /><br />");

             if (string.IsNullOrEmpty(drv["OPERATIONTYPENAME"].ToString()))
                 st.Append("<b>Operation Type:</b> N/A<br /><br />");
             else
                 st.Append("<b>Operation Type:</b> " + drv["OPERATIONTYPENAME"].ToString() + "<br /><br />");
            
            e.Row.Cells[1].Text = st.ToString();

            //Contact Details
            st = new StringBuilder();
            if (string.IsNullOrEmpty(drv["PHONE"].ToString()))
                 st.Append( "<b>Phone:</b> N/A<br /><br />");
            else
                 st.Append( "<b>Phone:</b> " + drv["PHONE"].ToString() + "<br /><br />");

            if (string.IsNullOrEmpty(drv["MOBILE"].ToString()))
                 st.Append( "<b>Mobile No.:</b> N/A<br /><br />");
            else
                 st.Append( "<b>Mobile No:</b> " + drv["MOBILE"].ToString() + "<br /><br />");

            if (string.IsNullOrEmpty(drv["FAX"].ToString()))
                 st.Append( "<b>Fax:</b> N/A<br /><br />");
            else
                 st.Append( "<b>Fax:</b> " + drv["FAX"].ToString() + "<br /><br />");

            if (string.IsNullOrEmpty(drv["EMAIL"].ToString()))
                 st.Append( "<b>Email:</b> N/A<br /><br />");
            else
                 st.Append( "<b>Email:</b> " + drv["EMAIL"].ToString() + "<br /><br />");

            if (string.IsNullOrEmpty(drv["BANKNAME"].ToString()))
                 st.Append( "<b>Bank Name:</b> N/A<br /><br />");
            else
                 st.Append( "<b>Bank Name:</b> " + drv["BANKNAME"].ToString() + "<br /><br />");

            if (string.IsNullOrEmpty(drv["BRANCHNAME"].ToString()))
                 st.Append( "<b>Branch Name:</b> N/A<br /><br />");
            else
                 st.Append( "<b>Branch Name:</b> " + drv["BRANCHNAME"].ToString() + "<br /><br />");

            e.Row.Cells[2].Text = st.ToString();


            //Edit
            e.Row.Cells[3].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='../Investor/Account_Open_2ND.aspx?ID=" + drv["ID"].ToString() + "'>Edit</a>";
            
            //Delete
            e.Row.Cells[4].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='../Investor/Account_Open_List_2ND.aspx?action=Delete&ID=" + drv["ID"].ToString() + "' onclick='return confirm(\"Are you sure you wish to delete this record?\")'>Delete</a>";
        }
    }

    protected void gv_Account_List_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Account_List.PageIndex = e.NewPageIndex;
        GetInvestorInfo();
    }
}
