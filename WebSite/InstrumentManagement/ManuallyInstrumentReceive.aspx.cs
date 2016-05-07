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
using BLL;
using System.Collections.Generic;

public partial class InstrumentManagement_ManuallyInstrumentReceive : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageTitle("Instrument Management");
        Master.ShowPageNavigationURL("View List", "~/InstrumentManagement/ManuallyInstrumentReceiveList.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDropDownControlData();
            txtTransactionDate.Text = TypeCasting.DateToString(Util.SystemDate());

            //Set Voucher No
            SetVoucherNO();
            
            //Set update mode
            String ID = Request.QueryString["ID"];
            if (!String.IsNullOrEmpty(ID))
            {
                GetInstrumentManagementData();
                hdn_ID.Value = ID;
            }
        }
    }

    private void SetVoucherNO()
    {
        Int64 Voucher_NO = Convert.ToInt64(BLLCommonEntity.GetMaxVoucherNo(ApplicationEnums.VoucherType.TBL_INST_TRANSACTION_MASTER_VOUCHER_NO));
        txtPreviousVoucherNo.Text = Voucher_NO.ToString();
        Voucher_NO = Voucher_NO + 1;
        txtVoucherNumber.Text = Voucher_NO.ToString();
    }

    private void GetDropDownControlData()
    {
        //Populate ddlTransactionMode        
        ddlTransactionMode.DataTextField = "Text";
        ddlTransactionMode.DataValueField = "Value";
        DataTable dtMode = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.TradeTransactionMode).Data;
        for (int i = 0; i < dtMode.Rows.Count; i++)
        {
            DataRow row = dtMode.Rows[i];
            if (String.Equals(row["Text"].ToString().ToUpper(), "RECEIVE") || String.Equals(row["Text"].ToString().ToUpper(), "DELIVERY"))
            {
                ddlTransactionMode.Items.Add(new ListItem(row["Text"].ToString(), row["Value"].ToString()));        
            }
        }
        //Bind values
        ddlTransactionMode.DataBind();
    }

    private Dictionary<String, String> GetInstrumentManagementDetails(GridViewRow oRow)
    {
        Dictionary<String, String> oParam = new Dictionary<string, string>();
        if (oRow != null)
        {
            oParam["MASTER_ID"] = hdn_ID.Value;
            oParam["COMPANY_ID"] = ((DropDownList)oRow.FindControl("ddl_ticker_name")).SelectedValue;
            oParam["REF_TRANSACTION_MODE_ID"] = ((DropDownList)oRow.FindControl("ddl_ref_transaction_mode")).SelectedValue;
            oParam["FOLIO_NO"] = String.Empty;
            oParam["QUANTITY"] = ((TextBox)oRow.FindControl("txt_quantity")).Text;
            oParam["TOTAL_AMOUNT"] = ((TextBox)oRow.FindControl("txt_total_amount")).Text;
        }
        else
        {
            oParam["MASTER_ID"] = hdn_ID.Value;
            oParam["COMPANY_ID"] = ((DropDownList)gvInstrumentManagement.Controls[0].Controls[0].FindControl("ddl_ticker_name")).SelectedValue;
            oParam["REF_TRANSACTION_MODE_ID"] = ((DropDownList)gvInstrumentManagement.Controls[0].Controls[0].FindControl("ddl_ref_transaction_mode")).SelectedValue;
            oParam["FOLIO_NO"] = String.Empty;
            oParam["QUANTITY"] = ((TextBox)gvInstrumentManagement.Controls[0].Controls[0].FindControl("txt_quantity")).Text;
            oParam["TOTAL_AMOUNT"] = ((TextBox)gvInstrumentManagement.Controls[0].Controls[0].FindControl("txt_total_amount")).Text;
        }
        return oParam;
    }

    private Dictionary<String, String> GetInstrumentManagementMaster()
    {
        Dictionary<String, String> oParam = new Dictionary<string, string>();
        oParam["VOUCHER_NO"] = txtVoucherNumber.Text;
        oParam["VOUCHER_REF_NO"] = txtReferenceNO.Text;
        oParam["INVESTOR_ID"] = hdnInvestor_ID.Value;
        oParam["TRANSACTION_DATE"] =txtTransactionDate.Text;
        oParam["TRANSACTION_MODE_ID"] =  ddlTransactionMode.SelectedValue;
        oParam["REMARKS"] = txtRemarks.Text;
        return oParam;
    }

    private void SetInstrumentManagement(DataTable dtInst)
    {
        DataRow oRow=dtInst.Rows[0];
        txtVoucherNumber.Text=oRow["VOUCHER_NO"].ToString();
        txtReferenceNO.Text=oRow["VOUCHER_REF_NO"].ToString();
        txtInvestorCode.Text = oRow["INVESTOR_CODE"].ToString(); 
        hdnInvestor_ID.Value = oRow["INVESTOR_ID"].ToString(); 
        txtTransactionDate.Text = oRow["TRANSACTION_DATE"].ToString(); 
        ddlTransactionMode.SelectedValue = oRow["TRANSACTION_MODE_ID"].ToString(); 
        txtRemarks.Text= oRow["REMARKS"].ToString(); 

        //Populate gridview
        gvInstrumentManagement.DataSource = dtInst;
        gvInstrumentManagement.DataBind();
    }

    private bool GetInsertValidation()
    {

        return true;
    }

    private void InsertInstrumentManagementMaster()
    {
        if (!GetInsertValidation()) return;

        BLLInstrumentManagement BLLInstrumentManagement = new BLLInstrumentManagement();
        CResult CResult = new CResult();
        Dictionary<String, String> oParam = GetInstrumentManagementMaster();
        CResult = BLLInstrumentManagement.INSERTINSTTRANSACTIONMASTER(oParam);
        if (CResult.IsSuccess)
        {
            if (CResult.ID > 0)
            {
                (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");
                hdn_ID.Value = CResult.ID.ToString();

                //Refresh grid view 
                GetGridviewControlData();
            }
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        InsertInstrumentManagementMaster();
    }


    protected void btnSaveDetails_Click(object sender, EventArgs e)
    {
        SaveInstrumentManagementDetailsInfo();
    }

    
    protected void txtInvestorCode_TextChanged(object sender, EventArgs e)
    {
        String Investor_Code = ((TextBox)sender).Text.Trim();
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        BLLAccountOpen.GetInvestorNameByCode(ref Investor_Code);
        hdnInvestor_ID.Value = Investor_Code.Split('=')[0];
        txtInvestorName.Text = Investor_Code.Split('=')[1];
    }

    protected bool ValidateTransactionDetailsSlabInfo()
    {

        return true;
    }

    private void InsertInstrumentManagementDetailsInfo(Dictionary<String, String> oParam)
    {
        if (!ValidateTransactionDetailsSlabInfo()) return;

        CResult CResult = new CResult();
        BLLInstrumentManagement BLLInstrumentManagement = new BLLInstrumentManagement();
        CResult = BLLInstrumentManagement.INSERTINSTTRANSACTIONDETAILSTEMP(oParam);

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

    private void SaveInstrumentManagementDetailsInfo()
    {
        if (!ValidateTransactionDetailsSlabInfo()) return;

        CResult CResult = new CResult();
        BLLInstrumentManagement BLLInstrumentManagement = new BLLInstrumentManagement();
        CResult = BLLInstrumentManagement.INSERTINSTTRANSACTIONDETAILS(hdn_ID.Value);

        if (CResult.AffectedRows>0)
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

    private void GetInstrumentManagementData()
    { 
        BLLInstrumentManagement BLLInstrumentManagement = new BLLInstrumentManagement();
        CResult CResult = new CResult();
        CResult = BLLInstrumentManagement.GETINSERTINSTTRANSACTIONINFO(hdn_ID.Value, "0", TypeCasting.DateToString(Util.SystemDate()), TypeCasting.DateToString(Util.SystemDate()));
        if (CResult.IsSuccess)
        {
            SetInstrumentManagement(CResult.Data);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    #region Grid Events
    private void GetGridviewControlData()
    {
        BLLInstrumentManagement BLLInstrumentManagement = new BLLInstrumentManagement();
        CResult CResult = new CResult();
        CResult = BLLInstrumentManagement.GETINSERTINSTTRANSACTIONINFO(hdn_ID.Value, "0", TypeCasting.DateToString(Util.SystemDate()), TypeCasting.DateToString(Util.SystemDate()));
        if (CResult.IsSuccess)
        {
            gvInstrumentManagement.DataSource = CResult.Data;
            gvInstrumentManagement.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }
    
    protected void gvInstrumentManagement_RowDataBound(object sender, GridViewRowEventArgs e)
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

        //Populate Company Information
        DropDownList ddl_ref_transaction_mode = (DropDownList)e.Row.FindControl("ddl_ref_transaction_mode");
        if (ddl_ref_transaction_mode != null)
        {
            ddl_ref_transaction_mode.DataTextField = "Text";
            ddl_ref_transaction_mode.DataValueField = "Value";
            ddl_ref_transaction_mode.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.TradeTransactionMode).Data;
            ddl_ref_transaction_mode.DataBind();
        }
    }

    protected void gvInstrumentManagement_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Dictionary<String, String> Transactions = new Dictionary<string, string>();
        if (e.CommandName.Equals("Insert"))
        {
            Transactions = GetInstrumentManagementDetails(gvInstrumentManagement.FooterRow);
            InsertInstrumentManagementDetailsInfo(Transactions);
        }
        else if (e.CommandName.Equals("emptyInsert"))
        {
            Transactions = GetInstrumentManagementDetails(null);
            InsertInstrumentManagementDetailsInfo(Transactions);
        }
    }
    
    protected void gvInstrumentManagement_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvInstrumentManagement.EditIndex = e.NewEditIndex;
        GetGridviewControlData();
    }
    
    protected void gvInstrumentManagement_RowUpdating(object sender, GridViewUpdateEventArgs e)
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
    
    protected void gvInstrumentManagement_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvInstrumentManagement.EditIndex = -1;
        //FillRistCriteriaGrid();
    }
    
    protected void gvInstrumentManagement_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        //CTradeImport objTradeImport = new CTradeImport();
        //objTradeImport.rsk_nm = gvTradeImport.DataKeys[e.RowIndex].Values[0].ToString();
        //deleteTradeImport(objTradeImport);
        //FillRistCriteriaGrid();
    }
    
    #endregion
}
