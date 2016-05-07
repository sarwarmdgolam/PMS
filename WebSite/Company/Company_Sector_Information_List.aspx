<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="Company_Sector_Information_List.aspx.cs" Inherits="Company_Company_Sector_Information_List"
    Title="Company Sector Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <div>
        <table style="width: 100%; height: 100%">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                Market Sector Type</td>
                            <td>
                                <asp:DropDownList ID="ddlMarketSectorType" runat="server" OnSelectedIndexChanged="ddlMarketSector_SelectedIndexChanged"
                                    AutoPostBack="true" SkinID="ddl100">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right; padding-right: 5px;">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="height: 100%;">
                        <asp:GridView ID="dgvMarketSector" runat="server" AutoGenerateColumns="False" Width="100%"
                            EmptyDataText="No Market Sector has been found." AllowPaging="True" PageSize="10"
                            CssClass="table_style1" OnRowDataBound="dgvMarketSector_RowDataBound" OnPageIndexChanging="dgvMarketSector_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="SEC_S_NAME" HeaderText="Short Name">
                                    <ItemStyle Width="14%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SEC_F_NAME" HeaderText="Full Name">
                                    <ItemStyle Width="30%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="INST_SECTOR_TYPE" HeaderText="Sector Type">
                                    <ItemStyle Width="20%" />
                                </asp:BoundField>
                                <asp:ButtonField Text="Edit" ItemStyle-Width="8%" HeaderText="Edit" />
                                <asp:ButtonField Text="Delete" ItemStyle-Width="8%" HeaderText="Delete" />
                            </Columns>
                            <AlternatingRowStyle BackColor="#C2D69B" />
                            <RowStyle BackColor="#B4B4B4" ForeColor="#2A6021" />
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#2A6021" />
                            <PagerStyle ForeColor="#2A6021" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#F7DFB5" Font-Bold="True" ForeColor="#2A6021" />
                            <HeaderStyle Wrap="True" />
                            <PagerSettings PageButtonCount="25" Mode="NumericFirstLast" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
