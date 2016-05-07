<%@ Page Language="C#" MasterPageFile="~/MasterPage/DefaultWithoutMenu.master" Title="Your Name Here | Home"
    CodeFile="Default.aspx.cs" Inherits="Default_aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <table width="100%">
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
    <div id="content" style="padding-top: 10%; padding-left: 30%">
        <table cellspacing="0" class="Content" width="100%">
            <tr>
                <td style="text-align: center;">
                    <div class="LM_Login">
                        <div style="padding-top: 100px;">
                            <table style="width: 100%; padding-left: 10px">
                                <tr>
                                    <td style="width: 30%; ">
                                        <asp:Label runat="server" ID="UserNameLabel" AssociatedControlID="txtUserName">User Name</asp:Label>
                                    </td>
                                    <td style="width: 70%;  text-align: left">
                                        <asp:TextBox runat="server" ID="txtUserName" AccessKey="u" />
                                        <asp:RequiredFieldValidator runat="server" ID="UserNameRequired" ControlToValidate="txtUserName"
                                            ValidationGroup="Login1" ErrorMessage="User Name is required." ToolTip="User Name	is required.">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30%; ">
                                        <asp:Label runat="server" ID="PasswordLabel" CssClass="label" AssociatedControlID="txtPassword">Password</asp:Label><br />
                                    </td>
                                    <td style="width: 70%;  text-align: left">
                                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="textbox"
                                            AccessKey="p" />
                                        <asp:RequiredFieldValidator runat="server" ID="PasswordRequired" ControlToValidate="txtPassword"
                                            ValidationGroup="Login1" ToolTip="Password is	required.">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="width: 70%;  text-align: left">
                                        <asp:Button ID="LoginButton" runat="server" Text="login" CommandName="Login"   SkinID="login" OnClick="LoginButton_Click1"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <p>
                                            <asp:Literal runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
                                        </p>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
