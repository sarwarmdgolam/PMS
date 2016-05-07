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
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using Common;
using Model;

public partial class ReportManagement_ReportShow : System.Web.UI.Page
{
    ReportManagement ReportManagement = new ReportManagement();
    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("Go Back", "~/ReportManagement/ReportParameterPage.aspx");
    }

    private void PreviewReport()
    {
        try 
        {
                if (ReportManagement != null)
            {
                MasterPage_Default Master = (MasterPage_Default)this.Master;
                Master.ShowPageTitle(ReportManagement.Title);
                
                //set report server information
                repViewer.ServerReport.ReportServerUrl = new Uri(ReportManagement.ReportServerUrl);
                repViewer.ServerReport.ReportPath = ReportManagement.ReportPath;
            }


            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList = (List<ReportParameter>)Common.SessionManagement.GetSessionObject(ApplicationEnums.SessionVariablesType.REPORTPARAMETERLIST);
            repViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            if (paramList != null)
            {
                repViewer.ServerReport.SetParameters(paramList);
            }
            repViewer.ShowBackButton = false;
            repViewer.ShowCredentialPrompts = false;
            repViewer.ShowParameterPrompts = false;
            repViewer.ServerReport.Refresh();
        }
        catch(Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    private void ShowReport(Common.ApplicationEnums.ReportPreviewType Format)
    {
        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList = (List<ReportParameter>)Common.SessionManagement.GetSessionObject(ApplicationEnums.SessionVariablesType.REPORTPARAMETERLIST);

        if (ReportManagement != null)
        {
            repViewer.Reset();
            repViewer.ShowCredentialPrompts = false;
            repViewer.ShowParameterPrompts = false;
            repViewer.ServerReport.ReportServerUrl = new Uri(ReportManagement.ReportServerUrl);
            repViewer.ServerReport.ReportPath = ReportManagement.ReportPath;
            repViewer.ServerReport.SetParameters(paramList);
        }


        string mimeType, encoding, extension, deviceInfo;
        string[] streamids; Microsoft.Reporting.WebForms.Warning[] warnings;
        deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>";
        byte[] bytes = repViewer.ServerReport.Render(Format.ToString(), deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
        Response.Clear();

        if (Format == Common.ApplicationEnums.ReportPreviewType.PDF)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-disposition", "filename=" + ReportManagement.Title.Replace(' ', '_') + ".pdf");
        }
        if (Format == Common.ApplicationEnums.ReportPreviewType.EXCEL)
        {
            Response.ContentType = "application/excel";
            Response.AddHeader("Content-disposition", "filename=" + ReportManagement.Title.Replace(' ', '_') + ".xls");
        }
        //Response.OutputStream.Write(bytes, 0, bytes.Length);
        //Response.OutputStream.Flush();
        //Response.OutputStream.Close();
        //Response.Flush();
        //Response.Close();

        Response.BinaryWrite(bytes);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReportManagement = (ReportManagement)Common.SessionManagement.GetSessionObject(ApplicationEnums.SessionVariablesType.REPORTMANAGEMENT);

            if (ReportManagement != null)
            {
                if (ReportManagement.PreviewType == Common.ApplicationEnums.ReportPreviewType.VIEW)
                {
                    PreviewReport();
                }
                else
                {
                    ShowReport(ReportManagement.PreviewType);
                }
            }
        }
    }
}
