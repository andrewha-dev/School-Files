using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Events : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        String eventName = txtEventName.Text;
        lblTableEvent.Text = "Cost Estimate for " + eventName;

        String amountOfGuests = (txtGuestAmount.Text);
        lblTableAmountGuests.Text = amountOfGuests;

        int costPerGuest = Convert.ToInt16(ddlCosts.SelectedItem.Value);
        int totalCostForGuest = Convert.ToInt16(amountOfGuests) * (costPerGuest);

        lblTotalCostGuest.Text = String.Format("{0:C}",totalCostForGuest);

        String typeOfMusic = "No music was selected";
        int musicCost = 0;
        if (rdDJ.Checked || rdLive.Checked || rdMixed.Checked)
            musicCost = 500;

        if (rdDJ.Checked)
            typeOfMusic = "DJ";
        else if (rdLive.Checked)
            typeOfMusic = "Live Music";
        else if (rdMixed.Checked)
            typeOfMusic = "Mixed";

        lblMusicCost.Text = String.Format("{0:C}", musicCost);
        lblTableMusic.Text = typeOfMusic;

        totalCostForGuest += musicCost;
        int barCost = 0;

        if (chkBar.Checked)
        {
            lblOpenBar.Text = "Open Bar";
            barCost =  Convert.ToInt16(amountOfGuests) * 30;
        }
        else
        {
            lblOpenBar.Text = "No Open Bar";
        }

        lblOpenBarCost.Text = String.Format("{0:C}",barCost);
        totalCostForGuest += barCost;

        lblTotalCost.Text = String.Format("{0:C}",totalCostForGuest);

        
    }
}