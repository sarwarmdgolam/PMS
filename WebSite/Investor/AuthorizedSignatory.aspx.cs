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

public partial class Investor_AuthorizedSignatory : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageTitle("Authorized Signature");
        //Master.ShowPageNavigationURL("View List", "~/Investor/AuthorizedSignatoryList.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            
             //Get Investor
            if (!String.IsNullOrEmpty(Request.QueryString["Investor_Code"]))
            {
                txt_investor_code.Text = Request.QueryString["Investor_Code"];
                btnInvestorCodeSearch_Click(null,null);
            }

             //Delete Item
            if (String.Equals(Request.QueryString["Action"], "Edit") && !String.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                GetAuthorizedSignatoryByID(Request.QueryString["ID"].Trim());
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.UPDATE);
            }
            //Delete Item
            else if (String.Equals(Request.QueryString["Action"], "Delete") && !String.IsNullOrEmpty(Request.QueryString["ID"]))
            {
              //  DeleteInvestorAccountOpen(Request.QueryString["ID"].Trim());
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.UPDATE);
            }
            else
            {
                ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.INSERT);
            }
        }
    }

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


    //private void DeleteInvestorAccountOpen(String strID)
    //{
    //    BLLAccountOpen BLLAccountOpen1 = new BLLAccountOpen();
    //    CResult CResult = new CResult();
    //    CResult = BLLAccountOpen1.DeleteAccountInfo(strID);

    //    if (CResult.IsSuccess)
    //    {
    //        (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully deleted.");

    //        GetAuthorizedSignatoryList();
    //        ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.REFRESH);
    //    }
    //    else
    //    {
    //        (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);

    //    }
    //}

    private Dictionary<String, String> GetAuthorizedSignatoryInfo()
    {
        Dictionary<String, String> oParams = new Dictionary<string, string>();
        oParams.Add("ID", hdn_ID.Value);
        oParams.Add("INVESTOR_ID", hdnInvestor_ID.Value);
        oParams.Add("NAME", txt_name.Text);
        oParams.Add("DESIGNATION", txt_Designation.Text);
        oParams.Add("PHONE", txt_Phone.Text);
        oParams.Add("EMAIL", txt_Email.Text);
        oParams.Add("PHOTO_PATH", img_picture.ImageUrl);
        oParams.Add("SIGNATURE_PATH", img_signature.ImageUrl);
        return oParams;
    }

    private void RefreshUIInputControls()
    {
        txt_Designation.Text = String.Empty;
        txt_Email.Text = String.Empty;
        txt_name.Text = String.Empty;
        txt_Phone.Text = String.Empty;
        img_picture.ImageUrl = String.Empty;
        img_signature.ImageUrl = String.Empty;
    }

    private void SetAuthorizedSignatoryInfo(DataTable dtNomineeInfo)
    {
        try
        {
            hdn_ID.Value = dtNomineeInfo.Rows[0]["ID"].ToString();
            hdnInvestor_ID.Value = dtNomineeInfo.Rows[0]["INVESTOR_ID"].ToString();
             txt_name.Text = dtNomineeInfo.Rows[0]["NAME"].ToString();
             txt_Designation.Text = dtNomineeInfo.Rows[0]["DESIGNATION"].ToString();
             txt_Phone.Text = dtNomineeInfo.Rows[0]["PHONE"].ToString();
             txt_Email.Text = dtNomineeInfo.Rows[0]["EMAIL"].ToString();
             img_picture.ImageUrl = dtNomineeInfo.Rows[0]["PHOTO_PATH"].ToString();
             img_signature.ImageUrl = dtNomineeInfo.Rows[0]["SIGNATURE_PATH"].ToString();
          }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    private bool ValidateInsertAuthorizedSignatoryInfo()
    {
        if (!Page.IsValid) return false;

        if (!Page_Create)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Warning, "Dont have enough Permission.");
            return false;
        }
        return true;
    }

    private CResult InsertAuthorizedSignature()
    {
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        CResult CResult = new CResult();
        if (!String.IsNullOrEmpty(hdn_ID.Value))
        {
            CResult = BLLAccountOpen.DeleteAuthorizedSignature(hdn_ID.Value);

            if (CResult.IsSuccess)
            {
                Dictionary<String, String> oParams = GetAuthorizedSignatoryInfo();
                if (oParams.Count > 0)
                {
                    CResult = BLLAccountOpen.InsertAuthorizedSignature(oParams);
                }
            }
        }

        return CResult;
    }

    private void InsertAuthorizedSignatoryInfo()
    {
        if (!ValidateInsertAuthorizedSignatoryInfo()) return;

        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        CResult CResult = new CResult();
        Dictionary<String, String> oParams = GetAuthorizedSignatoryInfo();
        CResult = BLLAccountOpen.InsertAuthorizedSignature(oParams);
        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");
            GetAuthorizedSignatoryList();
            ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.REFRESH);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void GetAuthorizedSignatoryByID(String ID)
    {
        if (String.IsNullOrEmpty(ID)) return;

        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        CResult CResult = new CResult();
        CResult = BLLAccountOpen.GetAuthorizedSignature(ID);
        if (CResult.IsSuccess && CResult.Data.Rows.Count > 0)
        {
            SetAuthorizedSignatoryInfo(CResult.Data);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
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

    private void GetAuthorizedSignatoryList()
    {
        CResult CResult = new CResult();
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        CResult = BLLAccountOpen.GetAuthorizedSignature(hdnInvestor_ID.Value);
        if (CResult.IsSuccess)
        {
            gvNominee.DataSource = CResult.Data;
            gvNominee.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }
  

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        InsertAuthorizedSignatoryInfo();
    }
   
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        if (!ValidateInsertAuthorizedSignatoryInfo()) return;

        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        CResult CResult = new CResult();
        Dictionary<String, String> oParams = GetAuthorizedSignatoryInfo();
        CResult = BLLAccountOpen.UpdateAuthorizedSignature(oParams);
        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully updated.");
            GetAuthorizedSignatoryList();
            ControlSelectionMode(Common.ApplicationEnums.UIOperationMode.REFRESH);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
       
    }
    
    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        Response.Redirect("AuthorizedSignatory.aspx");
    }

    protected void btnUploadN1Picture_Click(object sender, EventArgs e)
    {
        if (!ValidateImageUpload()) return;
        string sImageUploadDirectory = ConfigurationManager.AppSettings["ImageStoreDirectory"].ToString();
        string sImageName =  "SignatoryPhoto_"+ DateTime.Now.Ticks.ToString() +""+   txt_investor_code.Text.Trim();
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
            sImageName = "SignatorySignature_" +DateTime.Now.Ticks.ToString()+""+ txt_investor_code.Text.Trim();
            ImageUpload(sImageUploadDirectory, sImageName, file_n1_signature, img_signature);
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
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
    
    protected void btnInvestorCodeSearch_Click(object sender, EventArgs e)
    {
        RefreshUIInputControls();
        GetInvestorCode();
        GetAuthorizedSignatoryList();
    }

    protected void nominee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            string st = "";
            if (this.Page_Update)
                e.Row.Cells[4].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='AuthorizedSignatory.aspx?action=Edit&id=" + drv["ID"].ToString() + "&Investor_Code="+txt_investor_code.Text+"' >Edit</a>";
            else
                e.Row.Cells[4].Text = "&nbsp;";

            if (this.Page_Delete)
                e.Row.Cells[5].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='AuthorizedSignatory.aspx?action=Delete&id=" + drv["ID"].ToString() + "&Investor_Code=" + txt_investor_code.Text + "' onclick='return confirm(\"Are you sure you wish to delete this record?\")'>Delete</a>";
            else
                e.Row.Cells[5].Text = "&nbsp;";
        }
    }
    
    protected void nominee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //this.lblErrMsg.Text = "";
        //this.lblMsg.Text = "";
        //this.divErrMesg.Visible = false;
        //this.divInfoMsg.Visible = false;

        //gvNominee.PageIndex = e.NewPageIndex;
        //LoadNomineeGrid();
    }
    
    protected void btn_Preview_Click(object sender, EventArgs e)
    {
        try
        {
            if (!String.IsNullOrEmpty(hdnInvestor_ID.Value))
            {
                GetAuthorizedSignatoryList();
            }
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    

}
