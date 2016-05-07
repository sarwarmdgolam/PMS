<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="Cash_Chq_Payment_List.aspx.cs" Inherits="AccountTransaction_Cash_Chq_Payment_List"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    
    <fieldset>
        <legend><b>Search Criteria</b></legend>
        <table width="100%">
            <tr>
                <td>
                    <b>Investor&nbsp;Code:</b><span class="asterisk">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtInvestorCode" runat="server" onkeypress="return SuppressEnter();"
                        OnTextChanged="txtInvestorCode_TextChanged" AutoPostBack="true" SkinID="txt100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtInvestorCode"
                        Display="None" Text="*" ValidationGroup="a" runat="server" ErrorMessage="Investor Code is required."></asp:RequiredFieldValidator>
                    <asp:HiddenField ID="hdnInvestorId" runat="server" />
                </td>
                <td>
                    <strong>Investor&nbsp;Name:</strong>
                </td>
                <td>
                    <asp:TextBox ID="txtInvestorName" runat="server" ReadOnly="true" onkeypress="return SuppressEnter();"
                        SkinID="txt100"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <b>From Date:</b>
                </td>
                <td>
                    <asp:TextBox ID="txtFromDate" runat="server" onkeypress="return SuppressEnter();"
                        SkinID="txt100"></asp:TextBox>
                    <img id="imgtxtFromDate" src="../Images/Calendar.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtFromDate"
                        Display="None" Text="*" runat="server" ErrorMessage="From Date is required."></asp:RequiredFieldValidator>
                </td>
                <td>
                    <b>To Date:</b>
                </td>
                <td>
                    <asp:TextBox ID="txtToDate" runat="server" onkeypress="return SuppressEnter();" SkinID="txt100"></asp:TextBox>
                    <img id="imgtxtToDate" src="../Images/Calendar.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtToDate"
                        Display="None" Text="*" runat="server" ErrorMessage="To Date is required."></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Button ID="btnFilterData" runat="server" Text="Search" OnClick="btnFilterData_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <div id="Div1">
        <asp:GridView ID="gvCashChqPayment" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
            EmptyDataText="No Data Found." AllowPaging="True" PageSize="20" OnPageIndexChanging="gvCashChqPayment_PageIndexChanging"
            OnRowDataBound="gvCashChqPayment_RowDataBound" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Inv. Code" />
                <asp:BoundField DataField="CHEQUE_DT" HeaderText="Cheque" />
                <asp:BoundField DataField="BANK_F_NAME" HeaderText="Bank">
                    <ItemStyle Width="30%" />
                </asp:BoundField>
                <asp:BoundField DataField="TRANSACTION_DATE" HeaderText="Branch & Date">
                    <ItemStyle Width="30%" />
                </asp:BoundField>
                <asp:BoundField DataField="BROKER_BRANCH" HeaderText="GL A/C">
                    <ItemStyle Width="30%" />
                </asp:BoundField>
                <asp:BoundField DataField="Amount" HeaderText="Amount" />
                <asp:BoundField DataField="AUTH_STATUS" HeaderText="Status" />
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
