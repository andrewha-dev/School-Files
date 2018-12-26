<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkTime.aspx.cs" Inherits="aha_C40_L08.checkTime" %>

<%@ Register Src="~/theTime.ascx" TagPrefix="uc1" TagName="theTime" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:theTime runat="server" id="theTime" />
        <br />
        <asp:Button ID="btnDisplay" runat="server" Text="Refresh Time"/>
        <asp:Button ID="btnChangeDisplay" runat="server" Text="Change Format" OnClick="btnChangeDisplay_Click"/>
    </div> 
    </form>
</body>
</html>
