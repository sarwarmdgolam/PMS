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


public partial class MasterPage_Default : System.Web.UI.MasterPage
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
        if (Common.SessionManagement.GetSessionObject(ApplicationEnums.SessionVariablesType.CURRENT_USER_ID) == null)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            this.Page.Title = "Client  :: " + this.Page.Title;
            if (!Page.IsPostBack)
            {
                SetClearMessage();
                GetMenuData();
                lblTradingDate.Text = lblTradingDate.Text + TypeCasting.DateToString(Util.SystemDate());

                lblLoginName.Text = Common.SessionManagement.GetSessionObject(ApplicationEnums.SessionVariablesType.CURRENT_USER_NAME).ToString();
            }

            ////Set Content Page Title
            if (!String.IsNullOrEmpty(Request.QueryString["Title"]))
            {
                ShowPageTitle(Request.QueryString["Title"]);
            }
        }
    }

    private void GetMenuData()
    {
        if (Common.SessionManagement.GetSessionObject(ApplicationEnums.SessionVariablesType.CURRENT_USER_ID) == null) return;
        CResult CResult = new CResult();
        BLLAuthenticationInfo BLLAuthenticationInfo = new BLLAuthenticationInfo();
        CResult = BLLAuthenticationInfo.GetMenuInfo( (String)Common.SessionManagement.GetSessionObject(ApplicationEnums.SessionVariablesType.CURRENT_USER_ID));
        if (CResult.IsSuccess)
        {
            if (CResult.Data.Rows.Count > 0)
            {
                DataView view = new DataView(CResult.Data);
                view.RowFilter = "menu_parent_id is NULL";
                foreach (DataRowView row in view)
                {
                    MenuItem menuItem = new MenuItem(row["menu_name"].ToString(), row["menu_id"].ToString());
                  
                    if (String.IsNullOrEmpty(row["menu_url"].ToString()))
                    {
                        menuItem.Selectable = false;
                    }
                    else
                    {
                        menuItem.NavigateUrl = row["menu_url"].ToString();
                    }
                       
                    menuBar.Items.Add(menuItem);
                    AddChildItems(CResult.Data, menuItem);


                }
            }
        }

    }
    private void AddChildItems(DataTable table, MenuItem menuItem)
    {
        DataView viewItem = new DataView(table);
        viewItem.RowFilter = "menu_parent_id=" + menuItem.Value;
        foreach (DataRowView childView in viewItem)
        {
            MenuItem childItem = new MenuItem(childView["menu_name"].ToString(), childView["menu_id"].ToString());
            childItem.NavigateUrl = childView["menu_url"].ToString();
            menuItem.ChildItems.Add(childItem);
            AddChildItems(table, childItem);
        }
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

    private void SetClearMessage()
    {
        this.divErrMesg.Visible = false;
        this.divInfoMsg.Visible = false;
        lblErrMsg.Text = String.Empty;
        lblMsg.Text = String.Empty;
    }

    public void ShowPageNavigationURL(String Text,String URL)
    {
        aPageNav.InnerText = Text;
        aPageNav.HRef = URL;
    }

    public void ShowPageTitle(String Title)
    {
        spanPageTile.InnerText= Title;
    }

    public void ShowApplicationMessage(ApplicationEnums.ApplicationMessageType msgType, String Message)
    {
        switch (msgType)
        {
            case ApplicationEnums.ApplicationMessageType.Informaiton:
                divErrMesg.Visible = false;
                divInfoMsg.Visible = true;
                lblErrMsg.Text = String.Empty;
                lblMsg.Text = Message;
                break;
            case ApplicationEnums.ApplicationMessageType.Warning:
                divErrMesg.Visible = false;
                divInfoMsg.Visible = false;
                lblErrMsg.Text = Message;
                lblMsg.Text = Message;
                break;
            case ApplicationEnums.ApplicationMessageType.Error:
                divErrMesg.Visible = true;
                divInfoMsg.Visible = false;
                lblErrMsg.Text = Message;
                lblMsg.Text = String.Empty;
                break;
        }
    }
   
#region Event Driven Methods
    protected void lnkLogin_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("~/Default.aspx");

    }
  
    #endregion


}