using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCalc_Click(object sender, EventArgs e)
    {
        Decimal thePrincipal, theRate, theTime;

        thePrincipal = Convert.ToDecimal(txtPrincipal.Text);
        theRate = Convert.ToDecimal(txtRate.Text);
        theTime = Convert.ToDecimal(txtTime.Text);

        

        Decimal theTotal  =(thePrincipal * (1 + (theRate / 100) * theTime));

        lblTotal.Text = string.Format("{0:C}", theTotal);


    }
}