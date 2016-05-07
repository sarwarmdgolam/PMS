<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="NonTradingDayList.aspx.cs" Inherits="TradeManagement_NonTradingDayList"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%">
                            Security Exchange:
                        </td>
                        <td style="width: 80%">
                            <asp:DropDownList ID="ddlSecurityMarket" runat="server" SkinID="ddl100">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Non Trading Type:</td>
                        <td>
                            <asp:DropDownList ID="ddlNonTradingType" runat="server" AutoPostBack="False" SkinID="ddl100">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            From Date:
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="height: 24px">
                                        <asp:TextBox ID="txtFromDate" runat="server" SkinID="txt100"></asp:TextBox>
                                    </td>
                                    <td style="width: 111px; height: 24px;">
                                        <img id="imgFromDate" src="../Images/Calendar.gif" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            To Date:
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="height: 24px">
                                        <asp:TextBox ID="txtToDate" runat="server" SkinID="txt100"></asp:TextBox>
                                    </td>
                                    <td style="width: 111px; height: 24px;">
                                        <img id="imgToDate" src="../Images/Calendar.gif" /></td>
                                </tr>
                            </table>
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
                        <asp:GridView ID="gvNonTradingDay" runat="server" AutoGenerateColumns="False" Width="100%"
                            EmptyDataText="No Record" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvNonTradingDay_PageIndexChanging"
                            OnRowDataBound="gvNonTradingDay_RowDataBound" CssClass="mGrid" DataKeyNames="ID">
                            <Columns>
                                <asp:BoundField DataField="SECURITY_EXCHANGE_NAME" HeaderText="Security Exchange" />
                                <asp:BoundField DataField="DAY_TYPE" HeaderText="Non Trading Type" />
                                <asp:BoundField DataField="DETAILS" HeaderText="Purpose" />
                                <asp:BoundField DataField="NON_TRADING_DAY" HeaderText="Day" />
                                <asp:BoundField DataField="TRANSACTION_DATE" HeaderText="Date" />
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

    <script type="text/javascript">
       
    Calendar.setup
        ({
            inputField  : "ctl00_Main_txtFromDate",
            ifFormat    : "dd-M-y",
            button      : "imgFromDate",
            weekNumbers : false
        });

    Calendar.setup
        ({
            inputField  : "ctl00_Main_txtToDate",
            ifFormat    : "dd-M-y",
            button      : "imgToDate",
            weekNumbers : false
        });
        
    </script>

</asp:Content>
