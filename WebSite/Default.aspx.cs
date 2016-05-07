using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;
using Common;

public partial class Default_aspx  : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetClearMessage();
        }
    }

    private void SetClearMessage()
    {
        this.divErrMesg.Visible = false;
        this.divInfoMsg.Visible = false;
        lblErrMsg.Text = String.Empty;
    }



    private void GetLogInInformation(String UserName,String Password)
    {
        CResult CResult = new CResult();
        BLLAuthenticationInfo BLLAuthenticationInfo = new BLLAuthenticationInfo();
        CResult = BLLAuthenticationInfo.GetUserLoginInfo(UserName, Password);
        if (CResult.IsSuccess)
        {
            if (CResult.Data.Rows.Count > 0)
            {
                Common.SessionManagement.SetSessionObject(ApplicationEnums.SessionVariablesType.CURRENT_USER_ID, CResult.Data.Rows[0]["userid"].ToString());
                Common.SessionManagement.SetSessionObject(ApplicationEnums.SessionVariablesType.CURRENT_USER_NAME, UserName);
              

                Response.Redirect("Home.aspx");
            }
            else
            {
                FailureText.Text = "Invalid User Name Or Password.";
            }
        }
        else
        {
            divErrMesg.Visible = true;
            lblErrMsg.Text = CResult.Message;
        }
    }
    protected void LoginButton_Click1(object sender, EventArgs e)
    {
        String UserName = txtUserName.Text;
        String Password = txtPassword.Text;
        GetLogInInformation(UserName, Password);

    }
}