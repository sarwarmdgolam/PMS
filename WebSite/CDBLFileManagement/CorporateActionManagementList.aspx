<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="CorporateActionManagementList.aspx.cs" Inherits="CDBLFileManagement_CorporateActionManagementList"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table class="tb-TwoColumnDetail">
        <tr>
            <td class="td-twocolumnleftsideright">
                Transaction Date</td>
            <td class="td-twocolumnrightsideleft">
                <asp:TextBox ID="txtTransactionDate" runat="server" Enabled="false" SkinID="txtDate"></asp:TextBox>
            </td>
        </tr>
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
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <div id="Div1" class="ui-widget-content ui-corner-all list">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        PageSize="20" EmptyDataText="No data found." CssClass="mGrid" DataKeyNames="ID" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="INSTRUMENT_NAME" HeaderText="Instrument Name" />
                            <asp:BoundField DataField="CA_TYPENAME" HeaderText="CA type" />
                            <asp:BoundField DataField="RECORD_DATE" HeaderText="Record Date" />
                            <asp:BoundField DataField="ID" HeaderText="Edit">
                                <ItemStyle Width="6%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ID" HeaderText="Delete">
                                <ItemStyle Width="6%" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings PageButtonCount="15" Mode="NumericFirstLast" />
                    </asp:GridView>
                </div>
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
