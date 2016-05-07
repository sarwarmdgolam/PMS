<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true" CodeFile="TraderInfoList.aspx.cs" Inherits="TradeManagement_TraderInfoList" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
 <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%">
                            Trader name:
                        </td>
                        <td style="width: 80%">
                            <asp:TextBox ID="txtTraderCode" runat="server" SkinID="txt100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td style="text-align: left; height: 24px;">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <div class="EmptyRow">
                </div>
                <div id="Div1">
                    <div>
                        <asp:GridView ID="gvTraderInfo" runat="server" AutoGenerateColumns="False" Width="100%"
                            EmptyDataText="No Record" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvTraderInfo_PageIndexChanging"
                            OnRowDataBound="gvTraderInfo_RowDataBound" CssClass="mGrid" DataKeyNames="ID">
                            <Columns>
                                <asp:BoundField DataField="TRADER_CODE" HeaderText="Trader Code" />
                                <asp:BoundField DataField="EMP_NAME" HeaderText="Trader Name" />
                                <asp:BoundField DataField="ID" HeaderText="Edit">
                                    <ItemStyle Width="8%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ID" HeaderText="Delete">
                                    <ItemStyle Width="8%" />
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings PageButtonCount="15" Mode="NumericFirstLast" />
                        </asp:GridView>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

