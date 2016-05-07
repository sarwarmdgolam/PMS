<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="BrokerDefaultChargeInformation.aspx.cs" Inherits="ChargeInformation_BrokerDefaultChargeInformation"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td>
                Short Name<span class="asterisk">*</span></td>
            <td>
                <asp:TextBox ID="txtShortName" runat="server" SkinID="txt100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtShortName"
                    Display="None" Text="*" ValidationGroup="a" runat="server" ErrorMessage="Short Name is required."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 20%">
                Charge Name<span class="asterisk">*</span></td>
            <td style="width: 80%">
                <asp:TextBox ID="txtName" runat="server" SkinID="txt250"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName"
                    Display="None" Text="*" ValidationGroup="a" runat="server" ErrorMessage="Charge Name is required."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Charge Amount<span class="asterisk">*</span></td>
            <td>
                <asp:TextBox ID="txtChargeAmount" onkeypress="return blockNonNumbers(this, event, true, false);"
                    runat="server" MaxLength="18" Text="0.00" SkinID="txt100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtChargeAmount"
                    Display="None" Text="*" ValidationGroup="a" runat="server" ErrorMessage="Charge Amount is required."></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtChargeAmount"
                    ErrorMessage="The value specified as 'Charge Amount' is not valid." Text="*"
                    Display="None" ValidationExpression="^\d{1,13}(\.\d{0,4})?$" ValidationGroup="a">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Minimum Charge
            </td>
            <td>
                <asp:TextBox ID="txtMinimumCharge" onkeypress="return blockNonNumbers(this, event, true, false);"
                    runat="server" MaxLength="18" Text="0.00" SkinID="txt100"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMinimumCharge"
                    ErrorMessage="The value specified as 'Minimum Charge' is not valid." Text="*"
                    Display="None" ValidationExpression="^\d{1,13}(\.\d{0,4})?$" ValidationGroup="a">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                CDBL Charge
            </td>
            <td>
                <asp:TextBox ID="txtCDBLChargeAmount" onkeypress="return blockNonNumbers(this, event, true, false);"
                    runat="server" MaxLength="18" Text="0.00" SkinID="txt100"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtCDBLChargeAmount"
                    ErrorMessage="Input CDBL charge amount." Text="*" Display="None" ValidationExpression="^\d{1,13}(\.\d{0,4})?$"
                    ValidationGroup="a">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                CDBL Minimum Charge
            </td>
            <td>
                <asp:TextBox ID="txtCDBLMinChargeAmount" onkeypress="return blockNonNumbers(this, event, true, false);"
                    runat="server" MaxLength="18" Text="0.00" SkinID="txt100"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtCDBLMinChargeAmount"
                    ErrorMessage="Input CDBL minimum charge amount." Text="*" Display="None" ValidationExpression="^\d{1,13}(\.\d{0,4})?$"
                    ValidationGroup="a">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Charge Type<span class="asterisk">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlChargeType" runat="server" SkinID="ddl100">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlChargeType"
                    InitialValue="0" Display="None" Text="*" ValidationGroup="a" runat="server" ErrorMessage="Charge Type is required."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Percentage
            </td>
            <td>
                <asp:CheckBox ID="chkISPercentage" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Slab
            </td>
            <td>
                <asp:CheckBox ID="chkISSlab" runat="server" OnClientClick="return confirmSave();" />
            </td>
        </tr>
        <tr>
            <td>
                Active Date<span class="asterisk">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtActiveDate" runat="server" MaxLength="11" SkinID="txtDate"></asp:TextBox>
                <img id="imgActiveDate" alt="" src="../Images/Calendar.gif" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtActiveDate"
                    runat="server" ErrorMessage="Active Date is required."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Active
            </td>
            <td>
                <asp:CheckBox ID="chkISActive" runat="server" Checked="true" />
            </td>
        </tr>
    </table>
    <br />
    <table>
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
    <table style="width: 100%;">
        <tr>
            <td>
                <div style="width: 100%;">
                    <asp:GridView ID="gvChargeInformation" runat="server" AutoGenerateColumns="False"
                        ShowFooter="true" EmptyDataText="No Data found!" Width="100%" OnRowCancelingEdit="gvChargeInformation_RowCancelingEdit"
                        OnRowCommand="gvChargeInformation_RowCommand" OnRowDeleting="gvChargeInformation_RowDeleting"
                        OnRowEditing="gvChargeInformation_RowEditing" OnRowUpdating="gvChargeInformation_RowUpdating"
                        DataKeyNames="ID,DEFAULT_CHARGE_ID" OnRowDataBound="gvChargeInformation_RowDataBound"
                        CssClass="mGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Amount From">
                                <EditItemTemplate>
                                    <asp:TextBox Width="100px" ID="txtAmountFromEdit" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        MaxLength="17" runat="server" Text='<%# Bind("START_AMOUNT")%>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAmountFromEdit" ControlToValidate="txtAmountFromEdit"
                                        Display="None" Text="*" ValidationGroup="b" runat="server" ErrorMessage="Amount From is required."></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rexpvAmountFromEdit" runat="server" ControlToValidate="txtAmountFromEdit"
                                        ErrorMessage="The value specified as 'Amount From' is not valid." Text="*" Display="None"
                                        ValidationExpression="^\d{1,12}(\.\d{0,4})?$" ValidationGroup="b">
                                    </asp:RegularExpressionValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label Width="100px" ID="lblAmountFrom" runat="server" Text='<%# Bind("START_AMOUNT")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox Width="100px" ID="txtAmountFrom" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        MaxLength="17" runat="server" Text=""></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAmountFromEmpty" ControlToValidate="txtAmountFrom"
                                        Display="None" Text="*" ValidationGroup="b" runat="server" ErrorMessage="Amount From is required."></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rexpvAmountFromEmpty" runat="server" ControlToValidate="txtAmountFrom"
                                        ErrorMessage="The value specified as 'Amount From' is not valid." Text="*" Display="None"
                                        ValidationExpression="^\d{1,12}(\.\d{0,4})?$" ValidationGroup="b">
                                    </asp:RegularExpressionValidator>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount To">
                                <EditItemTemplate>
                                    <asp:TextBox Width="100px" ID="txtAmountToEdit" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        MaxLength="17" runat="server" Text='<%# Bind("END_AMOUNT")%>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAmountToEdit" ControlToValidate="txtAmountToEdit"
                                        Display="None" Text="*" ValidationGroup="b" runat="server" ErrorMessage="Amount To is required."></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rexpvAmountToEdit" runat="server" ControlToValidate="txtAmountToEdit"
                                        ErrorMessage="The value specified as 'Amount To' is not valid." Text="*" Display="None"
                                        ValidationExpression="^\d{1,12}(\.\d{0,4})?$" ValidationGroup="b">
                                    </asp:RegularExpressionValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label Width="100px" ID="lblAmountTo" runat="server" Text='<%# Bind("END_AMOUNT")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox Width="100px" ID="txtAmountTo" runat="server" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        MaxLength="17" Text=""></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAmountToEmpty" ControlToValidate="txtAmountTo"
                                        Display="None" Text="*" ValidationGroup="b" runat="server" ErrorMessage="Amount To is required."></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rexpvAmountToEmpty" runat="server" ControlToValidate="txtAmountTo"
                                        ErrorMessage="The value specified as 'Amount To' is not valid." Text="*" Display="None"
                                        ValidationExpression="^\d{1,12}(\.\d{0,4})?$" ValidationGroup="b">
                                    </asp:RegularExpressionValidator>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Charge Amount">
                                <EditItemTemplate>
                                    <asp:TextBox Width="100px" ID="txtChargeAmountEdit" runat="server" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        MaxLength="17" Text='<%# Bind("CHARGE_AMOUNT")%>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvChargeAmountEdit" ControlToValidate="txtChargeAmountEdit"
                                        Display="None" Text="*" ValidationGroup="b" runat="server" ErrorMessage="Charge Amount is required."></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rexpvChargeAmountEdit" runat="server" ControlToValidate="txtChargeAmountEdit"
                                        ErrorMessage="The value specified as 'Charge Amount' is not valid." Text="*"
                                        Display="None" ValidationExpression="^\d{1,12}(\.\d{0,4})?$" ValidationGroup="b">
                                    </asp:RegularExpressionValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label Width="100px" ID="lblChargeAmount" runat="server" Text='<%# Bind("CHARGE_AMOUNT")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox Width="100px" ID="txtChargeAmount" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        MaxLength="17" runat="server" Text=""></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvChargeAmountEmpty" ControlToValidate="txtChargeAmount"
                                        Display="None" Text="*" ValidationGroup="b" runat="server" ErrorMessage="Charge Amount is required."></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rexpvChargeAmountEmpty" runat="server" ControlToValidate="txtChargeAmount"
                                        ErrorMessage="The value specified as 'Charge Amount' is not valid." Text="*"
                                        Display="None" ValidationExpression="^\d{1,12}(\.\d{0,4})?$" ValidationGroup="b">
                                    </asp:RegularExpressionValidator>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Percentage">
                                <EditItemTemplate>
                                    <asp:CheckBox Width="80px" ID="chkPercentageEdit" runat="server" Checked='<%#  Eval("ISPERCENTAGE") %>'>
                                    </asp:CheckBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label Width="80px" ID="lblPercentage" runat="server" Text='<%# Bind("ISPERCENTAGE")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox Width="80px" ID="chkPercentage" runat="server" Text=""></asp:CheckBox>
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
                            <table id="gvChargeInformation">
                                <tr>
                                    <th align="left" scope="col">
                                        Amount From
                                    </th>
                                    <th align="left" scope="col">
                                        Amount To
                                    </th>
                                    <th align="left" scope="col">
                                        Charge Amount
                                    </th>
                                    <th align="right" scope="col">
                                        Percentage
                                    </th>
                                    <th align="right" scope="col">
                                        Add
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        No Records found...
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtAmountFrom" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            runat="server" Text="" Width="100px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvAmountFrom" ControlToValidate="txtAmountFrom"
                                            Display="None" Text="*" ValidationGroup="b" runat="server" ErrorMessage="Amount From is required."></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAmountFrom"
                                            ErrorMessage="The value specified as 'Amount From' is not valid." Text="*" Display="None"
                                            ValidationExpression="^\d{1,13}(\.\d{0,4})?$" ValidationGroup="b">
                                        </asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAmountTo" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            runat="server" Text="" Width="100px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvAmountTo" ControlToValidate="txtAmountTo" Display="None"
                                            Text="*" ValidationGroup="b" runat="server" ErrorMessage="Amount To is required."></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAmountTo"
                                            ErrorMessage="The value specified as 'Amount To' is not valid." Text="*" Display="None"
                                            ValidationExpression="^\d{1,13}(\.\d{0,4})?$" ValidationGroup="b">
                                        </asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtChargeAmount" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            runat="server" Text="" Width="100px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvChargeAmount" ControlToValidate="txtChargeAmount"
                                            Display="None" Text="*" ValidationGroup="b" runat="server" ErrorMessage="Charge Amount is required."></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtChargeAmount"
                                            ErrorMessage="The value specified as 'Charge Amount' is not valid." Text="*"
                                            Display="None" ValidationExpression="^\d{1,13}(\.\d{0,4})?$" ValidationGroup="b">
                                        </asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPercentage" runat="server" Text="" Width="80px"></asp:CheckBox>
                                    </td>
                                    <td colspan="2" valign="middle">
                                        <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="true" CommandName="emptyInsert"
                                            Text="emptyInsert"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnID" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdnIsSlab" runat="server"></asp:HiddenField>
</asp:Content>
