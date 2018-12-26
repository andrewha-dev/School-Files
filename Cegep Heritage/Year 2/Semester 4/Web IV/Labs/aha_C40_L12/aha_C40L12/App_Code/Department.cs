using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;

namespace aha_C40L12.App_Code
{
    public class Department
    {
        public int deptId { get; set; }
        public string deptName { get; set; }
        public Department()
        {

        }
        public Department(int _deptID, string _deptName)
        {
            this.deptId = _deptID;
            this.deptName = _deptName;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<Department> getDepartment()
        {
            List<Department> lDepart = new List<Department>();
            DepartmentDB dDB = new DepartmentDB();
            DataSet ds = new DataSet();
            ds = dDB.selectAllDept();
            lDepart = convertDepartList(ds);
            return lDepart;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public string getDepartmentById(int _id)
        {
            string name = "";
            DepartmentDB dDB = new DepartmentDB();
            name = dDB.selectDeptById(_id);
            return name;
        }

        private List<Department> convertDepartList(DataSet _ds)
        {
            List<Department> listDepart = new List<Department>();
            DataTable dt = _ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Department depart = new Department();
                depart.deptId = Convert.ToInt16(row["deptid"]);
                depart.deptName = row["deptname"].ToString();

                listDepart.Add(depart);
            }
            return listDepart;
        }
    }
}