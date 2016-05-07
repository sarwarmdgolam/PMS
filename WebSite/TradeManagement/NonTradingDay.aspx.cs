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

public partial class TradeManagement_NonTradingDay : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("View List", "~/TradeManagement/NonTradingDayList.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Text = txtToDate.Text = TypeCasting.DateToString(Util.SystemDate());
            GetDropDownControlData();

            String ID = Request.QueryString["ID"];
            if (!String.IsNullOrEmpty(ID))
            {
                GetNonTradingDayInfo(ID);
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.UPDATE);
            }
            else
            {
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.INSERT);
            }
        }
    }

    private void ControlSelectionMode(Common.ApplicationEnums.UIOperationMode Mode)
    {
        switch (Mode)
        {
            case Common.ApplicationEnums.UIOperationMode.INSERT:
                btn_Save.Enabled = true;
                btn_Update.Enabled = false;
                //btn_Save2.Enabled = true;
                //btn_Update2.Enabled = false;
                break;
            case Common.ApplicationEnums.UIOperationMode.UPDATE:
                btn_Save.Enabled = false;
                btn_Update.Enabled = true;
                //btn_Save2.Enabled = false;
                //btn_Update2.Enabled = true;
                break;
            case Common.ApplicationEnums.UIOperationMode.REFRESH:
                btn_Save.Enabled = false;
                btn_Update.Enabled = false;
                //btn_Save2.Enabled = false;
                //btn_Update2.Enabled = false;
                break;
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

    private String GetSelectedOffDay()
    {
        StringBuilder oDay = new StringBuilder();
        foreach (ListItem oItem in chkNonTradingDay.Items)
        {
            if (oItem.Selected)
            {
                oDay.Append(oItem.Value);
                oDay.Append(",");
            }
        }
        if (!String.IsNullOrEmpty(oDay.ToString()))
            return oDay.Remove(oDay.ToString().Length - 1, 1).ToString();
        else
            return String.Empty;
    }

    private void GetNonTradingDayInfo(String ID)
    {
        BLLNONTradingDay BLLNONTradingDay = new BLLNONTradingDay();
        CResult CResult = new CResult();
        CResult = BLLNONTradingDay.GetNonTradingDay(ID, "0", "0", txtFromDate.Text, txtToDate.Text);

        if (CResult.IsSuccess)
        {
            SetNonTradingDayInfo(CResult.Data.Rows[0]);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void SetNonTradingDayInfo(DataRow DataRow)
    {
        hdnID.Value = DataRow ["ID"].ToString();
        txtFromDate.Text = TypeCasting.DateToString(DataRow["TRANSACTION_DATE"].ToString());
        txtToDate.Text = TypeCasting.DateToString(DataRow["TRANSACTION_DATE"].ToString());
        txtPurpose.Text = DataRow["DETAILS"].ToString();
        ddlSecurityMarket.SelectedValue = DataRow["SECURITY_EXCHANGE_ID"].ToString();
        ddlNonTradingType.SelectedValue = DataRow["NON_TRADING_DAY_TYPE_ID"].ToString();
        chkNonTradingDay.SelectedValue = DataRow["NON_TRADING_DAY"].ToString();
        ddlNonTradingType_SelectedIndexChanged(null, null);
    }

    private void InsertNonTradingDayInfo()
    {
        BLLNONTradingDay BLLNONTradingDay = new BLLNONTradingDay();
        CResult CResult = new CResult();
        String oOffDay = GetSelectedOffDay();
        CResult = BLLNONTradingDay.InsertNonTradingDay(ddlSecurityMarket.SelectedValue, txtFromDate.Text, txtToDate.Text, ddlNonTradingType.SelectedValue, txtPurpose.Text, oOffDay);
        if (CResult.AffectedRows>0)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");
            ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.REFRESH);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void UpdateNonTradingDayInfo()
    {
        BLLNONTradingDay BLLNONTradingDay = new BLLNONTradingDay();
        CResult CResult = new CResult();
        String oOffDay = GetSelectedOffDay();
        CResult = BLLNONTradingDay.UpdateNonTradingDay(ddlSecurityMarket.SelectedValue, txtFromDate.Text, hdnID.Value, ddlNonTradingType.SelectedValue, txtPurpose.Text, oOffDay);
        if (CResult.AffectedRows > 0)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Updated.");
            ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.REFRESH);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    protected void ddlNonTradingType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNonTradingType.SelectedItem.Text.ToLower() == "weekly")
        {
            chkNonTradingDay.Enabled = true;
        }
        else
        {
            chkNonTradingDay.Enabled = false;
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        try
        {
            InsertNonTradingDayInfo();
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {

        if (!Page.IsValid) return;
        try
        {
            UpdateNonTradingDayInfo();
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        Response.Redirect("../TradeManagement/NonTradingDay.aspx");
    }
    
}
