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

public partial class Transaction_Cash_Chq_Collection_List : System.Web.UI.Page
{

    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;
    
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("Add New", "~/AccountTransaction/Cash_Chq_Collection.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtToDate.Text = this.txtFromDate.Text = String.Format("{0:dd-MMM-yyyy}", Util.SystemDate());
            GetCashChqCollection();
        }

        //Delete Item
        if (String.Equals(Request.QueryString["Action"], "Delete") && !String.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            DeleteCashChqCollection(Request.QueryString["ID"].Trim());
        }
    }

  

    private void DeleteCashChqCollection(String ID)
    {
        BLLCashChqCollection BLLCashChqCollection = new BLLCashChqCollection();
        CResult CResult = new CResult();
        CResult = BLLCashChqCollection.DeleteCashChqInfo(ID);

        if (CResult.IsSuccess)
        {
            GetCashChqCollection();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);

        }
    }

    private void GetCashChqCollection()
    {
        BLLCashChqCollection BLLCashChqCollection = new BLLCashChqCollection();
        CResult CResult = new CResult();
        CResult = BLLCashChqCollection.GetCashChqCollectionInfo(String.Empty,hdnInvestorId.Value, String.Empty, txtFromDate.Text, txtToDate.Text);

        if (CResult.IsSuccess)
        {
            gvCashCheque.DataSource = CResult.Data;
            gvCashCheque.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);

        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }

    protected void btnVoucherList_Click(object sender, EventArgs e)
    { }

    protected void btnFilterData_Click(object sender, EventArgs e)
    {
        GetCashChqCollection();
    }

    protected void gvCashCheque_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      
        gvCashCheque.PageIndex = e.NewPageIndex;
    }

    protected void gvCashCheque_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                string st;
                st = drv["VOUCHER_NO"].ToString() + "<br /><br />";
                e.Row.Cells[0].Text = st;


                st = "";
                st = "<b>Code:</b> " + drv["INVESTOR_CODE"].ToString() + "<br /><br />";
                st += "<b>Name:</b> " + drv["FIRST_JOIN_HOLDER_NAME"].ToString() + "<br /><br />";
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

                if (string.IsNullOrEmpty(drv["CHEQUE_NO"].ToString()))
                    st += "<b>No:</b> N/A<br /><br />";
                else
                    st += "<b>No:</b> " + drv["CHEQUE_NO"].ToString() + "<br /><br />";

                if (string.IsNullOrEmpty(drv["CHEQUE_DATE"].ToString()))
                    st += "<b>Date:</b> N/A<br /><br />";
                else
                    st += "<b>Date:</b> " + TypeCasting.DateToString( drv["CHEQUE_DATE"].ToString()) + "<br /><br />";

                e.Row.Cells[3].Text = st;

                st = "";

                if (string.IsNullOrEmpty(drv["BROKER_BRANCH"].ToString()))
                    st += "<b>Br.Branch:</b> N/A<br /><br />";
                else
                    st += "<b>Br.Branch:</b> " + drv["BROKER_BRANCH"].ToString() + "<br /><br />";

                if (string.IsNullOrEmpty(drv["MODE_F_Name"].ToString()))
                    st += "<b>Mode:</b> N/A<br /><br />";
                else
                    st += "<b>Mode:</b> " + drv["MODE_F_Name"].ToString() + "<br /><br />";

                if (string.IsNullOrEmpty(drv["TRANSACTION_DATE"].ToString()))
                    st += "<b>Rec.Date:</b> N/A<br /><br />";
                else
                    st += "<b>Rec.Date:</b> " +  TypeCasting.DateToString( drv["TRANSACTION_DATE"].ToString()) + "<br /><br />";
                e.Row.Cells[4].Text = st;

                e.Row.Cells[5].Text = Convert.ToDecimal(string.IsNullOrEmpty(drv["AMOUNT"].ToString()) ? "0" : drv["AMOUNT"].ToString()).ToString("N2");
                st = "";

                if ( drv["CLEAR_STATUS"].ToString() == "1")
                {
                    st += "<b>Cheque Cleared</b><br /><br />";
                }

                if ( drv["DISHONOUR_STATUS"].ToString() == "1")
                {
                    st += "<b>Cheque Dishonor</b><br /><br />";
                }

                if ( TypeCasting.ToBoolean( drv["AUTH_STATUS"].ToString()))
                {
                    st += "<b>Approved</b>";
                }
                else
                    st += "<b>Unapproved</b>";

                e.Row.Cells[6].Text = st;



                if (this.Page_Update)
                {
                    if (!string.IsNullOrEmpty(drv["AUTH_STATUS"].ToString()) && !TypeCasting.ToBoolean(drv["AUTH_STATUS"].ToString()))
                        e.Row.Cells[7].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='Cash_Chq_Collection.aspx?ID=" + drv["ID"].ToString() + "'>Edit</a>";
                    else
                        e.Row.Cells[7].Text = "&nbsp;";
                }
                else
                    e.Row.Cells[7].Text = "&nbsp;";

                if (this.Page_Delete)
                {
                    if (!string.IsNullOrEmpty(drv["AUTH_STATUS"].ToString()) && !TypeCasting.ToBoolean(drv["AUTH_STATUS"].ToString()))
                        e.Row.Cells[8].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='Cash_Chq_Collection_List.aspx?Action=Delete&ID=" + drv["ID"].ToString() + "' onclick='return confirm(\"Are you sure to delete this record?\")'>Delete</a>";
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

    protected void txtInvestorCode_TextChanged(object sender, EventArgs e)
    {
        String Investor_Code = ((TextBox)sender).Text.Trim();
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        BLLAccountOpen.GetInvestorNameByCode(ref Investor_Code);
        hdnInvestorId.Value = Investor_Code.Split('=')[0];
        txtInvestorName.Text = Investor_Code.Split('=')[1];
    }
}
