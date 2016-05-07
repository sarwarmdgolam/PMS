<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true" CodeFile="PriceManagement.aspx.cs"
    Inherits="PriceManagement_PriceManagement" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="width: 20%">
                <b>Trading Date</b>
            </td>
            <td style="width: 80%">
                <asp:TextBox ID="txtTradingDate" runat="server" MaxLength="50" Enabled="false" SkinID="txtDate"></asp:TextBox></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <b>Security Exchange</b><span class="asterisk">*</span></td>
            <td style="width: 243px">
                <asp:DropDownList ID="ddlSecurityExchange" runat="server" SkinID="ddl100">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlSecurityExchange"
                    InitialValue="0" Display="None" Text="*" ValidationGroup="insert" runat="server" ErrorMessage="Security Exchange required."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <b>File Name</b><span class="asterisk">*</span></td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="FileUpload1"
                    Display="None" Text="*" ValidationGroup="a" runat="server" ErrorMessage="File is required."></asp:RequiredFieldValidator>
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"
                    ValidationGroup="insert" />
            </td>
        </tr>
        <tr style="height: 15px">
        </tr>
    </table>
    <div style="width: 100%;">
        <table>
            <tr>
                <td>
                    &nbsp;<asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click"
                        CausesValidation="true" ValidationGroup="insert" />
                </td>
                <td>
                    <asp:Button ID="btn_Clear" runat="server" Text="Refresh" OnClick="btn_Clear_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
