<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="BankBranchInformation.aspx.cs" Inherits="AccountsManagement_BankBranchInformation"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table style="width: 100%">
        <tr>
            <td>
                Bank<span class="asterisk">*</span></td>
            <td>
                <asp:DropDownList ID="ddl_Bank" runat="server" SkinID="ddl100">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlBank" runat="server" ErrorMessage="Select bank."
                    ControlToValidate="ddl_Bank" ValidationGroup="insert" SetFocusOnError="true"
                    ForeColor="red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Name<span class="asterisk">*</span></td>
            <td>
                <asp:TextBox ID="txt_BranchName" runat="server" SkinID="txt250"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxt_BranchName" runat="server" ErrorMessage="Input Branch Name."
                    ControlToValidate="txt_BranchName" ValidationGroup="insert" SetFocusOnError="true"
                    ForeColor="red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Address<span class="asterisk">*</span></td>
            <td>
                <asp:TextBox ID="txt_Address" runat="server" SkinID="txt250"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxt_Address" runat="server" ErrorMessage="Input Address."
                    ControlToValidate="txt_Address" ValidationGroup="insert" SetFocusOnError="true"
                    ForeColor="red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <asp:HiddenField ID="hdn_ID" runat="server"></asp:HiddenField>
                <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="insert"
                    CausesValidation="true" />
            </td>
            <td>
                <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click"
                    ValidationGroup="insert" CausesValidation="true" />
            </td>
            <td>
                <asp:Button ID="btn_Clear" runat="server" Text="Refresh" OnClick="btn_Clear_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
