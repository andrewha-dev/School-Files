<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Events.aspx.cs" Inherits="Events" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event</title>
    <link href="styles/styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>

    
        <table class="table-style" style="text-align: right">
            <tr>
                <td style="text-align: right">Event Name:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtEventName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Number Of Guests:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtGuestAmount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="table-style-other" style="text-align: right">Cost Per Guest:</td>
                <td class="table-style-other" style="text-align: left">
                    <asp:DropDownList ID="ddlCosts" runat="server">
                        <asp:ListItem Value="20">$20 (Cold Buffet)</asp:ListItem>
                        <asp:ListItem Value="30">$30 (Hot Buffet)</asp:ListItem>
                        <asp:ListItem Value="40">$40 (Table Service, one course meal)</asp:ListItem>
                        <asp:ListItem Value="60">$60 (Table Service, three course meal)</asp:ListItem>
                        <asp:ListItem Value="100">$100 (Table Service, six course meal)</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Type Of Music:</td>
                <td style="text-align: left">
                    <asp:Panel ID="music" runat="server">
                        <asp:RadioButton ID="rdLive" runat="server" Text="Live Music" GroupName="Music" />
                        <asp:RadioButton ID="rdDJ" runat="server" Text="DJ " GroupName="Music" />
                        <asp:RadioButton ID="rdMixed" runat="server" Text="Mixed" GroupName="Music" />
                    </asp:Panel>
                  
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Open Bar?</td>
                <td style="text-align: left">
                    <asp:CheckBox ID="chkBar" runat="server" Text="Open Bar?" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left" class="table-style-other"></td>
                <td style="text-align: left" class="table-style-other"></td>
            </tr>
            <tr>
                <td style="text-align: left" class="table-style-other">&nbsp;</td>
                <td style="text-align: left" class="table-style-other">
                    <asp:Button ID="btnCalculate" runat="server" OnClick="btnCalculate_Click" Text="Calculate" />
                </td>
            </tr>
        </table>

    
    </div>
        <table class="table-style">
            <tr>
                <td>&nbsp;</td>
                <td>Event&#39;s &#39;R&#39; Us for All your Events</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblTableEvent" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Item</td>
                <td>Cost ($)</td>
                <td>Totals</td>
            </tr>
            <tr>
                <td>Number Of Guests</td>
                <td>
                    <asp:Label ID="lblTableAmountGuests" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Total Cost For Guests</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblTotalCostGuest" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Music </td>
                <td>
                    <asp:Label ID="lblTableMusic" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblMusicCost" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Open Bar (cost per guest = $30)</td>
                <td>
                    <asp:Label ID="lblOpenBar" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOpenBarCost" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Total Cost</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblTotalCost" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
