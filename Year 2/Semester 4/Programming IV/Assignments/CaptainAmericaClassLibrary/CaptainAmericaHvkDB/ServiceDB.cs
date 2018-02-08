using CaptainAmericaHvkDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace CaptainAmericaHvkDB
{
    public class ServiceDB
    {
        public DataSet listService(int _petResNum)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"SELECT s.service_number,
                            s.service_description
                            FROM HVK_SERVICE S,
                            HVK_PET_RESERVATION_SERVICE PRS
                            WHERE PRS.PR_PET_RES_NUMBER = :petResNum
                            and S.SERVICE_NUMBER = PRS.SERV_SERVICE_NUMBER";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("petResNum", _petResNum);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("petResDS");
            da.Fill(ds, "HVK_SERVICE");
            return ds;
        }

        public int addToService()
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string cmdStr = @"Insert into HVK_PET_RESERVATION_SERVICE
                        (SERVICE_FREQUENCY,PR_PET_RES_NUMBER,SERV_SERVICE_NUMBER)
                        values (null,HVK_PET_RES_SEQ.CURRVAL,1)";
            OracleCommand cmd = new OracleCommand(cmdStr, con);

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.InsertCommand = cmd;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Did not work");
                return -1;
            }
            finally
            {
                con.Close();
            }
            return 0;
        }
    }
}
