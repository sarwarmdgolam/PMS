<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true" CodeFile="SettlementScheduleReprocess.aspx.cs" Inherits="BrokerProcess_SettlementScheduleReprocess" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
  <table style="width: 100%">
        <tr>
            <td>
                <table>
                    <tr>
                        <td style="width: 25%;">
                            Transaction Date:<span class="asterisk">*</span></td>
                        <td style="width: 75%;">
                            <asp:TextBox ID="txtTransactionDate" runat="server" Enabled="false" SkinID="txtDate"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtTransactionDate" ControlToValidate="txtTransactionDate"
                                runat="server" ErrorMessage="Transaction date" Text="*" Display="None" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <div style="width: 100%;">
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hdn_ID" runat="server" />
                    <asp:Button ID="btn_Save" runat="server" Text="Process" OnClick="btn_Save_Click"
                        ValidationGroup="insert" CausesValidation="true" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

