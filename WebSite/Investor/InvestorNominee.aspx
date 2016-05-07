<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="InvestorNominee.aspx.cs" Inherits="Investor_InvestorNominee" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <asp:HiddenField ID="hdn_ID" runat="server" />
    <asp:HiddenField ID="hdnInvestor_ID" runat="server" />
    <table width="100%">
        <tr>
            <td style="width: 151px">
                Investor Code <span class="asterisk">*</span>
            </td>
            <td>
                <asp:TextBox ID="txt_investor_code" runat="server" MaxLength="15" SkinID="txt100"></asp:TextBox>&nbsp;
                <asp:Button ID="btnInvestorCodeSearch" runat="server" Text="..." 
                    OnClick="btnInvestorCodeSearch_Click"  CausesValidation="false" />
                <asp:RequiredFieldValidator ID="rfvInvestorAccountId" ControlToValidate="txt_investor_code"
                    runat="server" ErrorMessage="Please provide value for Investor Code." Text="*"
                    Display="None" ValidationGroup="insert" />
            </td>
        </tr>
        <tr>
            <td style="width: 151px">
                Investor Name
            </td>
            <td>
                <asp:TextBox ID="txt_investor_name" runat="server" Enabled="False" ReadOnly="True"
                    SkinID="txt250"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 26px; width: 152px;">
                Nominee Name:</td>
            <td style="height: 26px; width: 451px;">
                <asp:TextBox ID="txt_nominee_name" runat="server" SkinID="txt250"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_nominee_name"
                    runat="server" ErrorMessage="Please provide value for Investor Nominee." Text="*"
                    Display="None" ValidationGroup="insert" />
            </td>
        </tr>
        <tr>
            <td style="height: 26px; width: 152px;">
                Address:</td>
            <td style="height: 26px; width: 451px;">
                <asp:TextBox ID="txt_present_addresss" runat="server" SkinID="skMultilineTextBox" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="height: 26px; width: 152px;">
                Phone:</td>
            <td style="height: 26px; width: 451px;">
                <asp:TextBox ID="txt_Phone" runat="server" SkinID="txt250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 26px; width: 152px;">
                Relation:</td>
            <td style="height: 26px; width: 451px;">
                <asp:TextBox ID="txt_Relation" runat="server" SkinID="txt250"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_Relation"
                    runat="server" ErrorMessage="Please provide value for Relation." Text="*"
                    Display="None" ValidationGroup="insert" />
            </td>
        </tr>
        <tr>
            <td style="width: 152px; height: 26px">
                Share Percent (%) :</td>
            <td style="width: 451px; height: 26px">
                <asp:TextBox ID="txt_share_percent" Text="0.00" onkeypress="return blockNonNumbers(this, event, true, false);"
                    runat="server" SkinID="txt100"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_share_percent"
                    ErrorMessage="The value specified for Nominee (1) Share Percent is not valid."
                    Text="*" Display="None" ValidationExpression="^\d{1,3}(\.\d{0,2})?$" ValidationGroup="insert"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <fieldset>
                    <legend>Picture:</legend>
                    <asp:Image ID="img_picture" runat="server" Height="140px" />
                    <asp:FileUpload ID="file_n1_picture" runat="server" Width="230px" />
                    <asp:Button ID="btnUploadN1Picture" runat="server" Text="Upload" CausesValidation="false"
                        OnClick="btnUploadN1Picture_Click" CssClass="form_button ui-corner-all" />
                </fieldset>
            </td>
            <td>
                <fieldset>
                    <legend>Signature:</legend>
                    <asp:Image ID="img_signature" runat="server" Width="249px" Height="54px" />
                    <asp:FileUpload ID="file_n1_signature" runat="server" Width="230px" />
                    <asp:Button ID="btnUploadN1Signature" runat="server" Text="Upload" CausesValidation="false"
                        OnClick="btnUploadN1Signature_Click" CssClass="form_button ui-corner-all" />
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <span id="ctl00_contPlcHdrMasterHolder_MaxImageSize">Max size is 40KB.</span>
                <br />
                <span id="ctl00_contPlcHdrMasterHolder_hwOfImage">Max height and width is 300 X 300</span>
            </td>
        </tr>
    </table>
    <br />
    <div style="width: 100%;">
        <table>
            <tr>
                <td>
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
</asp:Content>
