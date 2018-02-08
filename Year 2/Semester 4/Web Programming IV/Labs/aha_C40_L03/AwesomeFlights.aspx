

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Account</title>
    <link href="styles/styles.css" rel="stylesheet" />
</head>
<body>
    <div class="topHeader">
        <p>Awesome Flights</p>
        <form id="loginForm">
            <button id="logOut">Log Out</button>
        </form>

    </div>
    <div class="wrapper">

        <div class="divNav">
            

            <div class="makeReservationDiv">
                <!-- Div for the button that takes you to the make reservation page -->
                <a class="makeReservationBtn" href="#">Make A Reservation</a>
            </div>

            <div class="navMenu">
                <!-- Div that contains the navigation menu -->
                <ul class="navList">
                    <li><a href="#">Home</a></li>
                    <li><a href="#">My Pets</a></li>
                    <li><a href="#">My Reservations</a></li>
                    <li><a href="#">My Account</a></li>

                </ul>
            </div>

        </div>

        <div class="divContent">
            <!--Div for the form content -->
            <span class="userName">Book A Flight</span>
            <div class="divForm">
                <form id="accountForm" runat="server">
                    <!-- Preparation for user's profile pictures -->
                    <div>
                        <asp:Label ID="lblProfilePicPlaceholder" runat="server" Text="Flight:"></asp:Label>

                        <div class="formFields">
                             <p>
                            <asp:Label ID="Label1" runat="server" Text="Departure:"></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Label ID="Label2" runat="server" Text="Destination: "></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </p>
                        </div>
                    </div>


                          



                    <div class="formFields">
                        <!-- Form Input Fields -->
                        <br />
                        <hr />
                        <div>
                            <asp:Label ID="lblUserInfoPlaceHolder" runat="server" Text="Date:"></asp:Label>
                        </div>
                        <p>
                            <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
                            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Label ID="lblLastName" runat="server" Text="Last Name: "></asp:Label>
                            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        </p>
                        
                    </div>

                </form>
            </div>
        </div>


    </div>

</body>
</html>
