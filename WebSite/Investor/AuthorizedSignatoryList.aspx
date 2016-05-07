<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true" CodeFile="AuthorizedSignatoryList.aspx.cs" Inherits="Investor_AuthorizedSignatoryList" Title="Untitled Page" %>

<%@ Register Src="~/UserControls/SearchInvestor.ascx" TagName="SearchInvestor" TagPrefix="SI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:HiddenField ID="hdnInvestor_ID" runat="server" />
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
</asp:Content>

