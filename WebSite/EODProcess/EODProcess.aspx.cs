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
using Model;
using BLL;
using Common;
using System.Collections.Generic;

public partial class EODProcess_EODProcess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtTransactionDate.Text = TypeCasting.DateToString(Util.SystemDate());
            GetCashReconcilation();
            GetStockReconcilation();
        }
    }


    private bool ValidateDayEndProcess()
    {
        return true;
    }

    private void GetCashReconcilation()
    {
        BLLReconciliation BLLReconciliation = new BLLReconciliation();
        CResult CResult = new CResult();
        CResult = BLLReconciliation.GetDailyCashReconciliation();

        if (CResult.IsSuccess)
        {
            gvCashReconcilation.DataSource = CResult.Data;
            gvCashReconcilation.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);

        }
    }

    private void GetStockReconcilation()
    {
        BLLReconciliation BLLReconciliation = new BLLReconciliation();
        CResult CResult = new CResult();
        CResult = BLLReconciliation.GetDailyStockReconciliation();

        if (CResult.IsSuccess)
        {
            gvStockReconciliation.DataSource = CResult.Data;
            gvStockReconciliation.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);

        }
    }

    private void ProcessDayEnd()
    {
        String Transaction_Date = txtTransactionDate.Text.Trim();
        CResult CResult = new CResult();
        BLLEODProcess BLLEODProcess = new BLLEODProcess();
        CResult = BLLEODProcess.ProcessDayEnd(Transaction_Date);

        if (CResult.IsSuccess)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Done.");

        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (!ValidateDayEndProcess()) return;

        ProcessDayEnd();
    }

    protected void gvCashReconcilation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvCashReconcilation.PageIndex = e.NewPageIndex;
    }

    protected void gvStockReconciliation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvStockReconciliation.PageIndex = e.NewPageIndex;
    }
}
