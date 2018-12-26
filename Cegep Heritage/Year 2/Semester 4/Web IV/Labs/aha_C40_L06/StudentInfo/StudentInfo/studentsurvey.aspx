<%@ Page Title="" Language="C#" MasterPageFile="~/mySite.Master" AutoEventWireup="true" CodeBehind="studentsurvey.aspx.cs" Inherits="StudentInfo.studentsurvey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table class="table-style">
        <tr>
            <td>
                <asp:Label ID="lblStudentID" runat="server" Text="Student ID:"></asp:Label>
                <asp:RequiredFieldValidator ID="valRequireID" runat="server" ControlToValidate="txtStudentID" Display="Dynamic" ErrorMessage="Student ID is required" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="valMustBeInt" runat="server" ControlToValidate="txtStudentID" Display="Dynamic" ErrorMessage="You must enter an integer" ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
            </td>
            <td>
                <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="lblGetCourses" runat="server" Text="Get Courses" OnClick="lblGetCourses_Click" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblYourCourse" runat="server" Text="Your Courses:"></asp:Label>
                <asp:RequiredFieldValidator ID="valRequireCourse" runat="server" ControlToValidate="lstCourses" Display="Dynamic" Enabled="False" ErrorMessage="You must select a course" ForeColor="Red" ValidateRequestMode="Disabled"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:ListBox ID="lstCourses" runat="server"></asp:ListBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblExpectations" runat="server" Text="Met Expectations:"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdoExpList" runat="server">
                    <asp:ListItem runat="server" Text="Not Satisfied" GroupName="expectations" Value="1" />
                    <asp:ListItem runat="server" Text="Somewhat Satisfied" GroupName="expectations" Value="2" />
                    <asp:ListItem runat="server" Text="Satisfied" GroupName="expectations" Value="3" />
                    <asp:ListItem runat="server" Text="Completely Satisfied" GroupName="expectations" Value="4" />
                </asp:RadioButtonList>
                
            </td>
            <td>
                
            </td>
            <td>
                
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblKnowledge" runat="server" Text="Professor's Knowledge:"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdoKnow" runat="server">
                <asp:ListItem runat="server" Text="Not Satisfied" GroupName="knowledge" Value="1" />
                <asp:ListItem runat="server" Text="Somewhat Satisfied" GroupName="knowledge" Value="1" />
                <asp:ListItem runat="server" Text="Satisfied" GroupName="knowledge" Value="3" />
                <asp:ListItem runat="server" Text="Completely Satisfied" GroupName="knowledge" Value="4" />
                </asp:RadioButtonList>
                
            </td>
            <td>
               
            </td>
            <td>
                
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAssessments" runat="server" Text="Fair Assessements:"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdoFair" runat="server">
                    <asp:ListItem runat="server" Text="Not Satisfied" GroupName="fair" Value="1" />
                    <asp:ListItem runat="server" Text="Somewhat Satisfied" GroupName="fair" Value="2" />                
                    <asp:ListItem runat="server" Text="Satisfied" GroupName="fair" Value="3" />
                    <asp:ListItem runat="server" Text="Completely Satisfied" GroupName="fair" Value="4" />
                </asp:RadioButtonList>
                
            </td>
            <td>
                
            </td>
            <td>
                
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblComments" runat="server" Text="Additional Comments:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="chkContact" runat="server" Text="Please contact me to discuss this survey" />
            </td>
            <td>
                <asp:RadioButton ID="rdoContactEmail" runat="server" GroupName="contact" Text="Contact By Email" />
            </td>
            <td>
                <asp:RadioButton ID="rdoContactPhone" runat="server" GroupName="contact" Text="Contact by phone" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" PostBackUrl="~/surveycomplete.aspx" OnClick="btnSubmit_Click" />
            </td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    
</asp:Content>
