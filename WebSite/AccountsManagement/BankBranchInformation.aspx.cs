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
using BLLAccountsManagement;

public partial class AccountsManagement_BankBranchInformation : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;

    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;

        Master.ShowPageNavigationURL("View List", "~/AccountsManagement/BankBranchInformationList.aspx");
    }

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDropDownControlData();
            hdn_ID.Value = Request.QueryString["ID"];

            if (!String.IsNullOrEmpty(hdn_ID.Value))
            {
                GetEntityInfo(hdn_ID.Value, String.Empty);
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.UPDATE);
            }
            else
            {
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.INSERT);
            }
        }
    }
    #endregion

    #region Methods

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
        //Populate Company Information
        ddl_Bank.DataTextField = "Text";
        ddl_Bank.DataValueField = "Value";
        ddl_Bank.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.Bank).Data;
        ddl_Bank.DataBind();
    }

    private Dictionary<String, String> GetEntityInfo()
    {
        Dictionary<String, String> oParams = new Dictionary<string, string>();
        oParams.Add("ID", hdn_ID.Value);
        oParams.Add("BANK_ID", ddl_Bank.SelectedValue);
        oParams.Add("BRANCH_NAME", txt_BranchName.Text);
        oParams.Add("ADDRESS", txt_Address.Text);
        return oParams;
    }

    private void InsertEntityInfo()
    {
        if (!ValidateInsertEntityInfo()) return;


        BLLBankManagement BLLBankManagement1 = new BLLBankManagement();
        CResult CResult = new CResult();
        Dictionary<String, String> oParams = GetEntityInfo();
        CResult = BLLBankManagement1.InsertBankBranchInfo(oParams);
        if (CResult.IsSuccess)
        {
            ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.REFRESH);
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void UpdateEntityInfo()
    {
        if (!ValidateUpdateEntityInfo()) return;

        //BLLEntityInformation BLLEntityInformation = new BLLEntityInformation();
        //CResult CResult = new CResult();
        //Dictionary<String, String> oParams = GetEntityInfo();
        //CResult = BLLEntityInformation.UpdateEntityInfo(oParams);
        //if (CResult.IsSuccess)
        //{
        //    ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.REFRESH);
        //    (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Updated.");
        //}
        //else
        //{
        //    (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        //}
    }

    private void SetEntityInfo(DataTable EntityInfo)
    {
        try
        {
            hdn_ID.Value = EntityInfo.Rows[0]["ID"].ToString();
            ddl_Bank.SelectedValue = EntityInfo.Rows[0]["BANK_ID"].ToString();
            txt_BranchName.Text = EntityInfo.Rows[0]["BRANCH_NAME"].ToString();
            txt_Address.Text = EntityInfo.Rows[0]["ADDRESS"].ToString();
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    private void GetEntityInfo(String ID, String BankID)
    {
        BLLBankManagement BLLBankManagement1 = new BLLBankManagement();
        CResult CResult = new CResult();
        CResult = BLLBankManagement1.GetBankBranchInfo(ID, BankID);
        if (CResult.IsSuccess)
        {
            SetEntityInfo(CResult.Data);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private bool ValidateInsertEntityInfo()
    {
        if (!Page.IsValid) return false;

        if (!Page_Create)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Warning, "Dont have enough Permission.");
            return false;
        }
        return true;
    }

    private bool ValidateUpdateEntityInfo()
    {
        if (!Page.IsValid) return false;

        if (!Page_Update)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Warning, "Dont have enough Permission.");
            return false;
        }
        return true;
    }
    #endregion

    #region Control Events
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        InsertEntityInfo();
    }
    #endregion

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        UpdateEntityInfo();
    }
    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        this.Page.Response.Redirect("../AccountsManagement/BankBranchInformation.aspx");
    }
}
