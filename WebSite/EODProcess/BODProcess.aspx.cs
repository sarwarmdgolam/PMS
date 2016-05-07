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
using Common;
using System.Collections.Generic;
using BLL;

public partial class EODProcess_EODProcess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetPossibleDayStartDate();
        }
    }


    private bool ValidateDayEndProcess()
    {
        return true;
    }

    private void GetPossibleDayStartDate()
    {
        CResult CResult = new CResult();
        BLLEODProcess BLLEODProcess = new BLLEODProcess();
        CResult = BLLEODProcess.GetPossibleDayStartDate();
        if (CResult.Data.Rows.Count > 0)
        {
            txtTransactionDate.Text = TypeCasting.DateToString(CResult.Data.Rows[0]["TRANSACTION_DATE"].ToString());
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void ProcessDayStart()
    {
        String Transaction_Date = txtTransactionDate.Text.Trim();
        CResult CResult = new CResult();
        BLLEODProcess BLLEODProcess = new BLLEODProcess();
        CResult = BLLEODProcess.ProcessDayStart(Transaction_Date);


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

        ProcessDayStart();
    }
}
