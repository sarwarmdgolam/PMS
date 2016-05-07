<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ApproveCashChqCollection.aspx.cs" Inherits="AccountTransaction_ApproveCashChqCollection"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    
    <table style="width: 100%">
        <tr>
            <td>
                <table>
                    <tr>
                        <td style="width: 25%;">
                            Transaction Date:
                        </td>
                        <td style="width: 75%;">
                            <asp:TextBox ID="txtTransactionDate" runat="server" Enabled="false" SkinID="txtDate"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtTransactionDate" ControlToValidate="txtTransactionDate"
                                runat="server" ErrorMessage="Transaction date" Text="*" Display="None" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvCashCheque" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                    ShowFooter="True" PageSize="20" EmptyDataText="No data found." OnRowDataBound="gvCashCheque_RowDataBound"
                    CssClass="mGrid" DataKeyNames="ID">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="50px">
                            <HeaderTemplate>
                                Approve
                            </HeaderTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:CheckBox ID="chk_Select_Single" runat="server" /><br />
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                            <FooterTemplate>
                                <asp:CheckBox ID="chk_Select_All" runat="server" AutoPostBack="true" OnCheckedChanged="chk_Select_All_CheckedChanged" /><br />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AMOUNT" HeaderText="Amount" />
                        <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Investor" />
                        <asp:BoundField DataField="CHEQUE_DATE" HeaderText="Cheque" />
                        <asp:BoundField DataField="BANK_F_NAME" HeaderText="Bank">
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BRANCH_NAME" HeaderText="B.Branch">
                            <ItemStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MODE_F_Name" HeaderText="Others"></asp:BoundField>
                    </Columns>
                    <EmptyDataRowStyle CssClass="defaultGridEmptyData" />
                    <PagerSettings PageButtonCount="15" Mode="NumericFirstLast" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <div style="width: 100%;">
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hdn_ID" runat="server" />
                    <asp:Button ID="btn_Save" runat="server" Text="Approve" OnClick="btn_Save_Click"
                        ValidationGroup="insert" CausesValidation="true" />
                </td>
                <td>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:Button ID="btn_Deny" runat="server" Text="Deny" OnClick="btn_Deny_Click" ValidationGroup="insert"
                        CausesValidation="true" />
                </td>
                <td>
                    <asp:Button ID="btn_Clear" runat="server" Text="Refresh" OnClick="btn_Clear_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
