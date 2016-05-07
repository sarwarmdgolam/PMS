<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="CustomerAccountOpenDiscritionary.aspx.cs" Inherits="Investor_CustomerAccountOpenDiscritionary"
    Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div style="width: 100%;">
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
    </div>
    <div style="width: 100%;">
        <table style="width: 100%;">
            <tr>
                <td style="vertical-align: top;">
                    <div style="width: 100%">
                        <fieldset>
                            <h3>
                                BO Information
                            </h3>
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 40%;">
                                        <span>Investor Code</span><span class="asterisk">*</span>
                                    </td>
                                    <td style="width: 60%;">
                                        <asp:TextBox ID="txt_INVESTOR_CODE" runat="server" SkinID="txt100"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxt_INVESTOR_CODE" runat="server" ErrorMessage="Investor Code!"
                                            ControlToValidate="txt_INVESTOR_CODE" ValidationGroup="insert" SetFocusOnError="true"
                                            ForeColor="red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>BO Code</span>
                                    </td>
                                    <td style="width: 229px">
                                        <asp:TextBox ID="txt_BO_CODE" runat="server" SkinID="txt100"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>First Join Holder Name</span><span class="asterisk">*</span>
                                    </td>
                                    <td style="width: 229px">
                                        <asp:TextBox ID="txt_FIRST_JOIN_HOLDER_NAME" runat="server" Width="200px" SkinID="txt100"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxt_FIRST_JOIN_HOLDER_NAME" runat="server" ErrorMessage="First Join Holder Name!"
                                            ControlToValidate="txt_FIRST_JOIN_HOLDER_NAME" ValidationGroup="insert" SetFocusOnError="true"
                                            ForeColor="red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Second Join Holder Name</span>
                                    </td>
                                    <td style="width: 229px">
                                        <asp:TextBox ID="txt_SEC_JOIN_HOLDER_NAME" runat="server" Width="200px" SkinID="txt100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Father Name</span>
                                    </td>
                                    <td style="width: 229px">
                                        <asp:TextBox ID="txt_FATHER_NAME" runat="server" SkinID="txt100"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Mother Name</span>
                                    </td>
                                    <td style="width: 229px">
                                        <asp:TextBox ID="txt_MOTHER_NAME" runat="server" SkinID="txt100"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Operate Branch</span><span class="asterisk">*</span>
                                    </td>
                                    <td style="width: 229px">
                                        <asp:DropDownList ID="ddl_BRANCH_ID" runat="server" SkinID="ddl100">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvddl_BRANCH_ID" runat="server" ValidationGroup="insert"
                                            ControlToValidate="ddl_BRANCH_ID" ErrorMessage="Branch " InitialValue="0" SetFocusOnError="true"
                                            ForeColor="red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Operation Type</span><span class="asterisk">*</span>
                                    </td>
                                    <td style="width: 229px">
                                        <asp:DropDownList ID="ddl_OPERATION_TYPE_ID" runat="server" SkinID="ddl100">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvddl_OPERATION_TYPE_ID" runat="server" ValidationGroup="insert"
                                            ControlToValidate="ddl_OPERATION_TYPE_ID" ErrorMessage="Operation Type!" InitialValue="0"
                                            SetFocusOnError="true" ForeColor="red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Investor Type</span><span class="asterisk">*</span>
                                    </td>
                                    <td style="width: 229px">
                                        <asp:DropDownList ID="ddl_INVESTOR_TYPE_ID" runat="server" SkinID="ddl100">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvddl_INVESTOR_TYPE_ID" runat="server" ValidationGroup="insert"
                                            ControlToValidate="ddl_INVESTOR_TYPE_ID" ErrorMessage="Investor Type!" InitialValue="0"
                                            SetFocusOnError="true" ForeColor="red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Account Type</span><span class="asterisk">*</span>
                                    </td>
                                    <td style="width: 229px">
                                        <asp:DropDownList ID="ddl_ACC_TYPE_ID" runat="server" SkinID="ddl100">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvddl_ACC_TYPE_ID" runat="server" ValidationGroup="insert"
                                            ControlToValidate="ddl_ACC_TYPE_ID" ErrorMessage="Account Type!" InitialValue="0"
                                            SetFocusOnError="true" ForeColor="red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Parent Code</span>
                                    </td>
                                    <td style="width: 229px">
                                        <asp:DropDownList ID="ddl_PARENT_ID" runat="server" SkinID="ddl100">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Sub Account </span>
                                    </td>
                                    <td style="width: 229px">
                                        <asp:DropDownList ID="ddl_SUB_ACCOUNT_ID" runat="server" SkinID="ddl100">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Gender </span>
                                    </td>
                                    <td style="width: 229px">
                                        <asp:DropDownList ID="ddl_GENDER" runat="server" SkinID="ddl100">
                                            <asp:ListItem Selected="True" Value="M">Male</asp:ListItem>
                                            <asp:ListItem Value="F">FeMale</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Opening Date</span>
                                    </td>
                                    <td style="width: 229px">
                                        <asp:TextBox ID="txt_OPENING_DT" runat="server" Enabled="false" SkinID="txt100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Date Of Birth</span>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="height: 24px">
                                                    <asp:TextBox ID="txt_BIRTH_DT" runat="server" SkinID="txt100"></asp:TextBox>
                                                </td>
                                                <td style="width: 111px; height: 24px;">
                                                    <img id="imgtxt_BIRTH_DT" src="../Images/Calendar.gif" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Account Status</span>
                                    </td>
                                    <td style="width: 229px">
                                        <asp:DropDownList ID="ddl_ACCOUNT_STATUS_ID" runat="server" SkinID="ddl100">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </div>
                    <div style="width: 100%;">
                        <fieldset>
                            <div style="float: left;">
                                <h3>
                                    Contact Information
                                </h3>
                            </div>
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 40%;">
                                        <span>Present Address</span>
                                    </td>
                                    <td style="width: 60%">
                                        <asp:TextBox ID="txt_PRESENT_ADDRESS" runat="server" SkinID="txt100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Parmanent Address</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_PARMANENT_ADDRESS" runat="server" SkinID="txt100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Phone No</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_PHONE" runat="server" SkinID="txt100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Mobile No</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_MOBILE" runat="server" SkinID="txt100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>FAX No</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_FAX" runat="server" SkinID="txt100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Email </span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_EMAIL" runat="server" SkinID="txt100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Division/State</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_DISTRICT_ID" runat="server" SkinID="ddl100">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Country</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_COUNTRY_ID" runat="server" SkinID="ddl100">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </div>
                </td>
                <td style="vertical-align: top; width: 30%;">
                    <table width="100%">
                        <tr>
                            <td style="height: 15px">
                                <strong>Picture (1st Joint Holder):</strong></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Image ID="imgFJH" runat="server" Width="150px" Height="122px" />
                                <asp:FileUpload ID="fuFJHpicture" runat="server" />
                                <asp:Button ID="btnUploadFJHPicture" runat="server" Text="Upload" CausesValidation="false"
                                    OnClick="btnUploadFJHPicture_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>Signature (1st Joint Holder):</strong></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Image ID="imgSignatureFJH" runat="server" Width="249px" Height="54px" />
                                <asp:FileUpload ID="fuFJHSignature" runat="server" />
                                <asp:Button ID="btnUploadFJHSignature" runat="server" Text="Upload" CausesValidation="false"
                                    OnClick="btnUploadFJHSignature_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>
                                    <br />
                                    Picture (2nd Joint Holder):</strong></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Image ID="imgSJH" runat="server" Width="150px" Height="122px" />
                                <asp:FileUpload ID="fuSJHpicture" runat="server" />
                                <asp:Button ID="btnUploadSJHPicture" runat="server" Text="Upload" CausesValidation="false"
                                    OnClick="btnUploadSJHPicture_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>Signature (2nd Joint Holder):</strong></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Image ID="imgSignatureSJH" runat="server" Width="249px" Height="54px" />
                                <asp:FileUpload ID="fuSJHSignature" runat="server" />
                                <asp:Button ID="btnUploadSJHSignature" runat="server" Text="Upload" CausesValidation="false"
                                    OnClick="btnUploadSJHSignature_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span id="ctl00_contPlcHdrMasterHolder_MaxImageSize">Max size is 40KB.
                                    <br />
                                    <span id="ctl00_contPlcHdrMasterHolder_hwOfImage">Max height and width is 300 X 300</span>
                                </span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td style="vertical-align: top">
                    <div style="width: 100%;">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="2">
                                    <div style="float: left;">
                                        <h3>
                                            Bank Information
                                        </h3>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 40%;">
                                    <span>Bank</span>
                                </td>
                                <td style="width: 60%;">
                                    <asp:DropDownList ID="ddl_BANK_ID" runat="server" SkinID="ddl100">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Bank Branch</span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_BANK_BRANCH_ID" runat="server" SkinID="ddl100">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Bank Account Type</span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_BANK_ACC_TP_ID" runat="server" SkinID="ddl100">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Account No#</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_BANK_ACC_NO" runat="server" SkinID="txt100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Routing No#</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRoutingNo" runat="server" SkinID="txt100"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="vertical-align: top">
                    <div style="width: 100%;">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="2">
                                    <div style="float: left;">
                                        <h3>
                                            Introducer Information
                                        </h3>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 40%;">
                                    <span>Introducer Code </span>
                                </td>
                                <td style="width: 60%;">
                                    <asp:TextBox ID="txt_INTRODUCER_CODE" runat="server" SkinID="txt100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Introducer Name </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_INTRODUCER_NAME" runat="server" SkinID="txt100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Introducer Contact No# </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_INTRODUCER_CONTACT_NO" runat="server" SkinID="txt100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Special Instruction </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_SPECIAL_INSTRUCTION" runat="server" SkinID="txt100"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <div style="width: 100%;">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="2">
                                    <div style="float: left;">
                                        <h3>
                                            Other Information
                                        </h3>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 40%;">
                                    <span>Voter ID NO# </span>
                                </td>
                                <td style="width: 60%;">
                                    <asp:TextBox ID="txt_VOTER_ID_NO" runat="server" SkinID="txt100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Occupation</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Occupation" runat="server" SkinID="txt100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Passport No#</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_PASSPORT_NO" runat="server" SkinID="txt100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>TIN No#</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_TIN_NO" runat="server" SkinID="txt100"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="vertical-align: top">
                    <div style="width: 100%;">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="2">
                                    <div style="float: left;">
                                        <h3>
                                            Accounts Settings
                                        </h3>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 40%;">
                                    <span>Trader</span>
                                </td>
                                <td style="width: 60%;">
                                    <asp:DropDownList ID="ddl_TRADER_ID" runat="server" SkinID="ddl100">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Interest Calculation ON</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_INTEREST_CAL_ON" runat="server" SkinID="txt100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Is PayIN</span>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_IS_PAYIN" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Is PayOUT</span>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_IS_PAYOUT" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Is Email Service </span>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_Is_Email_service" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Is SMS Service</span>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_Is_SMS_service" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Margin Loan Ratio </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_LOAN_RATIO" runat="server">0.00</asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div style="width: 100%;">
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
    </div>

    <script type="text/javascript">

    Calendar.setup
        ({
            inputField  : "ctl00_Main_txt_BIRTH_DT",
            ifFormat    : "dd-M-y",
            button      : "imgtxt_BIRTH_DT",
            weekNumbers : false
        });

    </script>

</asp:Content>
