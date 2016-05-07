<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="Company_Sector_Information.aspx.cs" Inherits="Company_Company_Sector_Information"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <div class="content">
        <table style="width: 100%">
            <tr>
                <td>
                    Short Name<span class="asterisk">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtShortName" runat="server" SkinID="txt100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtShortName"
                        runat="server" ErrorMessage="Please provide value for Short Name" Text="*" Display="None"
                        ValidationGroup="insert" />
                </td>
            </tr>
            <tr>
                <td style="width: 12%">
                    Full Name<span class="asterisk">*</span>
                </td>
                <td style="width: 80%">
                    <asp:HiddenField ID="MarketSectorID" runat="server"></asp:HiddenField>
                    <asp:TextBox ID="txtName" runat="server" SkinID="txt100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCode" ControlToValidate="txtName" runat="server"
                        ErrorMessage="Please provide value for Name" Text="*" Display="None" ValidationGroup="insert" />
                </td>
            </tr>
            <tr>
                <td style="height: 26px">
                    Sector<span class="asterisk">*</span>
                </td>
                <td style="height: 26px">
                    <div id="SectorList">
                        <asp:DropDownList ID="ddlSectorType" runat="server" SkinID="ddl100">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlSectorType"
                            runat="server" ErrorMessage="Please select Sector Type." InitialValue="0" Text="*"
                            Display="None" ValidationGroup="insert" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
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
    </div>
</asp:Content>
