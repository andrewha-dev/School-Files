<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="4dataDataList.aspx.cs" Inherits="aha_C40_L10Fixed._4dataDataList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="dsOwner" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;OWNER_NUMBER&quot;, &quot;OWNER_FIRST_NAME&quot;, &quot;OWNER_LAST_NAME&quot;, &quot;OWNER_STREET&quot;, &quot;OWNER_CITY&quot;, &quot;OWNER_PROVINCE&quot;, &quot;OWNER_POSTAL_CODE&quot;, &quot;OWNER_PHONE&quot; FROM &quot;HVK_OWNER&quot;"></asp:SqlDataSource>
        <br />
        <asp:DataList ID="dlOwner" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyField="OWNER_NUMBER" DataSourceID="dsOwner" ForeColor="Black" GridLines="Vertical">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#F7F7DE" />
            <ItemTemplate>

                <asp:Label ID="OWNER_FIRST_NAMELabel" runat="server" Text='<%# Eval("OWNER_FIRST_NAME") + " " + Eval("OWNER_LAST_NAME") %>' />
                <br />
                
               
                <asp:Label ID="OWNER_STREETLabel" runat="server" Text='<%# Eval("OWNER_STREET") %>' />
                <br />
                
                <asp:Label ID="OWNER_CITYLabel" runat="server" Text='<%# Eval("OWNER_CITY") + ", " +  Eval("OWNER_PROVINCE") %>' />
                <br />
  
                
                <asp:Label ID="OWNER_POSTAL_CODELabel" runat="server" Text='<%# Eval("OWNER_POSTAL_CODE").ToString() == "" ? "" : Eval("OWNER_POSTAL_CODE").ToString().Substring(0,3) + " " + Eval("OWNER_POSTAL_CODE").ToString().Substring(3)  %>' />
                <br />
               
                <asp:Label ID="OWNER_PHONELabel" runat="server" Text='<%#string.Format("{0: (###) ###-####}", Int64.Parse(Eval("OWNER_PHONE").ToString())) %>' />
                <br />
<br />
            </ItemTemplate>
            <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
    
    </div>
    </form>
</body>
</html>
