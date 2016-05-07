<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="BankInfoList.aspx.cs" Inherits="AccountsManagement_BankInfoList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <asp:GridView ID="gvBankInfo" runat="server" AutoGenerateColumns="False" Width="100%"
        EmptyDataText="No Record" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvBankInfo_PageIndexChanging"
        OnRowDataBound="gvBankInfo_RowDataBound" CssClass="mGrid" DataKeyNames="ID">
        <Columns>
            <asp:BoundField DataField="BANK_S_NAME" HeaderText="Short Name" />
            <asp:BoundField DataField="BANK_F_NAME" HeaderText="Full Name" />
            <asp:BoundField DataField="ID" HeaderText="Edit">
                <ItemStyle Width="8%" />
            </asp:BoundField>
            <asp:BoundField DataField="ID" HeaderText="Delete">
                <ItemStyle Width="8%" />
            </asp:BoundField>
        </Columns>
        <PagerSettings PageButtonCount="15" Mode="NumericFirstLast" />
    </asp:GridView>
</asp:Content>
