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
using BLLAccountsManagement;

public partial class AccountsManagement_BankInfo : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;
    
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageTitle("Bank info");
        Master.ShowPageNavigationURL("View List", "~/AccountsManagement/BankInfoList.aspx");
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
            String ID = Request.QueryString["ID"];
            if (!String.IsNullOrEmpty(ID))
            {
                GetEntityInfo(ID);
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.UPDATE);
            }
            else
            {
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.INSERT);
            }
        }
    }


    public CResult GetEntityInfo(String ID)
    {
        CResult CResult = new CResult();
        String Query = @"[SP_GET_BANK_INFO]";
        try
        {
            SqlParameter[] objList = new SqlParameter[1];
            objList[0] = new SqlParameter("@ID", TypeCasting.ToInt64(ID));

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
        oParams.Add("BANK_S_NAME", txt_short_name.Text);
        oParams.Add("BANK_F_NAME", txt_full_name.Text);
        return oParams;
    }

    private void SetEntityInfo(DataTable dtEntityInfo)
    {
        try
        {
            hdn_ID.Value = dtEntityInfo.Rows[0]["ID"].ToString();
            txt_short_name.Text=dtEntityInfo.Rows[0]["BANK_S_NAME"].ToString();
            txt_full_name.Text=dtEntityInfo.Rows[0]["BANK_F_NAME"].ToString();
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

        BLLBankManagement BLLBankManagement1 = new BLLBankManagement();
        CResult CResult = new CResult();
        Dictionary<String, String> oParams = GetEntityInfoToSave();
        CResult = BLLBankManagement1.InsertBankInfo(oParams);
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
        BLLBankManagement BLLBankManagement1 = new BLLBankManagement();
        CResult CResult = new CResult();
        Dictionary<String, String> oParams = GetEntityInfoToSave();
        CResult = BLLBankManagement1.UpdateBankInfo(oParams);
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
        Response.Redirect("BankInfo.aspx");
    }
}
