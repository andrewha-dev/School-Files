<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
      <div>
        <h1>
           <img alt="Heritage College Logo" class="defaultCSS" src="images/heritage.png" />My First ASP Page</h1>
          <p>
              Principal(P):<asp:TextBox ID="txtPrincipal" runat="server" Width="4em"></asp:TextBox>
          </p>
          <p>
              Rate(R):
              <asp:TextBox ID="txtRate" runat="server" Width="3em"></asp:TextBox>
          </p>
          <p>
              Time(T):<asp:TextBox ID="txtTime" runat="server" Width="3em"></asp:TextBox>
          </p>
          <p>
              Total:
              <asp:Label ID="lblTotal" runat="server" Text="Calculation goes here"></asp:Label>
          </p>
          <p>
              <asp:Button ID="btnCalc" runat="server" OnClick="btnCalc_Click" Text="Calculate" />
          </p>
    
    
    </div>
    </form>
</body>
</html>
