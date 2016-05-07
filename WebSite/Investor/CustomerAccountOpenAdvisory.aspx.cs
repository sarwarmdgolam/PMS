

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
using Model;
using BLL;
using System.Collections.Generic;
using Common;
using System.IO;
using System.Drawing;

public partial class Investor_CustomerAccountOpenAdvisory : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;
    ContentPlaceHolder mainContent ;

    #region Page load
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageTitle("Account Open(Advisory)");
        Master.ShowPageNavigationURL("View List", "~/Investor/Account_Open_List_Advisory.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        mainContent = (ContentPlaceHolder)this.Master.FindControl("Main");
        if (!IsPostBack)
        {
            try
            {
                txtIncorporationDate.Text = txtCorporateOpeningDate.Text = TypeCasting.DateToString(Util.SystemDate());
                GetDropDownControlData();
                String ID = Request.QueryString["ID"];
                if (!String.IsNullOrEmpty(ID))
                {
                    SetAccountPersonalInfoByID(ID);
                    ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.UPDATE);
                }
                else
                {
                    ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.INSERT);
                }
            }
            catch (Exception ex)
            {
                (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
            }
        }
    }
    #endregion

    private void ControlSelectionMode(Common.ApplicationEnums.UIOperationMode Mode)
    {
        switch (Mode)
        {
            case Common.ApplicationEnums.UIOperationMode.INSERT:
                btn_Save.Enabled = true;
                btn_Update.Enabled = false;
                btn_Save2.Enabled = true;
                btn_Update2.Enabled = false;
                break;
            case Common.ApplicationEnums.UIOperationMode.UPDATE:
                btn_Save.Enabled = false;
                btn_Update.Enabled = true;
                btn_Save2.Enabled = false;
                btn_Update2.Enabled = true;
                break;
            case Common.ApplicationEnums.UIOperationMode.REFRESH:
                btn_Save.Enabled = false;
                btn_Update.Enabled = false;
                btn_Save2.Enabled = false;
                btn_Update2.Enabled = false;
                break;
        }
    }

    private void GetDropDownControlData()
    {
        
        //Populate ddl_ACC_TYPE_ID
        ddl_ACC_TYPE_ID.DataTextField = "Text";
        ddl_ACC_TYPE_ID.DataValueField = "Value";
        ddl_ACC_TYPE_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.TradeAccountType).Data;
        ddl_ACC_TYPE_ID.DataBind();

        //ddl_ACC_TYPE_ID.SelectedValue = "1";
        //ddl_ACC_TYPE_ID.Enabled = false;
        
        
        //Populate ddl_ACCOUNT_STATUS_ID
        ddlBusinessNature.DataTextField = "Text";
        ddlBusinessNature.DataValueField = "Value";
        ddlBusinessNature.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.CustomerBusinessNature).Data;
        ddlBusinessNature.DataBind();

        //Populate ddl_ACCOUNT_STATUS_ID
        ddl_ACCOUNT_STATUS_ID.DataTextField = "Text";
        ddl_ACCOUNT_STATUS_ID.DataValueField = "Value";
        ddl_ACCOUNT_STATUS_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BOAccountStatus).Data;
        ddl_ACCOUNT_STATUS_ID.DataBind();

        //Populate Bank
        ddlBank.DataTextField = "Text";
        ddlBank.DataValueField = "Value";
        ddlBank.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.Bank).Data;
        ddlBank.DataBind();

        //Populate ddl_BANK_ACC_TP_ID
        ddl_BANK_ACC_TP_ID.DataTextField = "Text";
        ddl_BANK_ACC_TP_ID.DataValueField = "Value";
        ddl_BANK_ACC_TP_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BankAccountType).Data;
        ddl_BANK_ACC_TP_ID.DataBind();

        //Populate Bank Branch
        ddlBankBranch.DataTextField = "Text";
        ddlBankBranch.DataValueField = "Value";
        ddlBankBranch.DataSource = BLLCommonEntity.GetBankBranch(ddlBank.SelectedValue).Data;
        ddlBankBranch.DataBind();


        //Populate ddl_ACC_TYPE_ID
        ddl_SUB_ACCOUNT_ID.DataTextField = "Text";
        ddl_SUB_ACCOUNT_ID.DataValueField = "Value";
        ddl_SUB_ACCOUNT_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.SubAccount).Data;
        ddl_SUB_ACCOUNT_ID.DataBind();
    }

    private Dictionary<String, String> GetAccountPersonalInfo()
    {
        Dictionary<String, String> oParams = new Dictionary<string, string>();
        try
        {
            oParams.Add("ID", hdn_ID.Value);
            oParams.Add("INVESTOR_CODE", txt_INVESTOR_CODE.Text);
            oParams.Add("BO_CODE", txtExistingBOCode.Text);
            oParams.Add("FIRST_JOIN_HOLDER_NAME",txtExistingBOAcc.Text);
            oParams.Add("ACC_TYPE_ID", ddl_ACC_TYPE_ID.SelectedValue);
            oParams.Add("OPENING_DT", txtCorporateOpeningDate.Text);
            oParams.Add("PHONE",txtCorporatePhoneOffice.Text);
            oParams.Add("MOBILE", txtCorporatePhoneCell.Text);
            oParams.Add("FAX", txtCorporateFaxNo.Text);
            oParams.Add("EMAIL", txtCorporateEmail.Text);
            oParams.Add("TIN_NO", txtTINNo.Text);
            oParams.Add("BUSINESSNATURE_ID", ddlBusinessNature.SelectedValue);
            oParams.Add("TRADELICENSENO", txtTradeLicenseNo.Text);
            oParams.Add("INCORPORATIONDATE", txtIncorporationDate.Text);
            oParams.Add("REGISTRATIONNO", txtRegistrationNo.Text);
            oParams.Add("CORPORATENAME", txtCorporateName.Text);
            oParams.Add("CorporatedOfficeAddress", txtCorporatedOfficeAddress.Text);
            oParams.Add("CORPORATEMDNAME", txtCompanyMDName.Text);
            oParams.Add("EXISTINGBOACCDP", txtExistingBOAccDP.Text);
            oParams.Add("EXISTINGBOBROKER", txtExistingBOBroker.Text);
            oParams.Add("ACCOUNT_STATUS_ID", ddl_ACCOUNT_STATUS_ID.SelectedValue);

            oParams.Add("BANK_ID", ddlBank.SelectedValue);
            oParams.Add("BANK_BRANCH_ID", ddlBankBranch.SelectedValue);
            oParams.Add("BANK_ACC_TP_ID", ddl_BANK_ACC_TP_ID.SelectedValue);
            oParams.Add("BANK_ACC_NO", txt_BANK_ACC_NO.Text);
            oParams.Add("ROUTING_NO", txtRoutingNo.Text);

            oParams.Add("INTRODUCER_CODE", txt_INTRODUCER_CODE.Text);
            oParams.Add("INTRODUCER_NAME", txt_INTRODUCER_NAME.Text);
            oParams.Add("INTRODUCER_CONTACT_NO", txt_INTRODUCER_CONTACT_NO.Text);
            oParams.Add("SPECIAL_INSTRUCTION", txt_SPECIAL_INSTRUCTION.Text);

            oParams.Add("SUB_ACCOUNT_ID", ddl_SUB_ACCOUNT_ID.SelectedValue);

            oParams.Add("CREATED_BY", "0");
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
        return oParams;
    }

    private void SetAccountPersonalInfo(DataRow oRow)
    {
        try
        {
            hdn_ID.Value = oRow["ID"].ToString();
            txt_INVESTOR_CODE.Text = oRow["INVESTOR_CODE"].ToString();
            ddl_ACC_TYPE_ID.SelectedValue = oRow["ACC_TYPE_ID"].ToString();
            txtTINNo.Text = oRow["TIN_NO"].ToString();
            ddlBusinessNature.SelectedValue = oRow["BUSINESSNATURE_ID"].ToString();
            txtTradeLicenseNo.Text = oRow["TRADELICENSENO"].ToString();
            txtIncorporationDate.Text = TypeCasting.DateToString(oRow["INCORPORATIONDATE"].ToString());
            txtRegistrationNo.Text = oRow["REGISTRATIONNO"].ToString();
            txtCorporateName.Text = oRow["CORPORATENAME"].ToString();
            txtCorporatedOfficeAddress.Text = oRow["CorporatedOfficeAddress"].ToString();
            txtCompanyMDName.Text = oRow["CORPORATEMDNAME"].ToString();
            txtCorporateOpeningDate.Text = TypeCasting.DateToString(oRow["OPENING_DT"].ToString());

            txtExistingBOCode.Text = oRow["BO_CODE"].ToString();
            txtExistingBOAcc.Text = oRow["FIRST_JOIN_HOLDER_NAME"].ToString();
            txtExistingBOAccDP.Text = oRow["EXISTINGBOACCDP"].ToString();
            txtExistingBOBroker.Text = oRow["EXISTINGBOBROKER"].ToString();

            ddlBusinessNature.SelectedValue = oRow["BUSINESSNATURE_ID"].ToString();
            txtCorporatedOfficeAddress.Text = oRow["CorporatedOfficeAddress"].ToString();
            txtCompanyMDName.Text = oRow["CORPORATEMDNAME"].ToString();
            
            txtCorporatePhoneOffice.Text = oRow["PHONE"].ToString();
            txtCorporatePhoneCell.Text = oRow["MOBILE"].ToString();
            txtCorporateFaxNo.Text = oRow["FAX"].ToString();
            txtCorporateEmail.Text = oRow["EMAIL"].ToString();
            txtTradeLicenseNo.Text = oRow["TRADELICENSENO"].ToString();
            txtTINNo.Text = oRow["TIN_NO"].ToString();
            txtRegistrationNo.Text = oRow["REGISTRATIONNO"].ToString();

            ddl_ACCOUNT_STATUS_ID.SelectedValue = oRow["ACCOUNT_STATUS_ID"].ToString();


            ddlBank.SelectedValue = oRow["BANK_ID"].ToString();

            //Populate Bank Branch
            ddlBankBranch.DataTextField = "Text";
            ddlBankBranch.DataValueField = "Value";
            ddlBankBranch.DataSource = BLLCommonEntity.GetBankBranch(ddlBank.SelectedValue).Data;
            ddlBankBranch.DataBind();

            ddlBankBranch.SelectedValue = oRow["BANK_BRANCH_ID"].ToString();
            ddl_BANK_ACC_TP_ID.SelectedValue = oRow["BANK_ACC_TP_ID"].ToString();
            txt_BANK_ACC_NO.Text = oRow["BANK_ACC_NO"].ToString();
            txtRoutingNo.Text = oRow["ROUTING_NO"].ToString();

            txt_INTRODUCER_CODE.Text = oRow["INTRODUCER_CODE"].ToString();

            txt_INTRODUCER_NAME.Text = oRow["INTRODUCER_NAME"].ToString();

            txt_INTRODUCER_CONTACT_NO.Text = oRow["INTRODUCER_CONTACT_NO"].ToString();

            txt_SPECIAL_INSTRUCTION.Text = oRow["SPECIAL_INSTRUCTION"].ToString();

            ddl_SUB_ACCOUNT_ID.SelectedValue= oRow["SUB_ACCOUNT_ID"].ToString();
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    private void InsertAccountInfo()
    {
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        CResult CResult = new CResult();
        Dictionary<String, String> oParams = GetAccountPersonalInfo();

        CResult = BLLAccountOpen.InsertAccountInfo(oParams);
        if (CResult.AffectedRows > 0)
        {

            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");

        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void UpdateAccountInfo()
    {
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        CResult CResult = new CResult();
        Dictionary<String, String> oParams = GetAccountPersonalInfo();

        CResult = BLLAccountOpen.UpdateAccountInfo(oParams);
        if (CResult.AffectedRows>0)
        {
           
                (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Updated.");
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.REFRESH);
            
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void SetAccountPersonalInfoByID(String ID)
    {
        if (String.IsNullOrEmpty(ID)) return;

        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        CResult CResult = new CResult();
        CResult = BLLAccountOpen.GetAccountInfo(ID, "", "", "");
        if (CResult.IsSuccess && CResult.Data.Rows.Count>0)
        {
            SetAccountPersonalInfo(CResult.Data.Rows[0]);

          
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private bool ValidateInsertAccountInfo()
    {
        if (!Page_Create)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, "Dont have enough Permission.");
            return false;
        }
        if (!Page.IsValid)
        {
            return false;
        }
        return true;
    }

    private bool ValidateUpdateAccountInfo()
    {
        if (!Page_Update)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, "Dont have enough Permission.");
            return false;
        }
        if (!Page.IsValid)
        {
            return false;
        }
        return true;
    }

    /*
    private CResult InsertAuthorizedSignature()
    {
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        CResult CResult = new CResult();
        if(!String.IsNullOrEmpty(hdn_ID.Value))
        {
            CResult = BLLAccountOpen.DeleteAuthorizedSignature(hdn_ID.Value);

            if (CResult.IsSuccess)
            {
                List<Dictionary<String, String>> oParamsList = GetAuthorizedSignature();
                if (oParamsList.Count > 0)
                {
                    CResult = BLLAccountOpen.InsertAuthorizedSignature(oParamsList);
                }
            }
        }
       
        return CResult;
    }

    private List<Dictionary<String, String>> GetAuthorizedSignature()
    {
        List<Dictionary<String, String>> oParamsList = new List<Dictionary<string, string>>();
        for (int i = 1; i <= 4; i++)
        {
            Dictionary<String, String> oParam = new Dictionary<string, string>();
            if (mainContent.FindControl("txtName" + i.ToString())!=null &&  !String.IsNullOrEmpty(((TextBox)mainContent.FindControl("txtName" + i.ToString())).Text))
            {
                oParam["INVESTOR_ID"] = hdn_ID.Value;
                oParam["NAME"] = ((TextBox)mainContent.FindControl("txtName" + i.ToString())).Text;
                oParam["DESIGNATION"] = ((TextBox)mainContent.FindControl("txtDesignation" + i.ToString())).Text;
                oParam["PHONE"] = ((TextBox)mainContent.FindControl("txtPhone" + i.ToString())).Text;
                oParam["EMAIL"] = ((TextBox)mainContent.FindControl("txtEmail" + i.ToString())).Text;
                oParam["PHOTO_PATH"] = ((System.Web.UI.WebControls.Image)mainContent.FindControl("ImagePhoto" + i.ToString())).ImageUrl;
                oParam["SIGNATURE_PATH"] = ((System.Web.UI.WebControls.Image)mainContent.FindControl("ImageSignature" + i.ToString())).ImageUrl;
                oParamsList.Add(oParam);
            }
        }
        return oParamsList;
    }

    private void SetAuthorizedSignature(DataTable dt )
    {
        int i=1;
        foreach (DataRow oRow in dt.Rows)
        {
            ((TextBox)mainContent.FindControl("txtName" + i.ToString())).Text = oRow["NAME"].ToString();
            ((TextBox)mainContent.FindControl("txtDesignation" + i.ToString())).Text = oRow["DESIGNATION"].ToString();
            ((TextBox)mainContent.FindControl("txtPhone" + i.ToString())).Text = oRow["PHONE"].ToString();
            ((TextBox)mainContent.FindControl("txtEmail" + i.ToString())).Text = oRow["EMAIL"].ToString();
            ((System.Web.UI.WebControls.Image)mainContent.FindControl("ImagePhoto" + i.ToString())).ImageUrl = oRow["PHOTO_PATH"].ToString();
            ((System.Web.UI.WebControls.Image)mainContent.FindControl("ImageSignature" + i.ToString())).ImageUrl = oRow["SIGNATURE_PATH"].ToString();
            i++;
        }
    }

    */

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (!ValidateInsertAccountInfo()) return;
        try
        {
            InsertAccountInfo();
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        if (!ValidateUpdateAccountInfo()) return;
        try
        {
            UpdateAccountInfo();
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    protected void chkIsFull_CheckedChanged(object sender, EventArgs e)
    {
       
    }

    protected void btn_Clear_Click(object sender,EventArgs e)
    {
        Response.Redirect("../Investor/CustomerAccountOpenAdvisory.aspx");
    }

    protected void ddl_ACC_TYPE_ID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (String.Equals(ddl_ACC_TYPE_ID.SelectedValue, "1"))
        {
            divAdvisoryAccount.Visible = true;
        }
        else
        {
            divAdvisoryAccount.Visible = false;
        }
    }


    #region Image Uploading

    private void ImageUpload(string sImageUploadDirectory, string sImageName, FileUpload fu, System.Web.UI.WebControls.Image img)
    {
        string sImageUrl = string.Empty;
        string FileNameExtension = string.Empty;
        if (!"".Equals(fu.PostedFile.FileName.Trim()) && fu.PostedFile.ContentLength > 0)
        {
            FileNameExtension = System.IO.Path.GetFileName(fu.PostedFile.FileName).ToString().Trim().Remove(0, System.IO.Path.GetFileName(fu.PostedFile.FileName).ToString().Trim().IndexOf('.'));
            if (FileNameExtension != ".gif" && FileNameExtension != ".jpg" && FileNameExtension != ".jpeg" && FileNameExtension != ".bmp" && FileNameExtension != ".png")
            {
                (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, "Invalid Image file.");
                return;
            }

            //Resize Image
            sImageUrl = sImageUploadDirectory + "/" + sImageName + FileNameExtension;

            byte[] pic = null;
            int len = fu.PostedFile.ContentLength;
            if (len > 0)
            {
                pic = new byte[len];
                fu.PostedFile.InputStream.Read(pic, 0, len);
            }

            pic = PhotoManager.ResizeImageFile(pic, 300);
            if (pic != null)
            {
                MemoryStream ms = new MemoryStream(pic);
                System.Drawing.Image imgSave = System.Drawing.Image.FromStream(ms);

                Bitmap bmSave = new Bitmap(imgSave);
                Bitmap bmTemp = new Bitmap(bmSave);

                Graphics grSave = Graphics.FromImage(bmTemp);
                grSave.DrawImage(imgSave, 0, 0, imgSave.Width, imgSave.Height);

                //save resized image
                bmTemp.Save(Server.MapPath(sImageUrl));

                //View image 
                img.ImageUrl = sImageUrl;
                img.DataBind();

                //clear object
                imgSave.Dispose();
                bmSave.Dispose();
                bmTemp.Dispose();
                grSave.Dispose();
            }
        }
    }

    protected void btnUploadImagePhoto_Click(object sender, EventArgs e)
    {
        string sImageUploadDirectory = ConfigurationManager.AppSettings["ImageStoreDirectory"].ToString();
        string sImageName =string.Empty;
        if (!ValidateImageUpload()) return;
        try
        {
            if (((Button)sender).ID == "btnImagePhoto1")
            {
                sImageName = "ImagePhoto1_" + txt_INVESTOR_CODE.Text.Trim();
                ImageUpload(sImageUploadDirectory, sImageName, FileUploadPhoto1, ImagePhoto1);
            }
            else if (((Button)sender).ID == "btnImagePhoto2")
            {
                sImageName = "ImagePhoto2_" + txt_INVESTOR_CODE.Text.Trim();
                ImageUpload(sImageUploadDirectory, sImageName, FileUploadPhoto2, ImagePhoto2);
            }
            else if (((Button)sender).ID == "btnImagePhoto3")
            {
                sImageName = "ImagePhoto3_" + txt_INVESTOR_CODE.Text.Trim();
                ImageUpload(sImageUploadDirectory, sImageName, FileUploadPhoto3, ImagePhoto3);
            }
            else if (((Button)sender).ID == "btnImagePhoto4")
            {
                sImageName = "ImagePhoto4_" + txt_INVESTOR_CODE.Text.Trim();
                ImageUpload(sImageUploadDirectory, sImageName, FileUploadPhoto4, ImagePhoto4);
            }
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    private bool ValidateImageUpload()
    {
        if (String.IsNullOrEmpty(txt_INVESTOR_CODE.Text.Trim()))
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, "Please input Investor Code.");
            return false;
        }
        return true;
    }
    
    protected void btnUploadImageSignature_Click(object sender, EventArgs e)
    {
        string sImageUploadDirectory = ConfigurationManager.AppSettings["SignatureStoreDirectory"].ToString();
        string sImageName = string.Empty;
        if (!ValidateImageUpload()) return;
        try
        {
            if (((Button)sender).ID == "btnImageSignature1")
            {
                sImageName = "ImageSignature1_" + txt_INVESTOR_CODE.Text.Trim();
                ImageUpload(sImageUploadDirectory, sImageName, FileUploadSignature1, ImageSignature1);
            }
            else if (((Button)sender).ID == "btnImageSignature2")
            {
                sImageName = "ImageSignature2_" + txt_INVESTOR_CODE.Text.Trim();
                ImageUpload(sImageUploadDirectory, sImageName, FileUploadSignature2, ImageSignature2);
            }
            //else if (((Button)sender).ID == "btnImageSignature3")
            //{
            //    sImageName = "ImageSignature3_" + txt_INVESTOR_CODE.Text.Trim();
            //    ImageUpload(sImageUploadDirectory, sImageName, FileUploadSignature3, ImageSignature3);
            //}
            //else if (((Button)sender).ID == "btnImageSignature4")
            //{
            //    sImageName = "ImageSignature4_" + txt_INVESTOR_CODE.Text.Trim();
            //    ImageUpload(sImageUploadDirectory, sImageName, FileUploadSignature4, ImageSignature4);
            //}
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Populate Bank Branch
        ddlBankBranch.DataTextField = "Text";
        ddlBankBranch.DataValueField = "Value";
        ddlBankBranch.DataSource = BLLCommonEntity.GetBankBranch(ddlBank.SelectedValue).Data;
        ddlBankBranch.DataBind(); 
    }

    #endregion

}

