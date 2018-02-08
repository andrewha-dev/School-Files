<%@ Page Title="Manage Reservation" Language="C#" MasterPageFile="~/HVK_Manage.Master" AutoEventWireup="true" CodeBehind="manageReservation.aspx.cs" Inherits="HappyValleyKennels.manageReservation" %>

<%@ Register Src="petServices.ascx" TagName="petServices" TagPrefix="uc1" %>

<%@ Register src="Calendars.ascx" tagname="Calendars" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/manageReservation.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 51px;
            height: 24px;
        }

        .auto-style2 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formContent" runat="server">
    <div class="divContent">
        <!--Div for the form content -->
        <span class="userName">Manage Reservation</span>
        <div class="divForm">
            <form id="reservationForm" runat="server">
                <asp:ObjectDataSource ID="objUpcomRes" runat="server" SelectMethod="listUpcomingReservations" TypeName="HappyValleyKennels.App_Code.BLL.PetReservation">
                    <SelectParameters>
                        <asp:SessionParameter Name="Ownernum" SessionField="UserNumber" Type="Int32" DefaultValue="" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="objPetRes" runat="server" SelectMethod="listPetResInfo" TypeName="HappyValleyKennels.App_Code.BLL.PetReservation">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlRes" Name="resnum" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="objAllUpcomRes" runat="server" SelectMethod="listAllUpcomingReservations" TypeName="HappyValleyKennels.App_Code.BLL.PetReservation"></asp:ObjectDataSource>
                <asp:ScriptManager ID="smManageReservation" runat="server">
                </asp:ScriptManager>
                <br />
                <asp:ObjectDataSource ID="objPetResServ" runat="server" SelectMethod="listPetReservationServices" TypeName="HappyValleyKennels.App_Code.BLL.PetReservation">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlPetsInRes" Name="petRes" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
                <div id="resselect">
                    <asp:Label ID="lblSelect" runat="server" Text="Select reservation you wish to view"></asp:Label>
                    <asp:DropDownList ID="ddlRes" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlRes_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Select Reservation--</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />
                <div id="divResStart">
                    <h2>Starting on:</h2>
                    <uc2:Calendars ID="calResStart" runat="server" />
                </div>
                <div id="divResEnd">
                    <h2>Ending on:</h2>
                    <uc2:Calendars ID="calResEnd" runat="server" />
                </div>
                <br />
                <br />
                <br />
                <div id="listOfPets" runat="server">
                    <div class="petEntry" runat="server">
                        Select pet in reservation<br />
                        <asp:DropDownList ID="ddlPetsInRes" runat="server" DataSourceID="objPetRes" DataTextField="petres" DataValueField="resNum" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlPetsInRes_SelectedIndexChanged">
                            <asp:ListItem Value="0">--Select Pet--</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                    <div id="petResServTable">
                        <table>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblPetName" runat="server" Text="Extra services"></asp:Label>
                                </td>
                                <tr>
                                <td class="auto-style1">

                                    <asp:Label ID="lblPlaytime" runat="server" Text="Playtime"></asp:Label>

                                </td>
                                <td class="auto-style2">

                                    <asp:CheckBox ID="cbPlaytime" runat="server" />

                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">

                                    <asp:Label ID="lblWalk" runat="server" Text="Walk"></asp:Label>

                                </td>
                                <td class="auto-style2">

                                    <asp:CheckBox ID="cbWalk" runat="server" />

                                </td>
                            </tr>
                        </table>
                        </div>

                </div>
                <div class="petReservationFormField">
                </div>
                <asp:Label ID="lblUpdated" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btnSubmitReservation" runat="server" Text="Update" ValidationGroup="resInfo" OnClick="btnSubmitReservation_Click" />
            </form>
        </div>
    </div>
</asp:Content>
