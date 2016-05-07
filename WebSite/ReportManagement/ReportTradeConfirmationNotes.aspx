<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ReportTradeConfirmationNotes.aspx.cs" Inherits="ReportManagement_ReportTradeConfirmationNotes"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table width="100%">
        <tr>
            <td colspan="2">
                <div style="width: 100%; background-color: #99CCCC;">
                    <h2>
                        Trade Confirmation Notes
                    </h2>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="divErrMesg" class="ui-widget" runat="server">
                    <div class="ui-state-error ui-corner-all" style="padding: 0pt 0.7em;">
                        <span class="ui-icon ui-icon-alert" style="margin-right: 0.3em;"></span>
                        <asp:Label ID="lblErrMsg" runat="server" EnableTheming="true">
                        </asp:Label>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="divInfoMsg" class="ui-widget" runat="server">
                    <div class="ui-state-highlight ui-corner-all" style="padding: 0pt 0.7em;">
                        <span class="ui-icon ui-icon-info" style="margin-right: 0.3em;"></span>
                        <asp:Label ID="lblMsg" runat="server" EnableTheming="true">
                        </asp:Label>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td style="width: 20%">
                <span>Investor Code</span>
            </td>
            <td>
                <asp:TextBox ID="txtInvestorCode" runat="server"  SkinID="skMultilineTextBox" TextMode="MultiLine"></asp:TextBox>
                <asp:Button ID="btnSearchInvestor" runat="server" Text="Search" OnClick="btnSearchInvestor_Click" />
                <span>Ex:A001,A002..</span>
            </td>
        </tr>
        <tr>
            <td style="width: 20%">
                <span>Investor Name</span>
            </td>
            <td style="vertical-align: top">
                <asp:TextBox ID="txtInvestorName" runat="server" SkinID="txt250" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <tr>
                        <td>
                            From Date: <span class="asterisk">*</span></td>
                        <td>
                            <table cellpadding="0" border="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtFromDate" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvFromDate" ControlToValidate="txtFromDate" runat="server"
                                            ErrorMessage="From date" Text="*" Display="None" />
                                    </td>
                                    <td>
                                        &nbsp;<img id="imgtxtFromDate" src="../Images/Calendar.gif" alt="No Image" /></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            To Date: <span class="asterisk">*</span></td>
                        <td>
                            <table cellpadding="0" border="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtToDate" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvToDate" ControlToValidate="txtToDate" runat="server"
                                            ErrorMessage="To date" Text="*" Display="None" />
                                    </td>
                                    <td>
                                        &nbsp;<img id="imgToDate" src="../Images/Calendar.gif" alt="No Image" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <div style="width: 100%;">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnPreviewPDF" runat="server" Text="PDF" OnClick="btnPreviewPDF_Click" />
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="Excel" OnClick="btnExcel_Click" />
                </td>
                <td>
                    <asp:Button ID="btnExcelData" runat="server" Text="Excel Data" OnClick="btnExcelData_Click" />
                </td>
                <td>
                    <asp:Button ID="btnDoc" runat="server" Text="Doc" OnClick="btnDoc_Click" />
                </td>
            </tr>
        </table>
    </div>
     <script type="text/javascript">

    Calendar.setup
        ({
            inputField  : "ctl00_Main_txtFromDate",
            ifFormat    : "dd-M-y",
            button      : "imgtxtFromDate",
            weekNumbers : false
        });

          Calendar.setup
        ({
            inputField  : "ctl00_Main_txtToDate",
            ifFormat    : "dd-M-y",
            button      : "imgtxtToDate",
            weekNumbers : false
        });
    </script>

</asp:Content>
