<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ExecuteSettlementProcess.aspx.cs" Inherits="TradeTransaction_ExecuteSettlementProcess"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <div>
        <table>
            <tr>
                <td>
                    <b>Trading Date</b>
                </td>
                <td>
                    <asp:TextBox ID="txtTradingDate" runat="server" Enabled="false" SkinID="txtDate"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hdn_ID" runat="server"></asp:HiddenField>
                    <asp:Button ID="btnExecuteSettlement" runat="server" Text="Execute Settlement" OnClick="btnExecuteSettlement_Click"
                        ValidationGroup="insert" CausesValidation="true" />
                </td>
                <td>
                    <asp:Button ID="btnReverseSettlement" runat="server" Text="Reverse Settlement" OnClick="btnReverseSettlement_Click"
                        ValidationGroup="insert" CausesValidation="true" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
