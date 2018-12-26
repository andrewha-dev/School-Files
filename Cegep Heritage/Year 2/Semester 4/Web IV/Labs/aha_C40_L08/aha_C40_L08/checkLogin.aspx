<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkLogin.aspx.cs" Inherits="aha_C40_L08.checkLogin" %>

<%@ Register Src="~/login.ascx" TagPrefix="uc1" TagName="login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:login runat="server" ID="login" />
    </div>
    </form>
</body>
</html>
