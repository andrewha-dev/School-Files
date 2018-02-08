using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class undo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void btnSend_Click(object sender, EventArgs e)
    {
        ViewState["Name"] = txtBoxName.Text;
        ViewState["Phone"] = txtPhone.Text;
        ViewState["City"] = txtCity.Text;
    }

    protected void btnUndo_Click(object sender, EventArgs e)
    {
        txtBoxName.Text = (String)ViewState["Name"];
        txtCity.Text = (String)ViewState["City"];
        txtPhone.Text = (String)ViewState["Phone"];
    }
}