<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PresentValue.aspx.cs" Inherits="PresentValue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Future Value</title>
    <style type="text/css">
        .imageSize   {
            width: 150px;
            height: 65px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>
    
        <img alt="CS Logo" class="imageSize" src="images/CSlogo.png" /> Future Value of Savings <img alt="Heritage" class="imageSize" src="images/heritage.png" /></h1>
        <table>
            <tr>
                <td style="text-align: right">Monthly Investment: </td>
                <td>
                    <asp:DropDownList ID="ddlInvest" runat="server" Width="4em">
                    </asp:DropDownList><asp:RequiredFieldValidator ID="valRequiredAmount" runat="server" ErrorMessage="Monthly Investment Is Required" ControlToValidate="ddlInvest" Display="Dynamic" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Annual Interest Rate:</td>
                <td>
                    <asp:TextBox ID="txtInterest" runat="server" Width="4em"></asp:TextBox><asp:RequiredFieldValidator ID="valRequiredInterest" runat="server" ErrorMessage="Interest Rate is required" ControlToValidate="txtInterest" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator><asp:RangeValidator ID="valInvestRange" runat="server" ErrorMessage="RangeValidator" ControlToValidate="txtInterest" ForeColor="Red" MaximumValue="20" MinimumValue="1" Type="Integer">Rate must be between 1 and 20</asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Number of Years:</td>
                <td>
                    <asp:TextBox ID="txtYears" runat="server" Width="4em"></asp:TextBox><asp:RequiredFieldValidator ID="valRequiredYear" runat="server" ErrorMessage="Number Of Years is required" ControlToValidate="txtYears" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator><asp:CompareValidator ID="valCompareToYears" runat="server" ErrorMessage="Years must be greater than 0" ControlToValidate="txtYears" ForeColor="Red" Operator="GreaterThan" Type="Integer" ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Future Value:</td>
                <td class="auto-style1">
                    <asp:Label ID="lblFuture" runat="server" Width="12em"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnClear" runat="server" Text="Clear" Width="7em" OnClick="btnClear_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCalc" runat="server" Text="Calculate" Width="7em" OnClick="btnCalc_Click" />
                </td>
            </tr>
        </table>
        </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
