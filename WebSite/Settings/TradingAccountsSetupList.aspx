<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="TradingAccountsSetupList.aspx.cs" Inherits="Settings_TradingAccountsSetupList"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <div style="height: 100%;">
        <asp:GridView ID="gvEntity" runat="server" AutoGenerateColumns="False"
            BorderStyle="None" BorderWidth="1px" Width="100%" HeaderStyle-Wrap="true" CellPadding="3"
            CellSpacing="2" EmptyDataText="No Data found!" AllowPaging="True" HeaderStyle-Font-Size="12px"
            Font-Size="11px" PageSize="10" OnRowDataBound="gvEntity_RowDataBound"
            OnPageIndexChanging="gvEntity_PageIndexChanging" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ACC_Type_S_Name" HeaderText="Short Name">
                </asp:BoundField>
                <asp:BoundField DataField="ACC_Type_F_Name" HeaderText="Full Name">
                </asp:BoundField>
                <asp:BoundField DataField="ID" HeaderText="Edit">
                    <ItemStyle Width="8%" />
                </asp:BoundField>
                <asp:BoundField DataField="ID" HeaderText="Delete">
                    <ItemStyle Width="8%" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>0
</asp:Content>
