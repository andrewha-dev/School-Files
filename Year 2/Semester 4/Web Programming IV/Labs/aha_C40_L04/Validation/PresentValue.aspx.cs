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
        if (!IsPostBack) { 
            for (int i = 0; i <= 500; i += 50)
                ddlInvest.Items.Add(i.ToString());
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlInvest.Text = "50";
        txtInterest.Text = "";
        txtYears.Text = "";
        lblFuture.Text = "";
    }

    protected void btnCalc_Click(object sender, EventArgs e)
    {
        int months;
        decimal interestRate, monthlyInvestment;
        decimal futureValue;

        months = Convert.ToInt16(txtYears.Text) * 12;
        interestRate = Convert.ToDecimal(txtInterest.Text) / 12 / 100;
        monthlyInvestment = Convert.ToDecimal(ddlInvest.SelectedValue);
        futureValue = FutureValue(months, interestRate, monthlyInvestment);
        lblFuture.Text = futureValue.ToString("C");

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


}