<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="3dataUpdate.aspx.cs" Inherits="aha_C40_L10Fixed._3dataUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="dsOwner" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="SELECT &quot;OWNER_NUMBER&quot;, &quot;OWNER_FIRST_NAME&quot;, &quot;OWNER_LAST_NAME&quot;, &quot;OWNER_STREET&quot;, &quot;OWNER_CITY&quot;, &quot;OWNER_PROVINCE&quot;, &quot;OWNER_POSTAL_CODE&quot;, &quot;OWNER_PHONE&quot;, &quot;OWNER_EMAIL&quot; FROM &quot;HVK_OWNER&quot;" 
            DeleteCommand="DELETE FROM &quot;HVK_OWNER&quot; WHERE &quot;OWNER_NUMBER&quot; = ?" 
            InsertCommand="INSERT INTO &quot;HVK_OWNER&quot; (&quot;OWNER_NUMBER&quot;, &quot;OWNER_FIRST_NAME&quot;, &quot;OWNER_LAST_NAME&quot;, &quot;OWNER_STREET&quot;, &quot;OWNER_CITY&quot;, &quot;OWNER_PROVINCE&quot;, &quot;OWNER_POSTAL_CODE&quot;, &quot;OWNER_PHONE&quot;, &quot;OWNER_EMAIL&quot;) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)" 
            UpdateCommand="UPDATE HVK_OWNER SET OWNER_FIRST_NAME = :OWNER_FIRST_NAME, OWNER_LAST_NAME = :OWNER_LAST_NAME, OWNER_STREET = :OWNER_STREET, OWNER_CITY = :OWNER_CITY, OWNER_PROVINCE = :OWNER_PROVINCE, OWNER_POSTAL_CODE = :OWNER_POSTAL_CODE, OWNER_PHONE = :OWNER_PHONE, OWNER_EMAIL = :OWNER_EMAIL WHERE OWNER_NUMBER = :OWNER_NUMBER">
            <DeleteParameters>
                <asp:Parameter Name="OWNER_NUMBER" Type="Decimal" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="OWNER_NUMBER" Type="Decimal" />
                <asp:Parameter Name="OWNER_FIRST_NAME" Type="String" />
                <asp:Parameter Name="OWNER_LAST_NAME" Type="String" />
                <asp:Parameter Name="OWNER_STREET" Type="String" />
                <asp:Parameter Name="OWNER_CITY" Type="String" />
                <asp:Parameter Name="OWNER_PROVINCE" Type="String" />
                <asp:Parameter Name="OWNER_POSTAL_CODE" Type="String" />
                <asp:Parameter Name="OWNER_PHONE" Type="String" />
                <asp:Parameter Name="OWNER_EMAIL" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="OWNER_FIRST_NAME" Type="String" />
                <asp:Parameter Name="OWNER_LAST_NAME" Type="String" />
                <asp:Parameter Name="OWNER_STREET" Type="String" />
                <asp:Parameter Name="OWNER_CITY" Type="String" />
                <asp:Parameter Name="OWNER_PROVINCE" Type="String" />
                <asp:Parameter Name="OWNER_POSTAL_CODE" Type="String" />
                <asp:Parameter Name="OWNER_PHONE" Type="String" />
                <asp:Parameter Name="OWNER_EMAIL" Type="String" />
                <asp:Parameter Name="OWNER_NUMBER" Type="Decimal" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <asp:GridView ID="gvOwner" runat="server" AutoGenerateColumns="False" DataKeyNames="OWNER_NUMBER" DataSourceID="dsOwner">
            <Columns>
                <asp:CommandField HeaderText="Modify" ShowEditButton="True"></asp:CommandField>
                 <asp:BoundField DataField="OWNER_FIRST_NAME" HeaderText="First Name" SortExpression="OWNER_FIRST_NAME" />
                 <asp:BoundField DataField="OWNER_LAST_NAME" HeaderText="Last Name" SortExpression="OWNER_LAST_NAME" />
                 <asp:BoundField DataField="OWNER_STREET" HeaderText="Street" SortExpression="OWNER_STREET" />
                 <asp:BoundField DataField="OWNER_CITY" HeaderText="City" SortExpression="OWNER_CITY" />
                 <asp:BoundField DataField="OWNER_PROVINCE" HeaderText="Province" SortExpression="OWNER_PROVINCE" />
                 <asp:BoundField DataField="OWNER_POSTAL_CODE" HeaderText="Postal Code" SortExpression="OWNER_POSTAL_CODE" />
                 <asp:BoundField DataField="OWNER_PHONE" HeaderText="Phone" SortExpression="OWNER_PHONE" />
                 <asp:BoundField DataField="OWNER_EMAIL" HeaderText="Email" SortExpression="OWNER_EMAIL" />


            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
