using HappyValleyKennels.App_Code.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;

namespace HappyValleyKennels.App_Code.DB
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
            values (HVK_PET_RES_SEQ.NEXTVAL, :petNum, :resNumber ,null,null)";
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            cmd.Parameters.Add("resNumber", _resNumber);
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
        //This will returns a Pet_reservation number, it will be used in the associative entities to delete specific rows
        public DataSet getAllPetResNumber(int _reservationNumber)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = "Select PET_RES_NUMBER FROM HVK_PET_RESERVATION WHERE RES_RESERVATION_NUMBER =" + _reservationNumber;


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("RESNUM", _reservationNumber);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = null;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                ds = new DataSet("petResDS");
                da.Fill(ds, "HVK_PET_RESERVATION");
            }
            catch (Exception)
            {
                Console.WriteLine("Doesn't work");
            }
            finally
            {
                con.Close();


            }

            return ds;
        }

        //Delete HVK_PET_RESERVATION Rows where PR_PET_RES_NUMBER is something a res that needs to be deleted
        //Used in Conjunction with getAllPetResNumber() inside PetReservationDB into the PR_PET_RES_NUMBER parameter
        public void deletePetResRow(int _PR_PET_RES_NUMBER)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"DELETE FROM HVK_PET_RESERVATION WHERE PET_RES_NUMBER = :PET_RES_NUMBER";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("PET_RES_NUMBER", _PR_PET_RES_NUMBER);
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
        //Used to get pet Reservations
        public DataSet listPetRes(int _reservationNumber, int _petNumber)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = "Select PET_RES_NUMBER FROM HVK_PET_RESERVATION WHERE  RES_RESERVATION_NUMBER = :RESNUM AND PET_PET_NUMBER=:PETNUM";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("RESNUM", _reservationNumber);
            cmd.Parameters.Add("PETNUM", _petNumber);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("presnumDS");
            da.Fill(ds, "HVK_PET_RESERVATION");
            return ds;
        }

        public DataSet listUpcomingRes(int Ownernum)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);
            String cmdstr = @"SELECT distinct(res.reservation_number) || ' | ' || res.reservation_start_date as petres, res.reservation_start_date, res.reservation_end_date,
                            pr.res_reservation_number
                            FROM hvk_pet_reservation pr
                            INNER JOIN hvk_pet pet
                            ON pet.pet_number = pr.PET_PET_NUMBER
                            INNER JOIN hvk_reservation res
                            ON res.RESERVATION_NUMBER = pr.RES_RESERVATION_NUMBER
                            INNER JOIN hvk_owner o
                            ON o.OWNER_NUMBER = pet.OWN_OWNER_NUMBER
                            WHERE res.reservation_start_date > sysdate
                            AND o.owner_number =
                              :ownernum ";
            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("ownernum", Ownernum);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("upcomResDS");
            da.Fill(ds, "HVK_PET_RESERVATION");
            return ds;


        }

        public DataSet listAllUpcomingRes()
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);
            String cmdstr = @"select distinct(res.reservation_number) || ' | ' || res.reservation_start_date as petres, res.reservation_start_date, res.reservation_end_date,
                            hpr.res_reservation_number from hvk_reservation res 
                            inner join hvk_pet_reservation hpr 
                            on res.reservation_number = hpr.res_reservation_number
                            where RESERVATION_START_DATE > sysdate";
            OracleCommand cmd = new OracleCommand(cmdstr, con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("allUpcomRes");
            da.Fill(ds, "HVK_PET_RESERVATION");
            return ds;


        }

        public DataSet listPetRes(int resnum)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);
            String cmdstr = @"SELECT distinct(pet.pet_name),
                            res.RESERVATION_START_DATE, res.RESERVATION_END_DATE,
                            pr.pet_res_number
                            FROM hvk_pet_reservation pr
                            INNER JOIN hvk_pet pet
                            ON pet.pet_number = pr.PET_PET_NUMBER
                            INNER JOIN hvk_reservation res
                            ON res.RESERVATION_NUMBER = pr.RES_RESERVATION_NUMBER
                            INNER JOIN hvk_owner o
                            ON o.OWNER_NUMBER = pet.OWN_OWNER_NUMBER
                            inner join hvk_pet_reservation_service prs on prs.PR_PET_RES_NUMBER = pr.PET_RES_NUMBER inner join hvk_service serv on serv.SERVICE_NUMBER = prs.SERV_SERVICE_NUMBER
                            WHERE res.RESERVATION_NUMBER = :resnum";
            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("resnum", resnum);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("petResServDS");
            da.Fill(ds, "HVK_PET_RESERVATION");
            return ds;
        }

        public DataSet listPetResService(int petRes)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);
            String cmdstr = @"SELECT serv.service_description,
                            nvl(to_char(prs.SERVICE_FREQUENCY), 0) as Frequency
                            FROM hvk_pet_reservation_service prs
                            INNER JOIN hvk_service serv
                            ON serv.SERVICE_NUMBER = prs.SERV_SERVICE_NUMBER
                            WHERE prs.PR_PET_RES_NUMBER = :petresnum and serv.service_number in (2, 5)" ;
            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("petresnum", petRes);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("petResServDS");
            da.Fill(ds, "HVK_PET_RESERVATION");
            return ds;

        }

    }
}