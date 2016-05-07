<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchInvestor.ascx.cs" Inherits="UserControls_SearchInvestor" %>
<table id="tblInvestorCode" width="100%" runat="server" style="margin: 5px 5px 5px 5px;"
    cellpadding="0" border="0" cellspacing="0">
    <tr>
        <td style="text-align: left; width: 150px">
            <span>Investor Code</span>
        </td>
        <td style="text-align: left;">
            <asp:HiddenField ID="hdnInvestor_ID" runat="server" Value="0" />
            <asp:TextBox ID="txtInvestorCode" runat="server" SkinID="txt100" Style="margin: 5px 5px 0px 5px;"
                OnTextChanged="txtInvestorCode_TextChanged"></asp:TextBox>
            <asp:Button ID="btnSearchInvestor" runat="server" Text="Search" OnClick="btnSearchInvestor_Click"
                SkinID="button1" />
            <span>Ex:A001,A002..</span>
        </td>
    </tr>
    <tr>
        <td style="text-align: left; width: 150px">
            <span>Investor Name</span>
        </td>
        <td style="text-align: left;">
            <asp:TextBox ID="txtInvestorName" runat="server" SkinID="txt250" Enabled="false"
                Style="margin: 5px 5px 0px 5px;"></asp:TextBox>
        </td>
    </tr>
</table>
