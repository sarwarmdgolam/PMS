<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="TradingAccountsSetup.aspx.cs" Inherits="Settings_TradingAccountsSetup"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <asp:HiddenField ID="hdnID" runat="server" />
    <div>
        <fieldset>
            <table class="tb-twoColumn">
                <tr>
                    <td class="td-leftsideTwoColumn">
                        Short Name<span class="asterisk">*</span></td>
                    <td class="td-rightsideTwoColumn">
                        <asp:TextBox ID="txtShortName" runat="server" SkinID="txt100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtShortName" runat="server" ErrorMessage="Input Short Name."
                            ControlToValidate="txtShortName" ValidationGroup="insert" SetFocusOnError="true"
                            ForeColor="red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="td-leftsideTwoColumn">
                        Full Name<span class="asterisk">*</span></td>
                    <td class="td-rightsideTwoColumn">
                        <asp:TextBox ID="txtFullName" runat="server" SkinID="txt250"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtFullName" runat="server" ErrorMessage="Input Full Name."
                            ControlToValidate="txtFullName" ValidationGroup="insert" SetFocusOnError="true"
                            ForeColor="red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="td-leftsideTwoColumn">
                        Is Active</td>
                    <td class="td-rightsideTwoColumn">
                        <asp:CheckBox ID="chkIsActive" runat="server" />
                    </td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            <table class="tb-twoColumn">
                <tr>
                    <td class="td-leftsideTwoColumn">
                        Loan Ratio</td>
                    <td class="td-rightsideTwoColumn">
                        <asp:TextBox ID="txtLoanRatio" runat="server" MaxLength="20" SkinID="txt100"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rfvtxtLoanRatio" runat="server" ControlToValidate="txtLoanRatio"
                            ValidationGroup="insert" ErrorMessage="Input Loan Raio." Text="*" Display="None"
                            ValidationExpression="^\d{1,15}(\.\d{0,4})?$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="td-leftsideTwoColumn">
                        Max Allocated Loan</td>
                    <td class="td-rightsideTwoColumn">
                        <asp:TextBox ID="txtMaxAllocatedLoan" runat="server" MaxLength="20" SkinID="txt100"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rfvtxtMaxAllocatedLoan" runat="server" ControlToValidate="txtMaxAllocatedLoan"
                            Display="None" ErrorMessage="Input Max Allocated Loan ." Text="*" ValidationExpression="^\d{1,15}(\.\d{0,4})?$"
                            ValidationGroup="insert">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="td-leftsideTwoColumn">
                        Withdraw Limit Basis On</td>
                    <td class="td-rightsideTwoColumn">
                        <asp:DropDownList ID="ddlWithdrawBasisON" runat="server" SkinID="ddl100">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvddlWithdrawBasisON" runat="server" ErrorMessage="Input Withdraw Limit Basis On."
                            ControlToValidate="ddlWithdrawBasisON" ValidationGroup="insert" SetFocusOnError="true"
                            InitialValue="0" ForeColor="red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="td-leftsideTwoColumn">
                        Opening Deposit</td>
                    <td class="td-rightsideTwoColumn">
                        <asp:TextBox ID="txtOpeiningDeposit" runat="server" MaxLength="20" SkinID="txt100"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rfvtxtOpeiningDeposit" runat="server" ControlToValidate="txtOpeiningDeposit"
                            Display="None" ErrorMessage="Input Opening Deposit." Text="*" ValidationExpression="^\d{1,15}(\.\d{0,4})?$"
                            ValidationGroup="insert">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="td-leftsideTwoColumn">
                        Minimum Ledger Balance</td>
                    <td class="td-rightsideTwoColumn">
                        <asp:TextBox ID="txtMinLedgerBal" runat="server" MaxLength="20" SkinID="txt100"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rfvtxtMinLedgerBal" runat="server" ControlToValidate="txtMinLedgerBal"
                            Display="None" ErrorMessage="Input Minimum Ledger Balance." Text="*" ValidationExpression="^\d{1,15}(\.\d{0,4})?$"
                            ValidationGroup="insert">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="td-leftsideTwoColumn">
                        Trigger Call Balance</td>
                    <td class="td-rightsideTwoColumn">
                        <asp:TextBox ID="txtTriggerCallBal" runat="server" MaxLength="20" SkinID="txt100"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rfvtxtTriggerCallBal" runat="server" ControlToValidate="txtTriggerCallBal"
                            Display="None" ErrorMessage="Input Trigger Call Balance." Text="*" ValidationExpression="^\d{1,15}(\.\d{0,4})?$"
                            ValidationGroup="insert">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <br />
    <div>
        <table>
            <tr>
                <td>
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
    </div>
</asp:Content>
