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
using System.Text;
using System.Collections.Generic;
using BLL;
using Common;

public partial class AccountTransaction_CashChqCollectionClearDishonour : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtTransactionDate.Text = TypeCasting.DateToString(Util.SystemDate());
            GetCashChqCollection();
        }
    }
    
   

    private void GetCashChqCollection()
    {
        BLLCashChqCollectionManagement BLLCashChqCollectionManagement = new BLLCashChqCollectionManagement();
        CResult CResult = new CResult();
        CResult = BLLCashChqCollectionManagement.GetUnClearedCashChqDepositInfo(txtTransactionDate.Text);

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

    protected void gvCashCheque_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            StringBuilder st = new StringBuilder();

            //investor  information
            st.Append( "<b>Investor Code:</b> " + drv["INVESTOR_CODE"].ToString() + "<br /><br />");
            st.Append( "<b>Name:</b> " + drv["FIRST_JOIN_HOLDER_NAME"].ToString() + "<br /><br />");
            e.Row.Cells[2].Text = st.ToString();

            //cheque inforamtion 
            st = new StringBuilder();
            if (string.IsNullOrEmpty(drv["CHEQUE_NO"].ToString()))
                st.Append(  "<b>Number:</b> N/A<br /><br />");
            else
                st.Append( "<b>Number:</b> " + drv["CHEQUE_NO"].ToString() + "<br /><br />");
            if (string.IsNullOrEmpty(drv["CHEQUE_DATE"].ToString()))
                st.Append( "<b>Date:</b> N/A<br /><br />");
            else
                st.Append( "<b>Date:</b> " + drv["CHEQUE_DATE"].ToString() + "<br /><br />");
            e.Row.Cells[3].Text = st.ToString();

            //bank informatiponm 
            st =new StringBuilder();
            if (string.IsNullOrEmpty(drv["BANK_F_NAME"].ToString()))
                st.Append(  "<b>Bank:</b> N/A<br /><br />");
            else
                st.Append(  "<b>Bank:</b> " + drv["BANK_F_NAME"].ToString() + "<br /><br />");
            if (string.IsNullOrEmpty(drv["BRANCH_NAME"].ToString()))
                st.Append(  "<b>Branch:</b> N/A<br /><br />");
            else
                st.Append(  "<b>Branch:</b> " + drv["BRANCH_NAME"].ToString() + "<br /><br />");
            e.Row.Cells[4].Text = st.ToString();

            //broker barnch
            st = new StringBuilder();
            if (string.IsNullOrEmpty(drv["BROKER_BRANCH_NAME"].ToString()))
                st.Append(   "N/A<br /><br />");
            else
                st.Append(drv["BROKER_BRANCH_NAME"].ToString() + "<br /><br />");
            e.Row.Cells[5].Text = st.ToString();


            //transaciotrn date
            st = new StringBuilder();
            if (string.IsNullOrEmpty(drv["MODE_F_Name"].ToString()))
                st.Append(   "<b>Trans.Mode:</b> N/A<br /><br />");
            else
                st.Append("<b>Trans.Mode:</b> " + drv["MODE_F_Name"].ToString() + "<br /><br />");
            if (string.IsNullOrEmpty(drv["TRANSACTION_DATE"].ToString()))
                st.Append(   "<b>Rec. Date:</b> N/A<br /><br />");
            else
                st.Append("<b>Rec. Date</b> " + drv["TRANSACTION_DATE"].ToString() + "<br /><br />");
       
            e.Row.Cells[6].Text = st.ToString();

            //deposited amount
            e.Row.Cells[1].Text = Convert.ToDecimal(string.IsNullOrEmpty(drv["AMOUNT"].ToString()) ? "0" : drv["AMOUNT"].ToString()).ToString("N4");
        }
    }

    private List<String> GetSelectedItemFromGridView()
    {
        List<String> oItemList = new List<string>();
        int i=0;
        foreach (GridViewRow oRow in gvCashCheque.Rows)
        {
            CheckBox IsApprove = (CheckBox)oRow.Cells[0].FindControl("chk_Select_Single");
            if (IsApprove.Checked)
            {
                oItemList.Add(gvCashCheque.DataKeys[i++].Value.ToString());
            }
        }
        return oItemList;
    }

    protected void chk_Select_All_CheckedChanged(object sender,EventArgs e)
    {
        foreach (GridViewRow oRow in gvCashCheque.Rows)
        {
            CheckBox IsApprove = (CheckBox)oRow.Cells[0].FindControl("chk_Select_Single");
            IsApprove.Checked = ((CheckBox)sender).Checked;
        }
    }

    private bool ValidateDepositApprove()
    {
        bool IsSelected = false;
        foreach (GridViewRow oRow in gvCashCheque.Rows)
        {
            CheckBox IsApprove = (CheckBox)oRow.Cells[0].FindControl("chk_Select_Single");
            if (IsApprove.Checked)
            {
                IsSelected = true;
                break;
            }
        }
        return IsSelected;
    }
  
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (!ValidateDepositApprove()) return;

        CResult CResult = new CResult();
        BLLCashChqCollectionManagement BLLCashChqCollectionManagement = new BLLCashChqCollectionManagement();
        List<String> oParamList=GetSelectedItemFromGridView();
        CResult = BLLCashChqCollectionManagement.ClearCashChqDepositInfo(oParamList);

        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully honoured.");


            //Reload controls
            GetCashChqCollection();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);

        }
    }
    
    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        Response.Redirect("../AccountTransaction/ApproveCashChqCollection.aspx");
    }


    protected void btn_Deny_Click(object sender, EventArgs e)
    {
        if (!ValidateDepositApprove()) return;

        CResult CResult = new CResult();
        BLLCashChqCollectionManagement BLLCashChqCollectionManagement = new BLLCashChqCollectionManagement();
        List<String> oParamList = GetSelectedItemFromGridView();
        CResult = BLLCashChqCollectionManagement.DishonourCashChqDepositInfo(oParamList);

        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully dishonoured.");

           
            //Reload controls
            GetCashChqCollection();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);



        }
    }
}
