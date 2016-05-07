<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs"
    Inherits="UserControls_WebUserControl" %>
<div style="vertical-align: bottom">
    <asp:TextBox ID="txtRecordDate" runat="server" SkinID="txtDate"></asp:TextBox>
    <img id="imgRecordDate" src="../Images/Calendar.gif" style="margin-top: 7px;" />
</div>

<script type="text/javascript">

    Calendar.setup
        ({
            inputField  : "ctl00_Main_txtRecordDate",
            ifFormat    : "dd-M-y",
            button      : "imgRecordDate",
            weekNumbers : false
        });

          
</script>

