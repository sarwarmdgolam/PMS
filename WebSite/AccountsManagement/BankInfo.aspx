<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="BankInfo.aspx.cs" Inherits="AccountsManagement_BankInfo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <asp:HiddenField ID="hdn_ID" runat="server" />
    <table width="100%">
        <tr>
            <td style="width: 151px">
                Short name<span class="asterisk">*</span>
            </td>
            <td>
                <asp:TextBox ID="txt_short_name" runat="server" MaxLength="10" SkinID="txt100"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rfvtxt_short_name" ControlToValidate="txt_short_name"
                    runat="server" ErrorMessage="Please input trader code." Text="*" Display="dynamic"
                    ValidationGroup="insert" />
            </td>
        </tr>
        
        <tr>
            <td style="width: 151px">
                Full name<span class="asterisk">*</span>
            </td>
            <td>
                <asp:TextBox ID="txt_full_name" runat="server"  SkinID="txt100"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rfvtxt_full_name" ControlToValidate="txt_full_name"
                    runat="server" ErrorMessage="Please input trader code." Text="*" Display="dynamic"
                    ValidationGroup="insert" />
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
