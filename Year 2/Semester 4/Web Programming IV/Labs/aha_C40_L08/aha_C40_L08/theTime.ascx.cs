using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aha_C40_L08
{
    public enum WhatToShow
    {
        timeOnly,
        dateToo
    }
    public partial class theTime : System.Web.UI.UserControl
    {
        public WhatToShow showWhat { get; set; }
       

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Page_PreRender()
        {
            showWhat = (WhatToShow)(Session["showWhat"]);

            if (showWhat == WhatToShow.timeOnly)
            {
                lblTime.Text = DateTime.Now.ToLongTimeString();
            }
            if (showWhat == WhatToShow.dateToo)
            {
                lblTime.Text = String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now);
            }
        }
    }
}