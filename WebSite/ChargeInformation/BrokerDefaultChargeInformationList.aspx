<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="BrokerDefaultChargeInformationList.aspx.cs" Inherits="ChargeInformation_BrokerDefaultChargeInformationList"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table width="80%">
        <tr>
            <td>
                Charge Name:</td>
            <td>
                <asp:TextBox ID="txtSearchText" runat="server" Text="" Width="200" onkeypress="return SuppressEnter();"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    <div id="Div1" class="ui-widget-content ui-corner-all list">
        <div style="height: 100%;">
            <asp:GridView ID="dgvChargeInformation" runat="server" AutoGenerateColumns="False"
                Width="900px" EmptyDataText="No Charge Information has been found." AllowPaging="True"
                PageSize="10" OnPageIndexChanging="dgvChargeInformation_PageIndexChanging" OnRowDataBound="dgvChargeInformation_RowDataBound"
                DataKeyNames="ID" CssClass="table_style1">
                <Columns>
                    <asp:BoundField DataField="CHARGE_S_NAME" HeaderText="Short Name"></asp:BoundField>
                    <asp:BoundField DataField="CHARGE_F_NAME" HeaderText="Full Name"></asp:BoundField>
                    <asp:BoundField DataField="TYPE_F_NAME" HeaderText="Charge Type"></asp:BoundField>
                    <asp:BoundField DataField="CHARGE_AMOUNT" HeaderText="Charge Amount"></asp:BoundField>
                    <asp:BoundField DataField="MIN_CHARGE_AMOUNT" HeaderText="Minimum Charge"></asp:BoundField>
                    <asp:BoundField DataField="ACTIVATION_DATE" HeaderText="Active Date"></asp:BoundField>
                    <asp:BoundField DataField="ISPERCENTAGE" HeaderText="Percentage"></asp:BoundField>
                    <asp:BoundField DataField="ISSLAB" HeaderText="Slab"></asp:BoundField>
                    <asp:BoundField DataField="ISACTIVE" HeaderText="Active"></asp:BoundField>
                    <asp:ButtonField Text="Edit" HeaderText="Edit">
                        <ItemStyle Width="8%" />
                    </asp:ButtonField>
                    <asp:ButtonField Text="Delete" HeaderText="Delete">
                        <ItemStyle Width="8%" />
                    </asp:ButtonField>
                </Columns>
                <EmptyDataRowStyle />
                <PagerSettings PageButtonCount="15" Mode="NumericFirstLast" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
