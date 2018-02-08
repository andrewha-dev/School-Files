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
    public class PetReservationDB
    {
        public DataSet listPetReservations(int _reservationNumber)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"SELECT pr.pet_res_number,
                            p.pet_number,
                            p.pet_name, p.own_owner_number
                            FROM HVK_PET P,
                            HVK_PET_RESERVATION PR
                            WHERE PR.RES_RESERVATION_NUMBER =
                            :resNum
                            AND PR.PET_PET_NUMBER = p.pet_number";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("resNum", _reservationNumber);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("petResDS");
            da.Fill(ds, "HVK_PET_RESERVATION");
            return ds;
        }

        public DataSet listActivePetReservations(int _reservationNumber)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"SELECT pr.pet_res_number,
                            p.pet_number, p.dog_size ,
                            p.pet_name, pr.run_run_number  
                            FROM HVK_PET P,
                            HVK_PET_RESERVATION PR
                            WHERE PR.RES_RESERVATION_NUMBER =
                            :resNum
                            AND PR.PET_PET_NUMBER = p.pet_number order by p.pet_number";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("resNum", _reservationNumber);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("petResDS");
            da.Fill(ds, "HVK_PET_RESERVATION");
            return ds;
        }

        public int addToPetReservation(int _resNumber, int _petNumber)
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string cmdStr = @"Insert into HVK_PET_RESERVATION 
            (PET_RES_NUMBER,PET_PET_NUMBER,RES_RESERVATION_NUMBER,RUN_RUN_NUMBER,PR_SHARING_WITH)
            values (HVK_PET_RES_SEQ.NEXTVAL, :petNum, " + _resNumber + " ,null,null)";
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            //cmd.Parameters.Add("resNumber", _resNumber);
            cmd.Parameters.Add("petNum", _petNumber);

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
            }
            finally
            {
                con.Close();
            }
            return 0;
        }

        public int addNewPetReservation(int _petNumber)
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string cmdStr = @"Insert into HVK_PET_RESERVATION 
            (PET_RES_NUMBER,PET_PET_NUMBER,RES_RESERVATION_NUMBER,RUN_RUN_NUMBER,PR_SHARING_WITH)
            values (HVK_PET_RES_SEQ.NEXTVAL, :petNum, HVK_RESERVATION_SEQ.CURRVAL ,null,null)";
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            //cmd.Parameters.Add("resNumber", _resNumber);
            cmd.Parameters.Add("petNum", _petNumber);

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
            }
            finally
            {
                con.Close();
            }
            return 0;
        }
    }
}
