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
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using Common;

public partial class ReportManagement_ShowReport : System.Web.UI.Page
{
    protected ReportDocument objReportDocument;
    String sReportFormat = string.Empty;
    String sFileName = "Report";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ReportFormat"] != null && Request.QueryString["ReportFormat"] != "")
            sReportFormat = Request.QueryString["ReportFormat"].ToString();
        else sReportFormat = string.Empty;

        if (Session["ReportDocument"] != null)
        {
            sReportFormat = Request.QueryString["ReportFormat"].ToString();
            objReportDocument = (ReportDocument)Session["ReportDocument"];

            if (String.Equals(sReportFormat.ToUpper(), ApplicationEnums.ReportPreviewType.PDF.ToString()))
            {
                CrystalExportReporttoPdf();
            }
        }
    }

    public void CrystalExportReporttoPdf()
    {
        MemoryStream oStream;
        try
        {
            oStream = (MemoryStream)
            objReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            Context.Response.Clear();
            Context.Response.ClearContent();
            objReportDocument.Dispose();

            Session["ReportDocument"] = null;
            Context.Response.Buffer = true;
            Context.Response.AddHeader("content-disposition", string.Format("inline;filename={0}.pdf", sFileName));
            Context.Response.ContentType = "application/pdf";
            Context.Response.BinaryWrite(oStream.ToArray());

            Context.Response.End();
            Context.Response.ClearContent();
            Context.Response.Flush();
            oStream.Close();
            oStream.Dispose();
        }
        catch (Exception ex)
        {
            Context.Response.Write(ex.Message);
        }
        finally
        {

            HttpContext.Current.ApplicationInstance.CompleteRequest();
            Context.Response.Flush();
        }

    }

}
