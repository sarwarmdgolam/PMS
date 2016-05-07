using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class CReportManagementBase
    {
        //public void SetReportData()
        //{
        //    string strReportPath = Server.MapPath(@"../Reports/" + ReportName + "REPORT_PORTFOLIO_STATEMENT_MULTIPLE.rpt");
        //    this.objReportDocument.Load(strReportPath);

        //    // for passing connection info
        //    ConnectionInfo connectionInfo = new ConnectionInfo();
        //    connectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings["Report_ServerName"].ToString();
        //    connectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings["Report_ServerDBName"].ToString();
        //    connectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings["Report_UserID"].ToString();
        //    connectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings["Report_Password"].ToString();
        //    SetPermissions(connectionInfo);

        //    this.objReportDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
        //}

        //public void SetPermissions(ConnectionInfo conInfo)
        //{
        //    Sections crSections = objReportDocument.ReportDefinition.Sections;
        //    foreach (Section crSection in crSections)
        //    {
        //        foreach (ReportObject crReportObject in crSection.ReportObjects)
        //        {
        //            if (crReportObject.Kind == ReportObjectKind.SubreportObject)
        //            {
        //                SubreportObject crSubReportObject = (SubreportObject)crReportObject;
        //                ReportDocument subreport = crSubReportObject.OpenSubreport(crSubReportObject.SubreportName);
        //                foreach (CrystalDecisions.CrystalReports.Engine.Table subtbl in subreport.Database.Tables)
        //                {
        //                    TableLogOnInfo objTableLogonInfo = subtbl.LogOnInfo;
        //                    objTableLogonInfo.ConnectionInfo = conInfo;
        //                    subtbl.ApplyLogOnInfo(objTableLogonInfo);
        //                    //subtbl.Location = subtbl.Location.Substring(subtbl.Location.LastIndexOf(".") + 1);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
