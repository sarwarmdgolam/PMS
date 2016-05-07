<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="Cash_Chq_Payment.aspx.cs" Inherits="Transaction_Cash_Chq_Payment" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">

    <script language="javascript" type="text/javascript" src="../Script/AmountInWords.js"></script>

    <table cellpadding="0" border="0" cellspacing="0">
        <tr>
            <td>
                &nbsp;<asp:Button ID="btn_Save2" runat="server" Text="Save" OnClick="btn_Save_Click"
                    CausesValidation="true" ValidationGroup="insert" />
            </td>
            <td>
                <asp:Button ID="btn_Update2" runat="server" Text="Update" ValidationGroup="insert"
                    CausesValidation="true" OnClick="btn_Update_Click" />
            </td>
            <td>
                <asp:Button ID="btn_Clear2" runat="server" Text="Refresh" OnClick="btn_Clear_Click"
                    CausesValidation="false" />
            </td>
        </tr>
    </table>
    <fieldset>
        <table style="width: 100%" cellpadding="0" border="0" cellspacing="0">
            <tr>
                <td style="height: 26px; width: 20%">
                    <strong>Transaction Date:</strong></td>
                <td style="height: 26px; width: 30%">
                    <asp:TextBox ID="txtPaymentDate" runat="server" SkinID="txt100" Enabled="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtPaymentDate" runat="server" ControlToValidate="txtPaymentDate"
                        Display="None" ErrorMessage="Payment Date" Text="*" ValidationGroup="insert"></asp:RequiredFieldValidator>
                </td>
                <td style="height: 26px; width: 20%">
                    <strong>Value Date:</strong></td>
                <td style="height: 26px; width: 30%">
                    <asp:TextBox ID="txtValueDate" runat="server" SkinID="txtDate"></asp:TextBox>
                    <img id="imgValueDate" src="../Images/Calendar.gif" />
                    <asp:RequiredFieldValidator ID="rfvtxtValueDate" ControlToValidate="txtValueDate"
                        Display="None" Text="*" runat="server" ErrorMessage="Value Date is required."
                        ValidationGroup="insert"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 26px">
                    <b>Voucher No.</b></td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtVoucherNumber" runat="server" Enabled="False" MaxLength="10"
                        SkinID="txt100">Auto</asp:TextBox></td>
                <td style="height: 26px">
                    <b>Previous Voucher No.</b>
                </td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtPreviousVoucherNo" runat="server" Enabled="False" MaxLength="10"
                        SkinID="txt100"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 26px;">
                    <b>Investor Code:</b> <span class="asterisk">*</span>
                </td>
                <td style="height: 26px;">
                    <asp:TextBox ID="txtInvestorCode" runat="server" MaxLength="20" SkinID="txt100" AutoPostBack="True"
                        OnTextChanged="txtInvestorCode_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtInvestorCode" ControlToValidate="txtInvestorCode"
                        runat="server" ErrorMessage="Input Investor Code" Text="*" Display="None" ValidationGroup="insert" />
                </td>
                <td style="height: 26px">
                    <b>Investor Name:</b>
                </td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtInvestorName" runat="server" SkinID="txt250" Enabled="false"
                        ReadOnly="true" />
                </td>
            </tr>
            <tr>
                <td style="height: 26px;">
                    <b>Mode:</b>
                </td>
                <td style="height: 26px;">
                    <asp:DropDownList ID="ddlTransactionMode" runat="server" SkinID="ddl100" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlTransactionMode_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvTransactionMode" runat="server" ControlToValidate="ddlTransactionMode"
                        Display="None" ErrorMessage="Transaction Mode" InitialValue="0" Text="*" ValidationGroup="insert"></asp:RequiredFieldValidator></td>
                <td style="height: 26px">
                    <strong>Account No:</strong></td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtAccount" runat="server" MaxLength="16" SkinID="txt100"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 26px;">
                    <b>Cheque Date:</b></td>
                <td style="height: 26px;">
                    <table cellpadding="0" border="0" cellspacing="0">
                        <tr>
                            <td style="height: 26px">
                                <asp:TextBox ID="txtChequeDate" runat="server" SkinID="txtDate"></asp:TextBox></td>
                            <td style="height: 26px">
                                &nbsp;<img id="imgChequeDate" src="../Images/Calendar.gif" /></td>
                        </tr>
                    </table>
                </td>
                <td style="height: 26px">
                    <strong>Cheque Number:</strong></td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtChequeNo" runat="server" MaxLength="100" SkinID="txt100"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 26px;">
                    <b>Bank:</b></td>
                <td style="height: 26px;">
                    <asp:DropDownList ID="ddlBank" runat="server" SkinID="ddl100" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td style="height: 26px">
                    <strong>Bank Branch:</strong></td>
                <td style="height: 26px">
                    <asp:DropDownList ID="ddlBankBranch" runat="server" SkinID="ddl100">
                        <asp:ListItem>- Select -</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="chkIsFull" runat="server" AutoPostBack="True" OnCheckedChanged="chkIsFull_CheckedChanged" />
                    <b>Full Balance</b>
                </td>
                <td colspan="3">
                    <label id="lblAmountwords" style="background-color: #E2EEF1; color: Red; font-weight: bold;">
                    </label>
                </td>
            </tr>
            <tr>
                <td style="height: 26px;">
                    <strong>Amount:</strong> <span class="asterisk">*</span></td>
                <td style="height: 26px;">
                    <asp:TextBox ID="txtAmount" runat="server" Style="text-align: right;" MaxLength="20"
                        SkinID="txt100" onchange="addCommas();" onkeypress="return blockNonNumbers(this, event, true, false);"
                        onkeyup="AmountInWords(this,'lblAmountwords');"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAmount" runat="server" ControlToValidate="txtAmount"
                        Display="None" ErrorMessage="Input Amount" Text="*" ValidationGroup="insert"></asp:RequiredFieldValidator>
                </td>
                <td style="height: 26px;" colspan="2">
                </td>
            </tr>
            <tr>
                <td style="height: 26px;">
                    <b>Operating Branch:</b> <span class="asterisk">*</span></td>
                <td style="height: 26px;">
                    <asp:DropDownList ID="ddlOperatingBranch" runat="server" OnSelectedIndexChanged="ddlOperatingBranch_SelectedIndexChanged"
                        AutoPostBack="true" SkinID="ddl100">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlOperatingBranch" runat="server" ControlToValidate="ddlOperatingBranch"
                        Display="None" ErrorMessage="Input branch" InitialValue="0" Text="*" ValidationGroup="insert"></asp:RequiredFieldValidator></td>
                <td style="height: 26px">
                    <strong>Payment GL Acc:</strong> <span class="asterisk">*</span></td>
                <td style="height: 26px">
                    <asp:DropDownList ID="ddlPaymentGL" runat="server" SkinID="ddl100">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvPaymentGL" runat="server" ControlToValidate="ddlPaymentGL"
                        Display="None" ErrorMessage="Input Payment GL" InitialValue="0" Text="*" ValidationGroup="insert"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="height: 26px">
                    <strong>Doc. Ref No.</strong></td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtDocRefNumber" runat="server" MaxLength="15" SkinID="txt100"></asp:TextBox>
                </td>
                <td style="height: 26px;">
                </td>
                <td style="height: 26px;">
                </td>
            </tr>
            <tr>
                <td style="height: 26px;">
                    <strong>Remarks:</strong></td>
                <td style="height: 26px;" colspan="3">
                    <asp:TextBox ID="txtRemarks" runat="server" MaxLength="500" TextMode="MultiLine"
                        SkinID="txt250"></asp:TextBox></td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Current Status</legend>
        <table style="width: 100%" cellpadding="0" border="0" cellspacing="0">
            <tr>
                <td style="height: 26px; width: 20%">
                    <b>Ledger Balance:</b></td>
                <td style="height: 26px; width: 30%">
                    <asp:TextBox ID="txtLedgerBalabce" runat="server" Style="text-align: right;" TabIndex="-1"
                        ReadOnly="true" Enabled="false" SkinID="txt100"></asp:TextBox>
                </td>
                <td style="height: 26px; width: 20%">
                    <b>Available Balance:</b></td>
                <td style="height: 26px; width: 30%">
                    <asp:TextBox ID="txtAvailaleBalance" runat="server" Style="text-align: right;" TabIndex="-1"
                        ReadOnly="true" Enabled="false" SkinID="txt100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 26px">
                    <b>Immatured Balance:</b></td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtImmatiredBalance" runat="server" Style="text-align: right;" TabIndex="-1"
                        ReadOnly="true" Enabled="false" SkinID="txt100"></asp:TextBox>
                </td>
                <td style="height: 26px">
                    <b>Unclear Chq Balance:</b></td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtUnclearChqBalance" runat="server" Style="text-align: right;"
                        TabIndex="-1" ReadOnly="true" Enabled="false" SkinID="txt100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 26px">
                    <b>Interest Receivable:</b></td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtInterestReceivable" runat="server" Style="text-align: right;"
                        TabIndex="-1" ReadOnly="true" Enabled="false" SkinID="txt100"></asp:TextBox>
                </td>
            </tr>
        </table>
    </fieldset>
    <table cellpadding="0" border="0" cellspacing="0">
        <tr>
            <td>
                &nbsp;<asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click"
                    CausesValidation="true" ValidationGroup="insert" />
            </td>
            <td>
                <asp:Button ID="btn_Update" runat="server" Text="Update" ValidationGroup="insert"
                    CausesValidation="true" OnClick="btn_Update_Click" />
            </td>
            <td>
                <asp:Button ID="btn_Clear" runat="server" Text="Refresh" OnClick="btn_Clear_Click" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnID" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdnPreviousID" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdnInvestorID" runat="server" />

    <script type="text/javascript">

    Calendar.setup
        ({
            inputField  : "ctl00_Main_txtValueDate",
            ifFormat    : "dd-M-y",
            button      : "imgValueDate",
            weekNumbers : false
        });

  Calendar.setup
        ({
            inputField  : "ctl00_Main_txtChequeDate",
            ifFormat    : "dd-M-y",
            button      : "imgChequeDate",
            weekNumbers : false
        });
        
         
    </script>

</asp:Content>
