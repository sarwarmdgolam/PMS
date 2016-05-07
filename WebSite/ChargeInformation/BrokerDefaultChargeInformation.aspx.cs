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
using Common;
using System.Collections.Generic;
using BLL;

public partial class ChargeInformation_BrokerDefaultChargeInformation : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("View List", "~/ChargeInformation/BrokerDefaultChargeInformationList.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtActiveDate.Text =  TypeCasting.DateToString(Util.SystemDate());
            GetDropDownControlData();


            //SET UPDATE MODE
            String ID = Request.QueryString["ID"];
            if (!String.IsNullOrEmpty(ID))
            {
                hdnID.Value = ID;
                GetBrokerDefaultChargeInfoFromDB(ID);
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
                break;
            case Common.ApplicationEnums.UIOperationMode.UPDATE:
                btn_Save.Enabled = false;
                btn_Update.Enabled = true;
                break;
            case Common.ApplicationEnums.UIOperationMode.REFRESH:
                btn_Save.Enabled = false;
                btn_Update.Enabled = false;
                break;
        }
    }

    private void GetDropDownControlData()
    {
        //Populate ddlTransactionMode
        ddlChargeType.DataTextField = "Text";
        ddlChargeType.DataValueField = "Value";
        ddlChargeType.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.FeeChargeType).Data;
        ddlChargeType.DataBind();
    }

    private bool ValidateInsertDefaultChargeInfo()
    {

        return true;
    }

    private void GetBrokerDefaultChargeInfoFromDB(String ID)
    {
        BLLBrokerDefaultChargeInformation BLLBrokerDefaultChargeInformation = new BLLBrokerDefaultChargeInformation();
        CResult CResult = new CResult();
        CResult = BLLBrokerDefaultChargeInformation.GetBrokerDefaultChargeInfo(ID, String.Empty);
        if (CResult.IsSuccess)
        {
            if (CResult.Data.Rows.Count > 0)
            {
                SetBrokerDefaultChargeInfo(CResult.Data.Rows[0]);
            }
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private Dictionary<String, String> GetBrokerDefaultChargeInfo()
    {
        Dictionary<String, String> oParam = new Dictionary<string, string>();
        oParam["ID"] = hdnID.Value;
        oParam["CHARGE_S_NAME"] = txtShortName.Text;
        oParam["CHARGE_F_NAME"] = txtName.Text;
        oParam["CHARGE_AMOUNT"] = txtChargeAmount.Text;
        oParam["MIN_CHARGE_AMOUNT"] = txtMinimumCharge.Text;
        oParam["ISPERCENTAGE"] = chkISPercentage.Checked.ToString();
        oParam["ISSLAB"] = chkISSlab.Checked.ToString();
        oParam["CDBL_CHARGE_AMOUNT"] = txtCDBLChargeAmount.Text;
        oParam["CDBL_MIN_CHARGE_AMOUNT"] = txtCDBLMinChargeAmount.Text;
        oParam["ACTIVATION_DATE"] = txtActiveDate.Text;
        oParam["ISACTIVE"] = chkISActive.Checked.ToString();
        oParam["FEESCHARGE_TYPE_ID"] = ddlChargeType.SelectedValue.ToString();
        return oParam;
    }

    private void SetBrokerDefaultChargeInfo(DataRow Row)
    {
        try
        {
            hdnID.Value = Row["ID"].ToString();
            txtShortName.Text = Row["CHARGE_S_NAME"].ToString();
            txtName.Text = Row["CHARGE_F_NAME"].ToString();
            txtChargeAmount.Text = Row["CHARGE_AMOUNT"].ToString();
            txtMinimumCharge.Text = Row["MIN_CHARGE_AMOUNT"].ToString();
            if (TypeCasting.ToBoolean(Row["ISPERCENTAGE"].ToString()))
                chkISPercentage.Checked = true;
            else
                chkISPercentage.Checked = false;

            if (TypeCasting.ToBoolean(Row["ISSLAB"].ToString()))
                chkISSlab.Checked = true;
            else
                chkISSlab.Checked = false;

            txtCDBLChargeAmount.Text = Row["CDBL_CHARGE_AMOUNT"].ToString();
            txtCDBLMinChargeAmount.Text = Row["CDBL_MIN_CHARGE_AMOUNT"].ToString();
            txtActiveDate.Text = Row["ACTIVATION_DATE"].ToString();
            ddlChargeType.SelectedValue = Row["FEESCHARGE_TYPE_ID"].ToString();
            if (TypeCasting.ToBoolean(Row["ISACTIVE"].ToString()))
                chkISActive.Checked = true;
            else
                chkISActive.Checked = false;


            //Slab information
            if (chkISSlab.Checked)
            {
                //Insert slab information if exists  
                GetGridviewControlData();
            }
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    private void InsertBrokerDefaultChargeInfo()
    {
        if (!ValidateInsertDefaultChargeInfo()) return;

        CResult CResult = new CResult();
        BLLBrokerDefaultChargeInformation BLLBrokerDefaultChargeInformation = new BLLBrokerDefaultChargeInformation();
        CResult = BLLBrokerDefaultChargeInformation.InsertBrokerDefaultChargeInfo(GetBrokerDefaultChargeInfo());

        if (CResult.ID>1)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");

            //Slab information
            if (chkISSlab.Checked)
            {
                hdnID.Value = CResult.ID.ToString();
                //Insert slab information if exists  
                GetGridviewControlData();
            }
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private Dictionary<String, String> GetBrokerDefaultChargeSlabInfo(GridViewRow oRow)
    {
        Dictionary<String, String> oParam = new Dictionary<string, string>();
        if (oRow != null)
        {
            oParam["DEFAULT_CHARGE_ID"] = hdnID.Value;
            oParam["START_AMOUNT"] = ((TextBox)oRow.FindControl("txtAmountFrom")).Text;
            oParam["END_AMOUNT"] = ((TextBox)oRow.FindControl("txtAmountTo")).Text;
            oParam["CHARGE_AMOUNT"] = ((TextBox)oRow.FindControl("txtChargeAmount")).Text;
            oParam["ISPERCENTAGE"] = ((CheckBox)oRow.FindControl("chkPercentage")).Checked.ToString();
        }
        else
        {
            oParam["DEFAULT_CHARGE_ID"] = hdnID.Value;
            oParam["START_AMOUNT"] = ((TextBox)gvChargeInformation.Controls[0].Controls[0].FindControl("txtAmountFrom")).Text;
            oParam["END_AMOUNT"] = ((TextBox)gvChargeInformation.Controls[0].Controls[0].FindControl("txtAmountTo")).Text;
            oParam["CHARGE_AMOUNT"] = ((TextBox)gvChargeInformation.Controls[0].Controls[0].FindControl("txtChargeAmount")).Text;
            oParam["ISPERCENTAGE"] = ((CheckBox)gvChargeInformation.Controls[0].Controls[0].FindControl("chkPercentage")).Checked.ToString();
        }
        return oParam;
    }


    private bool ValidateInsertDefaultChargeSlabInfo()
    {

        return true;
    }

    private void InsertBrokerDefaultChargeSlabInfo(Dictionary<String, String> oParam)
    {
        if (!ValidateInsertDefaultChargeSlabInfo()) return;

        CResult CResult = new CResult();
        BLLBrokerDefaultChargeInformation BLLBrokerDefaultChargeInformation = new BLLBrokerDefaultChargeInformation();
        CResult = BLLBrokerDefaultChargeInformation.InsertBrokerDefaultChargeSlabInfo(oParam);

        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");

            //Refresh grid view 
            GetGridviewControlData();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void UpdatetBrokerDefaultChargeInfo()
    {
        if (!ValidateInsertDefaultChargeInfo()) return;

        CResult CResult = new CResult();
        BLLBrokerDefaultChargeInformation BLLBrokerDefaultChargeInformation = new BLLBrokerDefaultChargeInformation();
        CResult = BLLBrokerDefaultChargeInformation.UpdateBrokerDefaultChargeInfo(GetBrokerDefaultChargeInfo());

        if (CResult.AffectedRows > 0)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Updated.");
            ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.REFRESH);

            //Slab information
            if (chkISSlab.Checked)
            {
                //Insert slab information if exists  
                GetGridviewControlData();
            }
            else
            {
                gvChargeInformation.DataSource = null;
                gvChargeInformation.DataBind();
            }
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }


    #region Grid Events
    protected void gvChargeInformation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Populate Company Information
        //DropDownList ddl_ticker_name = (DropDownList)e.Row.FindControl("ddl_ticker_name");
        //if (ddl_ticker_name != null)
        //{
        //    ddl_ticker_name.DataTextField = "Text";
        //    ddl_ticker_name.DataValueField = "Value";
        //    ddl_ticker_name.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.CompanyInformation).Data;
        //    ddl_ticker_name.DataBind();
        //}

        ////Populate Market Type
        //DropDownList ddl_market_type = (DropDownList)e.Row.FindControl("ddl_market_type");
        //if (ddl_market_type != null)
        //{
        //    ddl_market_type.DataTextField = "Text";
        //    ddl_market_type.DataValueField = "Value";
        //    ddl_market_type.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.MarketType).Data;
        //    ddl_market_type.DataBind();
        //}

        ////Populate Trader
        //DropDownList ddl_trader = (DropDownList)e.Row.FindControl("ddl_trader");
        //if (ddl_trader != null)
        //{
        //    ddl_trader.DataTextField = "Text";
        //    ddl_trader.DataValueField = "Value";
        //    ddl_trader.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.Trader).Data;
        //    ddl_trader.DataBind();
        //}

        ////Populate Transaction Mode
        //DropDownList ddl_transaction_mode = (DropDownList)e.Row.FindControl("ddl_transaction_mode");
        //if (ddl_transaction_mode != null)
        //{
        //    ddl_transaction_mode.DataTextField = "Text";
        //    ddl_transaction_mode.DataValueField = "Value";
        //    ddl_transaction_mode.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.TradeTransactionMode).Data;
        //    ddl_transaction_mode.DataBind();
        //}
    }
    protected void gvChargeInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Insert"))
        {
            Dictionary<String, String> Transactions = GetBrokerDefaultChargeSlabInfo(gvChargeInformation.FooterRow);
            InsertBrokerDefaultChargeSlabInfo(Transactions);
        }
        else if (e.CommandName.Equals("emptyInsert"))
        {
            Dictionary<String, String> Transactions = GetBrokerDefaultChargeSlabInfo(null);
            InsertBrokerDefaultChargeSlabInfo(Transactions);
        }
    }
    private void GetGridviewControlData()
    {
        BLLBrokerDefaultChargeInformation BLLBrokerDefaultChargeInformation = new BLLBrokerDefaultChargeInformation();
        CResult CResult = new CResult();
        CResult = BLLBrokerDefaultChargeInformation.GetBrokerDefaultChargeSlabInfo(hdnID.Value);
        if (CResult.IsSuccess)
        {
            gvChargeInformation.DataSource = CResult.Data;
            gvChargeInformation.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }
    protected void gvChargeInformation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvChargeInformation.EditIndex = e.NewEditIndex;
        GetGridviewControlData();
    }
    protected void gvChargeInformation_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //CTradeImport objTradeImport = new CTradeImport();
        //objTradeImport.rsk_nm = gvChargeInformation.DataKeys[e.RowIndex].Values[0].ToString();

        ////objTradeImport.rsk_nm = ((TextBox)gvChargeInformation.Rows[e.RowIndex].FindControl("rsk_nm")).Text;
        //objTradeImport.risk_weight = Convert.ToDecimal(((TextBox)gvChargeInformation.Rows[e.RowIndex].FindControl("txtrisk_weight")).Text);
        //objTradeImport.proportional = ((CheckBox)gvChargeInformation.Rows[e.RowIndex].FindControl("chkproportional")).Checked;
        //objTradeImport.high_val = Convert.ToDecimal(((TextBox)gvChargeInformation.Rows[e.RowIndex].FindControl("txthigh_val")).Text);
        //objTradeImport.high_val_rel = ((DropDownList)gvChargeInformation.Rows[e.RowIndex].FindControl("ddlhigh_val_rel")).SelectedValue;
        //objTradeImport.moderate_val = Convert.ToDecimal(((TextBox)gvChargeInformation.Rows[e.RowIndex].FindControl("txtmoderate_val")).Text);
        //objTradeImport.moderate_val_rel = ((DropDownList)gvChargeInformation.Rows[e.RowIndex].FindControl("ddlmoderate_val_rel")).SelectedValue;
        //objTradeImport.low_val = Convert.ToDecimal(((TextBox)gvChargeInformation.Rows[e.RowIndex].FindControl("txtlow_val")).Text);
        //objTradeImport.low_val_rel = ((DropDownList)gvChargeInformation.Rows[e.RowIndex].FindControl("ddllow_val_rel")).SelectedValue;
        //objTradeImport.active_st = ((CheckBox)gvChargeInformation.Rows[e.RowIndex].FindControl("chkactive_st")).Checked;
        //objTradeImport.make_dt = DateTime.Now;
        //objTradeImport.make_By = LBSessionUtility.LBSessionContainer.USER_ID;

        //updateTradeImport(objTradeImport);
        //gvChargeInformation.EditIndex = -1;
        //FillRistCriteriaGrid();
    }
    protected void gvChargeInformation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvChargeInformation.EditIndex = -1;
        //FillRistCriteriaGrid();
    }
    protected void gvChargeInformation_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        //CTradeImport objTradeImport = new CTradeImport();
        //objTradeImport.rsk_nm = gvChargeInformation.DataKeys[e.RowIndex].Values[0].ToString();
        //deleteTradeImport(objTradeImport);
        //FillRistCriteriaGrid();
    }
    #endregion
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        InsertBrokerDefaultChargeInfo();
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        UpdatetBrokerDefaultChargeInfo();
    }
    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        Response.Redirect("BrokerDefaultChargeInformation.aspx");
    }
}
