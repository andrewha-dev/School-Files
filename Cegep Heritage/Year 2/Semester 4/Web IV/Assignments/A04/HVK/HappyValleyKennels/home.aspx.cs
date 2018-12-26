using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyValleyKennels.App_Code.BLL;

namespace HappyValleyKennels
{
    public partial class home : System.Web.UI.Page
    {
        User user;
        Pet pet;
        //Reservation reservation;
        char typeOfUser;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["UserSession"] == null)
            {


                //user = new User(123, "Andrew", "Ha", new List<Pet>(), "325 Cite Des Jeunes", "Gatineau", "Quebec", "A1A1A1", "819-123-1234", "Ha.Andrew@cegep-heritage.qc.ca", "MexWall", "Helay", "819-321-1234", App_Code.BLL.User.UserValues.Customer);
                user = new User();
                Session["UserSession"] = user;
                //typeOfUser = user.typeOfUser;
            }
            else
            {
                user = (User)Session["UserSession"];
                //typeOfUser = user.typeOfUser;
            }

       

            if (user.typeOfUser == App_Code.BLL.User.UserValues.Customer)
            {
                this.Master.FindControl("employeeNav").Visible = false;
                homePets.Visible = true;
                endingReservations.Visible = false;
                dViewActiveRes.Visible = false;
                ddlCustomerRes.Visible = true;
                ddlEmployeeRes.Visible = false;
                deetsViewCusRes.Visible = true;

            }
            else
            {
                this.Master.FindControl("customerNav").Visible = false;
                homePets.Visible = false;
                endingReservations.Visible = true;
                dViewActiveRes.Visible = true;
                ddlCustomerRes.Visible = false;
                deetsViewCusRes.Visible = false;
                ddlEmployeeRes.Visible = true;  
                hypePet.Visible = false;



            }


            //if (ddlCustomerRes.Items.Count == 0)
            //{ deetsViewCusRes.Visible = false; }
            //else
            //{ deetsViewCusRes.Visible = true; }
            ////fillFields();
        }

        protected void ddlCustomerRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["UserSessionReservation"] = ddlCustomerRes.SelectedValue;
        }

        protected void ddlEmployeeRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["UserSessionReservation"] = ddlEmployeeRes.SelectedValue;

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["UserSessionReservation"] = ddlEmployeeEnd.SelectedValue;
        }


    }

}