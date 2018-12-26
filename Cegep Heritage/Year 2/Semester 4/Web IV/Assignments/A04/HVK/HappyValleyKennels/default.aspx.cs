using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyValleyKennels;
using HappyValleyKennels.App_Code.BLL;

namespace HappyValleyKennels
{
    public partial class deafult : System.Web.UI.Page
    {
        User user;
        //Reservation reservation;
        Pet pet;
        protected void Page_Load(object sender, EventArgs e)
        {

            //Finish off the assignment  by doing sessions
            //if (Session["UserSession"] == null)
            //{
            //    Veterinarian theVet = new Veterinarian(1, "Dr. Strange", "123-123-1234", "Hardcoded street", "Vancouver", "Quebec", "Z9X8C7");
            //    user = new User(123, "Andrew", "Ha", new List<Pet>(), theVet, "325 Cite Des Jeunes", "Gatineau", "Quebec", "A1A1A1", "819-123-1234", "Ha.Andrew@cegep-heritage.qc.ca", "MexWall", "Helay", "819-321-1234", App_Code.BLL.User.UserValues.Customer);
            //    Session["UserSession"] = user;
            //}
            //else
            //{
            //    user = (User)(Session["UserSession"]);
            //}

            //if (Session["UserSessionPet"] == null)
            //{
            //    Vaccination bordertella = new Vaccination(new DateTime(2017, 1, 31), 1, "Bordetella", 'N');
            //    Vaccination distemper = new Vaccination(new DateTime(2017, 2, 20), 1, "Distemper", 'N');
            //    Vaccination hepatitis = new Vaccination(new DateTime(2017, 3, 21), 1, "Hepatitis", 'N');
            //    Vaccination parainfluenza = new Vaccination(new DateTime(2017, 4, 20), 1, "Parainfluenza", 'N');
            //    Vaccination paravirus = new Vaccination(new DateTime(2017, 5, 25), 1, "Paravirus", 'N');
            //    Vaccination rabies = new Vaccination(new DateTime(2017, 6, 16), 1, "Rabies", 'N');

            //    List<Vaccination> list = new List<Vaccination>();
            //    list.Add(bordertella);
            //    list.Add(distemper);
            //    list.Add(hepatitis);
            //    list.Add(parainfluenza);
            //    list.Add(paravirus);
            //    list.Add(rabies);
            //    pet = new Pet(123, "Sparly", 'M', 'Y', 123, list, new DateTime(2017, 1, 5), "Cocker Spaniel", 1, 'M', "Good Dog");

            //    Session["UserSessionPet"] = pet;
            //}
            //else
            //{
            //    pet = (Pet)(Session["UserSessionPet"]);
            //}

            //if (Session["UserSessionReservation"] == null)
            //{
            //    Vaccination bordertella = new Vaccination(new DateTime(2017, 1, 31), 1, "Bordetella", 'N');
            //    Vaccination distemper = new Vaccination(new DateTime(2017, 2, 20), 1, "Distemper", 'N');
            //    Vaccination hepatitis = new Vaccination(new DateTime(2017, 3, 21), 1, "Hepatitis", 'N');
            //    Vaccination parainfluenza = new Vaccination(new DateTime(2017, 4, 20), 1, "Parainfluenza", 'N');
            //    Vaccination paravirus = new Vaccination(new DateTime(2017, 5, 25), 1, "Paravirus", 'N');
            //    Vaccination rabies = new Vaccination(new DateTime(2017, 6, 16), 1, "Rabies", 'N');

            //    List<Vaccination> list = new List<Vaccination>();
            //    list.Add(bordertella);
            //    list.Add(distemper);
            //    list.Add(hepatitis);
            //    list.Add(parainfluenza);
            //    list.Add(paravirus);
            //    list.Add(rabies);
            //    pet = new Pet(123, "Sparly", 'M', 'Y', 123, list, new DateTime(2017, 1, 5), "Cocker Spaniel", 1, 'M', "Good Dog");
            //    Run run = new Run();
            //    KennelLog kennelLog = new KennelLog(new DateTime(2017, 2, 9), 123, "This dog was such a wonder at the reservation", 1);
            //    Medication med = new Medication(123, "Worms Medicine", "1 pill each day", "Apply generously", new DateTime(2017, 6, 10));
            //    List<Medication> medList = new List<Medication>();
            //    medList.Add(med);
            //    Food food = new Food(1, "Iams", 2, "Flavored", "1 cup");
            //    List<Service> servList = new List<Service>();

            //    Service serv = new Service(123, "Grooming", 7, 4);
            //    Service serv1 = new Service(123, "Walking", 5, 2);
            //    Service serv2 = new Service(123, "Medication", 1.3, 2);
            //    servList.Add(serv);
            //    servList.Add(serv1);
            //    servList.Add(serv2);
            //    PetReservation petRes = new PetReservation(pet, run, food, kennelLog, medList, servList);
            //    List<PetReservation> petResList = new List<PetReservation>();

            //    petResList.Add(petRes);
            //    reservation = new Reservation(111, user, petResList, new DateTime(2017, 3, 12), new DateTime(2017, 3, 28), 'C', new List<Discount>());

            //    Session["UserSessionReservation"] = reservation;

            //}
            //else
            //{
            //    reservation = (Reservation)(Session["UserSessionReservation"]);
            //}




        }

        protected void btnCustomer_Click(object sender, EventArgs e)
        {
            user.typeOfUser = App_Code.BLL.User.UserValues.Customer;
            Session["UserSession"] = user;
            Response.Redirect("./home.aspx");
        }

        protected void btnEmployee_Click(object sender, EventArgs e)
        {
            user.typeOfUser = App_Code.BLL.User.UserValues.Employee;
            Session["UserSession"] = user;
            Response.Redirect("./home.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            string enteredUsername = txtUsernameLogin.Text;
            string password = txtPasswordLogin.Text;
            user = user.getOwner(enteredUsername, password);

            //Invalid login for user
            if (user.number == -1)
            {
                lblError.Text = "Login Failed";
            }
            else

            //Login is successful
            if (user.number != -1)
            {
                Session["UserNumber"] = user.number;
                Session["UserSession"] = user;
                Response.Redirect("./home.aspx");
            }



        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/manageCustomer.aspx");
        }
    }
}