using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B42L06DB
{
    public class EmployeeDB
    {
        public EmployeeDB()
        {

        }

        public dsNaman.DataTableEmpInfoDataTable getEmployeeByDepartmentName(String _deptName)
        {
            dsNamanTableAdapters.DataTableEmpInfoTableAdapter myAdapter = new dsNamanTableAdapters.DataTableEmpInfoTableAdapter();
            myAdapter.ClearBeforeFill = true;
            return myAdapter.GetByDeptName(_deptName);
        }

        public dsNaman.DataTableEmpInfoDataTable getEmployeeByLastName(String _lastName)
        {
            dsNamanTableAdapters.DataTableEmpInfoTableAdapter myAdapter = new dsNamanTableAdapters.DataTableEmpInfoTableAdapter();
            myAdapter.ClearBeforeFill = true;
            return myAdapter.GetDataByLastName(_lastName);
        }

        public int getNumberOfEmployees(int _dept)
        {
            dsNamanTableAdapters.DataTableEmpInfoTableAdapter myAdapter = new dsNamanTableAdapters.DataTableEmpInfoTableAdapter();
            myAdapter.ClearBeforeFill = true;
            return Convert.ToInt32(myAdapter.FillByCountEmployees(_dept));
        }

        public Int32 sumAllSalaries()
        {
            dsNamanTableAdapters.DataTableEmpInfoTableAdapter myAdapter = new dsNamanTableAdapters.DataTableEmpInfoTableAdapter();
            myAdapter.ClearBeforeFill = true;
            return Convert.ToInt32(myAdapter.FillBySumAll());
        }

        public int  sumSalariesInDept(int _deptid)
        {
            dsNamanTableAdapters.DataTableEmpInfoTableAdapter myAdapter = new dsNamanTableAdapters.DataTableEmpInfoTableAdapter();
            myAdapter.ClearBeforeFill = true;
            return Convert.ToInt32(myAdapter.FillBySumDeptId(_deptid));
        }
        public dsNaman.DataTableEmpInfoDataTable sumSalariesAbove(int _salary)
        {
            dsNamanTableAdapters.DataTableEmpInfoTableAdapter myAdapter = new dsNamanTableAdapters.DataTableEmpInfoTableAdapter();
            myAdapter.ClearBeforeFill = true;
            return myAdapter.GetDataBySalaryPrompt(_salary);
        }



    }
}
