using HappyValleyKennels.App_Code.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HappyValleyKennels.App_Code.DB
{
    public class KennelLogDB
    {
        //Delete HVK_KENNEL_LOG Rows where PR_PET_RES_NUMBER is something a res that needs to be deleted
        //Used in Conjunction with getAllPetResNumber() inside PetReservationDB into the PR_PET_RES_NUMBER parameter
        public void deleteKenLogRow(int _PR_PET_RES_NUMBER)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"DELETE FROM HVK_PET_FOOD WHERE PR_PET_RES_NUMBER = :PETRESNUM";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("PETRESNUM", _PR_PET_RES_NUMBER);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.DeleteCommand = cmd;
            try
            {
                con.Open();
                da.DeleteCommand.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Doesn't work");
            }
            finally
            {
                con.Close();


            }
        }
    }
}