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



public partial class Investor_CustomerAccountOpenDiscritionary : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;

    #region Page load
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageTitle("Account Open(Discretionary)");
        Master.ShowPageNavigationURL("View List", "~/Investor/Account_Open_List_Discritionary.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
           
            txt_OPENING_DT.Text = TypeCasting.DateToString(Util.SystemDate());
            GetDropDownControlData();
           
            String ID = Request.QueryString["ID"];
            if (!String.IsNullOrEmpty(ID))
            {
                SetAccountPersonalInfoByID(Request.QueryString["ID"]);
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.UPDATE);
            }
            else
            {
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.INSERT);
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
        //Populate ddl_OPERATION_TYPE_ID
        ddl_OPERATION_TYPE_ID.DataTextField = "Text";
        ddl_OPERATION_TYPE_ID.DataValueField = "Value";
        ddl_OPERATION_TYPE_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BOAccountOperationType).Data;
        ddl_OPERATION_TYPE_ID.DataBind();

        //Populate ddl_INVESTOR_TYPE_ID
        ddl_INVESTOR_TYPE_ID.DataTextField = "Text";
        ddl_INVESTOR_TYPE_ID.DataValueField = "Value";
        ddl_INVESTOR_TYPE_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BOInvestorType).Data;
        ddl_INVESTOR_TYPE_ID.DataBind();

        //Populate ddl_ACC_TYPE_ID
        ddl_ACC_TYPE_ID.DataTextField = "Text";
        ddl_ACC_TYPE_ID.DataValueField = "Value";
        ddl_ACC_TYPE_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.TradeAccountType).Data;
        ddl_ACC_TYPE_ID.DataBind();
        ddl_ACC_TYPE_ID.SelectedValue = "2";

        //Populate ddl_SUB_ACCOUNT_ID
        ddl_SUB_ACCOUNT_ID.DataTextField = "Text";
        ddl_SUB_ACCOUNT_ID.DataValueField = "Value";
        ddl_SUB_ACCOUNT_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.SubAccount).Data;
        ddl_SUB_ACCOUNT_ID.DataBind();

        //Populate ddl_PARENT_ID
        ddl_PARENT_ID.DataTextField = "Text";
        ddl_PARENT_ID.DataValueField = "Value";
        ddl_PARENT_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.ParentAccount).Data;
        ddl_PARENT_ID.DataBind();

        //Populate ddl_TRADER_ID
        ddl_TRADER_ID.DataTextField = "Text";
        ddl_TRADER_ID.DataValueField = "Value";
        ddl_TRADER_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.Trader).Data;
        ddl_TRADER_ID.DataBind();

        //Populate ddl_BANK_ACC_TP_ID
        ddl_BANK_ACC_TP_ID.DataTextField = "Text";
        ddl_BANK_ACC_TP_ID.DataValueField = "Value";
        ddl_BANK_ACC_TP_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BankAccountType).Data;
        ddl_BANK_ACC_TP_ID.DataBind();

        //Populate ddl_BANK_BRANCH_ID
        ddl_BANK_BRANCH_ID.DataTextField = "Text";
        ddl_BANK_BRANCH_ID.DataValueField = "Value";
        ddl_BANK_BRANCH_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BankBranch).Data;
        ddl_BANK_BRANCH_ID.DataBind();

        //Populate ddl_BANK_BRANCH_ID
        ddl_BANK_ID.DataTextField = "Text";
        ddl_BANK_ID.DataValueField = "Value";
        ddl_BANK_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.Bank).Data;
        ddl_BANK_ID.DataBind();

        //Populate ddl_COUNTRY_ID
        ddl_COUNTRY_ID.DataTextField = "Text";
        ddl_COUNTRY_ID.DataValueField = "Value";
        ddl_COUNTRY_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.Country).Data;
        ddl_COUNTRY_ID.DataBind();

        //Populate ddl_DISTRICT_ID
        ddl_DISTRICT_ID.DataTextField = "Text";
        ddl_DISTRICT_ID.DataValueField = "Value";
        ddl_DISTRICT_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.District).Data;
        ddl_DISTRICT_ID.DataBind();

        //Populate ddl_BRANCH_ID
        ddl_BRANCH_ID.DataTextField = "Text";
        ddl_BRANCH_ID.DataValueField = "Value";
        ddl_BRANCH_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BrokerBranch).Data;
        ddl_BRANCH_ID.DataBind();

        //Populate ddl_ACCOUNT_STATUS_ID
        ddl_ACCOUNT_STATUS_ID.DataTextField = "Text";
        ddl_ACCOUNT_STATUS_ID.DataValueField = "Value";
        ddl_ACCOUNT_STATUS_ID.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BOAccountStatus).Data;
        ddl_ACCOUNT_STATUS_ID.DataBind();
    }

    private Dictionary<String, String> GetAccountPersonalInfo()
    {
        Dictionary<String, String> oParams = new Dictionary<string, string>();
        try
        {
            oParams.Add("ID", hdn_ID.Value);
            oParams.Add("INVESTOR_CODE", txt_INVESTOR_CODE.Text);
            oParams.Add("BO_CODE", txt_BO_CODE.Text);
            oParams.Add("FIRST_JOIN_HOLDER_NAME", txt_FIRST_JOIN_HOLDER_NAME.Text);
            oParams.Add("SEC_JOIN_HOLDER_NAME", txt_SEC_JOIN_HOLDER_NAME.Text);
            oParams.Add("FATHER_NAME", txt_FATHER_NAME.Text);
            oParams.Add("MOTHER_NAME", txt_MOTHER_NAME.Text);
            oParams.Add("BRANCH_ID", ddl_BRANCH_ID.SelectedValue);
            oParams.Add("OPERATION_TYPE_ID", ddl_OPERATION_TYPE_ID.SelectedValue);
            oParams.Add("INVESTOR_TYPE_ID", ddl_INVESTOR_TYPE_ID.SelectedValue);
            oParams.Add("ACC_TYPE_ID", ddl_ACC_TYPE_ID.SelectedValue);
            oParams.Add("PARENT_ID", ddl_PARENT_ID.SelectedValue);
            oParams.Add("SUB_ACCOUNT_ID", ddl_SUB_ACCOUNT_ID.SelectedValue);
            oParams.Add("OPENING_DT", txt_OPENING_DT.Text);


            oParams.Add("PRESENT_ADDRESS", txt_PRESENT_ADDRESS.Text);
            oParams.Add("PARMANENT_ADDRESS", txt_PARMANENT_ADDRESS.Text);
            oParams.Add("PHONE", txt_PHONE.Text);
            oParams.Add("MOBILE", txt_MOBILE.Text);
            oParams.Add("FAX", txt_FAX.Text);
            oParams.Add("EMAIL", txt_EMAIL.Text);
            oParams.Add("GENDER", ddl_GENDER.SelectedValue);
            oParams.Add("VOTER_ID_NO", txt_VOTER_ID_NO.Text);
            oParams.Add("INTRODUCER_CODE", txt_INTRODUCER_CODE.Text);
            oParams.Add("INTRODUCER_NAME", txt_INTRODUCER_NAME.Text);
            oParams.Add("INTRODUCER_CONTACT_NO", txt_INTRODUCER_CONTACT_NO.Text);
            oParams.Add("SPECIAL_INSTRUCTION", txt_SPECIAL_INSTRUCTION.Text);
            oParams.Add("OCCUPATION", txt_Occupation.Text);
            oParams.Add("DISTRICT_ID", ddl_DISTRICT_ID.SelectedValue);

            oParams.Add("COUNTRY_ID", ddl_COUNTRY_ID.SelectedValue);
            oParams.Add("PASSPORT_NO", txt_PASSPORT_NO.Text);
            oParams.Add("TIN_NO", txt_TIN_NO.Text);
            oParams.Add("BIRTH_DT", txt_BIRTH_DT.Text);
            oParams.Add("ACCOUNT_STATUS_ID", ddl_ACCOUNT_STATUS_ID.SelectedValue);
            oParams.Add("BANK_ID", ddl_BANK_ID.SelectedValue);
            oParams.Add("BANK_BRANCH_ID", ddl_BANK_BRANCH_ID.SelectedValue);
            oParams.Add("BANK_ACC_TP_ID", ddl_BANK_ACC_TP_ID.SelectedValue);
            oParams.Add("BANK_ACC_NO", txt_BANK_ACC_NO.Text);
            oParams.Add("TRADER_ID", ddl_TRADER_ID.SelectedValue);
            oParams.Add("INTEREST_CAL_ON", txt_INTEREST_CAL_ON.Text);
            oParams.Add("SMS_SERVICE_ST", chk_Is_SMS_service.Checked.ToString());
            oParams.Add("EMAIL_SERVICE_ST", chk_Is_Email_service.Checked.ToString());
            oParams.Add("IS_PAYIN", chk_IS_PAYIN.Checked.ToString());
            oParams.Add("IS_PAYOUT", chk_IS_PAYOUT.Checked.ToString());
            oParams.Add("LOAN_RATIO", txt_LOAN_RATIO.Text);

            oParams.Add("FJH_PHOTO_PATH", imgFJH.ImageUrl);
            oParams.Add("SJH_PHOTO_PATH", imgSJH.ImageUrl);
            oParams.Add("FJH_SIGNATURE_PATH", imgSignatureFJH.ImageUrl);
            oParams.Add("SJH_SIGNATURE_PATH", imgSignatureSJH.ImageUrl);
            oParams.Add("ROUTING_NO", txtRoutingNo.Text);

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
            txt_BO_CODE.Text = oRow["BO_CODE"].ToString();
            txt_FIRST_JOIN_HOLDER_NAME.Text = oRow["FIRST_JOIN_HOLDER_NAME"].ToString();
            txt_SEC_JOIN_HOLDER_NAME.Text = oRow["SEC_JOIN_HOLDER_NAME"].ToString();
            txt_FATHER_NAME.Text = oRow["FATHER_NAME"].ToString();
            txt_MOTHER_NAME.Text = oRow["MOTHER_NAME"].ToString();
            ddl_BRANCH_ID.SelectedValue = oRow["BRANCH_ID"].ToString();
            ddl_OPERATION_TYPE_ID.SelectedValue = oRow["OPERATION_TYPE_ID"].ToString();
            ddl_INVESTOR_TYPE_ID.SelectedValue = oRow["INVESTOR_TYPE_ID"].ToString();
            ddl_ACC_TYPE_ID.SelectedValue = oRow["ACC_TYPE_ID"].ToString();
            ddl_PARENT_ID.SelectedValue = oRow["PARENT_ID"].ToString();
            ddl_SUB_ACCOUNT_ID.SelectedValue = oRow["SUB_ACCOUNT_ID"].ToString();

            txt_OPENING_DT.Text = TypeCasting.DateToString( oRow["OPENING_DT"].ToString());
            txt_PRESENT_ADDRESS.Text = oRow["PRESENT_ADDRESS"].ToString();
            txt_PARMANENT_ADDRESS.Text = oRow["PARMANENT_ADDRESS"].ToString();
            txt_PHONE.Text = oRow["PHONE"].ToString();
            txt_MOBILE.Text = oRow["MOBILE"].ToString();
            txt_FAX.Text = oRow["FAX"].ToString();
            txt_EMAIL.Text = oRow["EMAIL"].ToString();

            ddl_GENDER.SelectedValue = oRow["GENDER"].ToString();

            txt_VOTER_ID_NO.Text = oRow["VOTER_ID_NO"].ToString();
            txt_INTRODUCER_CODE.Text = oRow["INTRODUCER_CODE"].ToString();
            txt_INTRODUCER_NAME.Text = oRow["INTRODUCER_NAME"].ToString();
            txt_INTRODUCER_CONTACT_NO.Text = oRow["INTRODUCER_CONTACT_NO"].ToString();
            txt_SPECIAL_INSTRUCTION.Text = oRow["SPECIAL_INSTRUCTION"].ToString();
            txt_Occupation.Text = oRow["OCCUPATION"].ToString();
            ddl_DISTRICT_ID.SelectedValue = oRow["DISTRICT_ID"].ToString();
            ddl_COUNTRY_ID.SelectedValue = oRow["COUNTRY_ID"].ToString();

            txt_PASSPORT_NO.Text = oRow["PASSPORT_NO"].ToString();
            txt_TIN_NO.Text = oRow["TIN_NO"].ToString();
            txt_BIRTH_DT.Text = TypeCasting.DateToString(oRow["BIRTH_DT"].ToString());
            ddl_ACCOUNT_STATUS_ID.SelectedValue = oRow["ACCOUNT_STATUS_ID"].ToString();
            ddl_BANK_ID.SelectedValue = oRow["BANK_ID"].ToString();
            ddl_BANK_BRANCH_ID.SelectedValue = oRow["BANK_BRANCH_ID"].ToString();
            ddl_BANK_ACC_TP_ID.SelectedValue = oRow["BANK_ACC_TP_ID"].ToString();
            txt_BANK_ACC_NO.Text = oRow["BANK_ACC_NO"].ToString();
            ddl_TRADER_ID.SelectedValue = oRow["TRADER_ID"].ToString();
            txt_INTEREST_CAL_ON.Text = oRow["INTEREST_CAL_ON"].ToString();

            chk_IS_PAYIN.Checked = Convert.ToBoolean(oRow["IS_PAYIN"].ToString());
            chk_IS_PAYOUT.Checked = Convert.ToBoolean(oRow["IS_PAYOUT"].ToString());
            txt_LOAN_RATIO.Text = oRow["LOAN_RATIO"].ToString();

            imgFJH.ImageUrl = oRow["FJH_PHOTO_PATH"].ToString();
            imgSignatureFJH.ImageUrl = oRow["FJH_SIGNATURE_PATH"].ToString();
            imgSJH.ImageUrl = oRow["SJH_PHOTO_PATH"].ToString();
            imgSignatureSJH.ImageUrl = oRow["SJH_SIGNATURE_PATH"].ToString();

            txtRoutingNo.Text = oRow["ROUTING_NO"].ToString();
            
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
        if (CResult.IsSuccess)
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
        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Updated.");
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

    #region Image Uploading
    private void ImageUpload(string sImageUploadDirectory, string sImageName, FileUpload fu,System.Web.UI.WebControls.Image img)
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
            sImageUrl =  sImageUploadDirectory + "/" + sImageName + FileNameExtension;

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


    protected void btnUploadFJHPicture_Click(object sender, EventArgs e)
    {
        string sImageUploadDirectory = ConfigurationManager.AppSettings["ImageStoreDirectory"].ToString();
        string sImageName = "FirstAccountPhoto"+DateTime.Now.Ticks.ToString()+""+txt_INVESTOR_CODE.Text.Trim();
        try
        {
            ImageUpload(sImageUploadDirectory, sImageName, fuFJHpicture,imgFJH);
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    protected void btnUploadFJHSignature_Click(object sender, EventArgs e)
    {
        string sImageUploadDirectory = ConfigurationManager.AppSettings["SignatureStoreDirectory"].ToString();
        string sImageName = "FirstAccountSignature" + DateTime.Now.Ticks.ToString() + "" + txt_INVESTOR_CODE.Text.Trim();
        try
        {
            ImageUpload(sImageUploadDirectory, sImageName, fuFJHSignature,imgSignatureFJH);
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    protected void btnUploadSJHPicture_Click(object sender, EventArgs e)
    {
        string sImageUploadDirectory = ConfigurationManager.AppSettings["ImageStoreDirectory"].ToString();
        string sImageName = "SecondAccountPhoto" + DateTime.Now.Ticks.ToString() + "" + txt_INVESTOR_CODE.Text.Trim();
        try
        {
            ImageUpload(sImageUploadDirectory, sImageName, fuSJHpicture,imgSJH);
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }


    protected void btnUploadSJHSignature_Click(object sender, EventArgs e)
    {
        string sImageUploadDirectory = ConfigurationManager.AppSettings["SignatureStoreDirectory"].ToString();
        string sImageName = "SecondAccountSignature" + DateTime.Now.Ticks.ToString() + "" + txt_INVESTOR_CODE.Text.Trim();
        try
        {
            ImageUpload(sImageUploadDirectory, sImageName, fuSJHSignature,imgSignatureSJH);
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    
  
    #endregion

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        
        if (!ValidateInsertAccountInfo()) return;

        InsertAccountInfo();
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        
        if (!ValidateUpdateAccountInfo()) return;

        UpdateAccountInfo();
    }

    protected void chkIsFull_CheckedChanged(object sender, EventArgs e)
    {
       
    }

    protected void btn_Clear_Click(object sender,EventArgs e)
    {
        Response.Redirect("../Investor/CustomerAccountOpenDiscritionary.aspx");
    }
}
