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
/// <summary>
/// Summary description for Util
/// </summary>
public static class Util
{
    public static DateTime SystemDate()
    {
        String SystemDate = DateTime.Now.Date.ToString();
        CResult CResult = new CResult();
        CResult = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.SystemDate);
        if (CResult.Data.Rows.Count>0)
        {
            SystemDate = CResult.Data.Rows[0][1].ToString();
        }
        return TypeCasting.ToDateTime(SystemDate);
    }
}
