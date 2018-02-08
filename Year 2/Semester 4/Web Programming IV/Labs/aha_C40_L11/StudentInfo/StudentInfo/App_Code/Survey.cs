using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentInfo.App_Code
{
    public class Survey
    {
        public int studentID { get; set; }
        public int CSID { get; set; }
        public int MetExpect { get; set; }
        public int ProfKnowledge { get; set; }
        public int FairAssess { get; set; }
        public String Comments { get; set; }
        public bool Contact { get; set; }
        public String ContactBy { get; set; }

        public Survey(int _studentID, int _CSID, int _MetExpect, int _ProfKnow, int _FairAssess, String _comments, bool _contact, String _contactBy)
        {
            studentID = _studentID;
            CSID = _CSID;
            MetExpect = _MetExpect;
            ProfKnowledge = _ProfKnow;
            FairAssess = _FairAssess;
            Comments = _comments;
            Contact = _contact;
            ContactBy = _contactBy;
        }

    }
}