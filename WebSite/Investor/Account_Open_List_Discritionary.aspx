<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="Account_Open_List_Discritionary.aspx.cs" Inherits="Investor_Account_Open_List_Discritionary" Title="Account Open List(Discritionary)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
 
    <div>
        <fieldset>
            <legend><b>Search Criteria</b></legend>
            <table class="tb-tablecenter">
                <tr>
                    <td class="td-twocolumnleftsideright">
                        <span>Search By</span>
                    </td>
                    <td class="td-twocolumnrightsideleft">
                        <asp:DropDownList ID="ddl_Search_By" runat="server" SkinID="ddl100">
                            <asp:ListItem Selected="True" Text="Investor Code" Value="InvestorCode"></asp:ListItem>
                            <asp:ListItem Text="Investor Name" Value="InvestorName"></asp:ListItem>
                            <asp:ListItem Text="BO Code" Value="BOCode"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                   <td class="td-twocolumnleftsideright">
                        <span>Search Text</span>
                    </td>
                     <td class="td-twocolumnrightsideleft">
                        <asp:TextBox ID="txt_Search_Text" runat="server" SkinID="txt250"></asp:TextBox>
                        <asp:Button ID="btn_Search" runat="server" Text="Search" OnClick="btn_Search_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    <div style="width: 100%; overflow: auto;">
                        <asp:GridView ID="gv_Account_List" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                            EmptyDataText="No Data found!" Width="100%" DataKeyNames="ID" EnableViewState="true"
                            OnRowDataBound="gv_Account_List_RowDataBound" CssClass="mGrid" OnPageIndexChanging="gv_Account_List_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Investor Code" />
                                <asp:BoundField DataField="FIRST_JOIN_HOLDER_NAME" HeaderText="Name" />
                                <asp:BoundField DataField="BO_CODE" HeaderText="BO Code" />
                                <asp:BoundField DataField="ACCOUNTTYPENAME" HeaderText="Account Type" />
                                
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
</asp:Content>
