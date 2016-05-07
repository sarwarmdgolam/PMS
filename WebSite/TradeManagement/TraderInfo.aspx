<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="TraderInfo.aspx.cs" Inherits="TradeManagement_TraderInfo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <asp:HiddenField ID="hdn_ID" runat="server" />
    <asp:HiddenField ID="hdnInvestor_ID" runat="server" />
    <table width="100%">
        <tr>
            <td style="width: 151px">
                Trader Code <span class="asterisk">*</span>
            </td>
            <td>
                <asp:TextBox ID="txt_trader_code" runat="server" MaxLength="10" SkinID="txt100"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rfvtxt_trader_code" ControlToValidate="txt_trader_code"
                    runat="server" ErrorMessage="Please input trader code." Text="*" Display="dynamic"
                    ValidationGroup="insert" />
            </td>
        </tr>
        <tr>
            <td style="width: 151px">
                Trading Branch
            </td>
            <td>
                <asp:DropDownList ID="ddl_Trading_branch" runat="server" SkinID="ddl100">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 151px">
                Security exchange
            </td>
            <td>
                <asp:DropDownList ID="ddl_security_exchange" runat="server" SkinID="ddl100">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 151px">
                Employee
            </td>
            <td>
                <asp:DropDownList ID="ddl_employee" runat="server" SkinID="ddl200">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 151px">
                Card ref No#
            </td>
            <td>
                <asp:TextBox ID="txt_card_ref_no" runat="server" SkinID="txt100"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 151px">
                Is active
            </td>
            <td>
                <asp:CheckBox ID="chk_IsActive" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <div style="width: 100%;">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="insert"
                        CausesValidation="true" />
                </td>
                <td>
                    <asp:Button ID="btn_Update" runat="server" Text="Update" ValidationGroup="insert"
                        OnClick="btn_Update_Click" CausesValidation="true" />
                </td>
                <td>
                    <asp:Button ID="btn_Clear" runat="server" Text="Refresh" OnClick="btn_Clear_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
