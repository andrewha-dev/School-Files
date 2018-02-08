using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aha_C40_L08
{
    public partial class firstAjax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAjax_Click(object sender, EventArgs e)
        {
            lblAjax.Text = DateTime.Now.ToShortDateString();
        }

        protected void btnNoAjax_Click(object sender, EventArgs e)
        {
            lblAjax.Text = DateTime.Now.ToShortDateString();
            lblNoAjax.Text = DateTime.Now.ToShortDateString();
        }
    }
}