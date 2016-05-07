<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="PreviewAccountInformation.aspx.cs" Inherits="Investor_PreviewAccountInformation"
    Title="Untitled Page" %>

<%@ Register Src="~/UserControls/SearchInvestor.ascx" TagName="SearchInvestor" TagPrefix="SI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table id="Table3" width="100%" runat="server" cellpadding="0" border="0" cellspacing="5">
        <tr>
            <td>
                <SI:SearchInvestor runat="server" ID="txtSearchInvestor" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btn_Preview" runat="server" Text="Preview" OnClick="btn_Preview_Click" />
            </td>
        </tr>
    </table>
    <fieldset id="fieldset2" runat="server">
        <div style="width: 100%; background-color: #99CCCC;">
            <span style="font-size: large; font-weight: bold">Corporate Particulars</span>
        </div>
        <table id="Table1" width="100%" runat="server" cellpadding="0" border="0" cellspacing="5">
            <tr>
                <td style="width: 40%; text-align: right">
                    <span>Investor Code</span><span class="asterisk">*</span>
                </td>
                <td style="width: 60%; text-align: left;">
                    <asp:TextBox ID="txt_INVESTOR_CODE" runat="server" SkinID="txt100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxt_INVESTOR_CODE" runat="server" ErrorMessage="Investor Code!"
                        ControlToValidate="txt_INVESTOR_CODE" ValidationGroup="insert" SetFocusOnError="true"
                        ForeColor="red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <span>Account Type</span><span class="asterisk">*</span>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddl_ACC_TYPE_ID" runat="server" SkinID="ddl100" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddl_ACC_TYPE_ID" runat="server" ValidationGroup="insert"
                        ControlToValidate="ddl_ACC_TYPE_ID" ErrorMessage="Account Type!" InitialValue="0"
                        SetFocusOnError="true" ForeColor="red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <span>Name</span><span class="asterisk">*</span>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtCorporateName" runat="server" SkinID="txt250"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Corporate Name!"
                        ControlToValidate="txtCorporateName" ValidationGroup="insert" SetFocusOnError="true"
                        ForeColor="red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <span>Nature of Business</span><span class="asterisk">*</span>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlBusinessNature" runat="server" SkinID="ddl100">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="insert"
                        ControlToValidate="ddlBusinessNature" ErrorMessage="Nature of Business!" InitialValue="0"
                        SetFocusOnError="true" ForeColor="red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <span>Business/Office Address</span>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtCorporatedOfficeAddress" runat="server" SkinID="skMultilineTextBox"
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <span>Name of Managing Director/CEO</span><span class="asterisk">*</span>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtCompanyMDName" runat="server" Width="200px" SkinID="txt100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table id="Table4" width="100%" runat="server" cellpadding="0" border="0" cellspacing="5">
                        <tr>
                            <td>
                                <span>Phone(Off.)</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCorporatePhoneOffice" runat="server" SkinID="txt100"></asp:TextBox>
                            </td>
                            <td>
                                <span>Phone(Cell)</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCorporatePhoneCell" runat="server" SkinID="txt100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>FAX No</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCorporateFaxNo" runat="server" SkinID="txt100"></asp:TextBox>
                            </td>
                            <td>
                                <span>Email </span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCorporateEmail" runat="server" SkinID="txt100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Trade License No </span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTradeLicenseNo" runat="server" SkinID="txt100"></asp:TextBox>
                            </td>
                            <td>
                                <span>TIN No#</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTINNo" runat="server" SkinID="txt100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Date of Incorporation</span>
                            </td>
                            <td style="width: 229px">
                                <asp:TextBox ID="txtIncorporationDate" runat="server" SkinID="txt100"></asp:TextBox>
                                <img id="imgIncorporationDate" src="../Images/Calendar.gif" />
                            </td>
                            <td>
                                <span>Registration No#</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRegistrationNo" runat="server" SkinID="txt100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Opening Date</span>
                            </td>
                            <td style="width: 229px">
                                <asp:TextBox ID="txtCorporateOpeningDate" runat="server" Enabled="false" SkinID="txt100"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div id="divAdvisoryAccount" runat="server">
                        <table id="Table2" width="100%" runat="server" style="margin: 5px 5px 5px 5px;" cellpadding="0"
                            border="0" cellspacing="5">
                            <tr>
                                <td style="width: 40%">
                                    <span>Name of Existing BO Account</span><span class="asterisk">*</span>
                                </td>
                                <td style="width: 60%">
                                    <asp:TextBox ID="txtExistingBOAcc" runat="server" SkinID="txt250"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Existing BO Code</span><span class="asterisk">*</span>
                                </td>
                                <td style="width: 229px">
                                    <asp:TextBox ID="txtExistingBOCode" runat="server" SkinID="txt100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Name of Depository Participant(DP)</span><span class="asterisk">*</span>
                                </td>
                                <td style="width: 229px">
                                    <asp:TextBox ID="txtExistingBOAccDP" runat="server" SkinID="txt100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Name of Broker</span><span class="asterisk">*</span>
                                </td>
                                <td style="width: 229px">
                                    <asp:TextBox ID="txtExistingBOBroker" runat="server" SkinID="txt100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Account Status</span>
                                </td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddl_ACCOUNT_STATUS_ID" runat="server" SkinID="ddl100">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset id="fieldset3" runat="server">
        <div style="width: 100%; background-color: #99CCCC;">
            <span style="font-size: large; font-weight: bold">Bank Information</span>
        </div>
        <table class="tb-tablecenter">
            <tr>
                <td class="td-twocolumnleftsideright">
                    <span>Bank</span>
                </td>
                <td class="td-twocolumnrightsideleft">
                    <asp:DropDownList ID="ddlBank" runat="server" SkinID="ddl100" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="td-twocolumnleftsideright">
                    <span>Bank Branch</span>
                </td>
                <td class="td-twocolumnrightsideleft">
                    <asp:DropDownList ID="ddlBankBranch" runat="server" SkinID="ddl100">
                        <asp:ListItem>N/A</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="td-twocolumnleftsideright">
                    <span>Bank Account Type</span>
                </td>
                <td class="td-twocolumnrightsideleft">
                    <asp:DropDownList ID="ddl_BANK_ACC_TP_ID" runat="server" SkinID="ddl100">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="td-twocolumnleftsideright">
                    <span>Account No#</span>
                </td>
                <td class="td-twocolumnrightsideleft">
                    <asp:TextBox ID="txt_BANK_ACC_NO" runat="server" SkinID="txt100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="td-twocolumnleftsideright">
                    <span>Routing No#</span>
                </td>
                <td class="td-twocolumnrightsideleft">
                    <asp:TextBox ID="txtRoutingNo" runat="server" SkinID="txt100"></asp:TextBox>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset id="fieldset4" runat="server">
        <div style="width: 100%; background-color: #99CCCC;">
            <span style="font-size: large; font-weight: bold">Particulars of Introducer</span>
        </div>
        <table class="tb-tablecenter">
            <tr>
                <td class="td-twocolumnleftsideright">
                    <span>Introducer Code </span>
                </td>
                <td class="td-twocolumnrightsideleft">
                    <asp:TextBox ID="txt_INTRODUCER_CODE" runat="server" SkinID="txt100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="td-twocolumnleftsideright">
                    <span>Introducer Name </span>
                </td>
                <td class="td-twocolumnrightsideleft">
                    <asp:TextBox ID="txt_INTRODUCER_NAME" runat="server" SkinID="txt100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="td-twocolumnleftsideright">
                    <span>Introducer Contact No# </span>
                </td>
                <td class="td-twocolumnrightsideleft">
                    <asp:TextBox ID="txt_INTRODUCER_CONTACT_NO" runat="server" SkinID="txt100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="td-twocolumnleftsideright">
                    <span>Special Instruction </span>
                </td>
                <td class="td-twocolumnrightsideleft">
                    <asp:TextBox ID="txt_SPECIAL_INSTRUCTION" runat="server" SkinID="txt100"></asp:TextBox>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
