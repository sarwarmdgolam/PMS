<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="NonTradingDay.aspx.cs" Inherits="TradeManagement_NonTradingDay" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <div>
        <table style="width: 100%">
            <tr>
                <td style="width: 20%">
                    Security Exchange: <span class="asterisk">*</span>
                </td>
                <td style="width: 80%">
                    <asp:DropDownList ID="ddlSecurityMarket" runat="server" SkinID="ddl100">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlSecurityMarket" runat="server" Text="*" Display="None"
                        ErrorMessage="Please select Security Market" ControlToValidate="ddlSecurityMarket"
                        InitialValue="0" ValidationGroup="insert"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 26px">
                    From Date: <span class="asterisk">*</span>
                </td>
                <td style="height: 26px">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td style="height: 24px">
                                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txt100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtFromDate" runat="server" Text="*" ControlToValidate="txtFromDate"
                                    ErrorMessage="Input From Date" Display="None" ValidationGroup="insert"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 111px; height: 24px;">
                                <img id="imgRecordDate" src="../Images/Calendar.gif" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 26px">
                    To Date: <span class="asterisk">*</span>
                </td>
                <td style="height: 26px">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td style="height: 24px">
                                <asp:TextBox ID="txtToDate" runat="server" SkinID="txt100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Text="*"
                                    ControlToValidate="txtToDate" ErrorMessage="Please provide To Date" Display="None"
                                    ValidationGroup="insert"></asp:RequiredFieldValidator></td>
                            <td style="width: 111px; height: 24px;">
                                <img id="imgEffectiveDate" src="../Images/Calendar.gif" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 24px">
                    Purpose:
                </td>
                <td style="height: 24px">
                    <asp:TextBox ID="txtPurpose" runat="server" SkinID="txt250"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Non Trading Type: <span class="asterisk">*</span></td>
                <td>
                    <asp:DropDownList ID="ddlNonTradingType" runat="server" OnSelectedIndexChanged="ddlNonTradingType_SelectedIndexChanged"
                        AutoPostBack="True" SkinID="ddl100">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlNonTradingType"
                        Display="None" ErrorMessage="Please Select Non Trading Type" InitialValue="0"
                        Text="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr id="dayRow" runat="server">
                <td>
                    Day: <span class="asterisk">*</span></td>
                <td>
                    <%-- <asp:CheckBoxList ID="chkNonTradingDay" runat="server">
                        <asp:ListItem Value="Saturday">Saturday</asp:ListItem>
                        <asp:ListItem Value="Sunday">Sunday</asp:ListItem>
                        <asp:ListItem Value="Monday">Monday</asp:ListItem>
                        <asp:ListItem Value="Tuesday">Tuesday</asp:ListItem>
                        <asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
                        <asp:ListItem Value="Thrusday">Thrusday</asp:ListItem>
                        <asp:ListItem Value="Friday">Friday</asp:ListItem>
                    </asp:CheckBoxList>--%>
                    <asp:RadioButtonList ID="chkNonTradingDay" runat="server" Enabled="false">
                        <asp:ListItem Value="Saturday">Saturday</asp:ListItem>
                        <asp:ListItem Value="Sunday">Sunday</asp:ListItem>
                        <asp:ListItem Value="Monday">Monday</asp:ListItem>
                        <asp:ListItem Value="Tuesday">Tuesday</asp:ListItem>
                        <asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
                        <asp:ListItem Value="Thrusday">Thrusday</asp:ListItem>
                        <asp:ListItem Value="Friday">Friday</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hdnID" runat="server" Value="0" />
                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" CausesValidation="true"
                        ValidationGroup="insert" />
                </td>
                <td>
                    <asp:Button ID="btn_Update" runat="server" Text="Update" ValidationGroup="insert"
                        OnClick="btn_Update_Click" />
                </td>
                <td>
                    <asp:Button ID="btn_Clear" runat="server" Text="Refresh" OnClick="btn_Clear_Click" />
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">

    Calendar.setup
        ({
            inputField  : "ctl00_Main_txtFromDate",
            ifFormat    : "dd-M-y",
            button      : "imgRecordDate",
            weekNumbers : false
        });

    Calendar.setup
        ({
            inputField  : "ctl00_Main_txtToDate",
            ifFormat    : "dd-M-y",
            button      : "imgEffectiveDate",
            weekNumbers : false
        });
        
    </script>

</asp:Content>
