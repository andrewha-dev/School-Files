<%@ Page Title="" Language="C#" MasterPageFile="~/mySite.Master" AutoEventWireup="true" CodeBehind="manageFaculty.aspx.cs" Inherits="StudentInfo.manageFaculty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:SqlDataSource ID="dsFaculty" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        DeleteCommand="DELETE FROM IU_FACULTY WHERE FACULTYID = :FACULTYID" 
        InsertCommand="INSERT INTO IU_FACULTY (FACULTYID, NAME, ROOMID, PHONE, DEPTID) VALUES (IU_FACULTY_SEQ.NEXTVAL, :NAME, :ROOMID, :PHONE, :DEPTID)" 
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
        SelectCommand="SELECT FACULTYID, NAME, ROOMID, PHONE, DEPTID FROM IU_FACULTY" 
        UpdateCommand="UPDATE IU_FACULTY SET NAME = :NAME, ROOMID = :ROOMID, PHONE = :PHONE, DEPTID = :DEPTID WHERE FACULTYID = :FACULTYID">
        <DeleteParameters>
            <asp:Parameter Name="FACULTYID" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="NAME" Type="String" />
            <asp:Parameter Name="ROOMID" Type="Decimal" />
            <asp:Parameter Name="PHONE" Type="String" />
            <asp:Parameter Name="DEPTID" Type="Decimal" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="NAME" Type="String" />
            <asp:Parameter Name="ROOMID" Type="Decimal" />
            <asp:Parameter Name="PHONE" Type="String" />
            <asp:Parameter Name="DEPTID" Type="Decimal" />
            <asp:Parameter Name="FACULTYID" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>





    <asp:DetailsView ID="dvFaculty" runat="server" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="FACULTYID" DataSourceID="dsFaculty" Height="50px" Width="125px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <Fields>
            
            <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
            <asp:BoundField DataField="ROOMID" HeaderText="ROOMID" SortExpression="ROOMID" />
            <asp:BoundField DataField="PHONE" HeaderText="PHONE" SortExpression="PHONE" />
            <asp:BoundField DataField="DEPTID" HeaderText="DEPTID" SortExpression="DEPTID" />
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
        </Fields>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:DetailsView>





</asp:Content>
