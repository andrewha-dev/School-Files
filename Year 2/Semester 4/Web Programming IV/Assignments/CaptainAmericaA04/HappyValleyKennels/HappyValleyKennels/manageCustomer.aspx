<%@ Page Title="Manage Customer" Language="C#" MasterPageFile="~/HVK_Manage.Master" AutoEventWireup="true" CodeBehind="manageCustomer.aspx.cs" Inherits="HappyValleyKennels.manageAccount" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formContent" runat="server">
    <div class="divContent">
        <br />
        <!--Div for the form content -->
        <span id="userNameEmployee" runat="server" class="userName">Manage Accounts</span>
        <span id="userNameCustomer" runat="server" class="userName">My Account</span>
        <hr />
        <div class="divForm">
            <form id="accountForm" runat="server">


                    <asp:Panel ID="pnlConfirmMessage" CssClass="messageSuccess" runat="server">
                        <div>
                            <asp:Label ID="lblMessage" runat="server" Text="Success: Your account has been created. Please sign into your account in order to access it"></asp:Label>
                        </div>
                    </asp:Panel>

                <asp:ObjectDataSource ID="odsListOwners" runat="server" SelectMethod="listOwners" TypeName="HappyValleyKennels.App_Code.BLL.User" UpdateMethod="updateOwnerByNumber">
                    <UpdateParameters>
                        <asp:Parameter Name="firstName" Type="String" />
                        <asp:Parameter Name="lastName" Type="String" />
                        <asp:Parameter Name="street" Type="String" />
                        <asp:Parameter Name="city" Type="String" />
                        <asp:Parameter Name="province" Type="String" />
                        <asp:Parameter Name="postalCode" Type="String" />
                        <asp:Parameter Name="phone" Type="String" />
                        <asp:Parameter Name="email" Type="String" />
                        <asp:Parameter Name="emergencyFirstName" Type="String" />
                        <asp:Parameter Name="emergencyLastName" Type="String" />
                        <asp:Parameter Name="emergencyPhone" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:DropDownList ID="ddlListCustomer" runat="server" DataSourceID="odsListOwners" DataTextField="fullName" AppendDataBoundItems="true" DataValueField="number" AutoPostBack="True" OnSelectedIndexChanged="ddlListCustomer_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Create an account</asp:ListItem>
                </asp:DropDownList>
                

                <div class="formFields">
                    <div>
                        <asp:Label ID="lblUserInfoPlaceHolder" runat="server" Text="User Info:"></asp:Label>
                    </div>
                     <div>
                        <asp:ValidationSummary ID="valSummaryCus" runat="server" ValidationGroup="cusInfo" HeaderText="Please correct the following fields:" ForeColor="Red" />
                    </div>


                   <p>
                        <asp:Label ID="lblFirstName" CssClass="formLabel" runat="server" Text="*First Name:"></asp:Label>
                        <asp:TextBox ID="txtFirstName" runat="server" MaxLength="25"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valRequireFirstName" runat="server" ErrorMessage="First Name Is Required" Text="*" ControlToValidate="txtFirstName" Display="Dynamic" ForeColor="Red" ValidationGroup="cusInfo"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="valRegFirstName" runat="server" ErrorMessage="First name has invalid characters entered, only letters, spaces and the following characters ( ' - .) are allowed" Display="Dynamic" Text="*" ControlToValidate="txtFirstName" ValidationExpression="^[a-zA-Z '-.]+$" ValidationGroup="cusInfo" ForeColor="Red"></asp:RegularExpressionValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblLastName" CssClass="formLabel" runat="server" Text="*Last Name: "></asp:Label>
                        <asp:TextBox ID="txtLastName" runat="server" MaxLength="25"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="valRequireLastName" runat="server" ErrorMessage="Last Name Is Required" Text="*" ControlToValidate="txtLastName" Display="Dynamic" ForeColor="Red" ValidationGroup="cusInfo"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="valRegLastName" runat="server" ErrorMessage="Last name has invalid characters entered, only letters, spaces and the following characters ( ' - .) are allowed" Display="Dynamic" Text="*" ControlToValidate="txtLastName" ValidationExpression="^[a-zA-Z '-.]+$" ValidationGroup="cusInfo" ForeColor="Red"></asp:RegularExpressionValidator>
                    </p>

                    <p>
                        <asp:Label ID="lblPass" CssClass="formLabel" runat="server" Text="*Password: "></asp:Label>
                        <asp:TextBox ID="txtPass" TextMode="Password" runat="server" MaxLength="25"></asp:TextBox>
                    </p>    
                    <p>
                        <asp:Label ID="lblConfirmPass" CssClass="formLabel" runat="server" Text="*Confirm Password "></asp:Label>
                        <asp:TextBox ID="txtConfirmPass" TextMode="Password" runat="server" MaxLength="25"></asp:TextBox>
                    </p>
                    
                    

                    <p>
                        <asp:Label ID="lblEmail" CssClass="formLabel" runat="server" Text="*Email: "></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="valRegEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email not in proper format" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="cusInfo">*</asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="valCusEmailPhone" runat="server" OnServerValidate="PhoneEmailValidate" ErrorMessage="Either the email field or phone field must be filled" ValidationGroup="cusInfo" ValidateRequestMode="Inherit" Text="*" Display="Dynamic" ClientIDMode="Static" ForeColor="Red"></asp:CustomValidator>
                    </p>

                    <p>
                        <asp:Label ID="lblPhone" CssClass="formLabel" runat="server" Text="*Phone: "></asp:Label>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>                      

                        <asp:RegularExpressionValidator ID="valUserPhoneReg" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ErrorMessage="Phone number not in proper format" ForeColor="Red" ValidationExpression="^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$" ValidationGroup="cusInfo">*</asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="valCusEmailPhoneBlank" runat="server" OnServerValidate="PhoneEmailValidate" ErrorMessage="" ValidationGroup="cusInfo" ValidateRequestMode="Inherit" Text="*" Display="Dynamic" ClientIDMode="Static" ForeColor="Red"></asp:CustomValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblStreet" CssClass="formLabel" runat="server" Text="Street: "></asp:Label>
                        <asp:TextBox ID="txtStreet" runat="server" MaxLength="50" ValidationGroup="cusInfo"></asp:TextBox>
                       
                    </p>
                    <p>
                        <asp:Label ID="lblCity" runat="server" CssClass="formLabel" Text="City:"></asp:Label>
                        <asp:TextBox ID="txtCity" runat="server" MaxLength="25"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="valUserCityReg" runat="server" ControlToValidate="txtCity" Display="Dynamic" ErrorMessage="City field contains invalid characters" ForeColor="Red" ValidationExpression="[a-zA-ZÀ-ÿ0-9 -.']+" ValidationGroup="cusInfo" Text="*">*</asp:RegularExpressionValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblProvince" CssClass="formLabel" runat="server" Text="Province: "></asp:Label>
                        <asp:DropDownList ID="ddlProvince" runat="server">
                            <asp:ListItem Selected="True" Value="">-- No Province Selected --</asp:ListItem>
                            <asp:ListItem Value="ON">Ontario</asp:ListItem>
                            <asp:ListItem Value="QC">Quebec</asp:ListItem>
                        </asp:DropDownList>
                    </p>
                    <p>
                        <asp:Label ID="lblPostalCode" CssClass="formLabel" runat="server" Text="Postal Code: "></asp:Label>
                        <asp:TextBox ID="txtPostalCode" runat="server" MaxLength="7"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="valRegPostalCode" runat="server" ErrorMessage="Postal Code field contains invalid characters" ControlToValidate="txtPostalCode" ValidationGroup="cusInfo" Text="*" Display="Dynamic" ValidationExpression="^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$" ForeColor="Red"></asp:RegularExpressionValidator>
                    </p>
                    <br />
                     <br />
                    <hr  runat="server" id="hrForPets"/>
                    <div runat="server" id="viewPets"> 
                         <asp:Label ID="lblCustomerPets" runat="server" Text="Pets:"></asp:Label>
                        <br />
                          <asp:HyperLink ID="lnkEditPet"  runat="server" NavigateUrl="~/managePet.aspx">Manage Pets</asp:HyperLink>
                    </div>
                    <hr>
                    <div>
                        <asp:Label ID="lblEmerContactPlaceHolder" runat="server" Text="Emergency Contact:"></asp:Label>
                    </div>
                    <p>
                        <asp:Label ID="lblEmerFirstName" CssClass="formLabel" runat="server" Text="First Name:"></asp:Label>
                        <asp:TextBox ID="txtEmerFirstName" runat="server" MaxLength="25"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="valRegEmerFirst" runat="server" ErrorMessage="Emergency first name has invalid characters entered, only letters, spaces and the following characters ( ' - .) are allowed" Display="Dynamic" Text="*" ControlToValidate="txtEmerFirstName" ValidationExpression="^[a-zA-Z '-.]+$" ValidationGroup="cusInfo" ForeColor="Red"></asp:RegularExpressionValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblEmerLastName" CssClass="formLabel" runat="server" Text="Last Name: "></asp:Label>
                        <asp:TextBox ID="txtEmerLastName" runat="server" MaxLength="25"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="valRegEmerLast" runat="server" ErrorMessage="Emergency last name has invalid characters entered, only letters, spaces and the following characters ( ' - .) are allowed" Display="Dynamic" Text="*" ControlToValidate="txtEmerLastName" ValidationExpression="^[a-zA-Z '-.]+$" ValidationGroup="cusInfo" ForeColor="Red"></asp:RegularExpressionValidator>
                    </p>

                    <p>
                        <asp:Label ID="lblEmerPhone" CssClass="formLabel" runat="server" Text="Phone: "></asp:Label>
                        <asp:TextBox ID="txtEmerPhone" runat="server"></asp:TextBox>
                        <asp:CustomValidator ID="valEmerFirstLast" runat="server" OnServerValidate="EmerFieldsValidate" ErrorMessage="Emergency phone number must be filled out" ClientIDMode="Static" Display="Dynamic" ValidationGroup="cusInfo" ForeColor="Red">*</asp:CustomValidator>
                        <asp:RegularExpressionValidator ID="valRegEmerPhone" runat="server" ErrorMessage="Emergency Phone not in the proper format" ValidationGroup="cusInfo" ControlToValidate="txtEmerPhone" Text="*" Display="Dynamic" ForeColor="Red" ValidationExpression="^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$"></asp:RegularExpressionValidator>
                    </p>
                   
                  
                    <br />
                    <hr/>
                   
                    <p>
                        <asp:Button ID="btnCreate" CausesValidation="true" runat="server" ValidationGroup="cusInfo" Text="Sign-Up" OnClick="btnCreate_Click" />

                        <asp:Button ID="btnUpdate"  CausesValidation="true" runat="server" Text="Update" ValidationGroup="cusInfo" OnClick="btnUpdate_Click" />
                        &nbsp;<a id="cancelChange" href="#" runat="server">Cancel</a>
                    </p>
                </div>


            </form>
        </div>
    </div>

</asp:Content>
