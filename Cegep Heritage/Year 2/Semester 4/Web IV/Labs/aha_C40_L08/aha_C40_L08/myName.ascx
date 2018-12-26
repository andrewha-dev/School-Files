<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="myName.ascx.cs" Inherits="aha_C40_L08.myName" %>
<div>
    <p>
        <asp:Label ID="lblFirst" runat="server" Text="First Name:"></asp:Label>
        <asp:TextBox ID="txtFirst" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lblLast" runat="server" Text="Last Name:"></asp:Label>
        <asp:TextBox ID="txtLast" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lblCount" runat="server" Text="Count:"></asp:Label>
        <asp:TextBox ID="txtCount" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnSayHello" runat="server" Text="Say Hello" />
    </p>
</div>