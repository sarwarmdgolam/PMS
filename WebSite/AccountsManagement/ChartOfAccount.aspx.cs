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


public partial class AccountsManagement_ChartOfAccount : System.Web.UI.Page
{
    bool Page_Read = true;
    bool Page_Create = true;
    bool Page_Update = true;
    bool Page_Delete = true;

    protected void Page_Init(object sender, EventArgs e)
    {
        MasterPage_Default Master = (MasterPage_Default)this.Master;
       // Master.ShowPageTitle("Account Open(Advisory)");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                SetClearMessage();
                this.txtOpenDate.Text = TypeCasting.DateToString(Util.SystemDate());
                GetDropDownControlData();

                //Get Chart of Accounts Data
                GetTreeViewChartOfAccountData();
                //String ID = Request.QueryString["ID"];
                //if (!String.IsNullOrEmpty(ID))
                //    GetCashChqCollection(ID, String.Empty, String.Empty, String.Empty, String.Empty);
            
            }
            catch (Exception ex)
            {
                (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
            } 
        }
    }

    private void SetTransactionMode(ApplicationEnums.UIOperationMode MODE )
    {
        switch (MODE)
        { 
            case ApplicationEnums.UIOperationMode.INSERT:
                break;
            case ApplicationEnums.UIOperationMode.UPDATE:
                txtGlNumber.Enabled = false;
                break;
        }
    }
   
    private void SetClearMessage()
    {
        //Refresh Tree View
        tvChartOfAccounts.Nodes.Clear();
    }

    private void GetDropDownControlData()
    {
        //Populate ddlTransactionMode
        ddlBrokerBranch.DataTextField = "Text";
        ddlBrokerBranch.DataValueField = "Value";
        ddlBrokerBranch.DataSource = BLLCommonEntity.GetCommonEntityData(ApplicationEnums.EntityEnum.BrokerBranch).Data;
        ddlBrokerBranch.DataBind();
    }

    private void GetTreeViewChartOfAccountData()
    {
        SetClearMessage();
        CResult CResult = new CResult();
        BLLChartOfAccount BLLChartOfAccount = new BLLChartOfAccount();
        CResult = BLLChartOfAccount.GETChartOfAccountsTreeView();

        if (CResult.IsSuccess)
        {
            if (CResult.Data.Rows.Count > 0)
            {
                CreateCOAChartOfAccount(CResult.Data);
            }
        }
        else 
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void CreateCOAChartOfAccount(DataTable dtCOA)
    {
        HierarchyTrees hierarchyTrees = new HierarchyTrees();
        HierarchyTrees.HTree objHTree = null;
        
        foreach (DataRow oRow in dtCOA.Rows)
        {
            objHTree = new HierarchyTrees.HTree();

            objHTree.LevelDepth = Convert.ToInt64(oRow["LEVEL_DEPTH"].ToString());
            objHTree.NodeID = Convert.ToInt64(oRow["NODE_ID"].ToString());
            objHTree.UnderParent = Convert.ToInt64(oRow["UNDER_PARENT"].ToString());
            objHTree.NodeDescription = oRow["NODE_DESCRIPTION"].ToString();
            hierarchyTrees.Add(objHTree);
        }

        //Iterate through Collections.
        foreach (HierarchyTrees.HTree hTree in hierarchyTrees)
        {
            //Filter the collection HierarchyTrees based on 
            //Iteration as per object Htree Parent ID 
            HierarchyTrees.HTree parentNode = hierarchyTrees.Find
            (delegate(HierarchyTrees.HTree emp)
           { return emp.NodeID == hTree.UnderParent; });
            //If parent node has child then populate the leaf node.
            if (parentNode != null)
            {
                foreach (TreeNode tn in tvChartOfAccounts.Nodes)
                {
                    //If single child then match Node ID with Parent ID
                    if (tn.Value == parentNode.NodeID.ToString())
                    {
                        tn.ChildNodes.Add(new TreeNode
                        (hTree.NodeDescription.ToString(), hTree.NodeID.ToString()));
                    }

                    //If Node has multiple child ,
                    //recursively traverse through end child or leaf node.
                    if (tn.ChildNodes.Count > 0)
                    {
                        foreach (TreeNode ctn in tn.ChildNodes)
                        {
                            RecursiveChild(ctn, parentNode.NodeID.ToString(), hTree);
                        }
                    }
                }
            }
            //Else add all Node at first level 
            else
            {
                tvChartOfAccounts.Nodes.Add(new TreeNode
                (hTree.NodeDescription, hTree.NodeID.ToString()));
            }
        }
        tvChartOfAccounts.ExpandAll();
    }

    public void RecursiveChild (TreeNode tn, string searchValue, HierarchyTrees.HTree hTree)
    {
        if (tn.Value == searchValue)
        {
            tn.ChildNodes.Add(new TreeNode
            (hTree.NodeDescription.ToString(), hTree.NodeID.ToString()));
        }
        if (tn.ChildNodes.Count > 0)
        {
            foreach (TreeNode ctn in tn.ChildNodes)
            {
                RecursiveChild(ctn, searchValue, hTree);
            }
        }
    }

    private void GetChartOfAccountsInfoByGLNO(String GLNO)
    {
        CResult CResult = new CResult();
        BLLChartOfAccount BLLChartOfAccount = new BLLChartOfAccount();
        CResult = BLLChartOfAccount.GETChartOfAccountsByGLNO(GLNO);

        if (CResult.Data.Rows.Count > 0)
        {
            SetChartOfAccountsInfo(CResult.Data);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }

    private void SetChartOfAccountsInfo(DataTable COAInfo)
    {
        try
        {
            hdnID.Value = COAInfo.Rows[0]["ID"].ToString();
            txtAccRefNum.Text = COAInfo.Rows[0]["ACC_REF_NO"].ToString();
            txtControlAccount.Text = COAInfo.Rows[0]["GENERAL_LEDGER_PARENT_NO"].ToString();
            txtCurrentBalance.Text = COAInfo.Rows[0]["CURRENT_BAL"].ToString();
            txtGLACName.Text = COAInfo.Rows[0]["GENERAL_LEDGER_NAME"].ToString();
            txtGlNumber.Text = COAInfo.Rows[0]["GENERAL_LEDGER_NO"].ToString();
            ddlGLAccLevel.SelectedValue = COAInfo.Rows[0]["GL_LEVEL"].ToString();
            txtMonthBalance.Text = COAInfo.Rows[0]["CLOSING_BAL"].ToString();
            txtOpenDate.Text = TypeCasting.DateToString(COAInfo.Rows[0]["GL_OPEING_DATE"].ToString());
            txtOpeningBalance.Text = COAInfo.Rows[0]["OPENING_BAL"].ToString();
            ddlBrokerBranch.SelectedValue = COAInfo.Rows[0]["BRANCH_ID"].ToString();
            
            if (String.Equals(COAInfo.Rows[0]["DR_CR"].ToString(), "D"))
                rbtnDebit.Checked = true;
            else
                rbtnCredit.Checked = true;

            if (Convert.ToBoolean(COAInfo.Rows[0]["IS_POST_FLAG"]))
                rbtnPosted.Checked = true;
            else
                rbtnNonPosted.Checked = true;

            chkIsActive.Checked = Convert.ToBoolean(COAInfo.Rows[0]["IS_ACTIVE"]);
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    private Dictionary<String, String> GetChartOfAccountsInfo()
    {
        Dictionary<String, String> oParam = new Dictionary<string, string>();
        try
        {
            oParam["ID"] = hdnID.Value;
            oParam["ACC_REF_NO"] = txtAccRefNum.Text;
            oParam["GENERAL_LEDGER_PARENT_NO"] = txtControlAccount.Text;
            oParam["CURRENT_BAL"] = txtCurrentBalance.Text;
            oParam["GENERAL_LEDGER_NAME"] = txtGLACName.Text;
            oParam["GENERAL_LEDGER_NO"] = txtGlNumber.Text;
            oParam["GL_LEVEL"] = ddlGLAccLevel.SelectedValue;
            oParam["CLOSING_BAL"] = txtMonthBalance.Text;
            oParam["GL_OPEING_DATE"] = txtOpenDate.Text;
            oParam["OPENING_BAL"] = txtOpeningBalance.Text;
            oParam["BRANCH_ID"] = ddlBrokerBranch.SelectedValue;


            if (rbtnDebit.Checked)
                oParam["DR_CR"] = "D";
            else
                oParam["DR_CR"] = "C";

            if(rbtnPosted.Checked )
                oParam["IS_POST_FLAG"] = true.ToString();
            else
                oParam["IS_POST_FLAG"] = false.ToString();

            oParam["IS_ACTIVE"] = chkIsActive.Checked.ToString();
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
        return oParam;
    }

    private bool ValidateInsertChartOfAccountsInfo()
    {

        return true;
    }

    private void InsertChartOfAccountsInfo()
    {
        SetClearMessage();
        if (!ValidateInsertChartOfAccountsInfo()) return;

        CResult CResult = new CResult();
        BLLChartOfAccount BLLChartOfAccount = new BLLChartOfAccount();
        CResult = BLLChartOfAccount.InsertChartOfAccountsInfo(GetChartOfAccountsInfo());

        if (CResult.AffectedRows > 0)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Informaiton, "Successfully Saved.");

            //Refresh Chart Of Accounts
            btnClear_Click(null,null);
        }
        else
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, CResult.Message);
        }
    }


    private void GetNewGLNO(ref String CurrentGLNo, ref String CurrentDepth)
    {
        CResult CResult = new CResult();
        BLLChartOfAccount BLLChartOfAccount = new BLLChartOfAccount();
        CResult = BLLChartOfAccount.GETChartOfAccountsTreeViewChildNode(CurrentGLNo, CurrentDepth);

        if (CResult.Data.Rows.Count > 0)
        {
            CurrentGLNo = CResult.Data.Rows[0]["CHILDNODE"].ToString();
            CurrentDepth = CResult.Data.Rows[0]["LEVEL"].ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            InsertChartOfAccountsInfo();
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChartOfAccount.aspx");  
    }


    private void SetChartOfAccountsNodeInfo(TreeView oNode)
    {
        //Set Page Operation Mode
        SetTransactionMode(ApplicationEnums.UIOperationMode.UPDATE);

       
        String SelectedGLNO = oNode.SelectedValue;
        String SelectedDepth = Convert.ToString(oNode.SelectedNode.Depth + 1);

        if (rbtnUpdateMode.Checked)
        {
            GetChartOfAccountsInfoByGLNO(SelectedGLNO);
        }
        else if (rbtnInsertMode.Checked)
        {

            if (Convert.ToInt16(SelectedDepth) < 4 && SelectedGLNO.Length == 9)
            {
                //Set parent GL account
                txtControlAccount.Text = SelectedGLNO;

                //Get Next level GL account
                GetNewGLNO(ref SelectedGLNO, ref SelectedDepth);

                //Set Next level GL account
                txtGlNumber.Text = SelectedGLNO;
                ddlGLAccLevel.SelectedValue = SelectedDepth.ToString();

                //Set DR/CR
                switch (Convert.ToUInt16(SelectedGLNO.Substring(0, 1)))
                {
                    case 1:
                        rbtnDebit.Checked = true;
                        break;
                    case 2:
                        rbtnCredit.Checked = true;
                        break;
                    case 3:
                        rbtnCredit.Checked = true;
                        break;
                    case 4:
                        rbtnDebit.Checked = true;
                        break;
                }
            }
        }
    }


    protected void tvChartOfAccounts_SelectedNodeChanged(object sender, EventArgs e)
    {
        try
        {
            SetChartOfAccountsNodeInfo((TreeView)sender);
        }
        catch (Exception ex)
        {
            (this.Master as MasterPage_Default).ShowApplicationMessage(ApplicationEnums.ApplicationMessageType.Error, ex.Message);
        }
    }

    

}


public class HierarchyTrees : List<HierarchyTrees.HTree>
{
    public class HTree
    {
        private String m_NodeDescription;
        private Int64 m_UnderParent;
        private Int64 m_LevelDepth;
        private Int64 m_NodeID;

        public Int64 NodeID
        {
            get { return m_NodeID; }
            set { m_NodeID = value; }
        }

        public String NodeDescription
        {
            get { return m_NodeDescription; }
            set { m_NodeDescription = value; }
        }
        public Int64 UnderParent
        {
            get { return m_UnderParent; }
            set { m_UnderParent = value; }
        }
        public Int64 LevelDepth
        {
            get { return m_LevelDepth; }
            set { m_LevelDepth = value; }
        }
    }
}

