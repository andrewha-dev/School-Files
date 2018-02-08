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

        public void AddToReservationService(int _petResNumber, int _servNumber)
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string cmdStr = @"Insert into HVK_PET_RESERVATION_SERVICE
            (PR_PET_RES_NUMBER, SERV_SERVICE_NUMBER)
            VALUES
            (:petResNum, :servNumber)";
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            cmd.Parameters.Add("petResNum", _petResNumber);
            cmd.Parameters.Add("servNumber", _servNumber);
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

        //Delete HVK_PET_RESERVATION_SERVICE Rows where PR_PET_RES_NUMBER is a res that needs to be deleted
        //Used in Conjunction with getAllPetResNumber() inside PetReservationDB into the PR_PET_RES_NUMBER parameter
        public void deletePetResServRow(int _PR_PET_RES_NUMBER)
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