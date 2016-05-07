<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ReportParameterPage.aspx.cs" Inherits="ReportManagement_ReportParameterPage"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table id="tblDateRange" width="100%" runat="server" style="margin: 5px 5px 5px 5px;"
        cellpadding="0" border="0" cellspacing="0">
        <tr>
            <td style="text-align: left; width: 150px">
                From Date:
            </td>
            <td style="text-align: left;">
                <table cellpadding="0" border="0" cellspacing="0" style="margin: 5px 5px 0px 5px;">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtFromDate" runat="server" MaxLength="11" SkinID="txtDate"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFromDate" ControlToValidate="txtFromDate" runat="server"
                                ErrorMessage="From date" Text="*" Display="None" />
                        </td>
                        <td>
                            &nbsp;<img id="imgFromDate" src="../Images/Calendar.gif" alt="No Image" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 150px">
                To Date: <span class="asterisk">*</span></td>
            <td style="text-align: left;">
                <table cellpadding="0" border="0" cellspacing="0" style="margin: 5px 5px 0px 5px;">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtToDate" runat="server" MaxLength="11" SkinID="txtDate"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvToDate" ControlToValidate="txtToDate" runat="server"
                                ErrorMessage="To date" Text="*" Display="None" />
                        </td>
                        <td>
                            <img id="imgToDate" src="../Images/Calendar.gif" alt="No Image" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table id="tblTransactionDate1" width="100%" runat="server" style="margin: 5px 5px 5px 5px;"
        cellpadding="0" border="0" cellspacing="0">
        <tr>
            <td style="text-align: left; width: 150px">
                <asp:Literal ID="lblTransactionDate1" runat="server" Text="Transaction Date 2:"></asp:Literal>
            </td>
            <td style="text-align: left;">
                <table cellpadding="0" border="0" cellspacing="0" style="margin: 5px 5px 0px 5px;">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtTransactionDate1" runat="server" MaxLength="11" SkinID="txtDate"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTransactionDate1"
                                runat="server" ErrorMessage="Transaction date" Text="*" Display="None" />
                        </td>
                        <td>
                            <img id="imgTransactionDate1" src="../Images/Calendar.gif" alt="No Image" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table id="tblTransactionDate2" width="100%" runat="server" style="margin: 5px 5px 5px 5px;"
        cellpadding="0" border="0" cellspacing="0">
        <tr>
            <td style="text-align: left; width: 150px">
                <asp:Literal ID="lblTransactionDate2" runat="server" Text="Transaction Date 2:"></asp:Literal>
                <%-- <asp:Label ID="lblTransactionDate2" runat="server" Text="Transaction Date 2:" Font-Bold="true"></asp:Label>--%>
            </td>
            <td style="text-align: left;">
                <table cellpadding="0" border="0" cellspacing="0" style="margin: 5px 5px 0px 5px;">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtTransactionDate2" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtTransactionDate2"
                                runat="server" ErrorMessage="Transaction date" Text="*" Display="None" />
                        </td>
                        <td>
                            &nbsp;<img id="imgTransactionDate2" src="../Images/Calendar.gif" alt="No Image" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table id="tblInvestorCode" width="100%" runat="server" style="margin: 5px 5px 5px 5px;"
        cellpadding="0" border="0" cellspacing="0">
        <tr>
            <td style="text-align: left; width: 150px">
                <span>Investor Code</span>
            </td>
            <td style="text-align: left;">
                <asp:HiddenField ID="hdnInvestor_ID" runat="server" Value="0" />
                <asp:TextBox ID="txtInvestorCode" runat="server" SkinID="skMultilineTextBox" TextMode="MultiLine"
                    Style="margin: 5px 5px 0px 5px;"></asp:TextBox>
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
    <div>
        <asp:Panel ID="pnlDynamicControls" runat="server" EnableViewState="true">
        </asp:Panel>
    </div>
    <br />
    <div style="width: 100%;">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnPreview" runat="server" Text="Preview" OnClick="btnPreview_Click" />
                </td>
                <td>
                    <asp:Button ID="btnPDF" runat="server" Text="PDF" OnClick="btnPDF_Click" />
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
        var FrmDate= document.getElementById("ctl00_Main_txtFromDate");
        if(FrmDate != null)
        {
            Calendar.setup
            ({
                inputField  : "ctl00_Main_txtFromDate",
                ifFormat    : "dd-M-y",
                button      : "imgFromDate",
                weekNumbers : false
            });
        }
        var ToDate= document.getElementById("ctl00_Main_txtToDate");
        if(ToDate != null)
        {
              Calendar.setup
            ({
                inputField  : "ctl00_Main_txtToDate",
                ifFormat    : "dd-M-y",
                button      : "imgToDate",
                weekNumbers : false
            });
        }
        
         var TransactionDate1= document.getElementById("ctl00_Main_txtTransactionDate1");
        if(TransactionDate1 != null)
        {
              Calendar.setup
            ({
                inputField  : "ctl00_Main_txtTransactionDate1",
                ifFormat    : "dd-M-y",
                button      : "imgTransactionDate1",
                weekNumbers : false
            });
        }
        
          var TransactionDate2= document.getElementById("ctl00_Main_txtTransactionDate2");
        if(TransactionDate2 != null)
        {
              Calendar.setup
            ({
                inputField  : "ctl00_Main_txtTransactionDate2",
                ifFormat    : "dd-M-y",
                button      : "imgTransactionDate2",
                weekNumbers : false
            });
        }
        
    </script>

</asp:Content>
