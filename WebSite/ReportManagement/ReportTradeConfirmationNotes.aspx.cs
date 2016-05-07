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

public partial class ReportManagement_ReportTradeConfirmationNotes : System.Web.UI.Page
{
    #region Vaiable Declaration
    protected ReportDocument objReportDocument;
    protected string ReportName = "";
    protected string ReportPath = "";
    protected string CompanyName = "";
    protected string CompanyAddress = "";
    protected string ReportTitle = "";
    int loggedInUserId = 0;
    string restrictedInvCodes = "0"; 
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetClearMessage();
            this.txtFromDate.Text = this.txtToDate.Text = TypeCasting.DateToString(Util.SystemDate());
        }
    } 
    #endregion
    private void SetClearMessage()
    {
        this.divErrMesg.Visible = false;
        this.divInfoMsg.Visible = false;
        lblErrMsg.Text = String.Empty;
    }
    protected void SetReportData()
    {
        string strReportPath = Server.MapPath(@"../Reports/" + ReportName + "REPORT_TRADE_CONFIRMATION_NOTES_SUMMARY.rpt");
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

    private void ValidateInvestorCode()
    {
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        String Investor_Code = txtInvestorCode.Text.Trim();
        BLLAccountOpen.GetInvestorNameByCode(ref Investor_Code);
        if (Investor_Code.Split('=')[0] == "0") txtInvestorCode.Text = String.Empty;
        txtInvestorName.Text = Investor_Code.Split('=')[1];
    }
    protected void btnSearchInvestor_Click(object sender, EventArgs e)
    {
        ValidateInvestorCode();
    }
    protected void txtInvestorCode_TextChanged(object sender, EventArgs e)
    {
        ValidateInvestorCode();
    }
    protected void PreviewReport(ApplicationEnums.ReportPreviewType sFormat, String Investor_Code, String FROM_DATE, String TO_DATE)
    {
        objReportDocument = new ReportDocument();
        SetReportData();

        objReportDocument.SetParameterValue("@INVESTOR_CODE", Investor_Code);
        objReportDocument.SetParameterValue("@FROM_DATE", FROM_DATE);
        objReportDocument.SetParameterValue("@TO_DATE", TO_DATE);
        objReportDocument.SetParameterValue("@CREATED_BY", "99");

        Session["ReportTitle"] = ReportTitle;
        Session["ReportDocument"] = objReportDocument;
        string url = "ShowReport.aspx?ReportFormat=" + sFormat.ToString();
        ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}',null,\"status=yes,toolbar=no,menubar=no,location=no,resizable=yes \");</script>", url));

    }

    protected void btnPreviewPDF_Click(object sender, EventArgs e)
    {
        PreviewReport(ApplicationEnums.ReportPreviewType.PDF, txtInvestorCode.Text, txtFromDate.Text, txtToDate.Text);
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        PreviewReport(ApplicationEnums.ReportPreviewType.EXCEL, txtInvestorCode.Text, txtFromDate.Text, txtToDate.Text);
    }

    protected void btnExcelData_Click(object sender, EventArgs e)
    {
        PreviewReport(ApplicationEnums.ReportPreviewType.EXCELDATA, txtInvestorCode.Text, txtFromDate.Text, txtToDate.Text);
    }

    protected void btnDoc_Click(object sender, EventArgs e)
    {
        PreviewReport(ApplicationEnums.ReportPreviewType.DOC, txtInvestorCode.Text, txtFromDate.Text, txtToDate.Text);
    }

    

        

        

}
