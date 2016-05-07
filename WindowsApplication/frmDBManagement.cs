using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using BLL;
using DAL;
using System.Configuration;

namespace WindowsApplication
{
    public partial class frmDBManagement : Form
    {
        public frmDBManagement()
        {
            InitializeComponent();
            GetDropDownControlData();
        }

        private void GetDropDownControlData()
        {
            ddlDatabaseNameList.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.DatabaseNameList).Data;
            ddlDatabaseNameList.DisplayMember = "Text";
            ddlDatabaseNameList.ValueMember = "Value";
            
        }

        private bool ValidateDBBackup()
        { 
        return true;
        }
        private void FullDatabaseBackup()
        {
            if (!ValidateDBBackup()) return;

            BLLDBManagement BLLDBManagement = new BLLDBManagement();
            CResult CResult = new CResult();
            CResult = BLLDBManagement.BackupDatabase(ddlDatabaseNameList.SelectedValue, ConfigurationSettings.AppSettings["DBBackupDestination"].ToString());

            if (CResult.IsSuccess)
            {
                (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");
                MessageBox.Show("", "Information");
            }
            else
            {
                (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
            }
        }

        private void btnFullBackup_Click(object sender, EventArgs e)
        {

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {

        }

        private void btnPartialBackup_Click(object sender, EventArgs e)
        {

        }
    }
}