<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ManuallyInstrumentReceive.aspx.cs" Inherits="InstrumentManagement_ManuallyInstrumentReceive"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <div class="content">
        <table style="width: 100%">
            <tr>
                <td style="width: 450px; height: 26px">
                    <strong>Transaction Date:</strong>
                </td>
                <td style="width: 327px; height: 26px">
                    <table cellpadding="0" border="0" cellspacing="0">
                        <tr>
                            <td style="height: 24px">
                                <asp:TextBox ID="txtTransactionDate" runat="server" MaxLength="10" SkinID="txt100"
                                    Enabled="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtTransactionDate" ControlToValidate="txtTransactionDate"
                                    runat="server" ErrorMessage="Transaction date" Text="*" Display="None" />
                            </td>
                            <td style="height: 24px">
                                <%-- &nbsp;<img id="imgReceiveDate" src="../Images/Calendar.gif" />--%>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 169px; height: 26px">
                    <b>Voucher No.</b></td>
                <td style="width: 209px; height: 26px">
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
                <td style="height: 26px; width: 169px;">
                    <b>Investor Code:</b> <span class="asterisk">*</span>
                </td>
                <td style="height: 26px; width: 209px;">
                    <asp:TextBox ID="txtInvestorCode" runat="server" MaxLength="20" SkinID="txt100" OnTextChanged="txtInvestorCode_TextChanged"
                        AutoPostBack="true"></asp:TextBox>
                    <asp:HiddenField ID="hdnInvestor_ID" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvtxtInvestorCode" ControlToValidate="txtInvestorCode"
                        runat="server" ErrorMessage="Investor Code" Text="*" Display="None" />
                </td>
                <td style="width: 157px; height: 26px">
                    <b>Investor Name:<span class="asterisk">*</span></b>
                </td>
                <td style="width: 327px; height: 26px">
                    <asp:TextBox ID="txtInvestorName" runat="server" SkinID="txt250" ReadOnly="true" />
                    <asp:RequiredFieldValidator ID="rfvInvestorName" ControlToValidate="txtInvestorName"
                        runat="server" ErrorMessage="Investor Name." Text="*" Display="None" />
                </td>
            </tr>
            <tr>
                <td style="height: 26px; width: 169px;">
                    <b>Transaction Mode:</b> <span class="asterisk">*</span></td>
                <td style="height: 26px; width: 209px;">
                    <asp:DropDownList ID="ddlTransactionMode" runat="server" SkinID="ddl100" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvTransactionMode" runat="server" ControlToValidate="ddlTransactionMode"
                        Display="None" ErrorMessage="Transaction Mode" InitialValue="0" Text="*"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 157px; height: 26px">
                </td>
                <td style="width: 327px; height: 26px">
                </td>
            </tr>
            <tr>
                <td style="height: 26px; width: 169px;">
                    <b>Reference No#:</b></td>
                <td style="height: 26px; width: 209px;">
                    <asp:TextBox ID="txtReferenceNO" runat="server" SkinID="txt100"></asp:TextBox>
                </td>
                <td style="width: 157px; height: 26px">
                </td>
                <td style="width: 327px; height: 26px">
                </td>
            </tr>
            <tr>
                <td style="height: 26px; width: 169px;">
                    <b>Remarks:</b>
                </td>
                <td style="height: 26px; width: 209px;" colspan="2">
                    <asp:TextBox ID="txtRemarks" runat="server" SkinID="txt250"></asp:TextBox>
                </td>
                <td style="width: 327px; height: 26px">
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hdn_ID" runat="server"></asp:HiddenField>
                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="insert" />
                </td>
                <td>
                    <asp:Button ID="btn_Update" runat="server" Text="Update" />
                </td>
                <td>
                    <asp:Button ID="btn_Delete" runat="server" Text="Delete" />
                </td>
                <td>
                    <asp:Button ID="btn_Clear" runat="server" Text="Refresh" />
                </td>
            </tr>
        </table>
        <table style="width: 100%">
            <tr>
                <td>
                    <div style="overflow: auto; height: 300px; width: 100%;">
                        <asp:GridView ID="gvInstrumentManagement" runat="server" AutoGenerateColumns="False"
                            BorderStyle="None" ShowFooter="True" EmptyDataText="No Data found!" EnableViewState="true"
                            OnRowCancelingEdit="gvInstrumentManagement_RowCancelingEdit" OnRowCommand="gvInstrumentManagement_RowCommand"
                            OnRowDeleting="gvInstrumentManagement_RowDeleting" OnRowEditing="gvInstrumentManagement_RowEditing"
                            OnRowUpdating="gvInstrumentManagement_RowUpdating" DataKeyNames="ID" OnRowDataBound="gvInstrumentManagement_RowDataBound"
                            CssClass="mGrid">
                            <Columns>
                                <asp:TemplateField HeaderText="Ticker" HeaderStyle-HorizontalAlign="Left" ControlStyle-Width="100px">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddl_ticker_name" runat="server" Width="100px" SelectedValue='<%# Eval("COMPANY_ID") %>'>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvddl_ticker_name" ValidationGroup="Update" runat="server"
                                            ControlToValidate="ddl_ticker_name" InitialValue="0" ErrorMessage="Please Select any Ticker."
                                            ToolTip="Please Select any Ticker." SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="ddl_ticker_name" runat="server" Width="100px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvddl_ticker_name" ValidationGroup="Update" runat="server"
                                            ControlToValidate="ddl_ticker_name" InitialValue="0" ErrorMessage="Please Select any Ticker."
                                            ToolTip="Please Select any Ticker." SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <%# Eval("SECURITYCODE")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ref Mode" HeaderStyle-HorizontalAlign="Left">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddl_ref_transaction_mode" runat="server" Width="50px" SelectedValue='<%# Eval("transaction_mode_id") %>'>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <%# Eval("MODE_F_Name")%>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="ddl_ref_transaction_mode" runat="server" Width="50px">
                                        </asp:DropDownList>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# Eval("quantity")%>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_quantity" runat="server" MaxLength="10" Width="60px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxt_quantity" ValidationGroup="Insert" runat="server"
                                            ControlToValidate="txt_quantity" ErrorMessage="Please Enter Trade Quantity" ToolTip="Please Enter Trade Quantity"
                                            SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="retxt_quantity" runat="server" ErrorMessage="Please Enter Only Numbers"
                                            ValidationGroup="Insert" ToolTip="Please Enter Only Numbers" ControlToValidate="txt_quantity"
                                            ValidationExpression="^-?\d*\.{0,1}\d+$" SetFocusOnError="true" ForeColor="red">*</asp:RegularExpressionValidator>
                                    </FooterTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_quantity" runat="server" Text='<%# Eval("quantity") %>' MaxLength="10"
                                            Width="60px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxt_quantity" ValidationGroup="Update" runat="server"
                                            ControlToValidate="txt_quantity" ErrorMessage="Please Enter Trade Quantity" ToolTip="Please Enter Trade Quantity"
                                            SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="retxt_quantity" runat="server" ErrorMessage="Please Enter Only Numbers"
                                            ValidationGroup="Update" ToolTip="Please Enter Only Numbers" ControlToValidate="txt_quantity"
                                            ValidationExpression="^-?\d*\.{0,1}\d+$" SetFocusOnError="true" ForeColor="red">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# Eval("total_amount")%>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_total_amount" runat="server" MaxLength="10" Width="40px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxt_total_amount" ValidationGroup="Insert" runat="server"
                                            ControlToValidate="txt_total_amount" ErrorMessage="Please Enter Total Amount"
                                            ToolTip="Please Enter Total Amount" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="retxt_total_amount" runat="server" ErrorMessage="Please Enter Only Numbers"
                                            ValidationGroup="Insert" ToolTip="Please Enter Only Numbers" ControlToValidate="txt_total_amount"
                                            ValidationExpression="^-?\d*\.{0,1}\d+$" SetFocusOnError="true" ForeColor="red">*</asp:RegularExpressionValidator>
                                    </FooterTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_total_amount" runat="server" Text='<%# Eval("total_amount") %>'
                                            MaxLength="10" Width="40px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxt_total_amount" ValidationGroup="Insert" runat="server"
                                            ControlToValidate="txt_total_amount" ErrorMessage="Please Enter Total Amount"
                                            ToolTip="Please Enter Total Amount" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="retxt_total_amount" runat="server" ErrorMessage="Please Enter Only Numbers"
                                            ValidationGroup="Insert" ToolTip="Please Enter Only Numbers" ControlToValidate="txt_total_amount"
                                            ValidationExpression="^-?\d*\.{0,1}\d+$" SetFocusOnError="true" ForeColor="red">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                            Text="Update" OnClientClick="return confirm('Update?')" ValidationGroup="Update"></asp:LinkButton>
                                        <asp:ValidationSummary ID="vsUpdate" runat="server" ShowMessageBox="true" ShowSummary="false"
                                            ValidationGroup="Update" Enabled="true" HeaderText="Validation Summary..." />
                                        <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                            Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="True" CommandName="Insert"
                                            ValidationGroup="Insert" Text="Insert"></asp:LinkButton>
                                        <asp:ValidationSummary ID="vsInsert" runat="server" ShowMessageBox="true" ShowSummary="false"
                                            ValidationGroup="Insert" Enabled="true" HeaderText="Validation..." />
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Delete" OnClientClick="return confirm('Delete?')"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table class="grid" cellspacing="0" rules="all" border="1" id="gvInstrumentManagement"
                                    style="border-collapse: collapse;">
                                    <tr>
                                        <th align="left" scope="col">
                                            Ticker
                                        </th>
                                        <th align="left" scope="col">
                                            Ref Mode
                                        </th>
                                        <th align="right" scope="col">
                                            Quantity
                                        </th>
                                        <th align="right" scope="col">
                                            Amount
                                        </th>
                                    </tr>
                                    <tr class="gridRow">
                                        <td colspan="11">
                                            No Records found...
                                        </td>
                                    </tr>
                                    <tr class="gridFooterRow">
                                        <td>
                                            <asp:DropDownList ID="ddl_ticker_name" runat="server" Width="100px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_ref_transaction_mode" runat="server" Width="50px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_quantity" runat="server" MaxLength="10" Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_total_amount" runat="server" MaxLength="10" Width="60px"></asp:TextBox>
                                        </td>
                                        <td colspan="2" valign="middle">
                                            <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="false" CommandName="emptyInsert"
                                                Text="emptyInsert"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <AlternatingRowStyle BackColor="#C2D69B" />
                            <RowStyle BackColor="#B4B4B4" ForeColor="#2A6021" VerticalAlign="Top" />
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#2A6021" VerticalAlign="Top" />
                            <PagerStyle ForeColor="#2A6021" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#F7DFB5" Font-Bold="True" ForeColor="#2A6021" />
                            <HeaderStyle Wrap="True" VerticalAlign="Top" />
                            <EmptyDataRowStyle BackColor="#B4B4B4" ForeColor="#2A6021" BorderStyle="none" BorderWidth="1px" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnSaveDetails" runat="server" Text="Save Datails" OnClick="btnSaveDetails_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
