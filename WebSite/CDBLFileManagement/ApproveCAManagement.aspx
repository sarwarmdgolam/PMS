<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ApproveCAManagement.aspx.cs" Inherits="CDBLFileManagement_ApproveCAManagement"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table class="tb-tablecenter">
        <tr>
            <td class="td-twocolumnleftsideright">
                Company
            </td>
            <td class="td-twocolumnrightsideleft">
                <asp:DropDownList ID="ddlCompany" runat="server" SkinID="ddl100">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlCompany" runat="server" ControlToValidate="ddlCompany"
                    Display="None" ErrorMessage="Select Company" InitialValue="0" Text="*" ValidationGroup="insert"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="td-twocolumnleftsideright">
                Corporate Action Type
            </td>
            <td class="td-twocolumnrightsideleft">
                <asp:DropDownList ID="ddlActionType" runat="server" SkinID="ddl100">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="td-twocolumnleftsideright">
                Record Date</td>
            <td class="td-twocolumnrightsideleft">
                <asp:TextBox ID="txtRecordDate" runat="server" SkinID="txtDate"></asp:TextBox>
                <img id="imgRecordDate" src="../Images/Calendar.gif" />
            </td>
        </tr>
    </table>
    <table class="tb-PageOperationButtonControl">
        <tr>
            <td>
                <asp:Button ID="btnCalculate" runat="server" Text="Calculate Holdings" OnClick="btnCalculate_Click" />
            </td>
            <td>
                <asp:Button ID="btnDownloadCA" runat="server" Text="Download Calculate Holdings"
                    OnClick="btnDownloadCA_Click" />
            </td>
        </tr>
    </table>
    <div id="Div1" style="height: 200px; width: 100%; overflow: auto;">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        PageSize="20" EmptyDataText="No data found." CssClass="mGrid">
                        <Columns>
                            <asp:BoundField DataField="TYPE_F_NAME" HeaderText="CA Type" />
                            <asp:BoundField DataField="INSTRUMENT_NAME" HeaderText="Security Code" />
                            <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Investor Code" />
                            <asp:BoundField DataField="BO_CODE" HeaderText="BO Code" />
                            <asp:BoundField DataField="LEDGER_QUANTITY" HeaderText="Current Holdings" />
                            <asp:BoundField DataField="BEN_RATIO" HeaderText="Ben Ratio" />
                            <asp:BoundField DataField="TOTAL_ENTITLEMENT" HeaderText="Quantity" />
                        </Columns>
                        <PagerSettings PageButtonCount="15" Mode="NumericFirstLast" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;">
                    <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <table class="tb-PageOperationButtonControl">
        <tr>
            <td>
                <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" />
            </td>
            <td>
                <asp:Button ID="btn_Approve" runat="server" Text="Approve" OnClick="btn_Approve_Click" OnClientClick="return confirm('Are you sure to delete this record?')" />
            </td>
            <td>
                <asp:Button ID="btn_Refresh" runat="server" Text="Refresh" OnClick="btn_Refresh_Click" />
            </td>
        </tr>
    </table>

    <script type="text/javascript">

    Calendar.setup
        ({
            inputField  : "ctl00_Main_txtRecordDate",
            ifFormat    : "dd-M-y",
            button      : "imgRecordDate",
            weekNumbers : false
        });


    </script>

</asp:Content>
