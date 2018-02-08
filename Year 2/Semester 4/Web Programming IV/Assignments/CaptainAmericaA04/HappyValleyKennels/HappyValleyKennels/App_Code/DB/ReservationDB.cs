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

            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"UPDATE HVK_RESERVATION
                            SET
                            RESERVATION_START_DATE = :start,
                            RESERVATION_END_DATE = :end
                            WHERE RESERVATION_NUMBER = :reserNumb";

            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("start", _startDate);
            cmd.Parameters.Add("end", _endDate);
            cmd.Parameters.Add("reserNumb", _reservationNumber);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.UpdateCommand = cmd;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return 6;
                //return success code
            }
            catch (Exception)
            {
                //return error code
                return -8;

            }
            finally
            {
                con.Close();
            }

            //return 0;
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
            PetDB pet = new PetDB();
            DataSet petDS = pet.listSpecificPet(_petNumber);
            if (petDS.Tables[0].Rows.Count == 0) // pet number does not exist
            {
                return -1;
            }
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"SELECT vac.vaccination_name,
                pet.pet_name, pv.VACCINATION_EXPIRY_DATE, pet.pet_number
                FROM hvk_vaccination vac
                INNER JOIN hvk_pet_vaccination pv
                ON pv.VACC_VACCINATION_NUMBER = vac.VACCINATION_NUMBER
                INNER JOIN hvk_pet pet
                ON pv.PET_PET_NUMBER = pet.PET_NUMBER where pet.PET_NUMBER = :petnum";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("petnum", _petNumber);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("resDS");
            da.Fill(ds, "HVK_RES");
            DataTable dt = ds.Tables[0];


            if (dt.Rows.Count < 6)
            {
                return -14; // missing at least 1 vac
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToDateTime(row["VACCINATION_EXPIRY_DATE"]) < byDate)
                    {
                        return -15; // 1 or more vac is expired
                    }
                }
            }

            return 11; // all vaccinations are present & valid
            //Vaccinations are not expired
            //Vaccinations are expired
            //Pet number doesn't exist

        }

        public bool checkRunAvailabilityDB(DateTime _startDate, DateTime _endDate, char _runSize)
        {

            if (_startDate > _endDate)
                return false;
            else
            {
                String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                OracleConnection con = new OracleConnection(constring);

                String cmdstr = @"SELECT run_number, run_size
                            FROM hvk_run
                            WHERE run_number not IN
                            (SELECT pr.run_run_number
                            FROM hvk_pet_reservation pr
                            INNER JOIN teamcaptainamerica.hvk_reservation res
                            ON res.RESERVATION_NUMBER         = pr.RES_RESERVATION_NUMBER
                            WHERE res.reservation_start_date >= :startdate
                            AND res.reservation_end_date     <= :enddate and pr.RUN_RUN_NUMBER is not null) and run_size = :runsize";

                OracleCommand cmd = new OracleCommand(cmdstr, con);
                cmd.Parameters.Add("startdate", _startDate);
                cmd.Parameters.Add("enddate", _endDate);
                cmd.Parameters.Add("runsize", _runSize);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.SelectCommand = cmd;
                DataSet ds = new DataSet("resDS");
                da.Fill(ds, "HVK_RES");

                if (ds.Tables[0].Rows.Count == 0)
                {
                    return false;
                }
                else
                    return true;
            }
            //check1
            //Run size doesn't exist
            //Runs are available
            //Runs are not available 
            //startDate after end date
        }

        private DataSet getUsedRunsBetween(DateTime _startDate, DateTime _endDate) // only used in check run avail
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"SELECT run_number, run_size
                            FROM hvk_run
                            WHERE run_number IN
                            (SELECT pr.run_run_number
                            FROM hvk_pet_reservation pr
                            INNER JOIN hvk_reservation res
                            ON res.RESERVATION_NUMBER         = pr.RES_RESERVATION_NUMBER
                            WHERE res.reservation_start_date >= :start
                            AND res.reservation_end_date     <= :end)";

            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("start", _startDate);
            cmd.Parameters.Add("end", _endDate);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("runsUsedDS");
            da.Fill(ds, "HVK_RES");
            return ds;
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

        public DataSet listReservationsEndByDB()
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
            where to_char(res.RESERVATION_END_DATE, 'yyyy-mm-dd') = to_char(sysdate, 'yyyy-mm-dd') 
            order
            by RESERVATION_NUMBER";

            OracleCommand cmd = new OracleCommand(cmdstr, con);

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("resDS");
            da.Fill(ds, "HVK_RES");
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
        //Gets a Specific Reservation, Useful for checking if reservation has already ended.
        public DataSet getSpecificReservation(int _reservationNumber)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"Select RESERVATION_NUMBER, RESERVATION_START_DATE, RESERVATION_END_DATE FROM HVK_RESERVATION WHERE RESERVATION_NUMBER = :RESNUM";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("RESNUM", _reservationNumber);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("resDS");
            da.Fill(ds, "HVK_SPEC_RES");
            return ds;
        }

        //Delete a specific Reservation Number
        // NEEDS TO BE CALL LAST IN ORDER TO AVOID DEPENDENCY ISSUES!
        public void deleteReservation(int _reservationNumber)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"DELETE FROM HVK_RESERVATION WHERE RESERVATION_NUMBER = :RESNUM";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("RESNUM", _reservationNumber);
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
        //This method adds a dummy reservation
        public void addDummyReservation()
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);
            con.Open();
            OracleCommand command = con.CreateCommand();
            OracleTransaction transaction;
            transaction = con.BeginTransaction(IsolationLevel.ReadCommitted);
            command.Transaction = transaction;
            try
            {
                command.CommandText =
                    @"Insert into HVK_RESERVATION (RESERVATION_NUMBER,RESERVATION_START_DATE,RESERVATION_END_DATE) values (4333,to_date('26-JUN-17','DD-MON-RR'),to_date('05-JUL-17','DD-MON-RR'))";
                command.ExecuteNonQuery();

                command.CommandText =
              @"Insert into HVK_PET_RESERVATION (PET_RES_NUMBER,PET_PET_NUMBER,RES_RESERVATION_NUMBER,RUN_RUN_NUMBER,PR_SHARING_WITH) values (3333,6,4333,27,null)";
                command.ExecuteNonQuery();
                command.CommandText =
                    @"Insert into HVK_MEDICATION (MEDICATION_NUMBER,MEDICATION_NAME,MEDICATION_DOSAGE,MEDICATION_SPECIAL_INSTRUCT,MEDICATION_END_DATE,PR_PET_RES_NUMBER) values (5,'Tapzole','1/2 tablet once daily',null,null,3333)";
                command.ExecuteNonQuery();
                command.CommandText =
                  @"Insert into HVK_PET_FOOD (PET_FOOD_FREQUENCY,PET_FOOD_QUANTITY,PR_PET_RES_NUMBER,FOOD_FOOD_NUMBER) values (2,'.5',3333,13)";
                command.ExecuteNonQuery();
                command.CommandText =
                     @"Insert into HVK_PET_RESERVATION_SERVICE (SERVICE_FREQUENCY,PR_PET_RES_NUMBER,SERV_SERVICE_NUMBER) values (null,3333,4)";
                command.ExecuteNonQuery();
                command.CommandText =
                    @"Insert into HVK_PET_RESERVATION_SERVICE (SERVICE_FREQUENCY,PR_PET_RES_NUMBER,SERV_SERVICE_NUMBER) values (null,3333,1)";
                command.ExecuteNonQuery();

                command.CommandText =
                   @"Insert into HVK_PET_RESERVATION_SERVICE (SERVICE_FREQUENCY,PR_PET_RES_NUMBER,SERV_SERVICE_NUMBER) values (null,3333,5)";
                command.ExecuteNonQuery();

                command.CommandText =
                   @"Insert into HVK_PET_RESERVATION_SERVICE (SERVICE_FREQUENCY,PR_PET_RES_NUMBER,SERV_SERVICE_NUMBER) values (1,3333,3)";
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.ToString());
                Console.WriteLine("Dummy Reservation was not written to HVK DB");
            }

        }





    }
}