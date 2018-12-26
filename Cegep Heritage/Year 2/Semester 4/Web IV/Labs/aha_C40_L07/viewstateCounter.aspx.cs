using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewstateCounter : System.Web.UI.Page
{
    int clickCounter;
    DateTime dataTimeLast;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["ClickCounter"] == null)
        {
            clickCounter = 0;
        }
        else
        {
            clickCounter = (int)(ViewState["ClickCounter"]);
        }

        if (ViewState["DateTimeLast"] == null)
        {
            dataTimeLast = DateTime.Now;
        }
        else
        {
            dataTimeLast = (DateTime)(ViewState["DateTimeLast"]);
        }
    }


    protected void btnCount1_Click(object sender, EventArgs e)
    {
        clickCounter++;

    }

    protected void btnCount2_Click(object sender, EventArgs e)
    {
        clickCounter += 2;
       
    }

    protected void Page_Prerender(object sender, EventArgs e)
    {
        ViewState["ClickCounter"] = clickCounter;
        if (ViewState["ClickCounter"] != null)
        {
            lblResult.Text = "You clicked the button " + clickCounter + ". The last time on " + dataTimeLast.ToString("dd-MM-yyyy, hh:mm:ss");
        }
        else
        {
            lblResult.Text = "Not Set Yet";
        }
    }
}