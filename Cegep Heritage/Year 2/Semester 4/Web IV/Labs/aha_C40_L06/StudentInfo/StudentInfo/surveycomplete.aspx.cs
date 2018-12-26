using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace StudentInfo
{
    public partial class surveycomplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["contact"] == "rdoContactEmail")
                    pickedPhone.Visible = false;
                if (Request.Form["contact"] == "rdoContactPhone")
                    pickedEmail.Visible = false;

            }
        }
    }
}