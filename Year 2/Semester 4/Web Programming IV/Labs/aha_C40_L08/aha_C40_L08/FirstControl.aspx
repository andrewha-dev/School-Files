<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstControl.aspx.cs" Inherits="aha_C40_L08.FirstControl" %>

<%@ Register Src="~/ListPicker.ascx" TagPrefix="uc1" TagName="ListPicker" %>
<%@ Register Src="~/ListPicker2.ascx" TagPrefix="uc1" TagName="ListPicker2" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:ListPicker runat="server" id="ListPicker" />
        <br />

        <br />
        <uc1:ListPicker2 runat="server" ID="ListPicker2" />
    </div>
    </form>
</body>
</html>
