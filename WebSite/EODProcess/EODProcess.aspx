<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="EODProcess.aspx.cs" Inherits="EODProcess_EODProcess" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table style="width: 100%">
        <tr>
            <td>
                <table>
                    <tr>
                        <td style="width: 25%;">
                            Transaction Date:<span class="asterisk">*</span></td>
                        <td style="width: 75%;">
                            <asp:TextBox ID="txtTransactionDate" runat="server" Enabled="false" SkinID="txtDate"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtTransactionDate" ControlToValidate="txtTransactionDate"
                                runat="server" ErrorMessage="Transaction date" Text="*" Display="None" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <fieldset>
        <div class="div-pagetitle">
            <span id="spanPageTile" runat="server" class="span-pagetitle">Cash Tranaction </span>
        </div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <div id="Div1" class="ui-widget-content ui-corner-all list">
                        <asp:GridView ID="gvCashReconcilation" runat="server" AutoGenerateColumns="False"
                            EmptyDataText="No Inconsistency Exists." AllowPaging="True" PageSize="20" OnPageIndexChanging="gvCashReconcilation_PageIndexChanging"
                            CssClass="mGrid">
                            <Columns>
                                <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Investor Code" />
                                <asp:BoundField DataField="CALCULATED_LB" HeaderText="Calculated Balance" />
                                <asp:BoundField DataField="LEDGER_BALANCE" HeaderText="Existing Balance" />
                                <asp:BoundField DataField="DIFF_AMOUNT" HeaderText="Difference" />
                            </Columns>
                            <PagerSettings PageButtonCount="15" Mode="NumericFirstLast" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <fieldset>
       <div class="div-pagetitle">
            <span id="span1" runat="server" class="span-pagetitle">Stock Tranaction </span>
        </div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <div id="Div2" class="ui-widget-content ui-corner-all list">
                        <asp:GridView ID="gvStockReconciliation" runat="server" AutoGenerateColumns="False"
                            EmptyDataText="No Inconsistency Exists." AllowPaging="True" PageSize="20" OnPageIndexChanging="gvStockReconciliation_PageIndexChanging"
                            CssClass="mGrid">
                            <Columns>
                                <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Investor Code" />
                                <asp:BoundField DataField="SECURITYCODE" HeaderText="Instrument" />
                                <asp:BoundField DataField="CALCULATED_LDGQTY" HeaderText="Calculated Qty" />
                                <asp:BoundField DataField="LEDGER_QUANTITY" HeaderText="Existing Qty" />
                                <asp:BoundField DataField="DIFF_QTY" HeaderText="Difference" />
                                <asp:BoundField DataField="CALCULATED_COST" HeaderText="Calculated Cost" />
                                <asp:BoundField DataField="COST_AMOUNT" HeaderText="Existing Cost" />
                                <asp:BoundField DataField="DIFF_AMOUNT" HeaderText="Difference" />
                            </Columns>
                            <PagerSettings PageButtonCount="15" Mode="NumericFirstLast" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    <div style="width: 100%;">
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hdn_ID" runat="server" />
                    <asp:Button ID="btn_Save" runat="server" Text="Process" OnClick="btn_Save_Click"
                        ValidationGroup="insert" CausesValidation="true" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
