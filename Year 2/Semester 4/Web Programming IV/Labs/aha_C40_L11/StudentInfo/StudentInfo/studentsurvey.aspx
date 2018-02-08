<%@ Page Title="" Language="C#" MasterPageFile="~/mySite.Master" AutoEventWireup="true" CodeBehind="studentsurvey.aspx.cs" Inherits="StudentInfo.studentsurvey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table class="table-style">
        <tr>
            <td>
                <asp:Label ID="lblStudentID" runat="server" Text="Student ID:"></asp:Label>
                <asp:RequiredFieldValidator ID="valRequireID" runat="server" ControlToValidate="ddlStudent" Display="Dynamic" ErrorMessage="Student ID is required" ForeColor="Red"></asp:RequiredFieldValidator>
               
            </td>
            <td>
                <asp:SqlDataSource ID="dsStudent" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT STUDENTID, LAST||', '||FIRST as NAME FROM IU_STUDENT"></asp:SqlDataSource>
                <asp:DropDownList ID="ddlStudent" runat="server" DataSourceID="dsStudent" DataTextField= "NAME" DataValueField="STUDENTID" AppendDataBoundItems="true">
                    <asp:ListItem Value="-1">
                        -- Select One --
                    </asp:ListItem>
                </asp:DropDownList>
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
              
            </td>
            <td>

                <asp:SqlDataSource ID="dsCourse" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT AHA.IU_FACULTY.FACULTYID, AHA.IU_REGISTRATION.STUDENTID, AHA.IU_REGISTRATION.CSID, AHA.IU_TERM.TERMID, AHA.IU_COURSE.COURSEID, AHA.IU_COURSE.TITLE, AHA.IU_TERM.TERMDESC FROM AHA.IU_FACULTY INNER JOIN AHA.IU_CRSSECTION ON AHA.IU_FACULTY.FACULTYID = AHA.IU_CRSSECTION.FACULTYID INNER JOIN AHA.IU_REGISTRATION ON AHA.IU_CRSSECTION.CSID = AHA.IU_REGISTRATION.CSID INNER JOIN AHA.IU_COURSE ON AHA.IU_CRSSECTION.COURSEID = AHA.IU_COURSE.COURSEID INNER JOIN AHA.IU_TERM ON AHA.IU_CRSSECTION.TERMID = AHA.IU_TERM.TERMID AND AHA.IU_REGISTRATION.STUDENTID = :STUDENTID">
                <SelectParameters>
                <asp:ControlParameter ControlID="ddlStudent" Name="STUDENTID" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
                </asp:SqlDataSource>
                
                <asp:GridView ID="gdCourse" runat="server" AutoGenerateColumns="False" DataSourceID="dsCourse">
                    <Columns>            
                        <asp:TemplateField HeaderText="Here are your courses" SortExpression="CourseID">
                            <ItemTemplate>
                                <asp:Label ID="lblCourse" runat="server" Text='<%# Eval("FACULTYID") + " / " + Eval("STUDENTID") + " / " + Eval("CSID") + " / " +  Eval("TERMID") + " / " + Eval("COURSEID") + " / " + Eval("TITLE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
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
