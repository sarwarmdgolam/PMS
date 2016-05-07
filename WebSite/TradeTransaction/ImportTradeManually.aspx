<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ImportTradeManually.aspx.cs" Inherits="TradeTransaction_ImportTradeManually"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table width="100%">
        <tr>
            <td colspan="2">
                <div style="width: 100%; background-color: #99CCCC;">
                    <h2>
                        Upload Trade Information (Manually)
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
    </table>
    <asp:HiddenField ID="hdn_investor_id" runat="server" />
    <table style="width: 100%;">
        <tr>
            <td>
                <div>
                    <table>
                        <tr>
                            <td style="width: 25%">
                                <b>Trading Date</b>
                            </td>
                            <td style="width: 75%">
                                <asp:TextBox ID="txtTradingDate" runat="server" Enabled="true" SkinID="txtDate"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Security Market</b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSecurityMarket" runat="server" SkinID="ddl100">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Investor</b>
                            </td>
                            <td>
                                <div>
                                    <asp:ListBox ID="listInvestor_Code" runat="server" Width="350" SelectionMode="Single">
                                    </asp:ListBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btn_Search_Trade" runat="server" Text="Search" OnClick="btn_Search_Trade_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="overflow: auto; height: 100%; width: 100%;">
                    <asp:GridView ID="gvTradeImport" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                        EmptyDataText="No Data found!" OnRowCancelingEdit="gvTradeImport_RowCancelingEdit"
                        OnRowCommand="gvTradeImport_RowCommand" OnRowDeleting="gvTradeImport_RowDeleting"
                        OnRowEditing="gvTradeImport_RowEditing" OnRowUpdating="gvTradeImport_RowUpdating"
                        DataKeyNames="ID" OnRowDataBound="gvTradeImport_RowDataBound" CssClass="mGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Ticker" HeaderStyle-HorizontalAlign="Left" ControlStyle-Width="120px">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_ticker_name" runat="server" Width="120px" SelectedValue='<%# Eval("COMPANY_ID") %>'>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddl_ticker_name" ValidationGroup="Update" runat="server"
                                        ControlToValidate="ddl_ticker_name" InitialValue="0" ErrorMessage="Please Select any Ticker."
                                        ToolTip="Please Select any Ticker." SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddl_ticker_name" runat="server" Width="120px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddl_ticker_name" ValidationGroup="Update" runat="server"
                                        ControlToValidate="ddl_ticker_name" InitialValue="0" ErrorMessage="Please Select any Ticker."
                                        ToolTip="Please Select any Ticker." SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <%# Eval("SECURITYCODE")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mode" HeaderStyle-HorizontalAlign="Left" ControlStyle-Width="60px">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_transaction_mode" runat="server" Width="60px" SelectedValue='<%# Eval("transaction_mode_id") %>'>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <%# Eval("MODE_F_Name")%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddl_transaction_mode" runat="server" Width="60px">
                                    </asp:DropDownList>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty" HeaderStyle-HorizontalAlign="Left">
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
                            <asp:TemplateField HeaderText="Price" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# Eval("unit_price")%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txt_unit_price" runat="server" MaxLength="10" Width="40px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxt_unit_price" ValidationGroup="Insert" runat="server"
                                        ControlToValidate="txt_unit_price" ErrorMessage="Please Enter Unit Price" ToolTip="Please Enter Unit Price"
                                        SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="retxt_unit_price" runat="server" ErrorMessage="Please Enter Only Numbers"
                                        ValidationGroup="Insert" ToolTip="Please Enter Only Numbers" ControlToValidate="txt_unit_price"
                                        ValidationExpression="^-?\d*\.{0,1}\d+$" SetFocusOnError="true" ForeColor="red">*</asp:RegularExpressionValidator>
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_unit_price" runat="server" Text='<%# Eval("unit_price") %>'
                                        MaxLength="10" Width="40px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxt_unit_price" ValidationGroup="Insert" runat="server"
                                        ControlToValidate="txt_unit_price" ErrorMessage="Please Enter Unit Price" ToolTip="Please Enter Unit Price"
                                        SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="retxt_unit_price" runat="server" ErrorMessage="Please Enter Only Numbers"
                                        ValidationGroup="Insert" ToolTip="Please Enter Only Numbers" ControlToValidate="txt_unit_price"
                                        ValidationExpression="^-?\d*\.{0,1}\d+$" SetFocusOnError="true" ForeColor="red">*</asp:RegularExpressionValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comm(%)" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# Eval("comm_percent")%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txt_comm_percent" runat="server" MaxLength="5" Width="40px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxt_comm_percent" ValidationGroup="Insert" runat="server"
                                        ControlToValidate="txt_comm_percent" ErrorMessage="Please Enter Commission Percent"
                                        ToolTip="Please Enter Commission Percent" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="retxt_comm_percent" runat="server" ErrorMessage="Please Enter Only Numbers"
                                        ValidationGroup="Insert" ToolTip="Please Enter Only Numbers" ControlToValidate="txt_comm_percent"
                                        ValidationExpression="^-?\d*\.{0,1}\d+$" SetFocusOnError="true" ForeColor="red">*</asp:RegularExpressionValidator>
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_unit_price" runat="server" Text='<%# Eval("comm_percent") %>'
                                        MaxLength="5" Width="40px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxt_comm_percent" ValidationGroup="Insert" runat="server"
                                        ControlToValidate="txt_comm_percent" ErrorMessage="Please Enter Commission Percent"
                                        ToolTip="Please Enter Commission Percent" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="retxt_comm_percent" runat="server" ErrorMessage="Please Enter Only Numbers"
                                        ValidationGroup="Insert" ToolTip="Please Enter Only Numbers" ControlToValidate="txt_comm_percent"
                                        ValidationExpression="^-?\d*\.{0,1}\d+$" SetFocusOnError="true" ForeColor="red">*</asp:RegularExpressionValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Board" HeaderStyle-HorizontalAlign="Left">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_market_type" runat="server" Width="60px" SelectedValue='<%# Eval("market_type_id") %>'>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <%# Eval("market_type_name")%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddl_market_type" runat="server" Width="60px">
                                    </asp:DropDownList>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IsSpot" HeaderStyle-HorizontalAlign="Left">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="chk_compulsory_spot" runat="server" Checked='<%# Eval("ISCOMPULSORY_SPOT") %>' />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_compulsory_spot" runat="server" Checked='<%# Eval("ISCOMPULSORY_SPOT") %>'
                                        Enabled="false" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="chk_compulsory_spot" runat="server" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Trader" HeaderStyle-HorizontalAlign="Left">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_trader" runat="server" Width="60px" SelectedValue='<%# Eval("trader_id") %>'>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <%# Eval("trader_id")%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddl_trader" runat="server" Width="60px">
                                    </asp:DropDownList>
                                </FooterTemplate>
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
                            <table id="gvTradeImport">
                                <tr>
                                    <th align="left" scope="col">
                                        Ticker
                                    </th>
                                    <th align="left" scope="col">
                                        Mode
                                    </th>
                                    <th align="right" scope="col">
                                        Quantity
                                    </th>
                                    <th align="right" scope="col">
                                        Unit Price
                                    </th>
                                    <th align="right" scope="col">
                                        Comm(%)
                                    </th>
                                    <th align="center" scope="col">
                                        Board
                                    </th>
                                    <th align="center" scope="col">
                                        Spot
                                    </th>
                                    <th align="left" scope="col">
                                        Trader
                                    </th>
                                    <th align="left" scope="col">
                                        Action
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan="11">
                                        No Records found...
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddl_ticker_name" runat="server" Width="120px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_transaction_mode" runat="server" Width="60px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_quantity" runat="server" MaxLength="10" Width="60px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_unit_price" runat="server" MaxLength="10" Width="60px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_comm_percent" runat="server" MaxLength="10" Width="50px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_market_type" runat="server" Width="60px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chk_compulsory_spot" runat="server" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_trader" runat="server" Width="60px">
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="2" align="center" valign="middle">
                                        <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="false" CommandName="emptyInsert"
                                            Text="emptyInsert"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <%--   <AlternatingRowStyle BackColor="#C2D69B" />--%>
                        <%-- <RowStyle BackColor="#B4B4B4" ForeColor="#2A6021" VerticalAlign="Top" />
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#2A6021" VerticalAlign="Top" />
                            <PagerStyle ForeColor="#2A6021" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#F7DFB5" Font-Bold="True" ForeColor="#2A6021" />
                            <HeaderStyle Wrap="True" VerticalAlign="Top" />
                            <EmptyDataRowStyle BackColor="#B4B4B4" ForeColor="#2A6021" BorderStyle="none" BorderWidth="1px" />--%>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    <div style="width: 100%;">
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hdn_ID" runat="server" />
                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="insert"
                        CausesValidation="true" />
                </td>
                <td>
                    <asp:Button ID="btn_Clear" runat="server" Text="Refresh" OnClick="btn_Clear_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
