using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;

namespace Common
{
    [Serializable]
    public static class SessionManagement
    {
        public static void SetSessionObject(Common.ApplicationEnums.SessionVariablesType Key, object Value)
        {
            HttpContext.Current.Session.Add(Key.ToString(), Value);
        }

        public static object GetSessionObject(Common.ApplicationEnums.SessionVariablesType Key)
        {
            if (HttpContext.Current.Session[Key.ToString()] != null)
            {
                return (object)HttpContext.Current.Session[Key.ToString()];
            }
            return null;
        }

        //public static long LoggedInUserId
        //{
        //    get
        //    {
        //        long lngUserId = 0;

        //        Authentication.Entity.User objUser = SessionManager.GetSession(SessionVariables.USER_LOGGEDIN) as Authentication.Entity.User;

        //        if (objUser != null)
        //        {
        //            lngUserId = objUser.UserId;
        //        }

        //        return lngUserId;
        //    }
        //}

        
        //public static Authentication.Entity.User LoggedInUser
        //{
        //    get
        //    {

        //        Authentication.Entity.User objUser = SessionManager.GetSession(SessionVariables.USER_LOGGEDIN) as Authentication.Entity.User;

        //        if (objUser != null)
        //        {
        //            return objUser;
        //        }

        //        return null;
        //    }
        //}


        //public static bool CheckPrivilege(string pstrNavigateUrl, Privilege privilege)
        //{
        //    bool HasPermission = false;
        //    List<Authentication.Entity.PrivilegedForm> oMenus = new List<Authentication.Entity.PrivilegedForm>();

        //    if (!SessionManager.CheckSession(SessionVariables.PRIVILEGED_FEATURE))
        //    {
        //        DataTable dtMenus = new UserManagement().GetPrivilegedFeaturesOnly(SessionManagement.LoggedInUser);

        //        Authentication.Entity.PrivilegedForm objForm;
        //        foreach (DataRow dr in dtMenus.Rows)
        //        {
        //            objForm = new Authentication.Entity.PrivilegedForm();
        //            objForm.FormName = dr["NAME"].ToString();
        //            objForm.PrivilegeCreate = Convert.ToBoolean(dr["ISINSERT"]);
        //            objForm.PrivilegeUpdate = Convert.ToBoolean(dr["ISUPDATE"]);
        //            objForm.PrivilegeView = Convert.ToBoolean(dr["ISSELECT"]);
        //            objForm.PrivilegeDelete = Convert.ToBoolean(dr["ISDELETE"]);

        //            oMenus.Add(objForm);
        //        }

        //        SessionManager.SetSession(SessionVariables.PRIVILEGED_FEATURE, oMenus);
        //        SessionManager.SetSession(SessionVariables.PRIVILEGED_MENU, dtMenus);
        //    }
        //    else
        //    {
        //        oMenus = SessionManager.GetSession(SessionVariables.PRIVILEGED_FEATURE) as List<Authentication.Entity.PrivilegedForm>;
        //    }


        //    foreach (Authentication.Entity.PrivilegedForm obj in oMenus)
        //    {
        //        if (obj.FormName.ToLower() == pstrNavigateUrl.ToLower())
        //        {
        //            if (privilege == Privilege.READ && obj.PrivilegeView == true)
        //            {
        //                return true;
        //            }
        //            else if (privilege == Privilege.CREATE && obj.PrivilegeCreate == true)
        //            {
        //                return true;
        //            }
        //            else if (privilege == Privilege.UPDATE && obj.PrivilegeUpdate == true)
        //            {
        //                return true;
        //            }
        //            else if (privilege == Privilege.DELETE && obj.PrivilegeDelete == true)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }

        //    }
        //    return HasPermission;
        //}

        //public static void resetSessionPrivilege()
        //{
        //    List<PrivilegedForm> oMenus = new List<PrivilegedForm>();
        //    List<PrivilegedMenu> oModulMenus = new List<PrivilegedMenu>();

        //    DataTable dtMenus = new UserManagement().GetPrivilegedFeaturesOnly(SessionManagement.LoggedInUser);
        //    PrivilegedForm objForm = null;
        //    PrivilegedMenu oPrivilegedMenu = null;

        //    foreach (DataRow dr in dtMenus.Rows)
        //    {
        //        objForm = new Authentication.Entity.PrivilegedForm();
        //        objForm.FormName = dr["NAME"].ToString();
        //        objForm.PrivilegeCreate = Convert.ToBoolean(dr["ISINSERT"]);
        //        objForm.PrivilegeUpdate = Convert.ToBoolean(dr["ISUPDATE"]);
        //        objForm.PrivilegeView = Convert.ToBoolean(dr["ISSELECT"]);
        //        objForm.PrivilegeDelete = Convert.ToBoolean(dr["ISDELETE"]);

        //        oMenus.Add(objForm);

        //        //oPrivilegedMenu = new PrivilegedMenu();
        //        //oPrivilegedMenu.MenuId = Convert.ToInt16(dr["MODULEID"].ToString());
        //        //oPrivilegedMenu.MenuName = dr["MODULENAME"].ToString();
        //        //oPrivilegedMenu.NavigateUrl = dr["NEVIGATIONURL"].ToString();
        //        //oPrivilegedMenu.ParentMenuId = Convert.ToInt16(dr["PARENTID"].ToString());
        //        //oModulMenus.Add(oPrivilegedMenu);
        //    }

        //    SessionManager.SetSession(SessionVariables.PRIVILEGED_FEATURE, oMenus);
        //    SessionManager.SetSession(SessionVariables.PRIVILEGED_MENU, dtMenus);
        //}

        //public static void CheckAuthentication()
        //{            
        //    if (!SessionManager.CheckSession(SessionVariables.USER_LOGGEDIN))
        //    {
        //        HttpContext.Current.Response.Redirect( "~/Default.aspx");
        //    }
        //}

        //public static void CheckAuthentication(string formName, Privilege privilege)
        //{
        //    //String sApplicationPath = SessionManager.CheckSession(ConstantText.SessionApplicationPath) ? (SessionManager.GetSession(ConstantText.SessionApplicationPath)).ToString() : "";            
        //    if (!SessionManager.CheckSession(SessionVariables.USER_LOGGEDIN))
        //    {
        //        HttpContext.Current.Response.Redirect( "~/Default.aspx");
        //    }
        //    else
        //    {
        //        if (!SessionManagement.CheckPrivilege(formName, privilege))
        //            HttpContext.Current.Response.Redirect( "~/Default.aspx?error=privilege");
        //    }
        //}


    }
}
