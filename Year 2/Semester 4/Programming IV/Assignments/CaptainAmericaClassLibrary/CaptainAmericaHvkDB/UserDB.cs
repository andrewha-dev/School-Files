using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;

namespace CaptainAmericaHvkDB
{
    public class UserDB
    {
        public DataSet listOwnersDB()
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"select owner_first_name, owner_last_name
                                from hvk_owner order by owner_last_name";

            OracleCommand cmd = new OracleCommand(cmdstr, con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;

            DataSet ds = new DataSet("ownerDS");
            da.Fill(ds, "HVK_OWNER");

            return ds;
        }



    }
}
