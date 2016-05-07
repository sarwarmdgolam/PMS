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

public partial class AccountTransaction_Cash_Chq_Payment_List : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("Add New", "~/AccountTransaction/Cash_Chq_Payment.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtToDate.Text = this.txtFromDate.Text = String.Format("{0:dd-MMM-yyyy}", Util.SystemDate());
            GetCashChqPayment();
        }

        //Delete Item
        if (String.Equals(Request.QueryString["Action"], "Delete") && !String.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            DeleteCashChqPayment(Request.QueryString["ID"].Trim());
        }
    }

    private void DeleteCashChqPayment(String ID)
    {
        BLLCashChqPayment BLLCashChqPayment = new BLLCashChqPayment();
        CResult CResult = new CResult();
        CResult = BLLCashChqPayment.DeleteCashChqPaymentInfo(ID);

        if (CResult.AffectedRows>0)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");

            //Reload
            GetCashChqPayment();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);

        }
    }



    private void GetCashChqPayment()
    {
        BLLCashChqPayment BLLCashChqPayment = new BLLCashChqPayment();
        CResult CResult = new CResult();
        CResult = BLLCashChqPayment.GetCashChqPaymentInfo(String.Empty,hdnInvestorId.Value, String.Empty, txtFromDate.Text, txtToDate.Text);

        if (CResult.IsSuccess)
        {
            gvCashChqPayment.DataSource = CResult.Data;
            gvCashChqPayment.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);

        }
    }

    protected void gvCashChqPayment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                string st;
                st = "";
                if (string.IsNullOrEmpty(drv["CHEQUE_NO"].ToString()))
                    st += "<b>Number:</b> N/A<br /><br />";
                else
                    st += "<b>Number:</b> " + drv["CHEQUE_NO"].ToString() + "<br /><br />";

                if (string.IsNullOrEmpty(drv["CHEQUE_DT"].ToString()))
                    st += "<b>Date:</b> N/A<br /><br />";
                else
                    st += "<b>Date:</b> " + drv["CHEQUE_DT"].ToString() + "<br /><br />";
                e.Row.Cells[1].Text = st;


                st = "";
                if (string.IsNullOrEmpty(drv["BANK_F_NAME"].ToString()))
                    st += "<b>Bank:</b> N/A<br /><br />";
                else
                    st = "<b>Bank:</b> " + drv["BANK_F_NAME"].ToString() + "<br /><br />";

                if (string.IsNullOrEmpty(drv["BANK_BRANCH"].ToString()))
                    st += "<b>Branch:</b> N/A<br /><br />";
                else
                    st += "<b>Branch:</b> " + drv["BANK_BRANCH"].ToString() + "<br /><br />";

                e.Row.Cells[2].Text = st;
                st = "";

                if (string.IsNullOrEmpty(drv["BROKER_BRANCH"].ToString()))
                    st += "<b>Br.Branch:</b> N/A<br /><br />";
                else
                    st += "<b>Br.Branch:</b> " + drv["BROKER_BRANCH"].ToString() + "<br /><br />";

                if (string.IsNullOrEmpty(drv["TRANSACTION_DATE"].ToString()))
                    st += "<b>Pay.Date:</b> N/A<br /><br />";
                else
                    st += "<b>Pay.Date:</b> " + drv["TRANSACTION_DATE"].ToString() + "<br /><br />";
                e.Row.Cells[3].Text = st;

                st = "";
                if (string.IsNullOrEmpty(drv["GENERAL_LEDGER_NAME"].ToString()))
                    st = "N/A";
                else
                    st = drv["GENERAL_LEDGER_NAME"].ToString();
                e.Row.Cells[4].Text = st;

                e.Row.Cells[5].Text = Convert.ToDecimal(string.IsNullOrEmpty(drv["AMOUNT"].ToString()) ? "0" : drv["AMOUNT"].ToString()).ToString("N2");
               
                if ( drv["AUTH_STATUS"].ToString() == "1")
                    e.Row.Cells[6].Text = "<b>Approved</b>";
                else
                    e.Row.Cells[6].Text = "<b>Unapproved</b>";

                if (this.Page_Update)
                {
                    if (!string.IsNullOrEmpty(drv["AUTH_STATUS"].ToString()) && drv["AUTH_STATUS"].ToString() != "1")
                        e.Row.Cells[7].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='Cash_Chq_Payment.aspx?ID=" + drv["ID"].ToString() + "'>Edit</a>";
                    else
                        e.Row.Cells[7].Text = "&nbsp;";
                }
                else
                    e.Row.Cells[7].Text = "&nbsp;";

                if (this.Page_Delete)
                {
                    if (!string.IsNullOrEmpty(drv["AUTH_STATUS"].ToString()) && drv["AUTH_STATUS"].ToString() != "1")
                        e.Row.Cells[8].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='Cash_Chq_Payment_List.aspx?action=Delete&ID=" + drv["ID"].ToString() + "' onclick='return confirm(\"Are you sure to delete this record?\")'>Delete</a>";
                    else
                        e.Row.Cells[8].Text = "&nbsp;";
                }
                else
                    e.Row.Cells[8].Text = "&nbsp;";

            }
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);

        }
    }
   
    protected void btnFilterData_Click(object sender, EventArgs e)
    {
        GetCashChqPayment();
    }
    protected void gvCashChqPayment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      
        gvCashChqPayment.PageIndex = e.NewPageIndex;
    }

    protected void txtInvestorCode_TextChanged(object sender, EventArgs e)
    {
        String Investor_Code = ((TextBox)sender).Text.Trim();
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        BLLAccountOpen.GetInvestorNameByCode(ref Investor_Code);
        hdnInvestorId.Value = Investor_Code.Split('=')[0];
        txtInvestorName.Text = Investor_Code.Split('=')[1];
    }
}
