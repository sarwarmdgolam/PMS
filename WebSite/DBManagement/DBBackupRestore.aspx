<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="DBBackupRestore.aspx.cs" Inherits="DBManagement_DBBackupRestore" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table class="tb-tablecenter">
        <tr>
            <td class="td-twocolumnleftsideleft">
                <table>
                
                    <tr>
                        <td >
                            Database<span class="asterisk">*</span></td>
                        <td >
                            <asp:DropDownList ID="ddlDatabaseList" runat="server" SkinID="ddl100">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvddlDatabaseList" runat="server" ErrorMessage="Input Database."
                                ControlToValidate="ddlDatabaseList" ValidationGroup="insert" SetFocusOnError="true"
                                ForeColor="red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                   <tr>
                    <td >
                            Remarks<span class="asterisk">*</span></td>
                        <td >
                            <asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox>
                        </td>
                   </tr>
                </table>
            </td>
            <td class="td-twocolumnrightsideright">
                <div style="float: right">
                    <asp:ListBox ID="lstDBBackupList"  Width="400px" Height="400px" runat="server"></asp:ListBox>
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Button ID="btnFullDBBackup" runat="server" Text="Full DB Backup" OnClick="btnFullDBBackup_Click"
                    ValidationGroup="insert" CausesValidation="true" SkinID="insertbutton" />
            </td>
            <td>
                <asp:Button ID="btnDBRestore" runat="server" Text="DB Restore" OnClick="btnDBRestore_Click"
                    ValidationGroup="insert" CausesValidation="true" SkinID="insertbutton" />
            </td>
            <td>
                <asp:Button ID="btnDeleteFile" runat="server" Text="Delete File" OnClick="btnDeleteFile_Click" OnClientClick="return confirm('Are you Confirm To Delete the selected file?');"
                     SkinID="insertbutton" />
            </td>
        </tr>
    </table>
</asp:Content>
