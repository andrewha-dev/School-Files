using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyValleyKennels;
using HappyValleyKennels.App_Code.BLL;
using System.Globalization;

namespace HappyValleyKennels
{
    public partial class managePet : System.Web.UI.Page
    {
        //Pet pet = new Pet(123, "Sparly", 'M', 'Y', 123, makeVaccineList(), new DateTime(2017, 1, 5), "Cocker Spaniel", 1, 'M', "Good Dog");
        User user = new User();
        List<Pet> petList;
        List<Vaccination> vaccList;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserSession"] != null)
                user = (User)Session["UserSession"];
            else
                Session["UserSession"] = user;

            if(user.typeOfUser == App_Code.BLL.User.UserValues.Employee)
            {
              
                lblPetHeader.Text = "Pets";
                chkBordetella.Visible = true;
                chkDistemper.Visible = true;
                chkHepatitis.Visible = true;
                chkParainfluenza.Visible = true;
                chkParovirus.Visible = true;
                chkRabies.Visible = true;
            }
            else if(user.typeOfUser == App_Code.BLL.User.UserValues.Customer)
            {
                lblPetHeader.Text = "My Pets";
                chkBordetella.Visible = false;
                chkDistemper.Visible = false;
                chkHepatitis.Visible = false;
                chkParainfluenza.Visible = false;
                chkParovirus.Visible = false;
                chkRabies.Visible = false;
            }

            txtPetName.Text = "";
            txtPetBreed.Text = "";
            calBirthday.setText("");
            txtNotes.Text = "";
            rdoGenderFemale.Checked = false;
            rdoGenderMale.Checked = false;

        }


        protected void ddlPetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayVaccinations();
            displayNotes();
        }
        public void displayNotes()
        {
            Pet pet = new Pet();
            if (Session["UserNumber"] != null)
            {
                //Get List of Pet(s) for owner
                petList = pet.listPets(Convert.ToInt16(Session["UserNumber"]));
                for (int i = 0; i < petList.Count; i++)
                {
                    if (petList[i].name == ddlPetList.SelectedItem.ToString())
                    {
                        txtPetName.Text = petList[i].name;
                        txtPetBreed.Text = petList[i].breed;
                        if(petList[i].birthdate != null)
                        calBirthday.setText(petList[i].birthdate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
                        rdoPetSize.SelectedValue = petList[i].size.ToString();
                        txtNotes.Text = petList[i].notes;
                        if(petList[i].gender == 'M')
                        {
                            rdoGenderMale.Checked = true;
                            rdoGenderFemale.Checked = false;

                        }
                        else if(petList[i].gender == 'F')
                        {
                            rdoGenderMale.Checked = false;
                            rdoGenderFemale.Checked = true;
                        }
                        if(petList[i].fixedPet == 'T')
                        {
                            chkFixed.Checked = true;
                        }
                        else if(petList[i].fixedPet == 'F')
                        {
                            chkFixed.Checked = false;
                        }
                    }
                }
            }
        }
        public void displayVaccinations()
        {
            Vaccination vacc;
            vacc = new Vaccination();
            Pet pet = new Pet();
            if (Session["UserNumber"] != null)
            {
                //Get List of Pet(s) for owner
                petList = pet.listPets(Convert.ToInt16(Session["UserNumber"]));
                //Loop through list to find the pet the owner selected in order to get the corresponding list of vaccination for that pet
                for (int i = 0; i < petList.Count; i++)
                {
                    if (petList[i].name == ddlPetList.SelectedItem.ToString())
                    {
                        //vaccList is the specific vaccinations for a specific pet.
                        vaccList = vacc.listVaccinations(Convert.ToInt16(ddlPetList.SelectedValue));
                    }
                }
                if(vaccList != null )
                {
                    if (vaccList.Count <= 0)
                    {
                        calBordetella.setText("");
                        calDistemper.setText("");
                        calHepatitis.setText("");
                        calParainfluenza.setText("");
                        calParovirus.setText("");
                        calRabies.setText("");
                    }
                    else
                    {     //Set Textboxes to have proper vaccination dates
                        for (int i = 0; i < vaccList.Count; i++)
                        {
                            switch (vaccList[i].name)
                            {
                                case "Bordetella":
                                    calBordetella.setText(vaccList[i].expiryDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
                                    break;
                                case "Distemper":
                                    calDistemper.setText(vaccList[i].expiryDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
                                    break;
                                case "Hepatitis":
                                    calHepatitis.setText(vaccList[i].expiryDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
                                    break;
                                case "Parainfluenza":
                                    calParainfluenza.setText(vaccList[i].expiryDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
                                    break;
                                case "Parovirus":
                                    calParovirus.setText(vaccList[i].expiryDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
                                    break;
                                case "Rabies":
                                    calRabies.setText(vaccList[i].expiryDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
                                    break;
                            }
                        }


                    }

                }//end if for vacc
            
                else
                {
                    calBordetella.setText("");
                    calDistemper.setText("");
                    calHepatitis.setText("");
                    calParainfluenza.setText("");
                    calParovirus.setText("");
                    calRabies.setText("");
                }
            }
        }
    }
}