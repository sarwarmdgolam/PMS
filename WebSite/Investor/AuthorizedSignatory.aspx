<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true" CodeFile="AuthorizedSignatory.aspx.cs" Inherits="Investor_AuthorizedSignatory" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
 <asp:HiddenField ID="hdn_ID" runat="server" />
    <asp:HiddenField ID="hdnInvestor_ID" runat="server" Value="0" />
    <asp:HiddenField ID="hdnID" runat="server" Value="0" />
     <div style="width: 100%;">
        <table>
            <tr>
                <td>
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
                Name:</td>
            <td style="height: 26px; width: 451px;">
                <asp:TextBox ID="txt_name" runat="server" SkinID="txt250"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_name"
                    runat="server" ErrorMessage="Please provide value for name." Text="*"
                    Display="None" ValidationGroup="insert" />
            </td>
        </tr>
        <tr>
            <td style="height: 26px; width: 152px;">
                Designation:</td>
            <td style="height: 26px; width: 451px;">
                <asp:TextBox ID="txt_Designation" runat="server" SkinID="txt250" ></asp:TextBox>
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
                Email:</td>
            <td style="height: 26px; width: 451px;">
                <asp:TextBox ID="txt_Email" runat="server" SkinID="txt250"></asp:TextBox>
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
                        OnClick="btnUploadN1Picture_Click"  />
                </fieldset>
            </td>
            <td>
                <fieldset>
                    <legend>Signature:</legend>
                    <asp:Image ID="img_signature" runat="server" Width="249px" Height="54px" />
                    <asp:FileUpload ID="file_n1_signature" runat="server" Width="230px" />
                    <asp:Button ID="btnUploadN1Signature" runat="server" Text="Upload" CausesValidation="false"
                        OnClick="btnUploadN1Signature_Click"  />
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
       <div style="width: 100%; overflow: auto;">
        <asp:GridView ID="gvNominee" runat="server" AutoGenerateColumns="False" Width="100%"
            EmptyDataText="No Investor" AllowPaging="True" PageSize="10" OnPageIndexChanging="nominee_PageIndexChanging"
            OnRowDataBound="nominee_RowDataBound" DataKeyNames="ID" CssClass="mGrid">
            <Columns>
                <asp:BoundField DataField="NAME" HeaderText="Name" />
                <asp:BoundField DataField="DESIGNATION" HeaderText="Designation" />
                <asp:BoundField DataField="PHONE" HeaderText="Phone" />
                <asp:BoundField DataField="EMAIL" HeaderText="Email" />
                <asp:BoundField DataField="ID" HeaderText="Edit">
                    <ItemStyle Width="8%" />
                </asp:BoundField>
                <asp:BoundField DataField="ID" HeaderText="Delete">
                    <ItemStyle Width="8%" />
                </asp:BoundField>
            </Columns>
            <EmptyDataRowStyle CssClass="defaultGridEmptyData" />
            <PagerSettings PageButtonCount="15" Mode="NumericFirstLast" />
        </asp:GridView>
    </div>
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

