using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aha_C40_L08
{
    public partial class login : System.Web.UI.UserControl
    {
        public bool isSuccess { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            isSuccess = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "heritage" && txtPass.Text == "c40")
            {
                isSuccess = true;
                //changeLabel();
            }
            else
            {
                isSuccess = false;
                //changeLabel();
            }
        }

        //protected void changeLabel()
        //{
        //    if (isSuccess == true)
        //    {
        //        lblAuthorized.Text = "You are authorized";
        //    }
        //    else
        //    {
        //        lblAuthorized.Text = "You are not authorized";
        //    }
        //}

        public String Value
        {
            get { return lblAuthorized.Text; }
            set { lblAuthorized.Text = value; }
        }
    }
}