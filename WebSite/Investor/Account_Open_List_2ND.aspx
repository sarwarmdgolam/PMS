<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="Account_Open_List_2ND.aspx.cs" Inherits="Investor_Account_Open_List" Title="Account Open List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table width="100%">
        <tr>
            <td colspan="2">
                <div style="width: 100%; background-color: #99CCCC;">
                    <h2>
                        BO Account List
                    </h2>
                    <div style="float: right;">
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="true" PostBackUrl="~/Investor/Account_Open_2ND.aspx">Add New</asp:LinkButton>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="divErrMesg" class="ui-widget" runat="server">
                    <div class="ui-state-error ui-corner-all" style="padding: 0pt 0.7em;">
                        <span class="ui-icon ui-icon-alert" style="margin-right: 0.3em;"></span>
                        <asp:Label ID="lblErrMsg" runat="server" EnableTheming="true">
                        </asp:Label>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="divInfoMsg" class="ui-widget" runat="server">
                    <div class="ui-state-highlight ui-corner-all" style="padding: 0pt 0.7em;">
                        <span class="ui-icon ui-icon-info" style="margin-right: 0.3em;"></span>
                        <asp:Label ID="lblMsg" runat="server" EnableTheming="true">
                        </asp:Label>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <div>
        <fieldset>
            <legend><b>Search Criteria</b></legend>
            <table width="100%">
                <tr>
                    <td>
                        <span>Search By</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_Search_By" runat="server" SkinID="ddl100">
                            <asp:ListItem Selected="True" Text="Investor Code" Value="InvestorCode"></asp:ListItem>
                            <asp:ListItem Text="Investor Name" Value="InvestorName"></asp:ListItem>
                            <asp:ListItem Text="BO Code" Value="BOCode"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>Search Text</span>
                    </td>
                    <td>
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
                                <asp:BoundField DataField="INVESTOR_CODE" HeaderText="Investor" />
                                <asp:BoundField DataField="FIRST_JOIN_HOLDER_NAME" HeaderText="Accounts Details" />
                                <asp:BoundField DataField="BO_CODE" HeaderText="Contacts" />
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
