using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace aha_C40L12.App_Code
{
    public class DepartmentDB
    {
        public DataSet selectAllDept()
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            String cmdstr = @"select deptid, deptname from iu_department order by deptname";

            OracleCommand cmd = new OracleCommand(cmdstr, con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("deptDS");
            da.Fill(ds, "IU_DEPARTMENT");
            return ds;
        }
        public string selectDeptById(int _deptId)
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            String cmdstr = @"select deptid, deptname from iu_department where deptid = :deptId order by deptname";

            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("deptId", _deptId);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("deptDS");
            da.Fill(ds, "IU_DEPARTMENTS");
            string name = "";

            DataTable dt = ds.Tables[0];

            name = dt.Rows[0]["DEPTNAME"].ToString();

            return name;
        }


    }
}