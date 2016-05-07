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
using System.Collections.Generic;

public partial class ChargeInformation_ApproveManuallyInvestorCharge : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtTransactionDate.Text = TypeCasting.DateToString(Util.SystemDate());
            GetDropDownControlData();

            GetGridviewControlData();
        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetGridviewControlData();
    }
    private void GetGridviewControlData()
    {
        BLLChargeApply BLLChargeApply = new BLLChargeApply();
        CResult CResult = new CResult();
        CResult = BLLChargeApply.GetUnapprovedInvestorAppliedChargeInfo(GetInvestorImposedCharge());
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
    private void GetDropDownControlData()
    {
        //Populate ddlTransactionMode
        ddlChargeInformation.DataTextField = "Text";
        ddlChargeInformation.DataValueField = "Value";
        ddlChargeInformation.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.ChargeInformation).Data;
        ddlChargeInformation.DataBind();

    }


    private Dictionary<String, String> GetInvestorImposedCharge()
    {
        Dictionary<String, String> oParam = new Dictionary<string, string>();
        
        oParam["INVESTOR_ID"] = hdnInvestorID.Value;
        oParam["CHARGE_ID"] = ddlChargeInformation.SelectedValue;
        oParam["TRANSACTION_MODE"] = ddlTransactionMode.SelectedValue;
        oParam["TRANSACTION_DATE"] = txtTransactionDate.Text;
        oParam["IS_ALLITEMSELECTED"] = hdnIS_ALLITEMSELECTED.Value;
        oParam["ID"] = "0";
        return oParam;
    }

    private List<String> GetSelectedItemFromGridView()
    {
        List<String> oItemList = new List<string>();
        int i = 0;
        foreach (GridViewRow oRow in dgvChargeInformation.Rows)
        {
            CheckBox IsApprove = (CheckBox)oRow.Cells[0].FindControl("chk_Select_Single");
            if (IsApprove.Checked)
            {
                oItemList.Add(dgvChargeInformation.DataKeys[i++].Value.ToString());
            }
        }
        return oItemList;
    }

    protected void dgvChargeInformation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //DataRowView drv = (DataRowView)e.Row.DataItem;
            //if (Page_Read)
            //    e.Row.Cells[4].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='ManuallyInvestorChargeManage.aspx?ID=" + drv["ID"].ToString() + "'>Edit</a>";
            //else
            //    e.Row.Cells[4].Text = "&nbsp;";

            //if (Page_Delete)
            //    e.Row.Cells[5].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='ManuallyInvestorChargeManageList.aspx?action=Delete&ID=" + drv["ID"].ToString() + "' onclick='return confirm(\"Are you sure you wish to delete this Data?\")'>Delete</a>";
            //else
            //    e.Row.Cells[5].Text = "&nbsp;";
        }
    }
    protected void dgvChargeInformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvChargeInformation.PageIndex = e.NewPageIndex;
        GetGridviewControlData();
    }

    protected void btn_SearchInvestor_Click(object sender, EventArgs e)
    {
        txtInvestorCode_TextChanged(sender, e);
    }
    
    protected void txtInvestorCode_TextChanged(object sender, EventArgs e)
    {
        String Investor_Code = txtInvestorCode.Text.Trim();
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        BLLAccountOpen.GetInvestorNameByCode(ref Investor_Code);
        hdnInvestorID.Value = Investor_Code.Split('=')[0];
        if (hdnInvestorID.Value == "0") txtInvestorCode.Text = String.Empty;
        txtInvestorName.Text = Investor_Code.Split('=')[1];
    }
    protected void chk_Select_All_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow oRow in dgvChargeInformation.Rows)
        {
            CheckBox IsApprove = (CheckBox)oRow.Cells[0].FindControl("chk_Select_Single");
            IsApprove.Checked = ((CheckBox)sender).Checked;
        }
        hdnIS_ALLITEMSELECTED.Value="true";
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {

        CResult CResult = new CResult();
        BLLChargeApply BLLChargeApply = new BLLChargeApply();
        Dictionary<String, String> oParam = GetInvestorImposedCharge();
        List<String> oParamList = GetSelectedItemFromGridView();
        CResult = BLLChargeApply.ApproveChargeImposeOnInvestor(oParam,oParamList);

        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully approved.");

            //Reload controls
            GetGridviewControlData();
        }
        else
        {

            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        Response.Redirect("../ChargeInformation/ApproveManuallyInvestorCharge.aspx");
    }


    protected void btn_Deny_Click(object sender, EventArgs e)
    { }

}
