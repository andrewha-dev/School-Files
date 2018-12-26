using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aha_C40_L08.styles
{
    public partial class ListPicker2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddAll_Click(object sender, EventArgs e)
        {
            lblAvErr.Text = "";
            if (lstAvailable.Items.Count == 0)
                lblAvErr.Text = "The list cannot be empty";

            else
            {
                lstSelected.SelectedIndex = -1;
                foreach (ListItem li in lstAvailable.Items)
                {
                    AddItem(li, lstSelected);
                
                }
                lstAvailable.Items.Clear();
            }
           
        }

        protected void btnAddOne_Click(object sender, EventArgs e)
        {
            lblAvErr.Text = "";
            if (lstAvailable.SelectedIndex >= 0)
            {
                AddItem(lstAvailable.SelectedItem, lstSelected);
                lstAvailable.Items.Remove(lstAvailable.SelectedItem);
            }
            else
            {
                lblAvErr.Text = "An item must be selected before it can be moved";
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            lblSeErr.Text = "";
            if (lstSelected.SelectedIndex >= 0)
            {
                lstSelected.Items.RemoveAt(lstSelected.SelectedIndex);
                lstSelected.SelectedIndex = -1;
            }
            else
            {
                lblSeErr.Text = "Please select an item before trying to move";
            }

        }

        protected void AddItem(ListItem li, ListBox _listBox)
        {
            _listBox.SelectedIndex = -1;
            _listBox.Items.Add(li);
        }

        protected void RemoveItem(ListItem li, ListBox _listBox)
        {

        }

        protected void btnBackAll_Click(object sender, EventArgs e)
        {
            lblSeErr.Text = "";
            if (lstSelected.Items.Count == 0)
                lblSeErr.Text = "The list cannot be empty";
            else
            {
            lstAvailable.SelectedIndex = -1;
            foreach (ListItem li in lstSelected.Items)
            {
                AddItem(li,lstAvailable);
            }
            lstSelected.Items.Clear();
            }
           
        }

        protected void btnBackOne_Click(object sender, EventArgs e)
        {
            if (lstSelected.SelectedIndex >= 0)
            {
                AddItem(lstSelected.SelectedItem, lstAvailable);
                lstSelected.Items.Remove(lstSelected.SelectedItem);
            }
            else
            {
                lblSeErr.Text = "An item must be selected before it can be moved";
            }
        }
    }
}