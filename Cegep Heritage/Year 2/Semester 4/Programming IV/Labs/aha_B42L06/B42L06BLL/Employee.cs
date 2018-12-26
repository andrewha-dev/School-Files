using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B42L06DB;
namespace B42L06BLL
{
    public class Employee
    {
        public int empNum { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int positionID { get; set; }
        public int department { get; set; }
        public int qualification { get; set; }
        public int salary { get; set; }
        public int supervisor { get; set; }
        public int commission { get; set; }
        public DateTime hiredate { get; set; }

            
        public Employee()
        {
            empNum = 0;
            firstName = null;
            lastName = null;
            positionID = 0;
            department = 0;
            qualification = 0;
            salary = 0;
            supervisor = 0;
            commission = 0;
            hiredate = DateTime.Now;
        }

        public Employee(int _empNum, String _firstName, String _lastName, int _positionID, int _department, int _qualification, int _salary, int _supervisor, int _commission, DateTime _hiredate)
        {
            this.empNum = _empNum;
            this.firstName = _firstName;
            this.lastName = _lastName;
            this.positionID = _positionID;
            this.department = _department;
            this.qualification = _qualification;
            this.salary = _salary;
            this.supervisor = _supervisor;
            this.commission = _commission;
            this.hiredate = _hiredate;
        }

        public List<Employee> getEmployeeByDepartmentName(String _deptName)
        {
            EmployeeDB empDB = new EmployeeDB();
            dsNaman.DataTableEmpInfoDataTable datatable = empDB.getEmployeeByDepartmentName(_deptName);
            return getEmployees(datatable);
        }

        public List<Employee> getEmployeeByLastName(String _lastName)
        {
            EmployeeDB empDB = new EmployeeDB();
            dsNaman.DataTableEmpInfoDataTable datatable = empDB.getEmployeeByLastName(_lastName);
            return getEmployees(datatable);
        }

        public int getNumberOfEmployees(int _dept)
        {
            EmployeeDB empDB = new EmployeeDB();
            int count = empDB.getNumberOfEmployees(_dept);
            return count;
        }

        public int sumAllSalaries()
        {
            EmployeeDB empDB = new EmployeeDB();
            int count = empDB.sumAllSalaries();
            return count;
        }

        public int sumSalariesInDept(int _deptid)
        {
            EmployeeDB empDB = new EmployeeDB();
            int count = empDB.sumSalariesInDept(_deptid);
            return count;
        }
        public List<Employee> sumSalriesAbove(int _salary)
        {
            EmployeeDB empDB = new EmployeeDB();
            dsNaman.DataTableEmpInfoDataTable datatable = empDB.sumSalariesAbove(_salary);
            return getEmployees(datatable);
        }

        private List<Employee> getEmployees(dsNaman.DataTableEmpInfoDataTable _datatable)
        {
            List<Employee> employees = new List<Employee>();
            if (_datatable != null)
            {
                for (int i = 0; i < _datatable.Rows.Count; i++)
                {
                    try
                    {
                        Employee emp = new Employee();
                        emp.empNum = Convert.ToInt32(_datatable.Rows[i]["EMPLOYEEID"].ToString());
                        emp.firstName = _datatable.Rows[i]["FNAME"].ToString();
                        emp.lastName = _datatable.Rows[i]["LNAME"].ToString();
                        emp.positionID = Convert.ToInt32(_datatable.Rows[i]["POSITIONID"].ToString());
                        emp.department = Convert.ToInt32(_datatable.Rows[i]["DEPTID"].ToString());
                        emp.qualification = Convert.ToInt32(_datatable.Rows[i]["QUALID"].ToString());
                        emp.salary = Convert.ToInt32(_datatable.Rows[i]["SALARY"].ToString());
                        emp.supervisor = Convert.ToInt32(_datatable.Rows[i]["SUPERVISOR"]);
                        emp.commission = Convert.ToInt32(_datatable.Rows[i]["COMMISSION"]);
                        emp.hiredate = Convert.ToDateTime(_datatable.Rows[i]["HIREDATE"]);
                        employees.Add(emp);
                    }
                    catch
                    {
                        Console.Write("Error");
                    }
                }
            }
            else
            {
                employees = null;
            }
            return employees;
        }


    }
}
