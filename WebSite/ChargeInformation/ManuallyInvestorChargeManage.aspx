<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ManuallyInvestorChargeManage.aspx.cs" Inherits="ChargeInformation_ManuallyInvestorChargeManage"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <asp:HiddenField ID="hdnID" runat="server" />
    <table style="width: 100%;">
        <tr>
            <td style="width: 20%;">
                Impose On:
            </td>
            <td style="width: 15%;">
                <asp:DropDownList ID="ddlImposeOn" runat="server" SkinID="ddl100">
                    <asp:ListItem Selected="True" Text="Single Investor" Value="singleinvestor"></asp:ListItem>
                    <asp:ListItem Text="Selected Investor" Value="selectedinvestor"></asp:ListItem>
                    <asp:ListItem Text="All Active Investor" Value="activeinvestor"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
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
                <asp:RequiredFieldValidator ID="rfvtxtInvestorCode" ControlToValidate="txtInvestorCode"
                    runat="server" ErrorMessage="Input Investor" Text="*" Display="None" ValidationGroup="insert" />
            </td>
        </tr>
        <tr>
            <td style="width: 20%">
                Charge Information<span class="asterisk">*</span></td>
            <td style="width: 80%">
                <asp:DropDownList ID="ddlChargeInformation" runat="server" SkinID="ddl200">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfddlChargeInformation" ControlToValidate="ddlChargeInformation"
                    InitialValue="0" Display="None" Text="*" ValidationGroup="a" runat="server" ErrorMessage="Charge Information."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="tr-TwoColumnDetail">
            <td class="td-labelColumnOfTwoColumn">
                <strong>Transaction Mode</strong></td>
            <td class="td-SingleColumnOfTwoColumn">
                <asp:RadioButtonList ID="rbtnTransactionMode" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="addition" Text="Addition" Selected="True" />
                    <asp:ListItem Value="deduction" Text="Deduction" />
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                Charge Amount<span class="asterisk">*</span></td>
            <td>
                <asp:TextBox ID="txtChargeAmount" onkeypress="return blockNonNumbers(this, event, true, false);"
                    runat="server" MaxLength="18" Text="0.00" SkinID="txt100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtChargeAmount"
                    Display="None" Text="*" ValidationGroup="a" runat="server" ErrorMessage="Charge Amount is required."></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtChargeAmount"
                    ErrorMessage="The value specified as 'Charge Amount' is not valid." Text="*"
                    Display="None" ValidationExpression="^\d{1,13}(\.\d{0,4})?$" ValidationGroup="a">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr class="tr-TwoColumnDetail">
            <td class="td-labelColumnOfTwoColumn">
                <b>Doc Ref NO#</b></td>
            <td class="td-SingleColumnOfTwoColumn">
                <asp:TextBox ID="txtDocRefNo" runat="server" MaxLength="100" SkinID="txt100"></asp:TextBox>
            </td>
        </tr>
        <tr class="tr-TwoColumnDetail">
            <td class="td-labelColumnOfTwoColumn">
                <b>Remarks</b></td>
            <td class="td-SingleColumnOfTwoColumn">
                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" MaxLength="250"
                    SkinID="skMultilineTextBox"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                &nbsp;<asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click"
                    CausesValidation="true" ValidationGroup="insert" />
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
</asp:Content>
