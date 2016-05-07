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

public partial class TradeTransaction_ImportTradeManually : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetClearMessage();
            txtTradingDate.Text = TypeCasting.DateToString( Util.SystemDate());
            GetDropDownControlData();

            GetGridviewControlData();
        }
    }

    private void SetClearMessage()
    {
        this.divErrMesg.Visible = false;
        this.divInfoMsg.Visible = false;
        lblErrMsg.Text = String.Empty;
    }

    private void GetDropDownControlData()
    {
        //Populate Security Exchange
        ddlSecurityMarket.DataTextField = "Text";
        ddlSecurityMarket.DataValueField = "Value";
        ddlSecurityMarket.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.SecurityExchange).Data;
        ddlSecurityMarket.DataBind();

        //ACTIVE INVESTOR LIST
        listInvestor_Code.DataTextField = "Text";
        listInvestor_Code.DataValueField = "Value";
        listInvestor_Code.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.ActiveInvestorList).Data;
        listInvestor_Code.DataBind();
    }

    private Dictionary<String, String> GetTradeTransaction(GridViewRow oRow)
    {
        Dictionary<String, String> oParam = new Dictionary<string, string>();
        if (oRow != null)
        {
            oParam["SECURITY_EXCHANGE_ID"] = ddlSecurityMarket.SelectedValue;
            oParam["MARKET_TYPE_ID"] = ((DropDownList)oRow.FindControl("ddl_market_type")).SelectedValue;
            oParam["ORDER_REF_NO"] = "";
            oParam["INVESTOR_ID"] = listInvestor_Code.SelectedValue;
            oParam["COMPANY_ID"] = ((DropDownList)oRow.FindControl("ddl_ticker_name")).SelectedValue;
            oParam["TRANSACTION_MODE_ID"] = ((DropDownList)oRow.FindControl("ddl_transaction_mode")).SelectedValue;
            oParam["QUANTITY"] = ((TextBox)oRow.FindControl("txt_quantity")).Text;
            oParam["UNIT_PRICE"] = ((TextBox)oRow.FindControl("txt_unit_price")).Text;
            oParam["COMM_PERCENT"] = ((TextBox)oRow.FindControl("txt_comm_percent")).Text;
            oParam["COMM_AMOUNT"] = (TypeCasting.ToInt64(oParam["QUANTITY"]) * TypeCasting.ToDecimal(oParam["UNIT_PRICE"])).ToString();
            oParam["HOWLA_AMOUNT"] = "";
            oParam["AIT_AMOUNT"] = "";
            oParam["TRANSACTION_AMOUNT"] = "";
            oParam["TRADER_ID"] = ((DropDownList)oRow.FindControl("ddl_trader")).SelectedValue;
            oParam["ISCOMPULSORY_SPOT"] = ((CheckBox)oRow.FindControl("chk_compulsory_spot")).Checked.ToString();
            oParam["HOWLA_REF_NO"] = "";
            oParam["EXEC_TIME"] = "";
            oParam["TRANSACTION_DATE"] = txtTradingDate.Text;
            oParam["FILL_TYPE"] = "FILL";
            oParam["FOREIGN_FLAG"] = "F";
             oParam["CATEGORY_ID"] = ""; 
        }
        else
        {
            oParam["SECURITY_EXCHANGE_ID"] = ddlSecurityMarket.SelectedValue;
            oParam["MARKET_TYPE_ID"] = ((DropDownList)gvTradeImport.Controls[0].Controls[0].FindControl("ddl_market_type")).SelectedValue;
            oParam["ORDER_REF_NO"] = "";
            oParam["INVESTOR_ID"] = listInvestor_Code.SelectedValue;
            oParam["COMPANY_ID"] = ((DropDownList)gvTradeImport.Controls[0].Controls[0].FindControl("ddl_ticker_name")).SelectedValue;
            oParam["TRANSACTION_MODE_ID"] = ((DropDownList)gvTradeImport.Controls[0].Controls[0].FindControl("ddl_transaction_mode")).SelectedValue;
            oParam["QUANTITY"] = ((TextBox)gvTradeImport.Controls[0].Controls[0].FindControl("txt_quantity")).Text;
            oParam["UNIT_PRICE"] = ((TextBox)gvTradeImport.Controls[0].Controls[0].FindControl("txt_unit_price")).Text;
            oParam["COMM_PERCENT"] = ((TextBox)gvTradeImport.Controls[0].Controls[0].FindControl("txt_comm_percent")).Text;
            oParam["COMM_AMOUNT"] = (TypeCasting.ToInt64(oParam["QUANTITY"]) * TypeCasting.ToDecimal(oParam["UNIT_PRICE"])).ToString();
            oParam["HOWLA_AMOUNT"] = "";
            oParam["AIT_AMOUNT"] = "";
            oParam["TRANSACTION_AMOUNT"] = "";
            oParam["TRADER_ID"] = ((DropDownList)gvTradeImport.Controls[0].Controls[0].FindControl("ddl_trader")).SelectedValue;
            oParam["ISCOMPULSORY_SPOT"] = ((CheckBox)gvTradeImport.Controls[0].Controls[0].FindControl("chk_compulsory_spot")).Checked.ToString();
            oParam["HOWLA_REF_NO"] = "";
            oParam["EXEC_TIME"] = "";
            oParam["TRANSACTION_DATE"] = txtTradingDate.Text;
            oParam["FILL_TYPE"] = "FILL";
            oParam["FOREIGN_FLAG"] = "F";
            oParam["CATEGORY_ID"] = ""; 
        
        }
        return oParam;
    }

    protected void btn_Search_Trade_Click(object sender, EventArgs e)
    {
        GetGridviewControlData();
        
    }

   
    private void GetSetInvestorInfoByCode(String Investor_Code, HiddenField ID,Label Investor_Name)
    {
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        BLLAccountOpen.GetInvestorNameByCode(ref Investor_Code);
        ID.Value = Investor_Code.Split('=')[0];
        Investor_Name.Text=Investor_Code.Split('=')[1];
    }

    protected void txt_investor_code_TextChanged(object sender, EventArgs e)
    {
        String Investor_Code = ((TextBox)sender).Text.Trim();
        HiddenField Investor_ID = (HiddenField)((TextBox)sender).Parent.Controls[0].FindControl("hdn_investor_id");
        Label Investor_Name = (Label)((TextBox)sender).Parent.Controls[0].FindControl("lbl_investor_name");
        GetSetInvestorInfoByCode(Investor_Code, Investor_ID, Investor_Name);
    
    }

    #region Grid Events
    protected void gvTradeImport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Populate Company Information
        DropDownList ddl_ticker_name = (DropDownList)e.Row.FindControl("ddl_ticker_name");
        if (ddl_ticker_name != null)
        {
            ddl_ticker_name.DataTextField = "Text";
            ddl_ticker_name.DataValueField = "Value";
            ddl_ticker_name.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.CompanyInformation).Data;
            ddl_ticker_name.DataBind();
        }

        //Populate Market Type
        DropDownList ddl_market_type = (DropDownList)e.Row.FindControl("ddl_market_type");
        if (ddl_market_type != null)
        {
            ddl_market_type.DataTextField = "Text";
            ddl_market_type.DataValueField = "Value";
            ddl_market_type.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.MarketType).Data;
            ddl_market_type.DataBind();
            ddl_market_type.Items.RemoveAt(0);
        }

        //Populate Trader
        DropDownList ddl_trader = (DropDownList)e.Row.FindControl("ddl_trader");
        if (ddl_trader != null)
        {
            ddl_trader.DataTextField = "Text";
            ddl_trader.DataValueField = "Value";
            ddl_trader.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.Trader).Data;
            ddl_trader.DataBind();
        }

        //Populate Transaction Mode
        DropDownList ddl_transaction_mode = (DropDownList)e.Row.FindControl("ddl_transaction_mode");
        if (ddl_transaction_mode != null)
        {
            ddl_transaction_mode.DataTextField = "Text";
            ddl_transaction_mode.DataValueField = "Value";
            ddl_transaction_mode.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.TradeTransactionMode).Data;
            ddl_transaction_mode.DataBind();
            ddl_transaction_mode.Items.RemoveAt(0);
        }
    }
    protected void gvTradeImport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Insert"))
        {
            Dictionary<String, String> Transactions = GetTradeTransaction(gvTradeImport.FooterRow);
            BLLImportTradeManually BLLImportTradeManually = new BLLImportTradeManually();
            CResult CResult = new CResult();
            CResult = BLLImportTradeManually.InsertImportTradeManually(Transactions);
            if (CResult.IsSuccess)
            {
                GetGridviewControlData();
            }
            else
            {
                divErrMesg.Visible = true;
                lblErrMsg.Text = CResult.Message;
            }

        }
        else if (e.CommandName.Equals("emptyInsert"))
        {
            Dictionary<String, String> Transactions = GetTradeTransaction(null);
            BLLImportTradeManually BLLImportTradeManually = new BLLImportTradeManually();
            CResult CResult = new CResult();
            CResult = BLLImportTradeManually.InsertImportTradeManually(Transactions);
            if (CResult.IsSuccess)
            {
                GetGridviewControlData();
            }
            else
            {
                divErrMesg.Visible = true;
                lblErrMsg.Text = CResult.Message;
            }

        }
    }
    private void GetGridviewControlData()
    {
        Dictionary<String, String> oParams = new Dictionary<string, string>();
        oParams["SECURITY_EXCHANGE_ID"] = ddlSecurityMarket.SelectedValue;
        oParams["ID"] = "0";
        oParams["Investor_ID"] = listInvestor_Code.SelectedValue;

        BLLImportTradeManually BLLImportTradeManually = new BLLImportTradeManually();
        CResult CResult = new CResult();
        CResult = BLLImportTradeManually.GetImportTradeManually(oParams);
        if (CResult.IsSuccess)
        {
            gvTradeImport.DataSource = CResult.Data;
            gvTradeImport.DataBind();
        }
        else
        {
            divErrMesg.Visible = true;
            lblErrMsg.Text = CResult.Message;
        }
    }
    protected void gvTradeImport_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvTradeImport.EditIndex = e.NewEditIndex;
        GetGridviewControlData();
    }
    protected void gvTradeImport_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //CTradeImport objTradeImport = new CTradeImport();
        //objTradeImport.rsk_nm = gvTradeImport.DataKeys[e.RowIndex].Values[0].ToString();

        ////objTradeImport.rsk_nm = ((TextBox)gvTradeImport.Rows[e.RowIndex].FindControl("rsk_nm")).Text;
        //objTradeImport.risk_weight = Convert.ToDecimal(((TextBox)gvTradeImport.Rows[e.RowIndex].FindControl("txtrisk_weight")).Text);
        //objTradeImport.proportional = ((CheckBox)gvTradeImport.Rows[e.RowIndex].FindControl("chkproportional")).Checked;
        //objTradeImport.high_val = Convert.ToDecimal(((TextBox)gvTradeImport.Rows[e.RowIndex].FindControl("txthigh_val")).Text);
        //objTradeImport.high_val_rel = ((DropDownList)gvTradeImport.Rows[e.RowIndex].FindControl("ddlhigh_val_rel")).SelectedValue;
        //objTradeImport.moderate_val = Convert.ToDecimal(((TextBox)gvTradeImport.Rows[e.RowIndex].FindControl("txtmoderate_val")).Text);
        //objTradeImport.moderate_val_rel = ((DropDownList)gvTradeImport.Rows[e.RowIndex].FindControl("ddlmoderate_val_rel")).SelectedValue;
        //objTradeImport.low_val = Convert.ToDecimal(((TextBox)gvTradeImport.Rows[e.RowIndex].FindControl("txtlow_val")).Text);
        //objTradeImport.low_val_rel = ((DropDownList)gvTradeImport.Rows[e.RowIndex].FindControl("ddllow_val_rel")).SelectedValue;
        //objTradeImport.active_st = ((CheckBox)gvTradeImport.Rows[e.RowIndex].FindControl("chkactive_st")).Checked;
        //objTradeImport.make_dt = DateTime.Now;
        //objTradeImport.make_By = LBSessionUtility.LBSessionContainer.USER_ID;

        //updateTradeImport(objTradeImport);
        //gvTradeImport.EditIndex = -1;
        //FillRistCriteriaGrid();
    }
    protected void gvTradeImport_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTradeImport.EditIndex = -1;
        //FillRistCriteriaGrid();
    }
    protected void gvTradeImport_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        //CTradeImport objTradeImport = new CTradeImport();
        //objTradeImport.rsk_nm = gvTradeImport.DataKeys[e.RowIndex].Values[0].ToString();
        //deleteTradeImport(objTradeImport);
        //FillRistCriteriaGrid();
    }
    #endregion

    protected void btn_Save_Click(object sender, EventArgs e)
    {

    }

    protected void btn_Clear_Click(object sender, EventArgs e)
    {

    }
    
    
}
