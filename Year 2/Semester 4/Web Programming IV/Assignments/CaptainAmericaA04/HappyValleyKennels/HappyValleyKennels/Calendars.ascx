<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Calendars.ascx.cs" Inherits="HappyValleyKennels.WebUserControl1" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

    <asp:TextBox ID="txtInput" placerholder="mm/dd/yyyy" runat="server"></asp:TextBox>
<ajaxToolkit:CalendarExtender ID="calUserControl" runat="server" TargetControlID="txtInput" />
