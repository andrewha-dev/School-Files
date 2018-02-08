<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="firstAjax.aspx.cs" Inherits="aha_C40_L08.firstAjax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="upCheckTime" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnAjax" runat="server" Text="Ajax Button" OnClick="btnAjax_Click" />        
            <asp:Label ID="lblAjax" runat="server" Text="&nbsp;"></asp:Label>
            
            </ContentTemplate>           
        </asp:UpdatePanel>
        
        <asp:Button ID="btnNoAjax" runat="server" Text="Non Ajax Button" OnClick="btnNoAjax_Click" />
        <asp:Label ID="lblNoAjax" runat="server" Text="&nbsp;"></asp:Label>
    </div>
    </form>
</body>
</html>
