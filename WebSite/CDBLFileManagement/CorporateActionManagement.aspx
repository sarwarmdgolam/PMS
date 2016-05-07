<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="CorporateActionManagement.aspx.cs" Inherits="CDBLFileManagement_CorporateActionManagement"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table class="tb-TwoColumnDetail">
        <tr>
            <td class="td-twocolumnleftsideright">
                Transaction Date</td>
            <td class="td-twocolumnrightsideleft">
                <asp:TextBox ID="txtTransactionDate" runat="server" Enabled="false" SkinID="txtDate"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="td-twocolumnleftsideright">
                Company
            </td>
            <td class="td-twocolumnrightsideleft">
                <asp:DropDownList ID="ddlCompany" runat="server" SkinID="ddl100">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlCompany" runat="server" ControlToValidate="ddlCompany"
                    Display="None" ErrorMessage="Select Company" InitialValue="0" Text="*" ValidationGroup="insert"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="td-twocolumnleftsideright">
                Corporate Action Type
            </td>
            <td class="td-twocolumnrightsideleft">
                <asp:DropDownList ID="ddlActionType" runat="server" SkinID="ddl100">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="td-twocolumnleftsideright">
                Record Date</td>
            <td class="td-twocolumnrightsideleft">
                <asp:TextBox ID="txtRecordDate" runat="server"   SkinID="txtDate"></asp:TextBox>
                <img id="imgRecordDate" src="../Images/Calendar.gif" />
            </td>
        </tr>
        <tr>
            <td class="td-twocolumnleftsideright">
                Effective Date</td>
            <td class="td-twocolumnrightsideleft">
                <asp:TextBox ID="txtEffectiveDate" runat="server"   SkinID="txtDate"></asp:TextBox>
                <img id="imgEffectiveDate" src="../Images/Calendar.gif" />
            </td>
        </tr>
        <tr>
            <td class="td-twocolumnleftsideright">
                Par Ratio</td>
            <td class="td-twocolumnrightsideleft">
                <asp:TextBox ID="txtRatio" runat="server" SkinID="txt100"></asp:TextBox>*
                <asp:RequiredFieldValidator ID="rfvtxtRatio" runat="server" Text="*" Display="None"
                    ErrorMessage="Please provide par ratio" ControlToValidate="txtRatio" ValidationGroup="insert"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="td-twocolumnleftsideright">
                Ben Ratio</td>
            <td class="td-twocolumnrightsideleft">
                <asp:TextBox ID="txtBenRatio" runat="server" SkinID="txt100"></asp:TextBox>*
                <asp:RequiredFieldValidator ID="rfvtxtBenRatio" runat="server" Text="*" Display="None"
                    ErrorMessage="Please provide ben ratio" ControlToValidate="txtBenRatio" ValidationGroup="insert"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td class="td-twocolumnleftsideright">
                Dividend Purify Ratio</td>
            <td class="td-twocolumnrightsideleft">
                <asp:TextBox ID="txtPufRatio" runat="server" SkinID="txt100"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="td-twocolumnleftsideright">
                Debit/Credit
            </td>
            <td class="td-twocolumnrightsideleft">
                <asp:DropDownList ID="ddlDebitCredit" runat="server" SkinID="ddl100">
                    <asp:ListItem Selected="True" Text="Debit" Value="Debit"></asp:ListItem>
                    <asp:ListItem Text="Credit" Value="Credit"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="td-twocolumnleftsideright">
                Remarks
            </td>
            <td class="td-twocolumnrightsideleft">
                <asp:TextBox ID="txtRemarks" runat="server" SkinID="txt250" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table class="tb-PageOperationButtonControl">
        <tr>
            <td>
                <asp:HiddenField ID="hdnID" runat="server" Value="0" />
                <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" CausesValidation="true"
                    ValidationGroup="insert" />
            </td>
            <td>
                <asp:Button ID="btn_Update" runat="server" Text="Update" ValidationGroup="insert"
                    OnClick="btn_Update_Click" CausesValidation="true" />
            </td>
            <td>
                <asp:Button ID="btn_Clear" runat="server" Text="Refresh" OnClick="btn_Clear_Click" />
            </td>
        </tr>
    </table>
     <script type="text/javascript">

    Calendar.setup
        ({
            inputField  : "ctl00_Main_txtRecordDate",
            ifFormat    : "dd-M-y",
            button      : "imgRecordDate",
            weekNumbers : false
        });

Calendar.setup
        ({
            inputField  : "ctl00_Main_txtEffectiveDate",
            ifFormat    : "dd-M-y",
            button      : "imgEffectiveDate",
            weekNumbers : false
        });
          
    </script>
</asp:Content>
