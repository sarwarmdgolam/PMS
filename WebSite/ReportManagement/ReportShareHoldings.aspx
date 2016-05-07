<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ReportShareHoldings.aspx.cs" Inherits="ReportManagement_ReportShareHoldings"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table width="100%">
        <tr>
            <td colspan="2">
                <div style="width: 100%; background-color: #99CCCC;">
                    <h2>
                        Investor Portfolio Statement
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
            <td style="width: 25%;">
                Transaction Date:<span class="asterisk">*</span></td>
            <td style="width: 75%;">
                <asp:TextBox ID="txtTransactionDate" runat="server" Enabled="true" SkinID="txtDate"></asp:TextBox>
                <img id="imgTransactionDate" src="../Images/Calendar.gif" alt="No Image" />
                <asp:RequiredFieldValidator ID="rfvtxtTransactionDate" ControlToValidate="txtTransactionDate"
                    runat="server" ErrorMessage="Transaction date" Text="*" Display="None" />
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
            inputField  : "ctl00_Main_txtTransactionDate",
            ifFormat    : "dd-M-y",
            button      : "imgTransactionDate",
            weekNumbers : false
        });

    </script>
</asp:Content>
