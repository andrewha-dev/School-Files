using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
//using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;

namespace HappyValleyKennels.App_Code.DB
{
    public class UserDB
    {
        public DataSet listOwnersDB()
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"select owner_number, owner_first_name, owner_last_name
                                from hvk_owner order by upper(owner_last_name)";

            OracleCommand cmd = new OracleCommand(cmdstr, con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;

            DataSet ds = new DataSet("ownerDS");
            da.Fill(ds, "HVK_OWNER");

            return ds;
        }

        public DataSet getOwnerByEmail(string _email)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"select owner_number, owner_first_name,
                                owner_last_name, owner_street, owner_city, owner_province,
                                owner_postal_code, owner_phone, owner_email, emergency_contact_first_name,
                                emergency_contact_last_name, emergency_contact_phone from HVK_OWNER where OWNER_EMAIL = :email";

            OracleCommand cmd = new OracleCommand(cmdstr, con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            cmd.Parameters.Add("email", _email);
            DataSet ds = new DataSet("ownerDS");
            da.Fill(ds, "HVK_OWNER");

            return ds;
        }

        public DataSet getOwnerByNumber(int _number)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"select owner_number, owner_first_name,
                                owner_last_name, owner_street, owner_city, owner_province,
                                owner_postal_code, owner_phone, owner_email, emergency_contact_first_name,
                                emergency_contact_last_name, emergency_contact_phone from HVK_OWNER where OWNER_NUMBER = :ownNum";

            OracleCommand cmd = new OracleCommand(cmdstr, con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            cmd.Parameters.Add("ownNum", _number);
            DataSet ds = new DataSet("ownerDS");
            da.Fill(ds, "HVK_OWNER");

            return ds;
        }

        public int updateCustomerInfo(int number, string firstName, string lastName, string street, string city, string province, string postalCode, string phone, string email, string emergencyFirstName, string emergencyLastName, string emergencyPhone)
        {
            int status = 0;
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string cmdStr = @"Update HVK_OWNER 
                                set OWNER_FIRST_NAME = :firstName, 
                                   OWNER_LAST_NAME = :lastName,
                                   OWNER_STREET = :street,
                                    OWNER_CITY = :city,
                                   OWNER_PROVINCE = :province,
                                    OWNER_POSTAL_CODE = :postalCode,
                                   OWNER_PHONE = :phone,
                                    OWNER_EMAIL = :email,
                                    EMERGENCY_CONTACT_FIRST_NAME = :emergencyFirst,
                                    EMERGENCY_CONTACT_LAST_NAME = :emergencyLast,
                                    EMERGENCY_CONTACT_PHONE = :emergencyPhone
                                    where OWNER_NUMBER = :ownerNumber";

            OracleCommand cmd = new OracleCommand(cmdStr, con);

            cmd.Parameters.Add("firstName", firstName);
            cmd.Parameters.Add("lastName", lastName);
            cmd.Parameters.Add("street", street);
            cmd.Parameters.Add("city", city);
            cmd.Parameters.Add("province", province);
            cmd.Parameters.Add("postalCode", postalCode);
            cmd.Parameters.Add("phone", phone);
            cmd.Parameters.Add("email", email);
            cmd.Parameters.Add("emergencyFirst", emergencyFirstName);
            cmd.Parameters.Add("emergencyLast", emergencyLastName);
            cmd.Parameters.Add("emergencyPhone", emergencyPhone);
            cmd.Parameters.Add("ownerNumber", number);

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.UpdateCommand = cmd;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                status = -1;
            }
            finally
            {
                con.Close();
            }
            return status;
        }

        public int createCustomerDB(string _firstName, string _lastName, string _street, string _city, string _province, string _postalCode, string _phone, string _email, string _emergencyFirstName, string _emergencyLastName, string _emergencyPhone)
        {
            int status = 0;
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);

            string cmdStr = @"Insert into HVK_OWNER (OWNER_NUMBER,OWNER_FIRST_NAME,
                            OWNER_LAST_NAME, 
                            OWNER_STREET,OWNER_CITY,OWNER_PROVINCE, OWNER_POSTAL_CODE,
                            OWNER_PHONE, OWNER_EMAIL,
                            EMERGENCY_CONTACT_FIRST_NAME,
                            EMERGENCY_CONTACT_LAST_NAME,
                            EMERGENCY_CONTACT_PHONE) values 
                            (HVK_OWNER_SEQ.NEXTVAL,:firstName,:lastName,
                            :street,:city,:province,:postalCode,
                            :phone,:email,
                            :emerFirstName,:emerLastName,:emerPhone)";

            OracleCommand cmd = new OracleCommand(cmdStr, con);

            cmd.Parameters.Add("firstName", _firstName);
            cmd.Parameters.Add("lastName", _lastName);
            cmd.Parameters.Add("street", _street);
            cmd.Parameters.Add("city", _city);
            cmd.Parameters.Add("province", _province);
            cmd.Parameters.Add("postalCode", _postalCode);
            cmd.Parameters.Add("phone", _phone);
            cmd.Parameters.Add("email", _email);
            cmd.Parameters.Add("emerFirstName", _emergencyFirstName);
            cmd.Parameters.Add("emerLastName", _emergencyLastName);
            cmd.Parameters.Add("emerPhone", _emergencyPhone);


            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.InsertCommand = cmd;



            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Didn't work");
                status = -1;
            }
            finally
            {
                con.Clone();
            }

            return status;


        }


    }
}
