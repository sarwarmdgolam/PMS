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
using System.Text;
using System.IO;
using System.Collections.Generic;

public partial class CDBLFileManagement_ImportCDBLFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   
        //Manage Tab 
        String hiddenFieldValue = hidLastTab.Value;
        StringBuilder js = new StringBuilder();
        js.Append("<script type='text/javascript'>");
        js.Append("var previouslySelectedTab = ");
        js.Append(hiddenFieldValue);
        js.Append(";</script>");
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "acttab", js.ToString());

        if (!IsPostBack)
        {
            txtTransactionDateFromUpload.Text = txtTransactionDateToUpload.Text = TypeCasting.DateToString(Util.SystemDate());
            GetDropDownControlData();
        }
    }
   
  

    private void GetDropDownControlData()
    {
        //Populate chkCDBLFileListUpload
        chkCDBLFileListUpload.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.CDBLUploadableFilesList).Data;
        chkCDBLFileListUpload.DataBind();

        chkCDBLFilesProcess.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.CDBLUploadableFilesList).Data;
        chkCDBLFilesProcess.DataBind();

        ddlCDBLFileList.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.CDBLUploadableFilesList).Data;
        ddlCDBLFileList.DataBind();
    }

    private bool ValidateUploadableCDBLFiles()
    {
        if (!fuUploadCDBLFiles.HasFile)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Warning, "Please Select Any One of the Files. ");
            return false;
        }

        return true;
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (ValidateUploadableCDBLFiles())
        {
            String FileName = fuUploadCDBLFiles.PostedFile.FileName;
            foreach (ListItem chkCDBL in chkCDBLFileListUpload.Items)
            {
                if (chkCDBL.Selected)
                {
                   GetCDBLFileContent(FileName,chkCDBL.Value.Split('.')[0],'~');
                }
            }
        }
    }

    private String GetCDBLFilePath(String FolderPath,String CDBLFileName)
    {
        String FilePath = String.Empty;
        DirectoryInfo rootUploadDir = new DirectoryInfo(FolderPath);
        if (rootUploadDir.Exists)
        {
            DirectoryInfo[] sub_dir = rootUploadDir.GetDirectories();
            if (sub_dir.Length != 0)
            {
                foreach (DirectoryInfo subdirectories in sub_dir)
                {
                    try
                    {
                        DateTime _d_sub_dir = TypeCasting.ToDateTime(subdirectories.Name);
                        //if (TypeCasting.ToDateTime(subdirectories.Name) >= TypeCasting.ToDateTime(txtTransactionDateFromUpload.Text) && TypeCasting.ToDateTime(subdirectories.Name) <= TypeCasting.ToDateTime(txtTransactionDateToUpload.Text))
                        //{
                        //    _flg_no_ins = 1;
                        //}
                        //if (TypeCasting.ToDateTime(subdirectories.Name) < TypeCasting.ToDateTime(txtTransactionDateFromUpload.Text) || TypeCasting.ToDateTime(subdirectories.Name) > TypeCasting.ToDateTime(txtTransactionDateToUpload.Text))
                        //    continue;
                        FileInfo[] files = subdirectories.GetFiles("*.txt");

                        foreach (FileInfo oFile in files)
                        {
                            if (String.Equals(oFile.Name, CDBLFileName))
                                return oFile.Name;
                        }
                    }
                    catch
                    {
                        (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, "Invalid Folder(Date)");
                        return null;
                    }
                }
            }
        }
        return null;
    }

    private void GetCDBLFileContent(String FolderPath,String CDBLFileName,Char Delimeter)
    {
        FileParser FileParser = new FileParser();
        DataTable DataTable = new DataTable();
        ArrayList list = new ArrayList();
        String CDBLFilePath = FolderPath;//GetCDBLFilePath( FolderPath, CDBLFileName);
        list = FileParser.PopulateListFromFile(CDBLFilePath, Delimeter);
        DataTable = FileParser.GetDatatableFromArrayList(list);

        if (DataTable.Rows.Count > 0)
        {
            InsertCDBLDataIntoTemp(DataTable, CDBLFileName);
        }
    }

    private void InsertCDBLDataIntoTemp(DataTable dt, String CDBLFileName)
    {
        BLLCDBLFileManagement BLLCDBLFileManagement = new BLLCDBLFileManagement();
        CResult CResult = new CResult();
        CResult = BLLCDBLFileManagement.InsertCDBLUploadedDataIntoTempTbl(dt,CDBLFileName);
        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }


    private void InsertCDBLDataFromTempTable(String CDBLFileName)
    {
        BLLCDBLFileManagement BLLCDBLFileManagement = new BLLCDBLFileManagement();
        CResult CResult = new CResult();
        CResult = BLLCDBLFileManagement.InsertCDBLUploadedDataFromTempTbl( CDBLFileName,txtTransactionDateFromUpload.Text,txtTransactionDateToUpload.Text);
        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (ListItem chkCDBL in chkCDBLFileListUpload.Items)
        {
            if (chkCDBL.Selected)
            {
                InsertCDBLDataFromTempTable( chkCDBL.Value.Split('.')[0]);
            }
        }
    }
    
    protected void btn_Clear_Click(object sender, EventArgs e)
    {

    }

    private void GetCDBLUploadedData()
    {
        String FileName=ddlCDBLFileList.SelectedValue.Split('.')[0].ToString();
        BLLCDBLFileManagement BLLCDBLFileManagement = new BLLCDBLFileManagement();
        CResult CResult = new CResult();
        CResult = BLLCDBLFileManagement.GetCDBLUploadedData(FileName, false.ToString(), txtTransactionDateFromUpload.Text,txtTransactionDateToUpload.Text);

        if (CResult.IsSuccess)
        {
            dgvUnapprovedCDBLData.DataSource = CResult.Data;
            dgvUnapprovedCDBLData.DataBind();
        }
    }
    protected void btnSearchCDBLInfo_Click(object sender, EventArgs e)
    {
        GetCDBLUploadedData();
    }
    
    protected void btnApproveCDBLInfo_Click(object sender, EventArgs e)
    {

    }

    protected void btnProcessCDBLFile_Click(object sender, EventArgs e)
    {

    }

    protected void btnClearProcess_Click(object sender, EventArgs e)
    {

    }
}
