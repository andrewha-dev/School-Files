<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StumbleInn.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Reservations</title>
    <link href="styles/Main.css" rel="stylesheet" type="text/css" />
    <link href="styles/Request.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnSubmit" defaultfocus="txtArrivalDate">
    <div id="page">
    
        <h1>Stumble Inn and Suites</h1>
        <h2>Where you&rsquo;re always treated like royalty</h2>
        <p id="arrival_date">
            Arrival date:&nbsp;
            <asp:TextBox ID="txtArrivalDate" runat="server" Width="75px">mm/dd/yyyy</asp:TextBox>&nbsp;
            <asp:ImageButton ID="ibtnCalendar" runat="server" 
                ImageUrl="./images/Calendar.bmp" ImageAlign="Top" 
                onclick="ibtnCalendar_Click" CausesValidation="False"  />
        </p><asp:RequiredFieldValidator ID="valRequireArrival" runat="server" ErrorMessage="Arrival Date Is Required" ControlToValidate="txtArrivalDate" Display="Dynamic" CssClass="validator" InitialValue="mm/dd/yyyy">*</asp:RequiredFieldValidator><asp:CompareValidator ID="valCompareDate" runat="server" ErrorMessage="A Date Must Be Entered" ControlToValidate="txtArrivalDate" CssClass="validator" Display="Dynamic" Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
        <asp:RangeValidator ID="valDateRange" runat="server" ErrorMessage="Date is out of range " ControlToValidate="txtArrivalDate" CssClass="validator" Display="Dynamic" MaximumValue="0" MinimumValue="0" Type="Date">*</asp:RangeValidator>
        <p>
            <asp:Calendar ID="calArrival" runat="server" Visible="False" OnSelectionChanged="calArrival_SelectionChanged"></asp:Calendar>
        </p>
        <p class="clear">
            Number of nights:&nbsp; 
            <asp:TextBox ID="txtNights" runat="server" Width="45px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valRequireNumberNights" runat="server" ErrorMessage="Number Of Nights Must Be Filled Out" ControlToValidate="txtNights" Display="Dynamic" CssClass="validator">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="valNumberOfNights" runat="server" ErrorMessage="Number of nights must be 1 or greater" ControlToValidate="txtNights" CssClass="validator" Display="Dynamic" Operator="GreaterThanEqual">*</asp:CompareValidator>
        </p>
        <p>
            Number of adults:&nbsp;
            <asp:DropDownList ID="ddlAdults" runat="server" Width="50px">
            </asp:DropDownList>&nbsp;&nbsp;
            Children:&nbsp;
            <asp:DropDownList ID="ddlChildren" runat="server" Width="50px">
            </asp:DropDownList>
        </p>
        <h3>Preferences</h3>
        <p>
            Room type:&nbsp;
            <asp:RadioButton ID="rdoBusiness" runat="server" Text="Business" 
                GroupName="Room" />&nbsp;
            <asp:RadioButton ID="rdoSuite" runat="server" Text="Suite" GroupName="Room" />&nbsp;
            <asp:RadioButton ID="rdoStandard" runat="server" Text="Standard" 
                GroupName="Room" />
        </p>
        <p>
            Bed type:&nbsp;
            <asp:RadioButton ID="rdoKing" runat="server" Text="King" 
                GroupName="Bed" />&nbsp;
            <asp:RadioButton ID="rdoDouble" runat="server" Text="Double Double" 
                GroupName="Bed" />
        </p>
        <p>
            <asp:CheckBox ID="chkSmoking" runat="server" Text="Smoking" />
        </p>
        <p id="requests">Special requests:</p>
        <p>
            <asp:TextBox ID="txtSpecialRequests" runat="server" Rows="4" TextMode="MultiLine" 
                Width="250px"></asp:TextBox>
        </p>
        <h3 class="clear">Contact information</h3>
        <p class="contact">Name:</p>
        <p><asp:TextBox ID="txtName" runat="server" Width="320px"></asp:TextBox><asp:RequiredFieldValidator ID="valRequireName" runat="server" ErrorMessage="Name is required" ControlToValidate="txtName" Display="Dynamic" CssClass="validator">*</asp:RequiredFieldValidator></p>
        <p class="contact">Email:</p>
        <p><asp:TextBox ID="txtEmail" runat="server" Width="320px"></asp:TextBox><asp:RequiredFieldValidator ID="valRequireEmail" runat="server" ErrorMessage="Email is required" ControlToValidate="txtEmail" Display="Dynamic" CssClass="validator">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="valEmail" runat="server" ErrorMessage="Inproper email format entered" ControlToValidate="txtEmail" CssClass="validator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic">*</asp:RegularExpressionValidator></p>
        <p id="buttons">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="80px" 
                onclick="btnSubmit_Click" />&nbsp;
            <asp:Button ID="btnClear" runat="server" Text="Clear" Width="80px" 
                onclick="btnClear_Click" CausesValidation="False" />
        </p>
        <p id="message">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <asp:ValidationSummary ID="valErrorMessages" runat="server" HeaderText="There were issues with the following fields:" CssClass="validator" />
    </div>
    </form>
</body>
</html>
