<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login.ascx.cs" Inherits="aha_C40_L08.login" %>
<p>
<asp:Label ID="lblUser" runat="server" Text="Username:"></asp:Label>
<asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
    <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    <br />
    <asp:Label ID="lblAuthorized" runat="server" Text="&nbsp;"></asp:Label>
</p>



