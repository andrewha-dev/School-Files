using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Others : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        lblFirstDate.Text = String.Format("{0:D}", Calendar1.SelectedDate);
        //Checking if the other calendar has a selected date
        if (Calendar2.SelectedDate.Date != DateTime.MinValue.Date)
        {
            
            calculateDays(Calendar1.SelectedDate, Calendar2.SelectedDate);
            calculateSeconds(Calendar1.SelectedDate, Calendar2.SelectedDate);
        }

    }

    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        lblSecondDate.Text = String.Format("{0:D}", Calendar2.SelectedDate);
        //Checking if the other calendar has a selected date
        if (Calendar1.SelectedDate.Date != DateTime.MinValue.Date)
        {
            lblFirstDate.Text = String.Format("{0:D}", Calendar1.SelectedDate);
            calculateDays(Calendar1.SelectedDate, Calendar2.SelectedDate);
            calculateSeconds(Calendar1.SelectedDate, Calendar2.SelectedDate);

        }

    }

    protected void calculateDays(DateTime _firstDate, DateTime _secondDate)
    {
        //Calculating date difference
        TimeSpan ts = Convert.ToDateTime(_secondDate) - Convert.ToDateTime(_firstDate);
        lblDifferenceDays.Text = Convert.ToString(ts.TotalDays);
        
    }
    protected void calculateSeconds(DateTime _firstDate, DateTime _secondDate)
    {
        //Calculating date difference
        TimeSpan ts = Convert.ToDateTime(_secondDate) - Convert.ToDateTime(_firstDate);
        lblDifferenceSeconds.Text = Convert.ToString(ts.TotalSeconds);

    }

}