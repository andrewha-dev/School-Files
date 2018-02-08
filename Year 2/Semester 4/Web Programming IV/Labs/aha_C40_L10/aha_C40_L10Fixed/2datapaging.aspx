<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2datapaging.aspx.cs" Inherits="aha_C40_L10Fixed._2datapaging" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="dsOwnerAndpet" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT AHA.HVK_OWNER.OWNER_FIRST_NAME, AHA.HVK_OWNER.OWNER_LAST_NAME, AHA.HVK_PET.PET_NAME, AHA.HVK_PET.PET_BREED, AHA.HVK_PET.PET_BIRTHDATE, AHA.HVK_PET.PET_GENDER, AHA.HVK_PET.DOG_SIZE, AHA.HVK_PET.PET_FIXED FROM AHA.HVK_PET INNER JOIN AHA.HVK_OWNER ON AHA.HVK_PET.OWN_OWNER_NUMBER = AHA.HVK_OWNER.OWNER_NUMBER ORDER BY AHA.HVK_OWNER.OWNER_LAST_NAME, AHA.HVK_PET.PET_NAME"></asp:SqlDataSource>
        <br />
        <asp:GridView ID="gdOwnerAndPet" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="dsOwnerAndpet" ForeColor="#333333" GridLines="None" PageSize="6">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="OWNER_FIRST_NAME" HeaderText="OWNER_FIRST_NAME" SortExpression="OWNER_FIRST_NAME" />
                <asp:BoundField DataField="OWNER_LAST_NAME" HeaderText="OWNER_LAST_NAME" SortExpression="OWNER_LAST_NAME" />
                <asp:BoundField DataField="PET_NAME" HeaderText="PET_NAME" SortExpression="PET_NAME" />
                <asp:BoundField DataField="PET_BREED" HeaderText="PET_BREED" SortExpression="PET_BREED" />
                <asp:BoundField DataField="PET_BIRTHDATE" HeaderText="PET_BIRTHDATE" SortExpression="PET_BIRTHDATE" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblPetBirthday" runat="server" Text='<%#Eval("PET_BIRTHDATE", "{0:yyyy/MM/dd}")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PET_GENDER" HeaderText="PET_GENDER" SortExpression="PET_GENDER" />
                <asp:BoundField DataField="DOG_SIZE" HeaderText="DOG_SIZE" SortExpression="DOG_SIZE" />
                <asp:BoundField DataField="PET_FIXED" HeaderText="PET_FIXED" SortExpression="PET_FIXED" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerSettings Mode="NextPrevious" NextPageImageUrl="~/arrow-2-right.png" PreviousPageImageUrl="~/arrow-2-left.png" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
