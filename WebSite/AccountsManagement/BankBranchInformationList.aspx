<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="BankBranchInformationList.aspx.cs" Inherits="AccountsManagement_BankBranchInformationList"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table style="width: 100%; height: 100%">
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            Bank</td>
                        <td>
                            <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" SkinID="ddl100">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right; padding-right: 5px;">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="Search" OnClick="btn_Search_Click"
                                ValidationGroup="insert" CausesValidation="true" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <div style="height: 100%;">
                    <asp:GridView ID="dgvBankBranch" runat="server" AutoGenerateColumns="False" Width="100%"
                        EmptyDataText="No Market Sector has been found." AllowPaging="True" PageSize="10"
                        CssClass="table_style1" OnRowDataBound="dgvBankBranch_RowDataBound" OnPageIndexChanging="dgvBankBranch_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="BRANCH_NAME" HeaderText="Branch Name">
                                <ItemStyle Width="14%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ADDRESS" HeaderText="Address">
                                <ItemStyle Width="30%" />
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
                        <PagerSettings PageButtonCount="15" Mode="NumericFirstLast" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
