<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true" CodeFile="ReportShow.aspx.cs" Inherits="ReportManagement_ReportShow" Title="Untitled Page" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
      <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
        </div>
         <table cellpadding="0" border="0" cellspacing="0" style="margin: 5px 5px 0px 5px;">
            <tr>
                <td style="text-align:center;">
                    <rsweb:ReportViewer ID="repViewer" runat="server" Width="844px" Height="588px" />
                </td>
            </tr>
        </table>
</asp:Content>

