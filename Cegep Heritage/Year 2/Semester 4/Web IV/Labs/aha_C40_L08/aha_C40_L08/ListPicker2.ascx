<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListPicker2.ascx.cs" Inherits="aha_C40_L08.styles.ListPicker2" %>
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
            <br />
            <asp:Label ID="lblAvErr" runat="server" Text="&amp;nbsp;"></asp:Label>
        </td>
        <td>
            <asp:Button ID="btnAddAll" runat="server" OnClick="btnAddAll_Click" Text="&gt;&gt;" />
            <br />
            <asp:Button ID="btnAddOne" runat="server" OnClick="btnAddOne_Click" Text=" &gt; " />
            <br />
            
            <asp:Button ID="btnBackAll" runat="server" OnClick="btnBackAll_Click" Text="&lt;&lt;" />
            <br />
            <asp:Button ID="btnBackOne" runat="server" OnClick="btnBackOne_Click" Text=" &lt; " />
            
        </td>
        <td>
            <asp:Label ID="lblSelected" runat="server" Text="Selected"></asp:Label>
            <br />
            <asp:ListBox ID="lstSelected" runat="server"></asp:ListBox>
            <br />
            <asp:Label ID="lblSeErr" runat="server" Text="&amp;nbsp;"></asp:Label>
        </td>
    </tr>
</table>