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
    public class ReservationDB
    {
        public int addReservationDB(int _petNumber, DateTime _startDate, DateTime _endDate)
        {

            return 0;
        }

        public int addReservationDB(int _petNumber, int _petNumber2, DateTime _startDate, DateTime _endDate)
        {

            return 0;

        }

        public int addToReservationDB(int _resNum, int _petNum)
        {
            //Pet Number Exists
            //Check if the reservation number exists
            //Check if the reservation  is still active
            //Verify pet size and the assigned run for the given dates
            //Able to create reservation with non-expired vaccinations
            //Able to create reservation with expired vaccines
            //Owner number must be the same
            //Verify dog size as well as door size

            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string cmdStr = @"Insert into NN_DEPT
                                (deptID,
                                 deptName,
                                 location)
                            VALUES(NN_DEPT_SEQ.NEXTVAL, 
                                   :DEPTNAME, 
                                   :LOCATION)";
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            cmd.Parameters.Add("resNum", _resNum);
            cmd.Parameters.Add("petNum", _petNum);

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

        public int addToReservationDB(int _reservationNumber, int _petNumber1, int _petNumber2)
        {
            //Pet Numbers Exist
            //Check if the reservation number exists
            //Check if the reservation  is still active
            //Verify pet size and the assigned run for the given dates
            //Able to create reservation with non-expired vaccinations
            //Able to create reservation with expired vaccines
            //Owner number must be the same
            //First parameter of the pet is the same of as the other



            return 0;
        }

        public int cancelReservationDB(int _reservationNumber)
        {


            return 0;
        }

        public int changeReservationDB(int _reservationNumber, DateTime _startDate, DateTime _endDate)
        {


            return 0;
        }

        public int changeToSharingDB(int _reservationNumber, int _petNumber1, int _petNumber2)
        {

            return 0;
        }

        public int changeToSoloDB(int _reservationNumber, int _petNumber1, int _petNumber2)
        {

            return 0;
        }

        public int deleteDogFromReservationDB(int _reservationNumber, int _petNumber)
        {
            //Success for cancelling the reservation (1)
            //Success for removing a pet (Multiple)
            //Reservation already in the past
            //Reservation doesnt exist
            //Pet number doesn't exist



            return 0;
        }

        //Method that checks to see whether the vaccinations are up to date
        public int checkVaccinationDB(int _petNumber, DateTime byDate)
        {
            //Vaccinations are not expired
            //Vaccinations are expired
            //Pet number doesn't exist


            return 0;
        }

        public bool checkRunAvailabilityDB(DateTime _startDate, DateTime _endDate, char _runSize)
        {
            //Run size doesn't exist
            //Runs are available
            //Runs are not available 
            //startDate after end date

            return true;
        }

        public enum errorCodes
        {

        }

        public DataSet listReservationsDB(int _ownerNumber)
        {
            
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"SELECT distinct r.reservation_number, R.RESERVATION_START_DATE, R.RESERVATION_END_DATE
                            FROM HVK_RESERVATION R,
                            HVK_PET_RESERVATION PR,
                            HVK_PET P
                            WHERE r.reservation_number = PR.RES_RESERVATION_NUMBER
                            AND P.PET_NUMBER           = PR.PET_PET_NUMBER
                            AND P.OWN_OWNER_NUMBER = :ownerNum AND r.reservation_start_date > SYSDATE order by r.reservation_number";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("ownerNum", _ownerNumber);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("resDS");
            da.Fill(ds, "HVK_PET_ESERVATION");
            return ds;
        }


        public DataSet listActiveReservationsDB()
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"SELECT distinct res.reservation_number,
            o.owner_first_name, o.owner_last_name, o.owner_number,
            res.reservation_start_date,
            res.reservation_end_date
            FROM hvk_reservation res
            INNER JOIN hvk_pet_reservation pr
            ON res.RESERVATION_NUMBER = pr.RES_RESERVATION_NUMBER
            INNER JOIN hvk_pet pet
            ON pet.PET_NUMBER = pr.PET_PET_NUMBER
            INNER JOIN hvk_owner o
            ON o.owner_number = pet.OWN_OWNER_NUMBER 
            where res.RESERVATION_START_DATE <= sysdate and 
            res.RESERVATION_END_DATE >= sysdate order
            by RESERVATION_NUMBER";


            OracleCommand cmd = new OracleCommand(cmdstr, con);

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("resDS");
            da.Fill(ds, "HVK_RES");
            return ds;           

        }


        public DataSet listActiveReservationsDB(int _ownerNumber)
        {

            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"SELECT distinct res.reservation_number,
            o.owner_first_name, o.owner_last_name, o.owner_number,
            res.reservation_start_date,
            res.reservation_end_date
            FROM hvk_reservation res
            INNER JOIN hvk_pet_reservation pr
            ON res.RESERVATION_NUMBER = pr.RES_RESERVATION_NUMBER
            INNER JOIN hvk_pet pet
            ON pet.PET_NUMBER = pr.PET_PET_NUMBER
            INNER JOIN hvk_owner o
            ON o.owner_number = pet.OWN_OWNER_NUMBER 
            where res.RESERVATION_START_DATE <= sysdate and 
            res.RESERVATION_END_DATE >= sysdate and o.owner_number = :ownerNum order 
            by res.reservation_start_date";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("ownerNum", _ownerNumber);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("resDS");
            da.Fill(ds, "HVK_RES");
            return ds;
        }

        public DataSet listUpcomingReservationsDB(DateTime _date)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"SELECT DISTINCT        RES.RESERVATION_NUMBER,
                            RES.RESERVATION_START_DATE,
                            RES.RESERVATION_END_DATE,
                            OWN.OWNER_NUMBER
                            FROM            HVK_PET P,
                            HVK_PET_RESERVATION PRES,
                            HVK_RESERVATION RES, HVK_OWNER OWN
                            WHERE        PRES.PET_PET_NUMBER = P.PET_NUMBER
                            AND RES.RESERVATION_NUMBER = PRES.RES_RESERVATION_NUMBER AND 
                            OWN.OWNER_NUMBER = P.OWN_OWNER_NUMBER
                            AND (RES.RESERVATION_START_DATE >= :startDate) order by reservation_start_date, reservation_number";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("startDate", _date);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("resDS");
            da.Fill(ds, "HVK_RES");
            return ds;
        }

        public DataSet getReservationDB(int _reservationNum)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"SELECT distinct res.reservation_number,
                        o.owner_first_name, o.owner_last_name, o.owner_number,
                        res.reservation_start_date,
                        res.reservation_end_date
                        FROM hvk_reservation res
                        INNER JOIN hvk_pet_reservation pr
                        ON res.RESERVATION_NUMBER = pr.RES_RESERVATION_NUMBER
                        INNER JOIN hvk_pet pet
                        ON pet.PET_NUMBER = pr.PET_PET_NUMBER
                        INNER JOIN hvk_owner o
                        ON o.owner_number = pet.OWN_OWNER_NUMBER 
                        where res.reservation_number = :resNum";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("resNum", _reservationNum);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("resDS");
            da.Fill(ds, "HVK_RES");
            return ds;
        }

        public int addNewReservation(DateTime _startDate, DateTime _endDate)
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string cmdStr = @"Insert into HVK_RESERVATION
            (RESERVATION_NUMBER,RESERVATION_START_DATE,RESERVATION_END_DATE) 
            values (HVK_RESERVATION_SEQ.NEXTVAL, :startDate, :endDate)";
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            cmd.Parameters.Add(":startDate", _startDate);
            cmd.Parameters.Add(":endDate", _endDate);

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
            return 1;
        }


        




    }
}
