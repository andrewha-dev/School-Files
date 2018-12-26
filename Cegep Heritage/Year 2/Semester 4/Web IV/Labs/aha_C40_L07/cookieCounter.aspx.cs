using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cookieCounter : System.Web.UI.Page
{
    int clickCounter;
    DateTime dataTimeLast;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["ClickCounter"] == null)
        {
            clickCounter = 0;
        }
        else
        {
            clickCounter = Convert.ToInt16(Request.Cookies["ClickCounter"].Value);
        }

        if (Request.Cookies["DateTimeLast"] == null)
        {
            dataTimeLast = DateTime.Now;
        }
        else
        {
            dataTimeLast = Convert.ToDateTime(Request.Cookies["DateTimeLast"].Value);
        }

        if (Request.Cookies["ClickCounter"] != null)
        {
            lblResult.Text = "You clicked the button " + clickCounter + ". The last time on " + dataTimeLast.ToString("dd-MM-yyyy, hh:mm:ss");
        }
    }

    protected void btnCount1_Click(object sender, EventArgs e)
    {
        clickCounter++;
        dataTimeLast = DateTime.Now;
        HttpCookie myCookieCount = new HttpCookie("ClickCounter", clickCounter.ToString());
        HttpCookie myCookieDate = new HttpCookie("DateTimeLast", dataTimeLast.ToString());

        myCookieCount.Expires = DateTime.Now.AddDays(14);
        myCookieDate.Expires = DateTime.Now.AddDays(14);

        Response.Cookies.Add(myCookieCount);
        Response.Cookies.Add(myCookieDate);

        lblResult.Text = "You clicked the button " + clickCounter + ". The last time on " + dataTimeLast.ToString("dd-MM-yyyy, hh:mm:ss");

    }

    protected void btnCount2_Click(object sender, EventArgs e)
    {
        clickCounter += 2;
        dataTimeLast = DateTime.Now;
        HttpCookie myCookieCount = new HttpCookie("ClickCounter", clickCounter.ToString());
        HttpCookie myCookieDate = new HttpCookie("DateTimeLast", dataTimeLast.ToString());

        myCookieCount.Expires = DateTime.Now.AddDays(14);
        myCookieDate.Expires = DateTime.Now.AddDays(14);

        Response.Cookies.Add(myCookieCount);
        Response.Cookies.Add(myCookieDate);

        lblResult.Text = "You clicked the button " + clickCounter + ". The last time on " + dataTimeLast.ToString("dd-MM-yyyy, hh:mm:ss");
    }

    //Pre render will not work because it is not
    //in the response object. Therefore the object needs to set the 
    //Value inside the button clicks
}