<%@ Page Title="Manage Pet" Language="C#" MasterPageFile="~/HVK_Manage.Master" AutoEventWireup="true" CodeBehind="managePet.aspx.cs" Inherits="HappyValleyKennels.managePet" %>
<%@ Register src="Calendars.ascx" tagname="Calendars" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/managePet.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 188px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formContent" runat="server">
    <div class="divContent">
            <!--Div for the form content -->
            <span class="userName">
            <asp:Label ID="lblPetHeader" runat="server" Text="My Pets"></asp:Label>
            </span>&nbsp;<div class="divForm">
                <form id="petForm" runat="server" defaultbutton="btnEdit">
                    <p class="petNameLabel">
                        <asp:Label ID="lblPetNameHeader" runat="server" Text=""></asp:Label>
                    </p>
&nbsp;<br />
                    <div id="petContent">
                    <div id="petInfo">

                        <asp:ScriptManager ID="smCalendars" runat="server"></asp:ScriptManager>

                    <br />
                    <asp:ObjectDataSource ID="dsPetSession" runat="server" SelectMethod="listPets" TypeName="HappyValleyKennels.App_Code.BLL.Pet">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="-1" Name="_ownerNumber" SessionField="UserNumber" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <br />
                        <div id="petDDL">
                            <asp:Label ID="lblPetDDL" runat="server" Text="Select Pet:" CssClass="vaccinationLabels"></asp:Label>
                    <asp:DropDownList ID="ddlPetList" runat="server" DataSourceID="dsPetSession" DataTextField="name" DataValueField="number" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlPetList_SelectedIndexChanged">
                    <asp:ListItem Value="-1">
                    -- Select Pet --
                    </asp:ListItem>
                    </asp:DropDownList>
                   
                     <br />
                    
                        </div>
                        <hr />
                  
                    



                    <div class="formFields">
                        <!-- Form Input Fields -->
                        <br />
                        
                        <div>
                            <asp:Label ID="lblUserInfoPlaceHolder" runat="server" Text="Pet Info:"></asp:Label>
                        </div>
                        <asp:ObjectDataSource ID="dsPetFormInfo" runat="server" SelectMethod="getPet" TypeName="HappyValleyKennels.App_Code.BLL.Pet">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlPetList" DefaultValue="" Name="_petNum" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                       
                    </div>

                    </div>
                                <div class="formFields">
                        <!-- Form Input Fields -->
                        <br />
                        
                        <p>
                            <asp:Label ID="lblPetName" CssClass="formLabel" runat="server" Text="Pet Name:"></asp:Label>
                            <asp:TextBox ID="txtPetName" runat="server" MaxLength="25"></asp:TextBox>
                        </p>

                         <p>
                            <asp:Label ID="lblPetBreed" CssClass="formLabel" runat="server" Text="Breed: "></asp:Label>
                            <asp:TextBox ID="txtPetBreed" runat="server" MaxLength="50"></asp:TextBox>
                        </p>

                        <div>
                            <div>
                                <asp:Label ID="lblPetBirthday" CssClass="formLabel" runat="server" Text="Date Of Birth: "></asp:Label>
                                <uc1:Calendars ID="calBirthday" runat="server" />
            
                            </div>
                            
                        </div>
                        <p>
                            <asp:Label ID="lblPetSize" CssClass="formLabel" runat="server" Text="Size: "></asp:Label>
                            <asp:RadioButtonList ID="rdoPetSize" runat="server" ValidationGroup="petInfo">
                                <asp:ListItem Value="S">Small</asp:ListItem>
                                <asp:ListItem Value="M">Medium</asp:ListItem>
                                <asp:ListItem Value="L">Large</asp:ListItem>

                            </asp:RadioButtonList>
                        </p>

                       
                        <p>
                            <asp:Label ID="lblPetGender" CssClass="formLabel" runat="server" Text="Gender: "></asp:Label>
                            <p class="maleButton">
                                <asp:RadioButton ID="rdoGenderMale" Text="Male" runat="server" GroupName="petGender" />
                                <br />
                                <asp:RadioButton ID="rdoGenderFemale" Text="Female" runat="server" GroupName="petGender" />
                            </p>

                        </p>
                        
                        <p>
                            <asp:Label ID="lblPetFixed" CssClass="formLabel" runat="server" Text="Spayed/Fixed:"></asp:Label>
                            <p class="fixedPara">
                                <asp:CheckBox ID="chkFixed" Text=&nbsp; runat="server" />
                            </p>
                        </p>

                       
                        <br />
                        <hr />
                        <div id="petVaccinations">
                           <asp:Label ID="lblVaccinePlaceHolder"  runat="server" Text="Vaccination Info:"></asp:Label>
                            <br />
                            <br />
                        <table>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1" >
                                    &nbsp;</td>
                                <td >
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td >                                
                            <asp:Label ID="lblBordetella" runat="server" CssClass="vaccinationLabels" Text="Bordetella:"></asp:Label>
                                </td>
                                <td class="auto-style1"  >
                            <uc1:Calendars ID="calBordetella" runat="server" />                                
                                </td>
                                <td  >
                                    <asp:CheckBox ID="chkBordetella" runat="server" Text="Valid Date" ValidationGroup="vaccValidation" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                <asp:Label ID="lblDistemper" runat="server"  CssClass="vaccinationLabels" Text="Distemper:"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                <uc1:Calendars ID="calDistemper" runat="server" />       
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkDistemper" runat="server" Text="Valid Date" ValidationGroup="vaccValidation" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                <asp:Label ID="lblHepatitis" runat="server"  CssClass="vaccinationLabels" Text="Hepatitis:"></asp:Label>
                                </td>
                                <td class="auto-style1" >
                                <uc1:Calendars ID="calHepatitis" runat="server" />       
                                                           
                                </td>
                                <td >
                                    <asp:CheckBox ID="chkHepatitis" runat="server" Text="Valid Date" ValidationGroup="vaccValidation" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td >
                            <asp:Label ID="lblParainfluenza" runat="server"  CssClass="vaccinationLabels" Text="Parainfluenza:"></asp:Label>
                                </td>
                                <td class="auto-style1"  >
                                <uc1:Calendars ID="calParainfluenza" runat="server" />       
                                
                                </td>
                                <td >
                                    <asp:CheckBox ID="chkParainfluenza" runat="server" Text="Valid Date" ValidationGroup="vaccValidation" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                <asp:Label ID="lblParovirus" runat="server"  CssClass="vaccinationLabels" Text="Parovirus:"></asp:Label>
                                </td>
                                <td class="auto-style1" >
                                <uc1:Calendars ID="calParovirus" runat="server" />       
                            
                            
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkParovirus" runat="server" Text="Valid Date" ValidationGroup="vaccValidation" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                <asp:Label ID="lblRabies" runat="server"  CssClass="vaccinationLabels" Text="Rabies:"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                <uc1:Calendars ID="calRabies" runat="server" />       
                            
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkRabies" runat="server" Text="Valid Date" ValidationGroup="vaccValidation" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td class="auto-style1">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                            <br />
                            <br />
                            <div class="inline">
                                <br />
                            </div>
                        </div>
                         <p>
                             &nbsp;</p>
                    </div>

                        </div>
                    <div class="formFields">
                        <p>
                       <asp:Label ID="lblNotes" CssClass="formLabel" runat="server" Text="Notes:"></asp:Label>
                        <asp:TextBox ID="txtNotes" TextMode="MultiLine" runat="server" MaxLength="200" CssClass="floatleft"></asp:TextBox>
                    </p>
                    </div>
                    <br />
                    <asp:Button ID="btnEdit" runat="server" Text="Update" ValidationGroup="petInfo" /> 
                    
                    <hr />
                    
                </form>
            </div>
        </div>
    
</asp:Content>
