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
using BLL;
using Common;
using System.IO;
using System.Drawing;

public partial class Investor_InvestorNominee : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageTitle("Nominee Information");
        Master.ShowPageNavigationURL("View List", "~/Investor/InvestorNomineeList.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }


    private Dictionary<String, String> GetInvestorNomineeInfo()
    {
        Dictionary<String, String> oParams = new Dictionary<string, string>();
        oParams.Add("ID", hdn_ID.Value);
        oParams.Add("INVESTOR_ID", hdnInvestor_ID.Value);
        oParams.Add("NOMINEE_NAME", txt_nominee_name.Text);
        oParams.Add("NOMINEE_ADDRESS", txt_present_addresss.Text);
        oParams.Add("PHONE_NO", txt_Phone.Text);
        oParams.Add("RELATION_WITH", txt_Relation.Text);
        oParams.Add("SHARE_PERCENTAGE", txt_share_percent.Text);
        oParams.Add("NOMINEE_PHOTO", "");
        oParams.Add("NOMINEE_SIGNATURE", "");

        return oParams;
    }

    private void SetInvestorNomineeInfo(DataTable dtNomineeInfo)
    {
        try
        {
            hdn_ID.Value = dtNomineeInfo.Rows[0]["ID"].ToString();
            hdnInvestor_ID.Value = dtNomineeInfo.Rows[0]["INVESTOR_ID"].ToString();
            txt_nominee_name.Text = dtNomineeInfo.Rows[0]["NOMINEE_NAME"].ToString();
            txt_present_addresss.Text = dtNomineeInfo.Rows[0]["NOMINEE_ADDRESS"].ToString();
            txt_Phone.Text = dtNomineeInfo.Rows[0]["PHONE_NO"].ToString();
            txt_Relation.Text = dtNomineeInfo.Rows[0]["RELATION_WITH"].ToString();
            txt_share_percent.Text = dtNomineeInfo.Rows[0]["SHARE_PERCENTAGE"].ToString();
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);

        }
    }

    private bool ValidateInsertInvestorNomineeInfo()
    {
        if (!Page.IsValid) return false;

        if (!Page_Create)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Warning, "Dont have enough Permission.");
            return false;
        }
        return true;
    }

    private void InsertInvestorNomineeInfo()
    {
        if (!ValidateInsertInvestorNomineeInfo()) return;

        BLLInvestorNominee BLLInvestorNominee = new BLLInvestorNominee();
        CResult CResult = new CResult();
        Dictionary<String, String> oParams = GetInvestorNomineeInfo();
        CResult = BLLInvestorNominee.InsertInvestorNomineeInfo(oParams);
        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        InsertInvestorNomineeInfo();
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {

    }
    protected void btn_Clear_Click(object sender, EventArgs e)
    {

    }

   
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

    private bool ValidateImageUpload()
    {
        if (String.IsNullOrEmpty(hdnInvestor_ID.Value.Trim()) && hdnInvestor_ID.Value.Trim() == "0")
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, "Please input Investor Code.");
            return false;
        }
        return true;
    }

    protected void btnUploadN1Picture_Click(object sender, EventArgs e)
    {
        if (!ValidateImageUpload()) return;
        string sImageUploadDirectory = ConfigurationManager.AppSettings["ImageStoreDirectory"].ToString();
        string sImageName = "NomineePhoto_" + DateTime.Now.Ticks.ToString() + "" + txt_investor_code.Text.Trim();
        try
        {
            ImageUpload(sImageUploadDirectory, sImageName, file_n1_picture, img_picture);
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }
    protected void btnUploadN1Signature_Click(object sender, EventArgs e)
    {
        if (!ValidateImageUpload()) return;
        string sImageUploadDirectory = ConfigurationManager.AppSettings["SignatureStoreDirectory"].ToString();
        string sImageName = string.Empty;
        try
        {
            sImageName = "NomineeSignature_" + DateTime.Now.Ticks.ToString() + "" + txt_investor_code.Text.Trim();
            ImageUpload(sImageUploadDirectory, sImageName, file_n1_signature, img_signature);
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    private void GetInvestorCode()
    {
        String Investor_Code = txt_investor_code.Text.Trim();
        if (!String.IsNullOrEmpty(Investor_Code))
        {
            BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
            BLLAccountOpen.GetInvestorNameByCode(ref Investor_Code);
            hdnInvestor_ID.Value = Investor_Code.Split('=')[0];
            if (hdnInvestor_ID.Value == "0") txt_investor_code.Text = String.Empty;
            txt_investor_name.Text = Investor_Code.Split('=')[1];
        }
    }

    protected void btnInvestorCodeSearch_Click(object sender, EventArgs e)
    {
        GetInvestorCode();
    }
}
