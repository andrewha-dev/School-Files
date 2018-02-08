<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="HappyValleyKennels.deafult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
     <link href="styles/styles.css" rel="stylesheet" />
</head>
<body>
    <div class="topHeader">
        <p>Happy Valley Kennels</p>
    </div>
    <form id="login" runat="server">
    <div class="loginDiv">
    <p class="loginHeader">Login</p>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="lblUserLogin" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox ID="txtUsernameLogin" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblPasswordLogin"  runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="txtPasswordLogin" Type="Password" runat="server"></asp:TextBox>
        <br/>
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <asp:LinkButton ID="btnCreate" runat="server" OnClick="btnCreate_Click">Create An Account</asp:LinkButton>
    </div>
    </form>
</body>
</html>
