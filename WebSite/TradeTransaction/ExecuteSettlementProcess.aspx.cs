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
using Common;
using System.Collections.Generic;

public partial class TradeTransaction_ExecuteSettlementProcess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtTradingDate.Text = TypeCasting.DateToString( Util.SystemDate());
        }
    }

    protected void btnExecuteSettlement_Click(object sender, EventArgs e)
    {
        CResult CResult = new CResult();

        BLLTradingManagement BLLTradingManagement = new BLLTradingManagement();
        CResult = BLLTradingManagement.ExecuteSettlementProcess(txtTradingDate.Text);

        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Processed");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    protected void btnReverseSettlement_Click(object sender, EventArgs e)
    {
        CResult CResult = new CResult();

        BLLTradingManagement BLLTradingManagement = new BLLTradingManagement();
        CResult = BLLTradingManagement.ReverseSettlementProcess(txtTradingDate.Text);

        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Reversed");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

}
