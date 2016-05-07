<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="CustomerAccountOpenAdvisory.aspx.cs" Inherits="Investor_CustomerAccountOpenAdvisory"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table>
        <tr>
            <td>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:Button ID="btn_Save2" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="insert"
                    CausesValidation="true" />
            </td>
            <td>
                <asp:Button ID="btn_Update2" runat="server" Text="Update" ValidationGroup="insert"
                    OnClick="btn_Update_Click" CausesValidation="true" />
            </td>
            <td>
                <asp:Button ID="btn_Clear2" runat="server" Text="Refresh" OnClick="btn_Clear_Click" />
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
                    <asp:DropDownList ID="ddl_ACC_TYPE_ID" runat="server" SkinID="ddl100" AutoPostBack="true"
                        OnSelectedIndexChanged="ddl_ACC_TYPE_ID_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddl_ACC_TYPE_ID" runat="server" ValidationGroup="insert"
                        ControlToValidate="ddl_ACC_TYPE_ID" ErrorMessage="Account Type!" InitialValue="0"
                        SetFocusOnError="true" ForeColor="red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                 <td style="text-align: right">
                    <span>Sub Account </span>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddl_SUB_ACCOUNT_ID" runat="server" SkinID="ddl100">
                    </asp:DropDownList>
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
                    <asp:DropDownList ID="ddlBank" runat="server" SkinID="ddl100" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
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
    <fieldset id="fieldset1" runat="server">
        <div style="width: 100%; background-color: #99CCCC;">
            <span style="font-size: large; font-weight: bold">Authorized Signatory</span>
        </div>
        <div style="overflow: auto; width: 100%; height: 300px;">
            <table border="1">
                <thead style="background-color: ThreeDShadow; font-weight: bold;">
                    <tr>
                        <th>
                            Sl No
                        </th>
                        <th>
                            Name
                        </th>
                        <th>
                            Designation</th>
                        <th>
                            Phone</th>
                        <th>
                            Email</th>
                        <th>
                            Signature</th>
                    </tr>
                </thead>
                <tr id="tr1">
                    <td>
                        1</td>
                    <td>
                        <asp:TextBox ID="txtName1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDesignation1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Image ID="ImageSignature1" runat="server" Width="200px" Height="54px" />
                        <asp:FileUpload ID="FileUploadSignature1" runat="server" />
                        <asp:Button ID="btnImageSignature1" runat="server" Text="Upload" CausesValidation="false"
                            OnClick="btnUploadImageSignature_Click" />
                    </td>
                </tr>
                <tr id="tr2">
                    <td>
                        2</td>
                    <td>
                        <asp:TextBox ID="txtName2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDesignation2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Image ID="ImageSignature2" runat="server" Width="200px" Height="54px" />
                        <asp:FileUpload ID="FileUploadSignature2" runat="server" />
                        <asp:Button ID="btnImageSignature2" runat="server" Text="Upload" CausesValidation="false"
                            OnClick="btnUploadImageSignature_Click" />
                    </td>
                </tr>
                <tr id="tr3">
                    <td>
                        3</td>
                    <td>
                        <asp:TextBox ID="txtName3" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDesignation3" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone3" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail3" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Image ID="ImageSignature3" runat="server" Width="200px" Height="54px" />
                        <asp:FileUpload ID="FileUploadSignature3" runat="server" />
                        <asp:Button ID="btnImageSignature3" runat="server" Text="Upload" CausesValidation="false"
                            OnClick="btnUploadImageSignature_Click" />
                    </td>
                </tr>
                <tr id="tr4">
                    <td>
                        4</td>
                    <td>
                        <asp:TextBox ID="txtName4" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDesignation4" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone4" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail4" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Image ID="ImageSignature4" runat="server" Width="200px" Height="54px" />
                        <asp:FileUpload ID="FileUploadSignature4" runat="server" />
                        <asp:Button ID="btnImageSignature4" runat="server" Text="Upload" CausesValidation="false"
                            OnClick="btnUploadImageSignature_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <table>
            <tr>
                <td>
                    <asp:Image ID="ImagePhoto1" runat="server" Width="150px" Height="122px" />
                    <asp:FileUpload ID="FileUploadPhoto1" runat="server" />
                    <asp:Button ID="btnImagePhoto1" runat="server" Text="Upload" CausesValidation="false"
                        OnClick="btnUploadImagePhoto_Click" />
                </td>
                <td>
                    <asp:Image ID="ImagePhoto2" runat="server" Width="150px" Height="122px" />
                    <asp:FileUpload ID="FileUploadPhoto2" runat="server" />
                    <asp:Button ID="btnImagePhoto2" runat="server" Text="Upload" CausesValidation="false"
                        OnClick="btnUploadImagePhoto_Click" />
                </td>
                <td>
                    <asp:Image ID="ImagePhoto3" runat="server" Width="150px" Height="122px" />
                    <asp:FileUpload ID="FileUploadPhoto3" runat="server" />
                    <asp:Button ID="btnImagePhoto3" runat="server" Text="Upload" CausesValidation="false"
                        OnClick="btnUploadImagePhoto_Click" />
                </td>
                <td>
                    <asp:Image ID="ImagePhoto4" runat="server" Width="150px" Height="122px" />
                    <asp:FileUpload ID="FileUploadPhoto4" runat="server" />
                    <asp:Button ID="btnImagePhoto4" runat="server" Text="Upload" CausesValidation="false"
                        OnClick="btnUploadImagePhoto_Click" />
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
    <table>
        <tr>
            <td>
                <asp:HiddenField ID="hdn_ID" runat="server" />
                <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="insert"
                    CausesValidation="true" />
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

    <script type="text/javascript">

    Calendar.setup
        ({
            inputField  : "ctl00_Main_txtIncorporationDate",
            ifFormat    : "dd-M-y",
            button      : "imgIncorporationDate",
            weekNumbers : false
        });

        
    </script>

</asp:Content>
