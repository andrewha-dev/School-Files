<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="faculty.aspx.cs" Inherits="aha_C40L12.faculty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ObjectDataSource ID="odsFaculty" runat="server" SelectMethod="getFaculty" TypeName="aha_C40L12.App_Code.Faculty">

        </asp:ObjectDataSource>
    
        <asp:ObjectDataSource ID="odsFacultyId" runat="server" SelectMethod="getFacultyById" TypeName="aha_C40L12.App_Code.Faculty">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlFaculty" Name="_facultyId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <asp:DropDownList ID="ddlFaculty" runat="server" AutoPostBack="True" DataSourceID="odsFaculty" DataTextField="facName" DataValueField="facultyId">
        </asp:DropDownList>
        <br />
        <br />
        <asp:DetailsView ID="dvFaculty" runat="server" AutoGenerateRows="False" DataSourceID="odsFacultyId" Height="50px" Width="125px">
            <Fields>
                <asp:BoundField DataField="facultyId" HeaderText="facultyId" SortExpression="facultyId" />
                <asp:BoundField DataField="facName" HeaderText="facName" SortExpression="facName" />
                <asp:BoundField DataField="roomId" HeaderText="roomId" SortExpression="roomId" />
                <asp:BoundField DataField="phoneNum" HeaderText="phoneNum" SortExpression="phoneNum" />
                <asp:BoundField DataField="deptId" HeaderText="deptId" SortExpression="deptId" />
                <asp:BoundField DataField="deptName" HeaderText="deptName" SortExpression="deptName" />
                <asp:BoundField DataField="roomLoc" HeaderText="roomLoc" SortExpression="roomLoc" />
            </Fields>
        </asp:DetailsView>
        <br />
        <asp:ObjectDataSource ID="odsDepart" runat="server" SelectMethod="getDepartment" TypeName="aha_C40L12.App_Code.Department"></asp:ObjectDataSource>
        <br />
        <asp:DropDownList ID="ddlDepartment" runat="server" DataSourceID="odsDepart" DataTextField="deptName" DataValueField="deptId">
        </asp:DropDownList>
        <br />
        <br />
        <asp:ObjectDataSource ID="odsLocation" runat="server" SelectMethod="getLocation" TypeName="aha_C40L12.App_Code.Location"></asp:ObjectDataSource>
        <br />
        <asp:DropDownList ID="ddlLocation" runat="server" DataSourceID="odsLocation" DataTextField="roomLoc" DataValueField="roomId">
        </asp:DropDownList>
        <br />
        <br />
        <asp:ObjectDataSource ID="odsExpanded" runat="server" SelectMethod="getFacultyDetailExpanded" TypeName="aha_C40L12.App_Code.Faculty">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlFaculty" Name="_facId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:DetailsView ID="dvExpanded" runat="server" AutoGenerateRows="False" DataSourceID="odsExpanded" Height="50px" Width="125px">
            <Fields>
                <asp:BoundField DataField="facultyId" HeaderText="facultyId" SortExpression="facultyId" />
                <asp:BoundField DataField="facName" HeaderText="facName" SortExpression="facName" />
                <asp:BoundField DataField="roomId" HeaderText="roomId" SortExpression="roomId" />
                <asp:BoundField DataField="phoneNum" HeaderText="phoneNum" SortExpression="phoneNum" />
                <asp:BoundField DataField="deptId" HeaderText="deptId" SortExpression="deptId" />
                <asp:BoundField DataField="deptName" HeaderText="deptName" SortExpression="deptName" />
                <asp:BoundField DataField="roomLoc" HeaderText="roomLoc" SortExpression="roomLoc" />
            </Fields>
        </asp:DetailsView>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
