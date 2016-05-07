<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ManuallyInvestorChargeManageList.aspx.cs" Inherits="ChargeInformation_ManuallyInvestorChargeManageList"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td style="width: 20%;">
                Transaction Date From:
            </td>
            <td style="width: 15%;">
                <asp:TextBox ID="txtTransactionDateFrom" runat="server" Enabled="false" SkinID="txtDate"></asp:TextBox>
                <img id="imgTransactionDateFrom" src="../Images/Calendar.gif" />
            </td>
        </tr>
        <tr>
            <td style="width: 20%;">
                Transaction Date To:
            </td>
            <td style="width: 15%;">
                <asp:TextBox ID="txtTransactionDateTo" runat="server" Enabled="false" SkinID="txtDate"></asp:TextBox>
                <img id="imgTransactionDateTo" src="../Images/Calendar.gif" />
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
                <asp:DropDownList ID="ddlTransactionMode" runat="server" SkinID="ddl100">
                 <asp:ListItem Value="" Text="N/A" Selected="True" />
                    <asp:ListItem Value="addition" Text="Addition"  />
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
                Width="900px" EmptyDataText="No Charge Information has been found." AllowPaging="True"
                PageSize="10" OnPageIndexChanging="dgvChargeInformation_PageIndexChanging" OnRowDataBound="dgvChargeInformation_RowDataBound"
                DataKeyNames="ID" CssClass="mGrid">
                <Columns>
                    <asp:BoundField DataField="TRANSACTION_DATE" HeaderText="Transaction Date"></asp:BoundField>
                       <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Investor Code"></asp:BoundField>
                    <asp:BoundField DataField="CHARGE_F_NAME" HeaderText="Full Name"></asp:BoundField>
                    <asp:BoundField DataField="AMOUNT" HeaderText="Charge Amount"></asp:BoundField>
                    <asp:ButtonField Text="Edit" HeaderText="Edit">
                        <ItemStyle Width="8%" />
                    </asp:ButtonField>
                    <asp:ButtonField Text="Delete" HeaderText="Delete">
                        <ItemStyle Width="8%" />
                    </asp:ButtonField>
                </Columns>
                <EmptyDataRowStyle />
                <PagerSettings PageButtonCount="15" Mode="NumericFirstLast" />
            </asp:GridView>
        </div>
    </div>

    <script type="text/javascript">

    Calendar.setup
        ({
            inputField  : "ctl00_Main_txtTransactionDateFrom",
            ifFormat    : "dd-M-y",
            button      : "imgTransactionDateFrom",
            weekNumbers : false
        });

          Calendar.setup
        ({
            inputField  : "ctl00_Main_txtTransactionDateTo",
            ifFormat    : "dd-M-y",
            button      : "imgTransactionDateTo",
            weekNumbers : false
        });
    </script>

</asp:Content>
