<%@ Page Language="C#" AutoEventWireup="true" CodeFile="undo.aspx.cs" Inherits="undo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="txtBoxName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblPhone" runat="server" Text="Phone:"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
            <asp:Button ID="btnUndo" runat="server" Text="Undo" OnClick="btnUndo_Click"/>
        </div>
    </form>
</body>
</html>
