using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aha_C40_L08
{
    public partial class sayHello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            lblSayHello.Text = "";
            if (myName.Count != "" && myName.FirstName != "" && myName.LastName != "")
            {
            String count = (myName.Count);
            String first = myName.FirstName;
            String last = myName.LastName;

            int loopCount = 0;
                loopCount = Convert.ToInt32(count);
            for (int i = 0; i < loopCount; i++)
            {
                lblSayHello.Text += first + " " +  last + " is awesome!<br/>";
            }
            }
           

        }
    }
}