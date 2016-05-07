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
using System.Collections.Generic;
using Common;
using BLL;
using DAL;
using System.Data.SqlClient;
using BLLTradeManagement;

public partial class TradeManagement_TraderInfo : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;
    
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageTitle("Trader info");
        Master.ShowPageNavigationURL("View List", "~/TradeManagement/TraderInfoList.aspx");
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
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDropDownControlData();

            String ID = Request.QueryString["ID"];
            if (!String.IsNullOrEmpty(ID))
            {
                GetEntityInfo(ID, "");
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.UPDATE);
            }
            else
            {
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.INSERT);
            }
        }
    }

    private void GetDropDownControlData()
    {
        //Populate Security Exchange
        ddl_security_exchange.DataTextField = "Text";
        ddl_security_exchange.DataValueField = "Value";
        ddl_security_exchange.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.SecurityExchange).Data;
        ddl_security_exchange.DataBind();

        //Populate broker branch
        ddl_Trading_branch.DataTextField = "Text";
        ddl_Trading_branch.DataValueField = "Value";
        ddl_Trading_branch.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BrokerBranch).Data;
        ddl_Trading_branch.DataBind();


        //Populate employee
        ddl_employee.DataTextField = "Text";
        ddl_employee.DataValueField = "Value";
        ddl_employee.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.EmployeeList).Data;
        ddl_employee.DataBind();

    }


    public CResult GetEntityInfo(String ID, String strTRADER_CODE)
    {
        CResult CResult = new CResult();
        String Query = @"[SP_GET_TRADER_INFO]";
        try
        {
            SqlParameter[] objList = new SqlParameter[2];
            objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));
            objList[1] = new SqlParameter("@TRADER_CODE", strTRADER_CODE);

            DatabaseManager DatabaseManager = new DatabaseManager();
            CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, false, CommandType.StoredProcedure);

            SetEntityInfo(CResult.Data);
        }
        catch (Exception ex)
        {
            CResult.IsSuccess = false;
            CResult.Message = ex.Message;
        }
        return CResult;
    }

    private Dictionary<String, String> GetEntityInfoToSave()
    {
        Dictionary<String, String> oParams = new Dictionary<string, string>();
        oParams.Add("ID", hdn_ID.Value);
        oParams.Add("TRADER_CODE", txt_trader_code.Text);
        oParams.Add("BRANCH_ID", ddl_Trading_branch.SelectedValue);
        oParams.Add("SECURITY_EXCHANGE_ID", ddl_security_exchange.SelectedValue);
        oParams.Add("EMPLOYEE_ID", ddl_employee.SelectedValue);
        oParams.Add("CARD_REF_NO", txt_card_ref_no.Text);
        oParams.Add("IS_ACTIVE", chk_IsActive.Checked.ToString());
        return oParams;
    }

    private void SetEntityInfo(DataTable dtEntityInfo)
    {
        try
        {
            hdn_ID.Value = dtEntityInfo.Rows[0]["ID"].ToString();
            txt_trader_code.Text= dtEntityInfo.Rows[0]["TRADER_CODE"].ToString();
            ddl_Trading_branch.SelectedValue = dtEntityInfo.Rows[0]["BRANCH_ID"].ToString();
            ddl_security_exchange.SelectedValue = dtEntityInfo.Rows[0]["SECURITY_EXCHANGE_ID"].ToString();
            ddl_employee.SelectedValue = dtEntityInfo.Rows[0]["EMPLOYEE_ID"].ToString();
            txt_card_ref_no.Text = dtEntityInfo.Rows[0]["CARD_REF_NO"].ToString();
            chk_IsActive.Checked = TypeCasting.ToBoolean(dtEntityInfo.Rows[0]["IS_ACTIVE"].ToString());
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    private bool ValidateInsertionInfo()
    {
        if (!Page.IsValid) return false;

        if (!Page_Create)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Warning, "Dont have enough Permission.");
            return false;
        }
        return true;
    }

    private void InsertEntityInfo()
    {
        if (!ValidateInsertionInfo()) return;

        BLLTraderInfo BLLTraderInfo1 = new BLLTraderInfo();
        CResult CResult = new CResult();
        Dictionary<String, String> oParams = GetEntityInfoToSave();
        CResult = BLLTraderInfo1.InsertTraderInfo(oParams);
        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }


    private void UpdateEntityInfo()
    {
        BLLTraderInfo BLLTraderInfo1 = new BLLTraderInfo();
        CResult CResult = new CResult();
        Dictionary<String, String> oParams = GetEntityInfoToSave();
        CResult = BLLTraderInfo1.UpdateTraderInfo(oParams);
        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Updated.");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }


    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            InsertEntityInfo();
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
        
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateEntityInfo();
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
        
    }

    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        Response.Redirect("TraderInfo.aspx");
    }
}
