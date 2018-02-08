<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1DataFormat.aspx.cs" Inherits="aha_C40_L10Fixed._1DataFormat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>GridView 1</h2>
        <asp:SqlDataSource ID="dsOwner" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;OWNER_NUMBER&quot;, &quot;OWNER_FIRST_NAME&quot;, &quot;OWNER_LAST_NAME&quot;, &quot;OWNER_STREET&quot;, &quot;OWNER_CITY&quot;, &quot;OWNER_PROVINCE&quot;, &quot;OWNER_POSTAL_CODE&quot;, &quot;OWNER_PHONE&quot;, &quot;OWNER_EMAIL&quot;, &quot;EMERGENCY_CONTACT_FIRST_NAME&quot;, &quot;EMERGENCY_CONTACT_LAST_NAME&quot;, &quot;EMERGENCY_CONTACT_PHONE&quot;, &quot;VET_VET_NUMBER&quot; FROM &quot;HVK_OWNER&quot;"></asp:SqlDataSource>
    
        <asp:GridView ID="gdOwner" runat="server" DataSourceID="dsOwner" AutoGenerateColumns="true">
        </asp:GridView>
        

        <br />

        <h2>GridView 2</h2>
        <asp:GridView ID="gdOwner2" runat="server" DataKeyNames="OWNER_NUMBER" DataSourceID="dsOwner" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" PageSize="6" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <%--<asp:BoundField DataField="OWNER_FIRST_NAME" HeaderText="OWNER_FIRST_NAME" SortExpression="OWNER_FIRST_NAME" />
                <asp:BoundField DataField="OWNER_LAST_NAME" HeaderText="OWNER_LAST_NAME" SortExpression="OWNER_LAST_NAME" />--%>
                <asp:TemplateField HeaderText="Name" SortExpression="OWNER_LAST_NAME">
                    <ItemTemplate>
                        <asp:Label ID="lblOwnerName" runat="server" Text='<%#Eval("OWNER_LAST_NAME") + ", " + Eval("OWNER_FIRST_NAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="OWNER_CITY" HeaderText="OWNER_CITY" SortExpression="OWNER_CITY" />--%>
                <asp:TemplateField HeaderText="City" SortExpression="OWNER_CITY">
                    <ItemTemplate>
                         <asp:Label ID="lblCity" runat="server" Text='<%#Eval("OWNER_CITY") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="OWNER_PHONE" HeaderText="OWNER_PHONE" SortExpression="OWNER_PHONE" />--%>
                <asp:TemplateField HeaderText="Phone">
                    <ItemTemplate>
                        <asp:Label ID="lblPhone" runat="server" Text='<%#string.Format("{0: (###) ###-####}", Int64.Parse(Eval("OWNER_PHONE").ToString())) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
<%--                <asp:BoundField DataField="OWNER_EMAIL" HeaderText="OWNER_EMAIL" SortExpression="OWNER_EMAIL" />--%>
                 <asp:TemplateField HeaderText="Email">         
                        <ItemTemplate>
                            <asp:Hyperlink ID="lblEmail" runat="server" NavigateUrl='<%# Eval("OWNER_EMAIL", "mailto:{0}") %>' Text='<%# Bind("OWNER_EMAIL") %>'></asp:Hyperlink>
                        </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerSettings Mode="NextPreviousFirstLast" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
