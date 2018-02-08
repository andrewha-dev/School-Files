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
        if (!IsPostBack)
        {
            for (int i = 1; i <= 4; i++)
            {
                ddlAdults.Items.Add(i.ToString());
            }
            for (int i = 0; i <= 4; i++)
            {
                ddlChildren.Items.Add(i.ToString());
            }

            rdoStandard.Checked = true;
            rdoKing.Checked = true;
        }

        valDateRange.MinimumValue = DateTime.Today.ToShortDateString();
        valDateRange.MaximumValue = DateTime.Today.AddMonths(6).ToShortDateString();


    }

    protected void ibtnCalendar_Click(object sender, ImageClickEventArgs e)
    {
        ibtnCalendar.Visible = false;
        calArrival.Visible = true;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "Thank you for your request.<br />We will get back to you within 24 hours.";
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
       // txtArrivalDate.Text = DateTime.Now.ToShortDateString();
        txtNights.Text = "";
        ddlAdults.SelectedIndex = -1;
        ddlChildren.SelectedIndex = -1;
        rdoStandard.Checked = true;
        rdoKing.Checked = true;
        chkSmoking.Checked = false;
        txtSpecialRequests.Text = "";
        txtName.Text = "";
        txtEmail.Text = "";
        lblMessage.Text = "";
    }
    protected void calArrival_SelectionChanged(object sender, EventArgs e)
    {
        txtArrivalDate.Text = calArrival.SelectedDate.ToShortDateString();
        calArrival.Visible = false;
        ibtnCalendar.Visible = true;
    }

}