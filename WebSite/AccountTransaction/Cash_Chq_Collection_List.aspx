<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="Cash_Chq_Collection_List.aspx.cs" Inherits="Transaction_Cash_Chq_Collection_List"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <fieldset>
        <legend>Search Criteria</legend>
        <table width="100%">
            <tr>
                <td>
                    Investor Code:<span class="asterisk">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtInvestorCode" runat="server" onkeypress="return SuppressEnter();"
                        OnTextChanged="txtInvestorCode_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtInvestorCode"
                        Display="None" Text="*" ValidationGroup="a" runat="server" ErrorMessage="Investor Code is required."></asp:RequiredFieldValidator>
                    <asp:HiddenField ID="hdnInvestorId" runat="server" />
                </td>
                <td>
                    Investor Name:</td>
                <td>
                    <asp:TextBox ID="txtInvestorName" runat="server" ReadOnly="true" onkeypress="return SuppressEnter();"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    From Date:</td>
                <td>
                    <asp:TextBox ID="txtFromDate" runat="server" Width="100px" onkeypress="return SuppressEnter();"></asp:TextBox>
                    <img id="imgtxtFromDate" src="../Images/Calendar.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtFromDate"
                        Display="None" Text="*" runat="server" ErrorMessage="From Date is required."></asp:RequiredFieldValidator>
                </td>
                <td>
                    To Date:</td>
                <td>
                    <asp:TextBox ID="txtToDate" runat="server" Width="100px" onkeypress="return SuppressEnter();"></asp:TextBox>
                    <img id="imgtxtToDate" src="../Images/Calendar.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtToDate"
                        Display="None" Text="*" runat="server" ErrorMessage="To Date is required."></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Button ID="btnFilterData" runat="server" Text="Search" OnClick="btnFilterData_Click" /></td>
            </tr>
        </table>
    </fieldset>
    <br />
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <div id="Div1" class="ui-widget-content ui-corner-all list">
                    <asp:GridView ID="gvCashCheque" runat="server" AutoGenerateColumns="False" EmptyDataText="No Cash & Cheque Receive exist"
                        AllowPaging="True" PageSize="20" OnPageIndexChanging="gvCashCheque_PageIndexChanging"
                        OnRowDataBound="gvCashCheque_RowDataBound" CssClass="mGrid" DataKeyNames="ID">
                        <Columns>
                            <asp:BoundField DataField="VOUCHER_NO" HeaderText="Voucher Number" />
                            <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Investor" />
                            <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Bank">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Cheque">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Transaction" />
                            <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Amount" />
                            <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Status">
                                <ItemStyle Width="8%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ID" HeaderText="Edit">
                                <ItemStyle Width="6%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ID" HeaderText="Delete">
                                <ItemStyle Width="6%" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings PageButtonCount="15" Mode="NumericFirstLast" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>

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
