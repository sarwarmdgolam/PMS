using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common;
using BLL;

public partial class CDBLFileManagement_CorporateActionManagementList : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;

    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
        Master.ShowPageNavigationURL("Add New", "~/CDBLFileManagement/CorporateActionManagement.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           txtTransactionDate.Text = txtRecordDate.Text = TypeCasting.DateToString(Util.SystemDate());
           GetDropDownControlData();
            GetCorporateAction();

           String ID = Request.QueryString["ID"];
           if (!String.IsNullOrEmpty(ID))
           {
               GetCorporateAction();
           }
                     
        }
    }

    private void GetDropDownControlData()
    {
        //Populate ddlTransactionMode
        ddlCompany.DataTextField = "Text";
        ddlCompany.DataValueField = "Value";
        ddlCompany.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.CompanyInformation).Data;
        ddlCompany.DataBind();

        //Populate Bank
        ddlActionType.DataTextField = "Text";
        ddlActionType.DataValueField = "Value";
        ddlActionType.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.CorporateActionType).Data;
        ddlActionType.DataBind();
    }

    private Dictionary<String, String> GetEntityValues()
    {
        Dictionary<String, String> obj = new Dictionary<string, string>();
        obj.Add("COMPANY_ID", ddlCompany.SelectedValue);
        obj.Add("CORPORATE_ACTION_TYPE_ID", ddlActionType.SelectedValue);
        obj.Add("RECORD_DATE", txtRecordDate.Text);
        return obj;
    }


    private void GetCorporateAction()
    {
        BLLCorporateActionManagement BLLCorporateActionManagement = new BLLCorporateActionManagement();
        CResult CResult = new CResult();
        CResult = BLLCorporateActionManagement.GetCorporateActionInfo(GetEntityValues());

        if (CResult.IsSuccess)
        {
            GridView1.DataSource = CResult.Data;
            GridView1.DataBind();
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;

            if (this.Page_Update)
            {
                e.Row.Cells[3].Text = "<img src='../Images/Icon/icon_edit_small.png' align='absbottom' /> <a href='CorporateActionManagement.aspx?ID=" + drv["ID"].ToString() + "'>Edit</a>";
            }
            else
                e.Row.Cells[3].Text = "&nbsp;";

            if (this.Page_Delete)
            {
                e.Row.Cells[4].Text = "<img src='../Images/Icon/icon_delete_small.png' align='absbottom' /> <a href='Cash_Chq_Collection_List.aspx?Action=Delete&ID=" + drv["ID"].ToString() + "' onclick='return confirm(\"Are you sure to delete this record?\")'>Delete</a>";
            }
            else
                e.Row.Cells[4].Text = "&nbsp;";
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetCorporateAction();
    }
    protected void btn_Clear_Click(object sender, EventArgs e)
    {

    }
}
