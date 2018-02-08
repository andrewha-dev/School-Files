using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aha_C40_L08
{
    public partial class ListPicker : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddAll_Click(object sender, EventArgs e)
        {
            lstSelected.SelectedIndex = -1;
            foreach (ListItem li in lstAvailable.Items)
            {
                AddItem(li);
            }

        }

        protected void btnAddOne_Click(object sender, EventArgs e)
        {
            if (lstAvailable.SelectedIndex >= 0)
            {
                AddItem(lstAvailable.SelectedItem);
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelected.SelectedIndex >= 0)
            {
                lstSelected.Items.RemoveAt(lstSelected.SelectedIndex);
                lstSelected.SelectedIndex = -1;
            }

        }

        protected void AddItem(ListItem li)
        {
            lstSelected.SelectedIndex = -1;
            lstSelected.Items.Add(li);
        }

    }
}