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
using System.IO;

public partial class DBManagement_DBBackupRestore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDropDownControlData();
            GetBackupList();
        }
    }

    private void GetBackupList()
    {
        ArrayList FilesList = new ArrayList();
        string[] arrFile = Directory.GetFiles(ConfigurationSettings.AppSettings["DBBackupDestination"].ToString());
        FilesList.AddRange(arrFile);
        FilesList.Reverse();
        lstDBBackupList.DataSource = FilesList;
        lstDBBackupList.DataBind();
    }

    private void GetDropDownControlData()
    {
        ddlDatabaseList.DataTextField = "Text";
        ddlDatabaseList.DataValueField = "Value";
        ddlDatabaseList.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.DatabaseNameList).Data;
        ddlDatabaseList.DataBind();
    }
   
    private bool ValidateDBBackup()
    {
        if (!Page.IsValid) return false;
        return true;
    }
    
    private void FullDatabaseBackup()
    {
        if (!ValidateDBBackup()) return;

        BLLDBManagement BLLDBManagement = new BLLDBManagement();
        CResult CResult = new CResult();
        CResult = BLLDBManagement.BackupDatabase(ddlDatabaseList.SelectedValue, ConfigurationSettings.AppSettings["DBBackupDestination"].ToString(),txtRemarks.Text);

        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Backuped.");
            GetBackupList();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }


    private void DatabaseRestore()
    {
        if (!ValidateDBBackup()) return;

        BLLDBManagement BLLDBManagement = new BLLDBManagement();
        CResult CResult = new CResult();
        CResult = BLLDBManagement.RestoreDatabase(ddlDatabaseList.SelectedValue, lstDBBackupList.SelectedItem.Value);

        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Restored.");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    protected void btnFullDBBackup_Click(object sender, EventArgs e)
    {
        FullDatabaseBackup();
    }

    protected void btnDBRestore_Click(object sender, EventArgs e)
    {
        DatabaseRestore();
    }

    protected void btnDeleteFile_Click(object sender, EventArgs e)
    {
        File.Delete(lstDBBackupList.SelectedItem.Value);
        GetBackupList();
    }
    
}
