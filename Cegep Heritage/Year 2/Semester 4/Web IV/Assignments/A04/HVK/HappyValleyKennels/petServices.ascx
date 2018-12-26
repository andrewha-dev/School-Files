<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="petServices.ascx.cs" Inherits="HappyValleyKennels.petServices" %>
<asp:Table ID="tblServices" runat="server" BorderColor="Black" BorderStyle="Solid" GridLines="Both">
    <asp:TableRow runat="server">
        <asp:TableCell>Playtime</asp:TableCell>
        <asp:TableCell><asp:CheckBox ID="cbServPlay" runat="server" /></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell>Walk</asp:TableCell>
        <asp:TableCell><asp:CheckBox ID="cbServWalk" runat="server" /></asp:TableCell>
    </asp:TableRow>

</asp:Table>

