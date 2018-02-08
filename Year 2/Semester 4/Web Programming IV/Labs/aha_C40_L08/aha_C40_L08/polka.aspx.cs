using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aha_C40_L08
{
    public partial class polka : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button btnMyButton = new Button();
            TextBox txtMyBox = new TextBox();
            CheckBox chkMyCheck = new CheckBox();

            btnMyButton.Text = "This has been dynamically generated";
            txtMyBox.Text = "I have manually added in text";
            chkMyCheck.Checked = true;
            AjaxControlToolkit.AccordionPane panel1 = new AjaxControlToolkit.AccordionPane();
            panel1.ID = "Panel 1";
            panel1.HeaderContainer.Controls.Add(new LiteralControl("Panel 1"));
            panel1.ContentContainer.Controls.Add(new LiteralControl("This is the content panel 1"));
            panel1.ContentContainer.Controls.Add(btnMyButton);
            accPanel2.Panes.Add(panel1);
            //
            AjaxControlToolkit.AccordionPane panel2 = new AjaxControlToolkit.AccordionPane();
            panel2.ID = "Panel 2";
            panel2.HeaderContainer.Controls.Add(new LiteralControl("Panel 2"));
            panel2.ContentContainer.Controls.Add(new LiteralControl("This is the content panel 2"));
            panel2.ContentContainer.Controls.Add(txtMyBox);
            accPanel2.Panes.Add(panel2);
            //
            AjaxControlToolkit.AccordionPane panel3 = new AjaxControlToolkit.AccordionPane();
            panel3.ID = "Panel 3";
            panel3.HeaderContainer.Controls.Add(new LiteralControl("Panel 3"));
            panel3.ContentContainer.Controls.Add(new LiteralControl("This is the content panel 3"));
            panel3.ContentContainer.Controls.Add(chkMyCheck);
            accPanel2.Panes.Add(panel3);

            accPanel2.SelectedIndex = 2;
        }
    }
}