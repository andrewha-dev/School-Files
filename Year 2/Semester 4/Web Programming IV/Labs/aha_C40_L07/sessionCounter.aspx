<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sessionCounter.aspx.cs" Inherits="sessionCounter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form" runat="server">
    <div>
    
        <asp:Label ID="lblResult" runat="server" Text="Result:"></asp:Label>
        <br />
        <asp:Button ID="btnCount1" runat="server" Text="Count 1" OnClick="btnCount1_Click" />
        <asp:Button ID="btnCount2" runat="server" Text="Count 2" OnClick="btnCount2_Click" />
    </div>
    </form>
</body>
</html>
