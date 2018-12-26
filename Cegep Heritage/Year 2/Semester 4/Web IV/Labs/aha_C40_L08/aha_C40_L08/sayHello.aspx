<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sayHello.aspx.cs" Inherits="aha_C40_L08.sayHello" %>

<%@ Register Src="~/myName.ascx" TagPrefix="uc1" TagName="myName" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Time To Say Hello!</h1>
    <div>
        <uc1:myName runat="server" id="myName" />
    </div>
    <asp:Label ID="lblSayHello" runat="server" Text="&nbsp;"></asp:Label>
    </form>
</body>
</html>
