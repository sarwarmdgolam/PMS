<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="Company_Information_List.aspx.cs" Inherits="Company_Company_Information_List"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <div id="content">
        <div>
            <table style="width: 100%; height: 100%">
                <tr>
                    <td>
                        <fieldset>
                            <legend><b>Search Criteria</b></legend>
                            <table>
                                <tr>
                                    <td>
                                        <b>Company Name</b><span class="asterisk">*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_Company_Name" runat="server" SkinID="txt250"></asp:TextBox>
                                        <asp:Button ID="btn_Search" runat="server" Text="Search" OnClick="btn_Search_Click" />
                                        <asp:RequiredFieldValidator ID="rfvtxt_Company_Name" runat="server" ErrorMessage="Input Company Name."
                                            ControlToValidate="txt_Company_Name" ValidationGroup="insert" SetFocusOnError="true"
                                            ForeColor="red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="height: 100%;">
                            <asp:GridView ID="dgvCompanyInformation" runat="server" AutoGenerateColumns="False"
                                BorderStyle="None" BorderWidth="1px" Width="100%" HeaderStyle-Wrap="true" CellPadding="3"
                                CellSpacing="2" EmptyDataText="No Data found!" AllowPaging="True" HeaderStyle-Font-Size="12px"
                                Font-Size="11px" PageSize="10" OnRowDataBound="dgvCompanyInformation_RowDataBound"
                                OnPageIndexChanging="dgvCompanyInformation_PageIndexChanging" DataKeyNames="ID">
                                <Columns>
                                    <asp:BoundField DataField="COMPANY_NAME" HeaderText="Company Name">
                                        <ItemStyle Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SECURITYCODE" HeaderText="Details" HtmlEncode="false">
                                        <ItemStyle Width="32%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ID" HeaderText="Edit">
                                        <ItemStyle Width="8%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ID" HeaderText="Delete">
                                        <ItemStyle Width="8%" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
