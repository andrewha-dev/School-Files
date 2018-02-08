using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;


namespace aha_C40L12.App_Code
{
    public class Faculty
    {

        public int facultyId { get; set; }
        public string facName { get; set; }
        public int? roomId{ get; set; }
        public string phoneNum { get; set; }
        public int deptId { get; set; }
        public string deptName { get; set; }
        public string roomLoc { get; set; }
        
        public Faculty()
        {
           
            
        }

        public Faculty(int _facultyId, string _facName, int _roomId, string _phoneNum, int _deptId, string _deptName, string _roomLoc)
        {
            this.facultyId = _facultyId;
            this.facName = _facName;
            this.roomId = _roomId;
            this.phoneNum = _phoneNum;
            this.deptId = _deptId;
            this.deptName = _deptName;
            this.roomLoc = _roomLoc;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<Faculty> getFaculty()
        {
            FacultyDB facDB = new FacultyDB();
            DataSet ds = new DataSet();
            ds = facDB.selectAllFaculty();
            List <Faculty> facultyList = convertFacList(ds);
            return facultyList;
        }

        

        private List<Faculty> convertFacList(DataSet _ds)
        {
            List<Faculty> facList = new List<Faculty>();
            DataTable dt = _ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Faculty fac = new Faculty();
                fac.facName = row["NAME"].ToString();
                fac.facultyId = Convert.ToInt16(row["FACULTYID"]);
                facList.Add(fac);
            }
            return facList;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Faculty getFacultyById(int _facultyId)
        {
            Faculty fac = new Faculty();
            FacultyDB facDB = new FacultyDB();
            DataSet ds = new DataSet();
            ds = facDB.selectFacultyById(_facultyId);
            fac = convertFac(ds);
            return fac;
        }

        private Faculty convertFac(DataSet _ds)
        {
            Faculty fac = new Faculty();
            DataTable dt = _ds.Tables[0];

            fac.facultyId = Convert.ToInt16(dt.Rows[0]["FACULTYID"]);
            fac.facName = dt.Rows[0]["NAME"].ToString();
            if (dt.Rows[0]["ROOMID"] != DBNull.Value)
                fac.roomId = Convert.ToInt16(dt.Rows[0]["ROOMID"]);
            else
                fac.roomId = null;
            fac.phoneNum = dt.Rows[0]["PHONE"].ToString();
            fac.deptId = Convert.ToInt16(dt.Rows[0]["DEPTID"]);            

            return fac;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Faculty getFacultyDetailExpanded(int _facId)
        {
            Faculty faculty = new Faculty();
            faculty = getFacultyById(_facId);
            Department depart = new Department();
            Location loc = new Location();
            faculty.deptName = depart.getDepartmentById(faculty.deptId);
            faculty.roomLoc = loc.getLocationById(faculty.roomId);
            return faculty;
        }
    }
}