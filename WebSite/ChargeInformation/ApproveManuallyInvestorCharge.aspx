<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ApproveManuallyInvestorCharge.aspx.cs" Inherits="ChargeInformation_ApproveManuallyInvestorCharge"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <asp:HiddenField ID="hdnIS_ALLITEMSELECTED" runat="server" Value="false" />
    <table style="width: 100%;">
        <tr>
            <td style="width: 20%;">
                Transaction Date:
            </td>
            <td style="width: 15%;">
                <asp:TextBox ID="txtTransactionDate" runat="server" Enabled="false" SkinID="txtDate"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Investor Code: <span class="asterisk">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtInvestorCode" runat="server" SkinID="txt100" OnTextChanged="txtInvestorCode_TextChanged"
                    AutoPostBack="true"></asp:TextBox>
                <asp:HiddenField ID="hdnInvestorID" runat="server" />
                <asp:Button ID="btn_SearchInvestor" runat="server" Text=".." OnClick="btn_SearchInvestor_Click"
                    Width="25px" Height="24px" />
                <asp:TextBox ID="txtInvestorName" runat="server" SkinID="txt100" ReadOnly="true" />
            </td>
        </tr>
        <tr>
            <td style="width: 20%">
                Charge Information<span class="asterisk">*</span></td>
            <td style="width: 80%">
                <asp:DropDownList ID="ddlChargeInformation" runat="server" SkinID="ddl200">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="tr-TwoColumnDetail">
            <td class="td-labelColumnOfTwoColumn">
                <strong>Transaction Mode</strong></td>
            <td class="td-SingleColumnOfTwoColumn">
                <asp:DropDownList ID="ddlTransactionMode" runat="server" SkinID="ddl100">
                    <asp:ListItem Value="" Text="N/A" Selected="True" />
                    <asp:ListItem Value="addition" Text="Addition" />
                    <asp:ListItem Value="deduction" Text="Deduction" />
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table width="80%">
        <tr>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    <div id="Div1" class="ui-widget-content ui-corner-all list">
        <div style="height: 100%;">
            <asp:GridView ID="dgvChargeInformation" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" ShowFooter="True" PageSize="20" EmptyDataText="No data found."
                OnRowDataBound="dgvChargeInformation_RowDataBound" CssClass="mGrid" DataKeyNames="ID">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="50px">
                        <HeaderTemplate>
                            Approve
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_Select_Single" runat="server" /><br />
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                        <FooterTemplate>
                            <asp:CheckBox ID="chk_Select_All" runat="server" AutoPostBack="true" OnCheckedChanged="chk_Select_All_CheckedChanged" /><br />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TRANSACTION_DATE" HeaderText="Transaction Date"></asp:BoundField>
                    <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Investor Code"></asp:BoundField>
                    <asp:BoundField DataField="CHARGE_F_NAME" HeaderText="Full Name"></asp:BoundField>
                    <asp:BoundField DataField="AMOUNT" HeaderText="Charge Amount"></asp:BoundField>
                </Columns>
                <EmptyDataRowStyle CssClass="defaultGridEmptyData" />
                <PagerSettings PageButtonCount="15" Mode="NumericFirstLast" />
            </asp:GridView>
        </div>
    </div>
    <div style="width: 100%;">
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hdn_ID" runat="server" />
                    <asp:Button ID="btn_Save" runat="server" Text="Approve" OnClick="btn_Save_Click"
                        ValidationGroup="insert" CausesValidation="true" />
                </td>
                <td>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:Button ID="btn_Deny" runat="server" Text="Deny" OnClick="btn_Deny_Click" ValidationGroup="insert"
                        CausesValidation="true" />
                </td>
                <td>
                    <asp:Button ID="btn_Clear" runat="server" Text="Refresh" OnClick="btn_Clear_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
