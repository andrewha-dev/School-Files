using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyValleyKennels.App_Code.BLL;
namespace HappyValleyKennels
{
    public partial class HVK_Manage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (FindControl("signIn") != null)
                FindControl("signIn").Visible = false;
        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/default.aspx");
        }
    }
}