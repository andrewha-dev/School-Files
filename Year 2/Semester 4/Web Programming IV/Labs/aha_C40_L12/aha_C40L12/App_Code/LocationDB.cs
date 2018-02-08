using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;


namespace aha_C40L12.App_Code
{
    public class LocationDB
    {
        public DataSet selectAllLocation()
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string cmdstr = @"select roomid, roomno||' - '||building as ADDRESS from iu_location";

            OracleCommand cmd = new OracleCommand(cmdstr, con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("locDS");
            da.Fill(ds, "IU_LOCATIONS");
            return ds;
        }
        public string selectLocationByID(int? _roomId)
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string cmdstr = @"select roomno||' - '||building as ADDRESS from iu_location where :roomId = roomid ";

            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("roomId", _roomId);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("locDS");
            da.Fill(ds, "IU_LOCATION");

            DataTable dt = ds.Tables[0];
            string address = "";

            foreach (DataRow row in dt.Rows)
            {
                address =  row["ADDRESS"].ToString();
            }

            return address;
        }


    }
}