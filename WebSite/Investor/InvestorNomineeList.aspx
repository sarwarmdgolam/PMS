<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="InvestorNomineeList.aspx.cs" Inherits="Investor_InvestorNomineeList"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table width="100%">
        <tr>
            <td colspan="2">
                <div style="width: 100%; background-color: #99CCCC;">
                    <h2>
                        Investor Nominees
                    </h2>
                    <div style="float: right;">
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="true" PostBackUrl="InvestorNominee.aspx">Add New</asp:LinkButton>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="divErrMesg" class="ui-widget" runat="server">
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
        <tr>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
        </tr>
    </table>
     <div style="width: 100%; overflow: auto;">
        <asp:GridView ID="gvNominee" runat="server" AutoGenerateColumns="False" Width="100%"
            EmptyDataText="No Investor" AllowPaging="True" PageSize="10" OnPageIndexChanging="nominee_PageIndexChanging"
            OnRowDataBound="nominee_RowDataBound" CssClass="mGrid">
            <Columns>
                <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Investor" />
                <asp:BoundField DataField="FIRST_JOIN_HOLDER_NAME" HeaderText="Detail Information" />
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
</asp:Content>
