using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Net;
using Common;
using BLL;


public partial class MasterPage_DefaultWithoutMenu : System.Web.UI.MasterPage
{
    #region Class-global variables
    public static string QinMasterOnLoadScript = "";
    protected DataTable alt_q_dt = null;
    protected string alt_q_js = "";
    public string warning;
    #endregion
    #region Member Variables
    private TreeNode rootNode;
    #endregion
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "Client  :: " + this.Page.Title;
    }

  
    #endregion
    private void CheckSessionTimeout()
    {
        string msgSession = "Warning: Within next 3 minutes, if you do not do anything, " +
            " our system will redirect to the login page. Please save changed data.";

        //time to remind, 3 minutes before session ends   
        int int_MilliSecondsTimeReminder = (this.Session.Timeout * 200);

        //time to redirect, 5 milliseconds before session ends   
        int int_MilliSecondsTimeOut = (this.Session.Timeout * 200) - 5;

        string str_Script = @" var myTimeReminder, myTimeOut; " +
            " clearTimeout(myTimeReminder); " +
            " clearTimeout(myTimeOut); " +
            "var sessionTimeReminder = " + int_MilliSecondsTimeReminder.ToString() + "; " +
            "var sessionTimeout = " + int_MilliSecondsTimeOut.ToString() + ";" +
            "function doReminder(){ alert('" + msgSession + "'); }" +
            "function doRedirect(){ window.location.href='../Login.aspx'; }" +
            " myTimeReminder=setTimeout('doReminder()', sessionTimeReminder); myTimeOut=setTimeout('doRedirect()',sessionTimeout); ";

        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "CheckSessionOut", str_Script, true);
    }
    //#region Event Driven Methods
    //protected void lnkLogin_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Default.aspx");
    //}
    //protected void loginStatus_OnLoggedOut(object sender, EventArgs e)
    //{
    //    Session.Abandon();
    //    FormsAuthentication.SignOut();
    //    Response.Redirect("~/Default.aspx");
    //}
    //#endregion

   
}