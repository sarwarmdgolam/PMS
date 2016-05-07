<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ImportTradeExcel.aspx.cs" Inherits="TradeTransaction_ImportTradeExcel"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
   
    <table width="100%">
        <tr>
            <td style="width: 25%">
                Trading Date
            </td>
            <td style="width: 75%">
                <asp:TextBox ID="txtTradingDate" runat="server" MaxLength="50" Enabled="false" SkinID="txtDate"></asp:TextBox></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Security Exchange<span class="asterisk">*</span></td>
            <td style="width: 243px">
                <asp:DropDownList ID="ddlSecurityExchange" runat="server" SkinID="ddl100">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlSecurityExchange"
                    InitialValue="0" Display="None" Text="*" ValidationGroup="insert" runat="server"
                    ErrorMessage="Security Exchange required."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:FileUpload ID="fuImportTrade" runat="server" />
            </td>
            <td>
                <asp:Button ID="btn_Import" runat="server" Text="Import" OnClick="btn_Import_Click" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <div style="overflow: auto; width: 700px;">
                    <asp:GridView ID="gv_Portfolio" runat="server">
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="insert" />
            </td>
             <td>
                <asp:Button ID="btn_Delete" runat="server" Text="Delete" OnClick="btn_Delete_Click"   OnClientClick="return confirm('Are you sure to delete the Uploaded trade records?');"  />
            </td>
        </tr>
    </table>
</asp:Content>
