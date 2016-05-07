<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true" CodeFile="Import_Portfolio.aspx.cs"
    Inherits="Import_Import_Portfolio" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <div class="shim gradient">
    </div>
    <div class="page" id="albums">
        <div id="divInfoMsg" class="ui-widget" runat="server">
            <div class="ui-state-highlight ui-corner-all" style="padding: 0pt 0.7em;">
                <span class="ui-icon ui-icon-info" style="margin-right: 0.3em;"></span>
                <asp:Label ID="lblMsg" runat="server" EnableTheming="false">
                </asp:Label>
            </div>
        </div>
        <div id="divErrMesg" class="ui-widget" runat="server">
            <div class="ui-state-error ui-corner-all" style="padding: 0pt 0.7em;">
                <span class="ui-icon ui-icon-alert" style="margin-right: 0.3em;"></span>
                <asp:Label ID="lblErrMsg" runat="server" EnableTheming="false">
                </asp:Label>
            </div>
        </div>
        <table>
            <tr>
                <td>
                    <asp:FileUpload ID="fu_Import" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btn_Import" runat="server" Text="Import" OnClick="btn_Import_Click" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <div style="overflow: auto; width: 700px; height: 400px;">
                        <asp:GridView ID="gv_Portfolio" runat="server">
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
