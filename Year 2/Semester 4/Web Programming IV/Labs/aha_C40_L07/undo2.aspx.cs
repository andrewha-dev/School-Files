using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using aha_C40_L07;

public partial class undo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void btnSend_Click(object sender, EventArgs e)
    {
        ThePerson person = new ThePerson(txtBoxName.Text, txtPhone.Text, txtCity.Text);
        ViewState["person"] = person;
    }
    

    protected void btnUndo_Click(object sender, EventArgs e)
    {
        ThePerson person = new ThePerson();
        if (ViewState["person"] != null)
        {
            person = (ThePerson)ViewState["person"];
        }
        txtBoxName.Text = person.name;
        txtCity.Text = person.city;
        txtPhone.Text = person.phone;
    }
}