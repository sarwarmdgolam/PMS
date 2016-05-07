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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using BLL;
using Common;

public partial class ReportManagement_ReportShareHoldings : System.Web.UI.Page
{
    #region Vaiable Declaration
    protected ReportDocument objReportDocument;
    protected string ReportName = "";
    protected string ReportTitle = "";
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtTransactionDate.Text = TypeCasting.DateToString(Util.SystemDate());
            SetClearMessage();            
        }
    } 
    #endregion
    private void SetClearMessage()
    {
        this.divErrMesg.Visible = false;
        this.divInfoMsg.Visible = false;
        lblErrMsg.Text = String.Empty;
        lblMsg.Text = String.Empty;
    }

    protected void SetReportData()
    {
        string strReportPath = Server.MapPath(@"../Reports/" + ReportName + "REPORT_BROKER_SHARE_HOLDINGS.rpt");
        this.objReportDocument.Load(strReportPath);

        // for passing connection info
        ConnectionInfo connectionInfo = new ConnectionInfo();
        connectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings["Report_ServerName"].ToString();
        connectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings["Report_ServerDBName"].ToString(); 
        connectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings["Report_UserID"].ToString();
        connectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings["Report_Password"].ToString();
        SetPermissions(connectionInfo);

        this.objReportDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
    }

    private void SetPermissions(ConnectionInfo conInfo)
    {
        Sections crSections = objReportDocument.ReportDefinition.Sections;
        foreach (Section crSection in crSections)
        {
            foreach (ReportObject crReportObject in crSection.ReportObjects)
            {
                if (crReportObject.Kind == ReportObjectKind.SubreportObject)
                {
                    SubreportObject crSubReportObject = (SubreportObject)crReportObject;
                    ReportDocument subreport = crSubReportObject.OpenSubreport(crSubReportObject.SubreportName);
                    foreach (CrystalDecisions.CrystalReports.Engine.Table subtbl in subreport.Database.Tables)
                    {
                        TableLogOnInfo objTableLogonInfo = subtbl.LogOnInfo;
                        objTableLogonInfo.ConnectionInfo = conInfo;
                        subtbl.ApplyLogOnInfo(objTableLogonInfo);
                        //subtbl.Location = subtbl.Location.Substring(subtbl.Location.LastIndexOf(".") + 1);
                    }
                }
            }
        }
    }
    
    protected void PreviewReport(ApplicationEnums.ReportPreviewType sFormat,String TransDate)
    {
        objReportDocument = new ReportDocument();
        SetReportData();
        objReportDocument.SetParameterValue("@TRANSACTION_DATE", TypeCasting.ToDateTime(TransDate) );
        objReportDocument.SetParameterValue("@CREATED_BY", "99");

        Session["ReportDocument"] = objReportDocument;
        string url = "ShowReport.aspx?ReportFormat=" + sFormat;
        ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}',null,\"status=yes,toolbar=no,menubar=no,location=no,resizable=yes \");</script>", url));

    }

    protected void btnPreviewPDF_Click(object sender, EventArgs e)
    {
        PreviewReport(ApplicationEnums.ReportPreviewType.PDF, txtTransactionDate.Text);
    }
    
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        PreviewReport(ApplicationEnums.ReportPreviewType.EXCEL, txtTransactionDate.Text);
    }

    protected void btnExcelData_Click(object sender, EventArgs e)
    {
        PreviewReport(ApplicationEnums.ReportPreviewType.EXCELDATA, txtTransactionDate.Text);
    }

    protected void btnDoc_Click(object sender, EventArgs e)
    {
        PreviewReport(ApplicationEnums.ReportPreviewType.DOC, txtTransactionDate.Text);
    }
}
