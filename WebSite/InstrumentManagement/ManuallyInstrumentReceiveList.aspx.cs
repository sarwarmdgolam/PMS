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
using System.Text;

public partial class InstrumentManagement_ManuallyInstrumentReceiveList : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("Add New", "~/InstrumentManagement/ManuallyInstrumentReceive.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetGridviewControlData();
        }
    }

    private void GetGridviewControlData()
    {
        BLLInstrumentManagement BLLInstrumentManagement = new BLLInstrumentManagement();
        CResult CResult = new CResult();
        CResult = BLLInstrumentManagement.GETINSERTINSTTRANSACTIONINFO("0", "0", TypeCasting.DateToString(Util.SystemDate()), TypeCasting.DateToString(Util.SystemDate()));
        if (CResult.IsSuccess)
        {
            dgvManageInstReceive.DataSource = CResult.Data;
            dgvManageInstReceive.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    #region Grid Events

    protected void dgvManageInstReceive_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            StringBuilder st = new StringBuilder();

            e.Row.Cells[3].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='ManuallyInstrumentReceive.aspx?ID=" + drv["ID"].ToString() + "'>Edit</a>";
            e.Row.Cells[4].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='ManuallyInstrumentReceiveList.aspx?action=Delete&ID=" + drv["ID"].ToString() + "' onclick='return confirm(\"Are you sure you wish to delete this Data?\")'>Delete</a>";
        }
    }

    protected void dgvManageInstReceive_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
        GetGridviewControlData();
    }

    #endregion Grid Events
   
}
