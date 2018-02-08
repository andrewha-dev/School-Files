using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentInfo
{
    public partial class studentsurvey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtStudentID.Focus();

            if (!IsPostBack)
            disableFields();
        }

        protected void disableFields()
        {
            lstCourses.Enabled = false;

            //Radio Button
            rdoExpList.Enabled = false;

            rdoKnow.Enabled = false;
            rdoFair.Enabled = false;

            chkContact.Enabled = false;
            txtComments.Enabled = false;

            rdoContactEmail.Enabled = false;
            rdoContactPhone.Enabled = false;

            btnSubmit.Enabled = false;

        }

        protected void lblGetCourses_Click(object sender, EventArgs e)
        {

            StudentInfo.App_Code.Course course1 = new App_Code.Course(123, 100, "English 100", "Fall 2017", "Jones");
            StudentInfo.App_Code.Course course2 = new App_Code.Course(321, 101, "French 200", "Winter 2018", "Here is a last name");
            StudentInfo.App_Code.Course course3 = new App_Code.Course(456, 999, "Programming 100", "Spring 2027", "Ha");
            lstCourses.Items.Add(new ListItem("--Select A Course -- ", "None"));
            lstCourses.Items.Add(new ListItem(course1.CourseDisplay(), Convert.ToString(course1.CSID)));
            lstCourses.Items.Add(new ListItem(course2.CourseDisplay(), Convert.ToString(course2.CSID)));
            lstCourses.Items.Add(new ListItem(course3.CourseDisplay(), Convert.ToString(course3.CSID)));
            valRequireCourse.Enabled = true;
            lstCourses.SelectedIndex = 0;
            lstCourses.Focus();
            enableFields();
        }

        protected void enableFields()
        {
            lstCourses.Enabled = true;

            //Radio Button
            rdoExpList.Enabled = true;
            rdoKnow.Enabled = true;
            rdoFair.Enabled = true;


            chkContact.Enabled = true;
            txtComments.Enabled = true;

            rdoContactEmail.Enabled = true;
            rdoContactPhone.Enabled = true;

            btnSubmit.Enabled = true;
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool isContact = false;
            if (chkContact.Checked)
                isContact = true;
            String contactBy = "None";
            if (rdoContactEmail.Checked)
                contactBy = "Email";
            if (rdoContactPhone.Checked)
                contactBy = "Phone";

            StudentInfo.App_Code.Survey survey = new App_Code.Survey(Convert.ToInt16(txtStudentID.Text),Convert.ToInt16(lstCourses.SelectedValue),Convert.ToInt16(rdoExpList.SelectedValue), Convert.ToInt16(rdoKnow.SelectedValue), Convert.ToInt16(rdoFair.SelectedValue), txtComments.Text, isContact, contactBy);
        }
    }
}