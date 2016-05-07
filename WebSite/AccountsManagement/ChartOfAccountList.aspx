<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ChartOfAccountList.aspx.cs" Inherits="AccountsManagement_ChartOfAccountList"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table width="100%">
        <tr>
            <td colspan="2">
                <div style="width: 100%; background-color: #99CCCC;">
                    <h2>
                        Chart Of Account
                    </h2>
                    <%--<div style="float: right;">
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="true" PostBackUrl="~/AccountTransaction/Cash_Chq_Collection_List.aspx">View List</asp:LinkButton>
                    </div>--%>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="divErrMesg" runat="server" style="visibility: hidden; display: none;">
                    <div class="ui-state-error ui-corner-all" style="padding: 0pt 0.7em;">
                        <span class="ui-icon ui-icon-alert" style="margin-right: 0.3em;"></span>
                        <asp:Label ID="lblErrMsg" runat="server" EnableTheming="true">
                        </asp:Label>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="divInfoMsg" class="ui-widget" runat="server">
                    <div class="ui-state-highlight ui-corner-all" style="padding: 0pt 0.7em;">
                        <span class="ui-icon ui-icon-info" style="margin-right: 0.3em;"></span>
                        <asp:Label ID="lblMsg" runat="server" EnableTheming="true">
                        </asp:Label>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
