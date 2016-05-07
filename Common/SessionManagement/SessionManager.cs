using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Authentication
{
    [Serializable]
    public class SessionManager
    {
        public SessionManager()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void SetSession(string sName, object oValue)
        {
            HttpContext.Current.Session[sName] = oValue;
        }

        public static object GetSession(string sName)
        {
            Object oReturnvalue = null;

            if (HttpContext.Current.Session[sName] != null)
            {
                oReturnvalue = HttpContext.Current.Session[sName];
            }

            return oReturnvalue;
        }

        public static bool CheckSession(string sName)
        {

            if (HttpContext.Current.Session[sName] != null)
            {
                return true;
            }

            return false;
        }

        public static void RemoveSession(string sName)
        {
            if (HttpContext.Current.Session[sName] != null)
                HttpContext.Current.Session.Remove(sName);
        }

        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}
