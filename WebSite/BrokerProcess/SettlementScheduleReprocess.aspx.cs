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
using BLL;

public partial class BrokerProcess_SettlementScheduleReprocess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtTransactionDate.Text = TypeCasting.DateToString(Util.SystemDate());
        }
    }

    private bool ValidateSettlementProcess()
    {
        return true;
    }


    private void ProcessSettlementProcess()
    {
        CResult CResult = new CResult();
        BrokerProcess BrokerProcess = new BrokerProcess();
        CResult = BrokerProcess.ReProcessSettlementSchedule();


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
        if (!ValidateSettlementProcess()) return;

        ProcessSettlementProcess();
    }
}
