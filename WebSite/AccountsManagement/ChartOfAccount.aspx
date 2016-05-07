<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="ChartOfAccount.aspx.cs" Inherits="AccountsManagement_ChartOfAccount"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <asp:HiddenField ID="hdnID" runat="server" />
    
    <table style="width: 100%;">
        <tr>
            <td style="width: 40%">
                <table align="center" width="100%">
                    <tr>
                        <td style="width: 30%;">
                            <b>GL Account NO: </b><span class="asterisk">*</span>
                        </td>
                        <td style="width: 70%;">
                            <asp:TextBox ID="txtGlNumber" runat="server" SkinID="txt100"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="height: 26px; width: 169px;">
                            <b>Parent Account:</b></td>
                        <td style="height: 26px; width: 209px;">
                            <asp:TextBox ID="txtControlAccount" runat="server" Enabled="false" SkinID="txt100"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="height: 26px; width: 169px;">
                            <b>Account Ref No.</b><span class="asterisk"></span></td>
                        <td style="height: 26px; width: 209px;">
                            <asp:TextBox ID="txtAccRefNum" runat="server" SkinID="txt100"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="height: 26px; width: 169px;">
                            <b>GL Account Name</b> <span class="asterisk">*</span>
                        </td>
                        <td style="height: 26px; width: 209px;">
                            <asp:TextBox ID="txtGLACName" runat="server" SkinID="txt100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCode" runat="server" Text="*" Display="None" ErrorMessage="Please provide GLAC Name"
                                ControlToValidate="txtGLACName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 26px; width: 169px;">
                            <b>GL Open Date:</b></td>
                        <td style="height: 26px; width: 209px;">
                            <table cellpadding="0" border="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtOpenDate" runat="server" ReadOnly="True" SkinID="txtDate"></asp:TextBox></td>
                                    <td>
                                        &nbsp;<img id="imgOpenDate" src="../Images/Calendar.gif" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 26px; width: 169px;">
                            <b>Level</b> <span class="asterisk">*</span></td>
                        <td style="height: 26px; width: 209px;">
                            <asp:DropDownList ID="ddlGLAccLevel" runat="server" Enabled="false" SkinID="ddl100">
                                <asp:ListItem Selected="True" Text="First" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Second" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Third" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Fourth" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Fifth" Value="5"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 26px; width: 169px;">
                            <b>Branch:</b> <span class="asterisk">*</span></td>
                        <td style="height: 26px; width: 209px;">
                            <asp:DropDownList ID="ddlBrokerBranch" runat="server" SkinID="ddl100">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlBrokerBranch"
                                Display="None" ErrorMessage="Please select Branch" InitialValue="0" Text="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 157px; height: 26px">
                            <strong>Opening Balance:</strong></td>
                        <td style="width: 327px; height: 26px">
                            <asp:TextBox ID="txtOpeningBalance" runat="server" onkeypress="return blockNonNumbers(this, event, true, false);"
                                SkinID="txt100"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 157px; height: 26px">
                            <strong>Current Balance:</strong></td>
                        <td style="width: 327px; height: 26px">
                            <asp:TextBox ID="txtCurrentBalance" onkeypress="return blockNonNumbers(this, event, true, false);"
                                runat="server" SkinID="txt100"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 157px; height: 26px">
                            <strong>Monthly Balance:</strong></td>
                        <td style="width: 327px; height: 26px">
                            <asp:TextBox ID="txtMonthBalance" onkeypress="return blockNonNumbers(this, event, true, false);"
                                runat="server" SkinID="txt100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 26px; width: 169px;">
                            <b>Debit/Credit</b> <span class="asterisk">*</span></td>
                        <td style="height: 26px; width: 209px;">
                            <asp:RadioButton ID="rbtnDebit" runat="server" GroupName="DrCr" Text="Debit" Checked="true" />
                            <asp:RadioButton ID="rbtnCredit" runat="server" GroupName="DrCr" Text="Credit" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 157px; height: 26px">
                            <strong>Post Flag:</strong> <span class="asterisk">*</span></td>
                        <td style="width: 327px; height: 26px">
                            <asp:RadioButton ID="rbtnNonPosted" runat="server" GroupName="postflag" Text="Non-PostedPosted"
                                Checked="true" />
                            <asp:RadioButton ID="rbtnPosted" runat="server" GroupName="postflag" Text="Posted" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 157px; height: 26px">
                            <strong>Ledger Name:</strong> <span class="asterisk">*</span></td>
                        <td style="width: 327px; height: 26px">
                            <asp:DropDownList ID="cboLedger" runat="server" SkinID="ddl100">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="*"
                                Display="None" ErrorMessage="Please select Ledger Name" ControlToValidate="cboLedger"
                                InitialValue="-- Select --"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 169px; height: 26px">
                            <strong>Status:</strong> <span class="asterisk">*</span></td>
                        <td style="width: 209px; height: 26px">
                            <asp:CheckBox ID="chkIsActive" runat="server" Checked="true" />
                        </td>
                    </tr>
                </table>
            </td>
            <td width="60%" height="400px" style="vertical-align: top;">
                <fieldset style="width: 90%; height: 100%;">
                    <legend style="font-weight: bold">Chart Of Account </legend>
                    <div>
                        <asp:RadioButton ID="rbtnInsertMode" runat="server" Checked="true" Text="Insert Mode"
                            GroupName="Mode" />
                        <asp:RadioButton ID="rbtnUpdateMode" runat="server" Text="Update Mode" GroupName="Mode" />
                    </div>
                    <div style="overflow:scroll; height:370px;">
                        <asp:TreeView ID="tvChartOfAccounts" runat="server" ShowExpandCollapse="true" Width="100%"
                            Height="100%"  OnSelectedNodeChanged="tvChartOfAccounts_SelectedNodeChanged">
                        </asp:TreeView>
                    </div>
                </fieldset>
            </td>
        </tr>
    </table>
    <br />
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="text-align: left; height: 24px;">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>
            <td>
                &nbsp;
            </td>
            <td style="height: 24px">
                <asp:Button ID="btnClear" runat="server" Text="Refresh" OnClick="btnClear_Click"
                    CausesValidation="false" /></td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>

    <script type="text/javascript">

    Calendar.setup
        ({
            inputField  : "ctl00_ContentPlaceHolder1_txtOpenDate",
            ifFormat    : "dd-M-y",
            button      : "imgOpenDate",
            weekNumbers : false
        });
        
    </script>

</asp:Content>
