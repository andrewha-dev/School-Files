using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;


namespace aha_C40L12.App_Code
{
    public class FacultyDB
    {
        public DataSet selectAllFaculty()
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            String cmdstr = @"select facultyId, name from iu_faculty order by name";

            OracleCommand cmd = new OracleCommand(cmdstr, con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("facDS");
            da.Fill(ds, "IU_FACULTY");
            return ds;

        }
        public DataSet selectFacultyById(int _facID)
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            String cmdstr = @"select facultyId, name, roomid, phone, deptid from iu_faculty where facultyId = :facId order by name";

            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("facID", _facID);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("facDS");
            da.Fill(ds, "IU_FACULTY");
            return ds;
        }
    }
}