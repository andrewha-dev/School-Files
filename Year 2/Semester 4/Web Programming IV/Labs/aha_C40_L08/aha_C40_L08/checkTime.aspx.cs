using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aha_C40_L08
{
    public partial class checkTime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            theTime.showWhat = WhatToShow.dateToo;
             Session["showWhat"] = theTime.showWhat;
            }
            if (Session["showWhat"] == null)
            {
                Session["showWhat"] = theTime.showWhat;
            }
            
        }

        protected void btnChangeDisplay_Click(object sender, EventArgs e)
        {
            if (theTime.showWhat == WhatToShow.timeOnly)
            {
                theTime.showWhat = WhatToShow.dateToo;
                Session["showWhat"] = theTime.showWhat;
            }
                
            if (theTime.showWhat == WhatToShow.dateToo)
            {
                theTime.showWhat = WhatToShow.timeOnly;
                Session["showWhat"] = theTime.showWhat;
            }
                
        }
    }
}