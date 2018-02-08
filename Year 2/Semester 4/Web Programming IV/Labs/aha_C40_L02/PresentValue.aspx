<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PresentValue.aspx.cs" Inherits="PresentValue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Future Value</title>
    <link href="styles/styles.css" rel="stylesheet" />
    </head>
<body>
    <form id="form1" runat="server">
    <div>    
        <img alt="Heritage Logo" class="imageSize" src="images/CSlogo.png" />&nbsp;
        <h1>Future Value Of Savings</h1>
&nbsp;
        <img alt="Heritage College Logo" class="imageSize" src="images/heritage.png" /><br />
        <table>
            <tr>
                <td style="text-align: right">Monthly Investment: </td>
                <td>
                    <asp:DropDownList ID="ddlInvest" runat="server" OnSelectedIndexChanged="ddlInvest_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Annual Interest Rate:</td>
                <td>
                    <asp:TextBox ID="txtInterest" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Number Of Years</td>
                <td>
                    <asp:TextBox ID="txtYears" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Future Value:</td>
                <td>
                    <asp:Label ID="lblFuture" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCalc" runat="server" Text="Calculate" OnClick="btnCalc_Click" />
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
