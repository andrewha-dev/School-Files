<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListPicker.ascx.cs" Inherits="aha_C40_L08.ListPicker" %>

<link href="styles/styles.css" rel="stylesheet" />
<table>
    <tr>
        <td>
            <asp:Label ID="lblAvailable" runat="server" Text="Available"></asp:Label>
            <br />
            <asp:ListBox ID="lstAvailable" runat="server">
                <asp:ListItem>Maple Leafs</asp:ListItem>
                <asp:ListItem>Canadiens</asp:ListItem>
                <asp:ListItem>Senators</asp:ListItem>
                <asp:ListItem>Jets</asp:ListItem>
            </asp:ListBox>
        </td>
        <td>
            <asp:Button ID="btnAddAll" runat="server" OnClick="btnAddAll_Click" Text="&gt;&gt;" />
            <br />
            <asp:Button ID="btnAddOne" runat="server" OnClick="btnAddOne_Click" Text=" &gt; " />
            <br />
            <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text=" x " />
        </td>
        <td>
            <asp:Label ID="lblSelected" runat="server" Text="Selected"></asp:Label>
            <br />
            <asp:ListBox ID="lstSelected" runat="server"></asp:ListBox>
        </td>
    </tr>
</table>

