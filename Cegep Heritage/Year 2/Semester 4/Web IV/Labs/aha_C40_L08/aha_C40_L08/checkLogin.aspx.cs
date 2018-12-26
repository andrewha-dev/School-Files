using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aha_C40_L08
{
    public partial class checkLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (login.isSuccess == true)
            {
                login.Value = "You are authorized";
            }
            else
            {
                login.Value = "You are not authorized";
            }
        }
    }
}