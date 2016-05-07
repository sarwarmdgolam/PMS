<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ImportCDBLFile.aspx.cs" Inherits="CDBLFileManagement_ImportCDBLFile"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">

    <script language="javascript" type="text/javascript" src="../Script/jquery-1.9.1.js"></script>

    <script language="javascript" type="text/javascript" src="../Script/jquery-ui-1.10.1.custom.js"></script>

    <script language="javascript" type="text/javascript">
     $(document).ready(function () {

            $('#tabs').tabs({
                activate: function () {
                    var newIdx = $('#tabs').tabs('option', 'active');
                    $('#<%=hidLastTab.ClientID%>').val(newIdx);

                }, heightStyle: "auto",
                active: previouslySelectedTab,
                show: { effect: "fadeIn", duration: 1000 }
            });

        });
    
    </script>

    <asp:HiddenField ID="hidLastTab" Value="0" runat="server" />
    <fieldset>
        <legend>Date Range</legend>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 20%;">
                    Date From:<span class="asterisk">*</span></td>
                <td style="width: 80%;">
                    <asp:TextBox ID="txtTransactionDateFromUpload" runat="server" Enabled="true" SkinID="txtDate"></asp:TextBox>
                    <img id="imgTransactionDateFromUpload" src="../Images/Calendar.gif" alt="No Image" />
                    <asp:RequiredFieldValidator ID="rfvtxtTransactionFromDate" ControlToValidate="txtTransactionDateFromUpload"
                        runat="server" ErrorMessage="Transaction date" Text="*" Display="None" />
                </td>
            </tr>
            <tr>
                <td style="width: 20%;">
                    Date To:<span class="asterisk">*</span></td>
                <td style="width: 80%;">
                    <asp:TextBox ID="txtTransactionDateToUpload" runat="server" Enabled="true" SkinID="txtDate"></asp:TextBox>
                    <img id="imgTransactionDateToUpload" src="../Images/Calendar.gif" alt="No Image" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtTransactionDateToUpload"
                        runat="server" ErrorMessage="Transaction date" Text="*" Display="None" />
                </td>
            </tr>
        </table>
    </fieldset>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Upload File</a></li>
            <li><a href="#tabs-2">Approve File</a></li>
            <li><a href="#tabs-3">Process File</a></li>
        </ul>
        <div id="tabs-1">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2">
                        <div>
                            <fieldset>
                                <legend>CDBL Files</legend>
                                <asp:CheckBoxList ID="chkCDBLFileListUpload" runat="server" DataTextField="Text"
                                    DataValueField="Value" RepeatColumns="3" RepeatDirection="Horizontal" RepeatLayout="Table">
                                </asp:CheckBoxList>
                            </fieldset>
                        </div>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" ValidationGroup="insert"
                            OnClick="btnUpload_Click" CausesValidation="true" />
                    </td>
                    <td>
                        <asp:FileUpload ID="fuUploadCDBLFiles" runat="server" />
                    </td>
                </tr>
            </table>
            <br />
            <div style="width: 100%;">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="insert"
                                CausesValidation="true" />
                        </td>
                        <td>
                            <asp:Button ID="btn_Clear" runat="server" Text="Refresh" OnClick="btn_Clear_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="tabs-2">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        CDBL File<span class="asterisk">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCDBLFileList" runat="server" DataTextField="Text" DataValueField="Value">
                        </asp:DropDownList>
                        <asp:Button ID="btnSearchCDBLInfo" runat="server" Text="Search" ValidationGroup="insert"
                            OnClick="btnSearchCDBLInfo_Click" CausesValidation="true" />
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnApproveCDBLInfo" runat="server" Text="Approve" ValidationGroup="insert"
                            OnClick="btnApproveCDBLInfo_Click" CausesValidation="true" />
                    </td>
                </tr>
            </table>
            <br />
            <div style="height: 100%;">
                <asp:GridView ID="dgvUnapprovedCDBLData" runat="server" AutoGenerateColumns="true"
                    Width="900px" EmptyDataText="No CDBL Data has been found." AllowPaging="True"
                    PageSize="10" DataKeyNames="ID" CssClass="mGrid">
                    <PagerSettings PageButtonCount="15" Mode="NumericFirstLast" />
                </asp:GridView>
            </div>
        </div>
        <div id="tabs-3">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2">
                        <div>
                            <fieldset>
                                <legend>CDBL Files</legend>
                                <asp:CheckBoxList ID="chkCDBLFilesProcess" runat="server" DataTextField="Text" DataValueField="Value"
                                    RepeatColumns="3" RepeatDirection="Horizontal" RepeatLayout="Table">
                                </asp:CheckBoxList>
                            </fieldset>
                        </div>
                    </td>
                </tr>
            </table>
            <br />
            <div style="width: 100%;">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnProcessCDBLFile" runat="server" Text="Process" ValidationGroup="insert"
                                OnClick="btnProcessCDBLFile_Click" CausesValidation="true" />
                        </td>
                        <td>
                            <asp:Button ID="btnClearProcess" runat="server" Text="Refresh" OnClick="btnClearProcess_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

    <script type="text/javascript">

    Calendar.setup
        ({
            inputField  : "ctl00_Main_txtTransactionDateFromUpload",
            ifFormat    : "dd-M-y",
            button      : "imgTransactionDateFromUpload",
            weekNumbers : false
        });
        
   Calendar.setup
        ({
            inputField  : "ctl00_Main_txtTransactionDateToUpload",
            ifFormat    : "dd-M-y",
            button      : "imgTransactionDateToUpload",
            weekNumbers : false
        });

   

    </script>

</asp:Content>
