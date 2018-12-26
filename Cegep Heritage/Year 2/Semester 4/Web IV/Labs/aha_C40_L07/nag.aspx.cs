using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class nag : System.Web.UI.Page
{
    int counter;
    String name;
    String email;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblInfo.Visible = false;


        if (Request.Cookies["name"] != null && Request.Cookies["email"] != null)
        {
            lblInfo.Visible = true;
            lblInfo.Text = "Name: " + Request.Cookies["name"].Values + "<br>Email: " + Request.Cookies["name"].Values;
        }
        else
        {
            if (Request.Cookies["nagCount"] == null)
            {

                HttpCookie myCookie = new HttpCookie("nagCount", "0");
                myCookie.Expires = DateTime.Now.AddDays(14);
                Response.Cookies.Add(myCookie);
            }
            else
            {
                counter = Convert.ToInt16(Request.Cookies["nagCount"].Value);
                counter++;
                HttpCookie myCookie = new HttpCookie("nagCount", counter.ToString());
                myCookie.Expires = DateTime.Now.AddDays(14);
                Response.Cookies.Add(myCookie);
            }

            if (counter % 5 == 0)
            {
                lblCount.Text = "Please register man " + counter;
            }
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Cookies["nagCount"].Expires = DateTime.Now.AddDays(-1);
        name = txtName.Text;
        email = txtEmail.Text;
        lblCount.Visible = false;

        HttpCookie nameCookie = new HttpCookie("name", name);
        nameCookie.Expires = DateTime.Now.AddDays(14);
        Response.Cookies.Add(nameCookie);

        HttpCookie emailCookie = new HttpCookie("email", name);
        emailCookie.Expires = DateTime.Now.AddDays(14);
        Response.Cookies.Add(emailCookie);


    }
}