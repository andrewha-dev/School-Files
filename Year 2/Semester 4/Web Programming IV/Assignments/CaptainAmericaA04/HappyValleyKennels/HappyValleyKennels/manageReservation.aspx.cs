using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyValleyKennels.App_Code.BLL;
using HappyValleyKennels.App_Code;

namespace HappyValleyKennels
{
    public partial class manageReservation : System.Web.UI.Page
    {
        Reservation reservation;
        User user;
        Pet pet;
        User.UserValues typeOfUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["UserSession"];
            typeOfUser = user.typeOfUser;
            if (typeOfUser == App_Code.BLL.User.UserValues.Customer)
            {
                this.Master.FindControl("employeeNav").Visible = false;

                if (!IsPostBack) // first time on page
                {
                    ddlRes.DataSource = objUpcomRes;

                    ddlRes.DataTextField = "PETRES";
                    ddlRes.DataValueField = "resNum";
                    ddlRes.DataBind();

                }
                //disableCheckBoxes();
            }
            else if (typeOfUser == App_Code.BLL.User.UserValues.Employee)
            {
                this.Master.FindControl("customerNav").Visible = false;

                if (!IsPostBack) // FIRST TIME
                {
                    ddlRes.DataSource = objAllUpcomRes;

                    ddlRes.DataTextField = "PETRES";
                    ddlRes.DataValueField = "resNum";
                    ddlRes.DataBind();
                }
            }
            Session["time"] = DateTime.Today;
            //if (!IsPostBack)// first time on page
            //{
            //    ddlRes.DataTextField = "petres";
            //}
            //else
            //{
            //    listOfPets.Style.Add("border", "0.15em solid black");
            //}


            //if (Session["UserSession"] != null)
            //{
            //    user = (User)Session["UserSession"];
            //    typeOfUser = user.typeOfUser;

            //}

            //else
            //{
            //    reservation = (Reservation)(Session["UserSessionReservation"]);
            //    //load reservations into ddl
            //}


            if (Request.HttpMethod == "POST")
            {


            }



        }




        protected void ddlPetsInRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPetsInRes.SelectedIndex != 0)
            {
                lblPetName.Text = ddlPetsInRes.SelectedItem.ToString() + "'s extra services";
                PetReservation petres = new PetReservation();
                List<Service> services = petres.listPetReservationServices(Convert.ToInt16(ddlPetsInRes.SelectedValue));
                foreach (Service serv in services)
                {
                    if (serv.description == "Playtime")
                        cbPlaytime.Checked = true;
                    else
                        cbPlaytime.Checked = false;
                    if (serv.description == "Walk")
                        cbWalk.Checked = true;
                    else
                        cbWalk.Checked = false;

                }
            }
            else
            {
                lblPetName.Text = "Extra services";
                cbPlaytime.Checked = false;
                cbWalk.Checked = false;
            }
        }

        protected void ddlRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRes.SelectedIndex != 0)
            {
                PetReservation petres = new PetReservation();
                List<PetReservation> petreses = petres.listPetResInfo(Convert.ToInt16(ddlRes.SelectedValue));
                String resstart = petres.resStart;
                ddlPetsInRes.Items.Clear();
                ddlPetsInRes.Items.Add(new ListItem("--Select Pet--", "0"));
                lblPetName.Text = "Extra services";
                cbPlaytime.Checked = false;
                cbWalk.Checked = false;
                calResStart.setText(petreses[0].resStart);
                calResEnd.setText(petreses[0].resEnd);

            }
        }

        protected void btnSubmitReservation_Click(object sender, EventArgs e)
        {
            Reservation res = new Reservation();
            if (!res.checkRunAvailability(Convert.ToDateTime(calResStart.getText()), Convert.ToDateTime(calResEnd.getText()), pet.size))
            {
                lblUpdated.Text = "No runs are available during that time";
            }
            int code = res.updateReservation(Convert.ToInt16(ddlRes.SelectedValue), Convert.ToDateTime(calResStart.getText()), Convert.ToDateTime(calResEnd.getText()));
            if (code == 6)
            {
                lblUpdated.Text = "Reservation updated successfully!";
            }
            else if (code == -8)
            {
                lblUpdated.Text = "Reservation could not be updated";
            }
        }
    }
}