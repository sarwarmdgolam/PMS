<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="Cash_Chq_Collection.aspx.cs" Inherits="AccountTransaction_Cash_Chq_Collection"
    Title="Cash Cheque Collection" %>

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
                    OnClick="btn_Update_Click" CausesValidation="true" />
            </td>
            <td>
                <asp:Button ID="btn_Clear2" runat="server" Text="Refresh" OnClick="btn_Clear_Click" />
            </td>
        </tr>
    </table>
    <table style="width: 80%; margin-left: 20px; margin-right: 20px;">
        <tr>
            <td style="width: 20%;">
                Transaction Date:
            </td>
            <td style="width: 15%;">
                <asp:TextBox ID="txtTransactionDate" runat="server" Enabled="false" SkinID="txtDate"></asp:TextBox>
            </td>
            <td style="width: 20%;">
            </td>
            <td style="width: 10%;">
            </td>
        </tr>
        <tr>
            <td>
                Voucher No.</td>
            <td>
                <asp:TextBox ID="txtVoucherNumber" runat="server" Enabled="False" SkinID="txt100">Auto</asp:TextBox></td>
            <td>
                Previous Voucher No.
            </td>
            <td>
                <asp:TextBox ID="txtPreviousVoucherNo" runat="server" Enabled="False" SkinID="txt100"></asp:TextBox>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Investor Code: <span class="asterisk">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtInvestorCode" runat="server" SkinID="txt100" OnTextChanged="txtInvestorCode_TextChanged"
                    AutoPostBack="true"></asp:TextBox>
                <asp:Button ID="btn_SearchInvestor" runat="server" Text=".." OnClick="btn_SearchInvestor_Click"
                    Width="25px" Height="24px" />
                <asp:RequiredFieldValidator ID="rfvtxtInvestorCode" ControlToValidate="txtInvestorCode"
                    runat="server" ErrorMessage="Input Investor" Text="*" Display="None" ValidationGroup="insert" />
            </td>
            <td>
                Investor Name:
            </td>
            <td>
                <asp:TextBox ID="txtInvestorName" runat="server" SkinID="txt100" ReadOnly="true" />
            </td>
        </tr>
        <tr>
            <td>
                Transaction Mode:
            </td>
            <td>
                <asp:DropDownList ID="ddlTransactionMode" runat="server" SkinID="ddl100" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlTransactionMode_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvTransactionMode" runat="server" ControlToValidate="ddlTransactionMode"
                    Display="None" ErrorMessage="Input Transaction Mode" InitialValue="0" Text="*" ValidationGroup="insert"></asp:RequiredFieldValidator>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Cheque Date:</td>
            <td>
                <table cellpadding="0" border="0" cellspacing="0">
                    <tr>
                        <td style="height: 25px">
                            <asp:TextBox ID="txtChequeDate" runat="server" MaxLength="10" SkinID="txt100"></asp:TextBox></td>
                        <td style="height: 25px">
                            &nbsp;<img id="imgChequeDate" src="../Images/Calendar.gif" /></td>
                    </tr>
                </table>
            </td>
            <td>
                Cheque Number:</td>
            <td>
                <asp:TextBox ID="txtChequeNo" runat="server" SkinID="txt100"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Bank:</td>
            <td>
                <asp:DropDownList ID="ddlBank" runat="server" SkinID="ddl100" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                Bank Branch:</td>
            <td>
                <asp:DropDownList ID="ddlBankBranch" runat="server" SkinID="ddl100">
                    <asp:ListItem>N/A</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="3">
                <label id="lblAmountwords" style="background-color: #E2EEF1; color: Red; font-weight: bold;">
                </label>
            </td>
        </tr>
        <tr>
            <td>
                Amount: <span class="asterisk">*</span></td>
            <td>
                <asp:TextBox ID="txtAmount" runat="server" MaxLength="21" Style="text-align: right;"
                    SkinID="txt100" onchange="addCommas();" onkeypress="return blockNonNumbers(this, event, true, false);"
                    onkeyup="AmountInWords(this,'lblAmountwords');"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAmount" runat="server" Text="*" Display="None"
                    ErrorMessage="Input Amount" ControlToValidate="txtAmount" ValidationGroup="insert"></asp:RequiredFieldValidator>
            </td>
            <td>
                Doc Ref No.</td>
            <td>
                <asp:TextBox ID="txtDocRefNumber" runat="server" MaxLength="15" SkinID="txt100"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Operating Branch: <span class="asterisk">*</span></td>
            <td>
                <asp:DropDownList ID="ddlOperatingBranch" runat="server" SkinID="ddl100">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlOperatingBranch" InitialValue="0" ControlToValidate="ddlOperatingBranch"
                    runat="server" ErrorMessage="Input Operating branch" Text="*" Display="None" ValidationGroup="insert" />
            </td>
            <td>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Value Date:
            </td>
            <td>
                <table cellpadding="0" border="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtValueDate" runat="server" MaxLength="10" SkinID="txt100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvValueDate" ControlToValidate="txtValueDate" runat="server"
                                ErrorMessage="Input Value date" Text="*" Display="None" ValidationGroup="insert" />
                        </td>
                        <td>
                            &nbsp;<img id="imgValueDate" src="../Images/Calendar.gif" alt="No Image" /></td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Remarks:</td>
            <td colspan="3">
                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" SkinID="txt250"></asp:TextBox></td>
        </tr>
    </table>
    <br />
    <table cellpadding="0" border="0" cellspacing="0">
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
    <asp:HiddenField ID="hdnID" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdnPreviousID" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdnInvestorID" runat="server"></asp:HiddenField>

    <script type="text/javascript">

    Calendar.setup
        ({
            inputField  : "ctl00_Main_txtChequeDate",
            ifFormat    : "dd-M-y",
            button      : "imgChequeDate",
            weekNumbers : false
        });

          Calendar.setup
        ({
            inputField  : "ctl00_Main_txtValueDate",
            ifFormat    : "dd-M-y",
            button      : "imgValueDate",
            weekNumbers : false
        });
    </script>

</asp:Content>
