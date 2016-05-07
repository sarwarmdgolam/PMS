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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Model;
using Microsoft.Reporting.WebForms;


public partial class ReportManagement_ReportParameterPage : System.Web.UI.Page
{
    ApplicationEnums.ReportPreviewType enumPreviewType;
    DataTable dtParameter = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtFromDate.Text = this.txtToDate.Text = this.txtTransactionDate1.Text = this.txtTransactionDate2.Text = TypeCasting.DateToString(Util.SystemDate());
            HidearameterControls();
            pnlDynamicControls.Visible = true;

            //get report parameter control and store into session
             GetParameterControlsInfo();
        }
        PopulateParameterControls( ); 
    }

    private void HidearameterControls()
    {
        tblDateRange.Visible = false;
        //tblDynamicControls.Visible = false;
        tblInvestorCode.Visible = false;
        tblTransactionDate1.Visible = false;
        tblTransactionDate2.Visible = false;
    }

    private void GetParameterControlsInfo()
    {
        String MenuID = "0";
        if (!String.IsNullOrEmpty(Request.QueryString["Title"]))
        {
            MenuID = Request.QueryString["ID"];
        }
        CResult CResult=new CResult();
        BLLReportManagement BLLReportManagement = new BLLReportManagement();
        CResult = BLLReportManagement.GetReportParameterInfo(MenuID);

        if (CResult.Data.Rows.Count > 0)
        {
            Common.SessionManagement.SetSessionObject(ApplicationEnums.SessionVariablesType.PARAMETERCONTROLSINFO, CResult.Data);
        }
    }

    private void PopulateParameterControls()
    {
        DataTable dtParameter = (DataTable)Common.SessionManagement.GetSessionObject(ApplicationEnums.SessionVariablesType.PARAMETERCONTROLSINFO);

        if (dtParameter != null && dtParameter.Rows.Count > 0) 
        {
            foreach (DataRow oRow in dtParameter.Rows)
            {
                //Create Parameter label
                Label objLabel = new Label();
                objLabel.ID = "Label" + oRow["ID"].ToString();
                objLabel.Text = oRow["label"].ToString();
                objLabel.Width = 150;
                objLabel.Height = 15;
                objLabel.Style.Add("margin", "5px 5px 5px 5px");


                //create textbox control
                if (String.Equals(oRow["Control_Type"].ToString(), "TextBox"))
                {
                    TextBox objTextBox = new TextBox();
                    objTextBox.ID = oRow["Control_Type"].ToString() + oRow["ID"].ToString();
                    objTextBox.Text = String.Empty;
                    objTextBox.Width = 150;
                    objTextBox.Height = 15;
                    pnlDynamicControls.Controls.Add(objLabel);
                    pnlDynamicControls.Controls.Add(objTextBox);
                }
                //create dropdown control
                else if (String.Equals(oRow["Control_Type"].ToString(), "DropDownList"))
                {
                    DropDownList DropDownList = new DropDownList();
                    DropDownList.ID = oRow["Control_Type"].ToString() + oRow["ID"].ToString();
                    DropDownList.DataTextField = "Text";
                    DropDownList.DataValueField = "Value";
                    DropDownList.Width = 156;
                    DropDownList.Height = 25;
                    DropDownList.DataSource = BLLCommonEntity.GetCommonEntityData(oRow["tbllookup"].ToString()).Data;
                    DropDownList.DataBind();
                    pnlDynamicControls.Controls.Add(objLabel);
                    pnlDynamicControls.Controls.Add(DropDownList);
                }
                //create textbox control
                else if (String.Equals(oRow["Control_Type"].ToString(), "CheckBox"))
                {
                    CheckBox CheckBox = new CheckBox();
                    CheckBox.ID = oRow["Control_Type"].ToString() + oRow["ID"].ToString();
                    CheckBox.Text = String.Empty;
                    pnlDynamicControls.Controls.Add(objLabel);
                    pnlDynamicControls.Controls.Add(CheckBox);
                }
                //visible composite controls
                else
                {
                    switch (oRow["Control_Type"].ToString())
                    {
                        case "tblDateRange":
                            tblDateRange.Visible = true;
                            break;
                        case "tblTransactionDate1":
                            tblTransactionDate1.Visible = true;
                            lblTransactionDate1.Text = oRow["label"].ToString();
                            break;
                        case "tblTransactionDate2":
                            tblTransactionDate2.Visible = true;
                            lblTransactionDate2.Text = oRow["label"].ToString();
                            break;
                        case "tblInvestorCode":
                            tblInvestorCode.Visible = true;
                            break;
                    }

                }

                // Set a break after each control
                Literal lt1 = new Literal();
                lt1.Text = "<br/>";
                pnlDynamicControls.Controls.Add(lt1);
            }
        }
    }

    private void GetReportParameterValue()
    {
        List<ReportParameter> paramList = new List<ReportParameter>();
        DataTable dtParameter = (DataTable)Common.SessionManagement.GetSessionObject(ApplicationEnums.SessionVariablesType.PARAMETERCONTROLSINFO);
        foreach (DataRow oRow in dtParameter.Rows)
        {
            if (String.Equals(oRow["Control_Type"].ToString(), "TextBox"))
            {
                String stControl = oRow["Control_Type"].ToString() + oRow["ID"].ToString();
                TextBox TextBox1 = (TextBox)pnlDynamicControls.FindControl(stControl);
                if (TextBox1 != null)
                {
                    paramList.Add(new ReportParameter(oRow["parametername"].ToString(), TextBox1.Text));
                }
            }
            //create dropdown control
            else if (String.Equals(oRow["Control_Type"].ToString(), "DropDownList"))
            {
                String stControl = oRow["Control_Type"].ToString() + oRow["ID"].ToString();
                DropDownList DropDownList = (DropDownList)pnlDynamicControls.FindControl(stControl);
                if (DropDownList != null)
                {
                    paramList.Add(new ReportParameter(oRow["parametername"].ToString(), DropDownList.SelectedValue));
                }
            }
            //create CheckBox control
            else if (String.Equals(oRow["Control_Type"].ToString(), "CheckBox"))
            {
                String stControl = oRow["Control_Type"].ToString() + oRow["ID"].ToString();
                CheckBox CheckBox = (CheckBox)pnlDynamicControls.FindControl(stControl);
                if (CheckBox != null)
                {
                    paramList.Add(new ReportParameter(oRow["parametername"].ToString(), CheckBox.Checked.ToString()));
                }
            }
            else
            {
                switch (oRow["Control_Type"].ToString())
                {
                    case "tblDateRange":
                        if (oRow["parametername"].ToString().ToLower().Contains("from"))
                        {
                            paramList.Add(new ReportParameter(oRow["parametername"].ToString(), txtFromDate.Text));
                        }
                        else if (oRow["parametername"].ToString().ToLower().Contains("to"))
                        {
                            paramList.Add(new ReportParameter(oRow["parametername"].ToString(), txtToDate.Text));
                        }
                        break;
                    case "tblTransactionDate1":
                        paramList.Add(new ReportParameter(oRow["parametername"].ToString(), txtTransactionDate1.Text));
                        break;
                    case "tblTransactionDate2":
                        paramList.Add(new ReportParameter(oRow["parametername"].ToString(), txtTransactionDate2.Text));
                        break;
                    case "tblInvestorCode":
                        paramList.Add(new ReportParameter(oRow["parametername"].ToString(), hdnInvestor_ID.Value));
                        break;
                }
            }
        }

      


       
        //By Default Every Report parameter should be; CREATED_BY
        paramList.Add(new ReportParameter("CREATED_BY", (String)Common.SessionManagement.GetSessionObject(ApplicationEnums.SessionVariablesType.CURRENT_USER_ID)));
        
        //Store parameter list
        Common.SessionManagement.SetSessionObject(ApplicationEnums.SessionVariablesType.REPORTPARAMETERLIST, paramList);

        ReportManagement ReportManagement = new ReportManagement();
        ReportManagement.ReportServerUrl = dtParameter.Rows[0]["ReportServerUrl"].ToString();
        ReportManagement.ReportPath = dtParameter.Rows[0]["ReportPath"].ToString();
        ReportManagement.Title = dtParameter.Rows[0]["menu_caption"].ToString();
        ReportManagement.PreviewType = enumPreviewType;

        //Store ReportManagement
        Common.SessionManagement.SetSessionObject(ApplicationEnums.SessionVariablesType.REPORTMANAGEMENT, ReportManagement);
    }

    protected void btnSearchInvestor_Click(object sender, EventArgs e)
    {
        BLLAccountOpen BLLAccountOpen = new BLLAccountOpen();
        String Investor_Code = txtInvestorCode.Text.Trim();
        BLLAccountOpen.GetInvestorNameByCode(ref Investor_Code);
        if (Investor_Code.Split('=')[0] == "0")
        {
            txtInvestorCode.Text = String.Empty;
            hdnInvestor_ID.Value = "0";
        }
        else
        {
            hdnInvestor_ID.Value = Investor_Code.Split('=')[0];
        }
        txtInvestorName.Text = Investor_Code.Split('=')[1];
    }


    protected void btnPreview_Click(object sender, EventArgs e)
    {
        enumPreviewType = ApplicationEnums.ReportPreviewType.VIEW;
        GetReportParameterValue();
        Response.Redirect("ReportShow.aspx");
    }

    protected void btnPDF_Click(object sender, EventArgs e)
    {
        enumPreviewType = ApplicationEnums.ReportPreviewType.PDF;
        GetReportParameterValue();
        Response.Redirect("ReportShow.aspx");
    }
       
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        enumPreviewType = ApplicationEnums.ReportPreviewType.EXCEL;
        GetReportParameterValue();
        Response.Redirect("ReportShow.aspx");
    }

    protected void btnExcelData_Click(object sender, EventArgs e)
    {

    }

    protected void btnDoc_Click(object sender, EventArgs e)
    {

    }

    private void PreviewReport(ApplicationEnums.ReportPreviewType sFormat, Dictionary<String, String> oParam)
    {
        ReportDocument  objReportDocument = new ReportDocument();

        foreach (String oKey in oParam.Keys)
        {
            objReportDocument.SetParameterValue("@" + oKey, oParam[oKey]);
        }
        objReportDocument.SetParameterValue("@CREATED_BY", "99");

        Session["ReportDocument"] = objReportDocument;
        string url = "ShowReport.aspx?ReportFormat=" + sFormat;
        ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}',null,\"status=yes,toolbar=no,menubar=no,location=no,resizable=yes \");</script>", url));

    }

    protected void SetReportData()
    {
        //string strReportPath = Server.MapPath(@"../Reports/" + ReportName + "REPORT_PORTFOLIO_STATEMENT_MULTIPLE.rpt");
        //this.objReportDocument.Load(strReportPath);

        //// for passing connection info
        //ConnectionInfo connectionInfo = new ConnectionInfo();
        //connectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings["Report_ServerName"].ToString();
        //connectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings["Report_ServerDBName"].ToString();
        //connectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings["Report_UserID"].ToString();
        //connectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings["Report_Password"].ToString();
        //SetPermissions(connectionInfo);

        //this.objReportDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
    }

    private void SetPermissions(ConnectionInfo conInfo)
    {
        //Sections crSections = objReportDocument.ReportDefinition.Sections;
        //foreach (Section crSection in crSections)
        //{
        //    foreach (ReportObject crReportObject in crSection.ReportObjects)
        //    {
        //        if (crReportObject.Kind == ReportObjectKind.SubreportObject)
        //        {
        //            SubreportObject crSubReportObject = (SubreportObject)crReportObject;
        //            ReportDocument subreport = crSubReportObject.OpenSubreport(crSubReportObject.SubreportName);
        //            foreach (CrystalDecisions.CrystalReports.Engine.Table subtbl in subreport.Database.Tables)
        //            {
        //                TableLogOnInfo objTableLogonInfo = subtbl.LogOnInfo;
        //                objTableLogonInfo.ConnectionInfo = conInfo;
        //                subtbl.ApplyLogOnInfo(objTableLogonInfo);
        //                //subtbl.Location = subtbl.Location.Substring(subtbl.Location.LastIndexOf(".") + 1);
        //            }
        //        }
        //    }
        //}
    }
}
