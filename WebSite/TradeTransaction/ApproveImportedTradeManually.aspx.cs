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

public partial class TradeTransaction_ApproveImportedTradeManually : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetTradeTransaction();
        }
    }

    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        CResult CResult = new CResult();
        BLLTradingManagement BLLTradingManagement = new BLLTradingManagement();
        CResult = BLLTradingManagement.ApproveImportTradeManuallyByExchange(TypeCasting.DateToString(Util.SystemDate()));

        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Approved");
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
         
        }
    }


    private void GetTradeTransaction()
    {
        CResult CResult = new CResult();
        
        BLLTradingManagement BLLTradingManagement = new BLLTradingManagement();
        CResult = BLLTradingManagement.GetImportTradeManuallyByExchange();

        if (CResult.IsSuccess && CResult.Data.Rows.Count>0)
        {
            GridView1.DataSource = CResult.Data;
            GridView1.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }
    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        this.Page.Response.Redirect("../TradeTransaction/ApproveImportedTradeManually.aspx");
    }
}
