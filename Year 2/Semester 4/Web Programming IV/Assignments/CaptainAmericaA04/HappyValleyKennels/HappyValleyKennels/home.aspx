<%@ Page Title="Home" Language="C#" MasterPageFile="~/HVK_Manage.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="HappyValleyKennels.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formContent" runat="server">
    <div class="divContent">
        <!--Div for the form content -->
        <span class="userName">Welcome To Happy Valley Kennels</span>
        <div class="divForm">
            <form id="accountForm" runat="server">
                <div class="upcomingReservations">
                    <asp:Label ID="lblUpcomingReservation" runat="server" Text="Upcoming Reservations"></asp:Label>
                </div>

                <div class="upcomingReservationPet" runat="server">
                    <div>

                 <!--Visible
                 <span class="reserveName" id="nameReservation" runat="server">Sparly:</span> <span class="reserveStart" id="homeReserveStart" runat="server">Start Date - 10/23/2016</span><span runat="server" id="homeReserveEnd" class="reserveEnd">End Date - 11/15/2016</span>
                 <a class="viewUpcomingReservation" href="manageReservation.aspx">View Reservation</a>
                 Customer -->

        <!--List of reservations based on customer number -->

                   <asp:ObjectDataSource ID="odsCustomerRes" runat="server" SelectMethod="listReservations" TypeName="HappyValleyKennels.App_Code.Reservation">
                      <SelectParameters>
                         <asp:SessionParameter Name="_ownerNumber" SessionField="UserNumber" Type="Int32" />
                      </SelectParameters>
                   </asp:ObjectDataSource>

         <!--Selecting the given reservation based on ddl selection -->
                   <asp:ObjectDataSource ID="odsCustomerReservIn" runat="server" SelectMethod="getReservation" TypeName="HappyValleyKennels.App_Code.Reservation">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlCustomerRes" Name="_reservationNum" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>




                   <asp:DropDownList ID="ddlCustomerRes" runat="server" DataSourceID="odsCustomerRes" DataTextField="number" DataValueField="number" OnSelectedIndexChanged="ddlCustomerRes_SelectedIndexChanged" AutoPostBack="True">
                   </asp:DropDownList>

                   

        <!--Get this detail view to update based on session field -->
                        <asp:DetailsView ID="deetsViewCusRes" runat="server" AutoGenerateRows="False" DataSourceID="odsCustomerReservIn" Height="50px" Width="125px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                             <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                             <Fields>

                                 <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                                 <asp:BoundField DataField="number" HeaderText="number" SortExpression="number" />
                                 <asp:BoundField DataField="startDate" HeaderText="startDate" SortExpression="startDate" />
                                 <asp:BoundField DataField="endDate" HeaderText="endDate" SortExpression="endDate" />

                            </Fields>

                             <FooterStyle BackColor="#CCCCCC" />
                             <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                             <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                             <RowStyle BackColor="White" />

                        </asp:DetailsView>                      
 </div>        
         <!--Get the list of active reservations-->
            <asp:ObjectDataSource ID="odsActiveRes" runat="server" SelectMethod="listActiveReservations" TypeName="HappyValleyKennels.App_Code.Reservation"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="odsEmploReservIn" runat="server" SelectMethod="getReservation" TypeName="HappyValleyKennels.App_Code.Reservation">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlEmployeeRes" Name="_reservationNum" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
            <asp:DropDownList ID="ddlEmployeeRes" runat="server" DataSourceID="odsActiveRes" DataTextField="number" DataValueField="number" AutoPostBack="True" OnSelectedIndexChanged="ddlEmployeeRes_SelectedIndexChanged">
                        </asp:DropDownList>


                        <asp:DetailsView ID="dViewActiveRes" runat="server" AutoGenerateRows="False" DataSourceID="odsEmploReservIn" Height="50px" Width="125px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                                <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <Fields>

                                    <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                                    <asp:BoundField DataField="number" HeaderText="number" SortExpression="number" />
                                    <asp:BoundField DataField="startDate" HeaderText="startDate" SortExpression="startDate" />
                                    <asp:BoundField DataField="endDate" HeaderText="endDate" SortExpression="endDate" />

                            </Fields>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" />
                        </asp:DetailsView>
                        <br />
                </div>



                <br />
                <hr />

          <!--Visible for Customer -->
                <div id="homePets" runat="server">
                    <asp:Label ID="lblPetsFromOwner" runat="server" Text="Pets"></asp:Label>

                     <!--Insert Database link here or something -->



                   <!-- Cuck code
                    <div class="petsFromOwnerBlock">
                        <div class="petsFromOwnerBlockEntry">
                            <img class="petsBlockPic" src="images/dogProfilePlaceHolder.jpg" width="100" height="100" alt="Pet Profile Picture" />
                            <div class="petsBlockInfo">
                                <asp:Label ID="lblBlockPetName" runat="server" Text="Name:"></asp:Label>
                                <asp:Label ID="lblBlockPetNameGen" runat="server" Text="Sparly"></asp:Label>
                                <br />
                                <asp:Label ID="lblBlockPetGender" runat="server" Text="Gender:"></asp:Label>
                                <asp:Label ID="lblBlockPetGenderGen" runat="server" Text="Male"></asp:Label>
                                <br />


                            </div>
                            <a class="blockEditInfo" href="managePet.aspx">Edit Information</a>
                        </div>

                    </div>
                    -->
                    <asp:ObjectDataSource ID="odsCustomer" runat="server" SelectMethod="listPets" TypeName="HappyValleyKennels.App_Code.BLL.Pet">
                        <SelectParameters>
                            <asp:SessionParameter Name="_ownerNumber" SessionField="UserNumber" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>


                    <asp:DetailsView ID="dvPets" runat="server" AutoGenerateRows="False" DataSourceID="odsCustomer" Height="50px" Width="125px" AllowPaging="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                        <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <Fields>
                            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                            <asp:BoundField DataField="breed" HeaderText="breed" SortExpression="breed" />

                        
                        
                        </Fields>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                    </asp:DetailsView>
                    <asp:HyperLink ID="hypePet" runat="server" NavigateUrl="~/managePet.aspx">Edit</asp:HyperLink>
                    <br />

                </div>
          <!--for Customer -->


                <div id="endingReservations" runat="server" class="endingReservations">
                    <asp:Label ID="lblEndingReservation" runat="server" Text="Reservations Ending Today"></asp:Label>
                    <div class="upcomingReservationPet" runat="server">
                    <div>
                        
                        <asp:ObjectDataSource ID="odsReservationsToday" runat="server" SelectMethod="listReservationsEnding" TypeName="HappyValleyKennels.App_Code.Reservation"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="odbEmployeeEndIn" runat="server" SelectMethod="getReservation" TypeName="HappyValleyKennels.App_Code.Reservation">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlEmployeeEnd" Name="_reservationNum" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:DropDownList ID="ddlEmployeeEnd" runat="server" DataSourceID="odsReservationsToday" DataTextField="number" DataValueField="number" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:DetailsView ID="dvResEnding" runat="server" AutoGenerateRows="False" DataSourceID="odsReservationsToday" Height="50px" Width="125px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                            <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <Fields>
                                <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                                <asp:BoundField DataField="number" HeaderText="number" SortExpression="number" />
                                <asp:BoundField DataField="startDate" HeaderText="startDate" SortExpression="startDate" />
                                <asp:BoundField DataField="endDate" HeaderText="endDate" SortExpression="endDate" />
                            </Fields>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" />
                        </asp:DetailsView>
                        <br />
                        
                    </div>

                </div>
                </div>


            </form>
        </div>
    </div>
</asp:Content>
