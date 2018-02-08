using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyValleyKennels.App_Code.BLL;
namespace HappyValleyKennels
{
    public partial class manageAccount : System.Web.UI.Page
    {
       
        User user = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
            viewPets.Visible = false;
            pnlConfirmMessage.Visible = false;
            //Updating the user object
            if (Session["UserSession"] == null)
            {
                Session["UserSession"] = user;
                if (user.typeOfUser == App_Code.BLL.User.UserValues.Employee)
                {
                    user.number = 0;
                    user.typeOfUser = App_Code.BLL.User.UserValues.Employee;
                }
                
            }
            else
            {
                if (Session["UserSession"] != null)
                    user = (User)Session["UserSession"];
                
                //Resetting information for the clerk
                if (user.typeOfUser == App_Code.BLL.User.UserValues.Employee &&
                    ddlListCustomer.SelectedIndex == 0)
                {
                    user = new User();
                    user.typeOfUser = App_Code.BLL.User.UserValues.Employee;
                    user.number = 0;
                }

                
            }

            String masterID = "ctl00$formContent$";
            if (Request.HttpMethod == "POST")
            {
                Session["UserSession"] = new User(user.number, Request.Form[masterID + "txtFirstName"], Request.Form[masterID + "txtLastName"], new List<Pet>(),
                Request.Form[masterID + "txtStreet"], Request.Form[masterID + "txtCity"], Request.Form[masterID + "ddlProvince"], Request.Form[masterID + "txtPostalCode"], Request.Form[masterID + "txtPhone"],
                Request.Form[masterID + "txtEmail"], Request.Form[masterID + "txtEmerFirstName"], Request.Form[masterID + "txtEmerLastName"], Request.Form[masterID + "txtEmerPhone"], user.typeOfUser);
                //A clerk will have a temporary user session created, for whichever user they are editing
                if (user.number == 0)
                {
                    Session["UserSessionTemp"] = Session["UserSession"];
                }
            }

            if (user.typeOfUser == App_Code.BLL.User.UserValues.Customer)
            {
                this.Master.FindControl("customerNav").Visible = true;
                this.Master.FindControl("employeeNav").Visible = false;
                userNameEmployee.Visible = false;
                ddlListCustomer.Visible = false;
                viewPets.Visible = false;
                hrForPets.Visible = false;

                //If it is a customer creating an account
                if (user.number == -1)
                {
                    this.Master.FindControl("divNav").Visible = false;
                    viewPets.Visible = false;
                    hrForPets.Visible = false;
                    userNameCustomer.InnerText = "Sign-Up For An Account";
                    btnUpdate.Visible = false;
                    btnCreate.Visible = true;
                    
                    
                    

                }
                else
                {
                    btnUpdate.Visible = true;
                    btnCreate.Visible = false;
                }

            }
            //If it is a Clerk
            else
            {
                this.Master.FindControl("customerNav").Visible = false;
                this.Master.FindControl("employeeNav").Visible = true;
                userNameCustomer.Visible = false;
                if (ddlListCustomer.SelectedValue == "-1")
                {
                    lblUserInfoPlaceHolder.Text = "Create An Account:";
                    btnUpdate.Visible = false;
                    btnCreate.Visible = true;
                    hrForPets.Visible = false;
                }
                else
                {
                    lblUserInfoPlaceHolder.Text = "Customer's Account:";
                    viewPets.Visible = true;
                    hrForPets.Visible = true;
                    btnCreate.Visible = false;
                    btnUpdate.Visible = true;
                }

            }
            

        }

        protected void fillFields(User _userToFill)
        {
            User user = _userToFill;
            txtFirstName.Text = user.firstName;
            txtLastName.Text = user.lastName;
            txtEmail.Text = user.email;
            txtPhone.Text = user.phone;
            txtStreet.Text = user.street;
            txtCity.Text = user.city;
            ddlProvince.SelectedValue = user.province;
            txtPostalCode.Text = user.postalCode;
            txtEmerFirstName.Text = user.emergencyFirstName;
            txtEmerLastName.Text = user.emergencyLastName;
            txtEmerPhone.Text = user.emergencyPhone;


        }
        protected void PhoneEmailValidate(object source, ServerValidateEventArgs args)
        {
             args.IsValid = (txtEmail.Text.Trim().Length > 0) || (txtPhone.Text.Trim().Length > 0);
        }

