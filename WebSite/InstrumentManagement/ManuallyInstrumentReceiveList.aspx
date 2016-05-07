<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ManuallyInstrumentReceiveList.aspx.cs" Inherits="InstrumentManagement_ManuallyInstrumentReceiveList"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table style="width:100%">
        <tr>
            <td>
                <asp:GridView ID="dgvManageInstReceive" runat="server" AutoGenerateColumns="False" Width="100%"
                    EmptyDataText="No data found." AllowPaging="True" PageSize="10"
                    CssClass="mGrid" OnRowDataBound="dgvManageInstReceive_RowDataBound" OnPageIndexChanging="dgvManageInstReceive_PageIndexChanging" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Investor Code">
                        </asp:BoundField>
                        <asp:BoundField DataField="VOUCHER_REF_NO" HeaderText="Voucher Ref No">
                        </asp:BoundField>
                        <asp:BoundField DataField="RECDEL_MODE" HeaderText="Model">
                        </asp:BoundField>
                        <asp:ButtonField Text="Edit" ItemStyle-Width="8%" HeaderText="Edit" />
                        <asp:ButtonField Text="Delete" ItemStyle-Width="8%" HeaderText="Delete" />
                    </Columns>
                   
                    <PagerSettings PageButtonCount="15" Mode="NumericFirstLast" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
