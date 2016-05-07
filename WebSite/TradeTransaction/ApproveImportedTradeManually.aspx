<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ApproveImportedTradeManually.aspx.cs" Inherits="TradeTransaction_ApproveImportedTradeManually"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
            EmptyDataText="No Record" AllowPaging="True" PageSize="10" CssClass="mGrid" CellPadding="5"
            CellSpacing="10">
            <Columns>
                <asp:BoundField DataField="EXCHANGE_SHORT_NAME" HeaderText="Security Exchange" />
                <asp:BoundField DataField="M_TYPE_F_NAME" HeaderText="Market Type" />
                <asp:BoundField DataField="MODE_F_Name" HeaderText="Mode" />
                <asp:BoundField DataField="TOTAL_HOWLA_NO" HeaderText="Total Howla" />
                <asp:BoundField DataField="TURNOVER" HeaderText="Turnover"  /> 
            </Columns>
            <PagerSettings PageButtonCount="15" Mode="NumericFirstLast" />
        </asp:GridView>
    </div>
    <br />
    <div>
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hdn_ID" runat="server"></asp:HiddenField>
                    <asp:Button ID="btn_Approve" runat="server" Text="Approve" OnClick="btn_Approve_Click"
                        ValidationGroup="insert" CausesValidation="true" />
                </td>
                <td>
                    <asp:Button ID="btn_Clear" runat="server" Text="Refresh" OnClick="btn_Clear_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
