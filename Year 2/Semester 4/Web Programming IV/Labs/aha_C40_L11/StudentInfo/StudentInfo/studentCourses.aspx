<%@ Page Title="" Language="C#" MasterPageFile="~/mySite.Master" AutoEventWireup="true" CodeBehind="studentCourses.aspx.cs" Inherits="StudentInfo.studentCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="dsStudent" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
        SelectCommand="SELECT STUDENTID, LAST, FIRST, POSTCODE, BIRTHDATE FROM IU_STUDENT"></asp:SqlDataSource>


        <asp:SqlDataSource ID="dsCourse" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
        SelectCommand="SELECT STUDENTID, CSID, MIDTERM, FINAL FROM IU_REGISTRATION WHERE (STUDENTID = :STUDENTID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="dvStudent" Name="STUDENTID" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:DetailsView ID="dvStudent" runat="server" Height="50px" Width="125px" AllowPaging="True" CellPadding="4" DataSourceID="dsStudent" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#C5BBAF" Font-Bold="True" />
        <EditRowStyle BackColor="#7C6F57" />
        <FieldHeaderStyle BackColor="#D0D0D0" Font-Bold="True" />
        <Fields>
            <asp:CommandField />
        </Fields>
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
    </asp:DetailsView>





    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataKeyNames="STUDENTID" AllowSorting="True" DataSourceID="dsCourse" AutoGenerateColumns="False" CellPadding="3" GridLines="Horizontal" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="STUDENTID" HeaderText="STUDENTID" SortExpression="STUDENTID" />
            <asp:BoundField DataField="CSID" HeaderText="CSID" SortExpression="CSID" />
            <asp:BoundField DataField="MIDTERM" HeaderText="MIDTERM" SortExpression="MIDTERM" />
            <asp:BoundField DataField="FINAL" HeaderText="FINAL" SortExpression="FINAL" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>



</asp:Content>
