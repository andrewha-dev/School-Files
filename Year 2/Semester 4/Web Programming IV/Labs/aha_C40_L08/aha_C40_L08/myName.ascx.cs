using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aha_C40_L08
{
    public partial class myName : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String FirstName
        {
            set { txtFirst.Text = value; }
            get {  return txtFirst.Text; }
        }
        public String LastName
        {
            set { txtLast.Text = value; }
            get { return txtLast.Text; }
        }

        public String Count
        {
            set { txtCount.Text = value; }
            get { return txtCount.Text; }
        }
    }
}