        protected void EmerFieldsValidate(object source, ServerValidateEventArgs args)
        {
             args.IsValid = (txtEmerFirstName.Text.Trim().Length > 0 && txtEmerPhone.Text.Trim().Length > 0) || (txtEmerLastName.Text.Trim().Length > 0 && txtEmerPhone.Text.Trim().Length > 0) || (txtEmerFirstName.Text.Trim().Length > 0 && txtEmerLastName.Text.Trim().Length > 0 && txtEmerPhone.Text.Trim().Length > 0) || (txtEmerLastName.Text.Trim().Length > 0 && txtEmerPhone.Text.Trim().Length > 0) || (txtEmerFirstName.Text.Trim().Length == 0 && txtEmerLastName.Text.Trim().Length == 0 && txtEmerPhone.Text.Trim().Length > 0) || (txtEmerFirstName.Text.Trim().Length == 0 && txtEmerLastName.Text.Trim().Length == 0 && txtEmerPhone.Text.Trim().Length == 0);
        }

      

        protected void ddlListCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["UserNumber"] = ddlListCustomer.SelectedValue;
            if(ddlListCustomer.SelectedIndex == 0)
            {
                viewPets.Visible = false;
                //Resetting back to employee
                User employee = new User();
                employee.number = 0;
                employee.typeOfUser = App_Code.BLL.User.UserValues.Employee;
                Session["UserSession"] = employee;

            }
            else if(ddlListCustomer.SelectedIndex != 0)
            {
                viewPets.Visible = true;
                Session["UserNumber"] = ddlListCustomer.SelectedValue;
                int userFillNum = int.Parse(ddlListCustomer.SelectedValue);
                User userToFill = user.getOwnerByNumber(userFillNum);
                Session["UserSessionTemp"] = userToFill;
                user = userToFill;
                user.number = 0;
                user.typeOfUser = App_Code.BLL.User.UserValues.Employee;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (user.number == -1)
            {
                this.Master.FindControl("logOut").Visible = false;
                this.Master.FindControl("signIn").Visible = true;
            }

            if (user.number != 0 || user.typeOfUser == App_Code.BLL.User.UserValues.Customer)
            {
                user = (User)Session["UserSession"];                
                fillFields(user);
            } 

            
            else
            {
                User userToFill = new User();
                if (Session["UserNumber"].ToString() != "0" && ddlListCustomer.SelectedIndex != 0)
                {
                    userToFill = (User)Session["UserSessionTemp"];
                    int userFillNum = int.Parse((Session["UserNumber"].ToString()));
                    
                    
                }
                else
                {
                    //Resetting the clerk info, if they aren't selecting a client
                    
                    
                    userToFill = (User)Session["UserSession"];

                        //userToFill = new User();
                        userToFill.number = 0;
                        userToFill.typeOfUser = App_Code.BLL.User.UserValues.Employee;

                    
                    
                }

                fillFields(userToFill);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int statusCode = 0;
            Page.Validate();
            if (Page.IsValid)
            {
                User update = new User();
                //Check to see if its an employee first
                if (user.typeOfUser == App_Code.BLL.User.UserValues.Employee)
                {
                    update = (User)Session["UserSessionTemp"];
                    
                    update.number = int.Parse(Session["UserNumber"].ToString());
                    user = update;
                    user.number = 0;
                    user.typeOfUser = App_Code.BLL.User.UserValues.Employee;


                    int updateNumber = int.Parse(Session["UserNumber"].ToString());
                    statusCode = update.updateOwnerByNumber(updateNumber, update.firstName,
                                                    update.lastName, update.street,
                                                    update.city, update.province,
                                                    update.postalCode, update.phone,
                                                    update.email, update.emergencyFirstName,
                                                    update.emergencyLastName,
                                                    update.emergencyPhone);
                }
                //It is a customer wanting to update
                else
                {
                    update = (User)Session["UserSession"];
                    //Setting user object to the object to being updated
                    user = update;
                    statusCode = update.updateOwnerByNumber(update.number, update.firstName,
                                                    update.lastName, update.street,
                                                    update.city, update.province,
                                                    update.postalCode, update.phone,
                                                    update.email, update.emergencyFirstName,
                                                    update.emergencyLastName,
                                                    update.emergencyPhone);
                }
                
                //If statusCode account has been created
                if (statusCode == 0)
                {
                    if (user.typeOfUser == App_Code.BLL.User.UserValues.Customer)
                    {
                        pnlConfirmMessage.Visible = true;
                        lblMessage.Text = "Success: Your Account has been sucessfully updated.";
                    }
                    else
                    {
                        pnlConfirmMessage.Visible = true;
                        lblMessage.Text = "Success: Customer account has been successfully updated";
                        
                    }
                    
                }
                else
                {
                    if (user.typeOfUser == App_Code.BLL.User.UserValues.Customer)
                    {
                        pnlConfirmMessage.Visible = true;
                        pnlConfirmMessage.CssClass = "messageFailed";
                        lblMessage.Text = "Error: There has been an updating your account. Status Code ( " + statusCode + " ) ";
                    }
                    else
                    {
                        pnlConfirmMessage.Visible = true;
                        pnlConfirmMessage.CssClass = "messageFailed";
                        lblMessage.Text = "Error: There has an issue updating the customer's account. Status Code ( " + statusCode + " ) ";
                    }
                }


            }

            
        }

        //When request is to create an account
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            int statusCode = 0;
            Page.Validate();

            if (Page.IsValid)
            {

                user = (User)Session["UserSession"];
                //Creating the account for the user

                //If its a non-clerk
                if (user.typeOfUser == App_Code.BLL.User.UserValues.Customer)
                {
                    statusCode = user.createCustomer(user.firstName, user.lastName,
                           user.street, user.city, user.province, user.postalCode,
                           user.phone, user.email,
                           user.emergencyFirstName, user.emergencyLastName,
                           user.emergencyPhone);

                }
                //If it is a clerk creating the account
                else
                {
                    //Extra logic checking to make sure that the clerk wants to 
                    //Add a new customer
                    if (ddlListCustomer.SelectedValue == "-1")
                    {
                        statusCode = user.createCustomer(user.firstName, user.lastName,
                            user.street, user.city, user.province, user.postalCode,
                            user.phone, user.email,
                            user.emergencyFirstName, user.emergencyLastName,
                            user.emergencyPhone);

                        //Refresh the dropdown
                        ddlListCustomer.Items.Clear();
                        ddlListCustomer.Items.Add(new ListItem("Create an Account", "-1"));
                        ddlListCustomer.DataBind();


                    }
                }

                

                //Display successful add message
                if (statusCode == 0)
                {
                    //If it was a new customer creating the account
                    if (user.typeOfUser == App_Code.BLL.User.UserValues.Customer)
                    {


                        //Display Message Informing of successful add
                        //Requesting redirect to sign in website
                        pnlConfirmMessage.Visible = true;

                        //Clear the fields
                        Session["UserSession"] = new User();


                    }
                    else
                    {
                        pnlConfirmMessage.Visible = true;
                        lblMessage.Text = "Success: Customer account has been created.";
                        user = new User();
                        user.number = 0;
                        user.typeOfUser = App_Code.BLL.User.UserValues.Employee;
                        Session["UserSession"] = user;
                    }
                    


                    //Display message for user of success

                }
                //Method returned an error
                else
                {
                    if (user.typeOfUser == App_Code.BLL.User.UserValues.Customer)
                    {
                        pnlConfirmMessage.Visible = true;
                        pnlConfirmMessage.CssClass = "messageFailed";
                        lblMessage.Text = "Error: There has been an issue signing up. Status Code ( " + statusCode + " ) ";
                    }
                    else
                    {
                        pnlConfirmMessage.Visible = true;
                        pnlConfirmMessage.CssClass = "messageFailed";
                        lblMessage.Text = "Error: There has an issue creating a new account. Status Code ( " + statusCode + " ) ";
                    }
                    
                }
            }
        }


    }
}