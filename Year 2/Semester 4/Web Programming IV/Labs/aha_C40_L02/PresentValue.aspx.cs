using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentValue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        for(int i = 50; i <= 500; i+= 50)
        {
            ddlInvest.Items.Add(Convert.ToString(i));
        }
        //It is because when a postback is called, the page is reloaded again
    }

    protected void ddlInvest_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlInvest.Text = "50";
        txtInterest.Text = "";
        txtYears.Text = "";
        lblFuture.Text = "";
    }

    protected decimal FutureValue(int months, decimal interestRate, decimal monthlyInvestment)
    {
        decimal calcValue = 0;

        for (int i = 1; i <= months; i++)
        {
            calcValue = (calcValue + monthlyInvestment) * (1 + interestRate);
        }
        return calcValue;
    }

    protected void btnCalc_Click(object sender, EventArgs e)
    {
        int months = Convert.ToInt16(txtYears.Text) * 12;
        decimal interestRate = Convert.ToDecimal(txtInterest.Text) / 12 / 100;
        decimal monthlyInvestment = Convert.ToDecimal(ddlInvest.Text);
        decimal theResult = FutureValue(months, interestRate, monthlyInvestment);

        lblFuture.Text = String.Format("{0:C}", (theResult));

        
    }
}