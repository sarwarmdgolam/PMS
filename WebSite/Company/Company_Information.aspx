<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="Company_Information.aspx.cs" Inherits="Company_Company_Information"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table style="width: 100%">
        <tr>
            <td>
                Company Name<span class="asterisk">*</span></td>
            <td>
                <asp:TextBox ID="txt_Company_Name" runat="server" SkinID="txt250"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxt_Company_Name" runat="server" ErrorMessage="Input Company Name."
                    ControlToValidate="txt_Company_Name" ValidationGroup="insert" SetFocusOnError="true"
                    ForeColor="red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                Security Code<span class="asterisk">*</span></td>
            <td>
                <asp:TextBox ID="txt_Security_Code" runat="server" SkinID="txt100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxt_Security_Code" runat="server" ErrorMessage="Input Security Code."
                    ControlToValidate="txt_Security_Code" ValidationGroup="insert" SetFocusOnError="true"
                    ForeColor="red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                ISIN<span class="asterisk">*</span></td>
            <td>
                <asp:TextBox ID="txt_ISIN" runat="server" SkinID="txt100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxt_ISIN" runat="server" ErrorMessage="Input ISIN."
                    ControlToValidate="txt_ISIN" ValidationGroup="insert" SetFocusOnError="true"
                    ForeColor="red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                Market Closing Price</td>
            <td>
                <asp:TextBox ID="txt_Closing_Price" runat="server" SkinID="txt100"></asp:TextBox>
                <asp:RegularExpressionValidator ID="retxt_Closing_Price" runat="server" ControlToValidate="txt_Closing_Price"
                    ErrorMessage="Input Valid Market Closing Price." Text="*" Display="None"
                    ValidationExpression="^\d{1,15}(\.\d{0,2})?$">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Authorize Capital</td>
            <td>
                <asp:TextBox ID="txtAuthorizeCapital" runat="server" MaxLength="20" SkinID="txt100"></asp:TextBox>
                <asp:RegularExpressionValidator ID="rfvtxtAuthorizeCapital" runat="server" ControlToValidate="txtAuthorizeCapital"
                   ErrorMessage="Input Valid  Authorize Capital." Text="*" Display="None"
                    ValidationExpression="^\d{1,15}(\.\d{0,2})?$">
                </asp:RegularExpressionValidator>
            </td>
            <td>
                Paid-Up Capital</td>
            <td>
                <asp:TextBox ID="txtPaidUPCapital" runat="server" MaxLength="20" Text="" SkinID="txt100"></asp:TextBox>
                <asp:RegularExpressionValidator ID="rfvtxtPaidUPCapital" runat="server" ControlToValidate="txtPaidUPCapital"
                     ErrorMessage="Input Valid Paid-Up Capital." Text="*" Display="None"
                    ValidationExpression="^\d{1,15}(\.\d{0,2})?$">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Reserve Capital</td>
            <td>
                <asp:TextBox ID="txtReserveCapital" runat="server" MaxLength="20" Text="" SkinID="txt100"></asp:TextBox>
                <asp:RegularExpressionValidator ID="rfvtxtReserveCapital" runat="server" ControlToValidate="txtReserveCapital"
                    ErrorMessage="Input Valid Reserve Capital." Text="*" Display="None"
                    ValidationExpression="^\d{1,15}(\.\d{0,2})?$">
                </asp:RegularExpressionValidator>
            </td>
            <td>
                Instrument Type<span class="asterisk">*</span></td>
            <td>
                <asp:DropDownList ID="ddlInstrumentType" runat="server" SkinID="ddl100">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Face Value<span class="asterisk">*</span></td>
            <td>
                <asp:TextBox ID="txtFaceValue" runat="server" MaxLength="16" Text="" SkinID="txt100"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Input Face Value."
                    ControlToValidate="txtFaceValue" ValidationGroup="insert" SetFocusOnError="true"
                    ForeColor="red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFaceValue"
                     ErrorMessage="Input Valid Face Value." Text="*" Display="None"
                    ValidationExpression="^\d{1,12}(\.\d{0,2})?$">
                </asp:RegularExpressionValidator>
            </td>
            <td>
                Category<span class="asterisk">*</span></td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server" SkinID="ddl100">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlCategory" runat="server" ErrorMessage="Select Category."
                    InitialValue="0" ControlToValidate="ddlCategory" ValidationGroup="insert" SetFocusOnError="true"
                    ForeColor="red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                EPS</td>
            <td>
                <asp:TextBox ID="txtEPS" runat="server" MaxLength="18" Text="" SkinID="txt100"></asp:TextBox>
                <asp:RegularExpressionValidator ID="retxtEPS" runat="server" ControlToValidate="txtEPS"
                     ErrorMessage="Input Valid EPS." Text="*" Display="None"
                    ValidationExpression="^\d{1,15}(\.\d{0,2})?$"> 
                </asp:RegularExpressionValidator>
            </td>
            <td>
                NAV</td>
            <td>
                <asp:TextBox ID="txtNAV" runat="server" MaxLength="18" Text="" SkinID="txt100"></asp:TextBox>
                <asp:RegularExpressionValidator ID="retxtNAV" runat="server" ControlToValidate="txtNAV"
                    ErrorMessage="Input Valid NAV." Text="*" Display="None"
                    ValidationExpression="^\d{1,15}(\.\d{0,2})?$">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Sector Type</td>
            <td>
                <asp:DropDownList ID="ddlInstrumentSector" runat="server" SkinID="ddl100">
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Is Active</td>
            <td colspan="3">
                <asp:CheckBox ID="chkIsActive" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Is OTC</td>
            <td colspan="3">
                <asp:CheckBox ID="chkIsOTC" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Is Marginable</td>
            <td colspan="3">
                <asp:CheckBox ID="chkMarginable" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <asp:HiddenField ID="hdn_ID" runat="server"></asp:HiddenField>
                <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="insert"
                    CausesValidation="true" />
            </td>
            <td>
                <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click"
                    ValidationGroup="insert" CausesValidation="true" />
            </td>
            <td>
                <asp:Button ID="btn_Clear" runat="server" Text="Refresh" OnClick="btn_Clear_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
