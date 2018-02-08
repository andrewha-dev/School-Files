<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nag.aspx.cs" Inherits="nag" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Nag Counter</h1>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" AutoCompleteType="FirstName"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" AutoCompleteType="Email"></asp:TextBox>
        <br />
        <br />
       <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
        <br />
        <br />
        <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
    &nbsp;<asp:Label ID="lblInfo" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
