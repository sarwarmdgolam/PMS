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
using BLL;

public partial class UserControls_SearchInvestor : System.Web.UI.UserControl
{
   
    #region Private Method
    private void GetInvestorInformation()
    {
        try
        {
            BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
            String Investor_Code = txtInvestorCode.Text.Trim();
            BLLAccountOpen.GetInvestorNameByCode(ref Investor_Code);
            if (Investor_Code.Split('=')[0] == "0")
            {
                txtInvestorCode.Text = String.Empty;
                hdnInvestor_ID.Value = "0";
            }
            else
            {
                hdnInvestor_ID.Value = Investor_Code.Split('=')[0];
            }
            txtInvestorName.Text = Investor_Code.Split('=')[1];
        }
        catch (Exception ex)
        {
            txtInvestorName.Text = ex.Message;
        }
    } 
    #endregion

    #region Events
    protected void btnSearchInvestor_Click(object sender, EventArgs e)
    {
        GetInvestorInformation();
    }

    public string InvestorID
    {
        get
        {
            return hdnInvestor_ID.Value;
        }
    }

    protected void txtInvestorCode_TextChanged(object sender, EventArgs e)
    {
        GetInvestorInformation();
    } 
    #endregion
}
