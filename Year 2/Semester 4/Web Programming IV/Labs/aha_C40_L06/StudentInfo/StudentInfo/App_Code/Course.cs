using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentInfo.App_Code
{
    public class Course
    {
        public int CSID { get; set; }
        public int courseID { get; set; }
        public String courseTitle { get; set; }
        public String termID { get; set; }
        public String facultyName { get; set; }

        public Course(int _CSID, int _courseID, String _courseTitle, String _termID, String _facultyName)
        {
            CSID = _CSID;
            courseID = _courseID;
            courseTitle = _courseTitle;
            termID = _termID;
            facultyName = _facultyName;            
        }

        public String CourseDisplay()
        {
            return this.courseID + " / " + this.courseTitle + " / " + this.termID + " / " + this.facultyName;
        }
    }
}