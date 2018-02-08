<%@ Page Title="" Language="C#" MasterPageFile="~/mySite.Master" AutoEventWireup="true" CodeBehind="surveycomplete.aspx.cs" Inherits="StudentInfo.surveycomplete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:panel id="isSelected" runat="server"><p>
        Thank  for completing the survey. We value your comments.
                              </p></asp:panel>
    <asp:panel id="pickedPhone" runat="server"><p>
        We will contact you by phone as soon as possible.
                              </p></asp:panel>
        <asp:panel id="pickedEmail" runat="server"><p>
        We will contact you by email as soon as possible.
                              </p></asp:panel>

    <div>
        <a href="studentsurvey.aspx">Return to the previous page</a>
    </div>

</asp:Content>
