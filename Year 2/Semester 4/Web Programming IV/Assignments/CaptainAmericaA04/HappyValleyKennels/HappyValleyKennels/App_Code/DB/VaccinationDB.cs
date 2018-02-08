using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;


namespace HappyValleyKennels.App_Code.DB
{
    public class VaccinationDB
    {
        public DataSet listVaccinations(int _petNumber)
        {
            
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"SELECT DISTINCT VAC.VACCINATION_NAME, PVAC.VACCINATION_EXPIRY_DATE, PVAC.VACCINATION_CHECKED_STATUS
            FROM            HVK_PET_VACCINATION PVAC, HVK_VACCINATION VAC, HVK_PET P, HVK_PET_RESERVATION PRES
            WHERE        VAC.VACCINATION_NUMBER = PVAC.VACC_VACCINATION_NUMBER AND P.PET_NUMBER = PVAC.PET_PET_NUMBER AND 
                         PRES.PET_PET_NUMBER = P.PET_NUMBER AND (PVAC.PET_PET_NUMBER = :petNumber)
            ORDER BY VACCINATION_NAME";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("petNumber", _petNumber);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("resDS");
            da.Fill(ds, "HVK_PET_VACCINATION");
            return ds;
        }

        public DataSet checkVaccinations(int _resNum, int _petNum)
        {
            //List<Vaccination> vaccines = new List<Vaccination>();
            //Assuming that they enter pet number 6 for reservation 615


            //Even if some vaccines are missing
            //Assuming they enter pet number 20 for reservation 625
            //if (_scenario == 2)
            //    {
            //        vaccines.Add(new Vaccination(new DateTime(), 3, "Hepatitis", false));
            //        vaccines.Add(new Vaccination(new DateTime(), 4, "Parainfluenza", false));
            //    }
            //All vaccines need to be verified
            //Assuming they enter pet number 1 for reservation 703
            //if (_scenario == 3)
            //    {
            //        vaccines.Add(new Vaccination(new DateTime(2017, 3, 5), 1, "Bordetella", false));
            //        vaccines.Add(new Vaccination(new DateTime(2017, 3, 5), 2, "Distemper", false));
            //        vaccines.Add(new Vaccination(new DateTime(2017, 3, 5), 3, "Hepatitis", false));
            //        vaccines.Add(new Vaccination(new DateTime(2017, 3, 5), 4, "Parainfluenza", false));
            //        vaccines.Add(new Vaccination(new DateTime(2017, 3, 5), 5, "Paravirus", false));
            //        vaccines.Add(new Vaccination(new DateTime(2018, 3, 5), 6, "Rabies", false));
            //    }

            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"SELECT V.Vaccination_NAME FROM HVK_VACCINATION V WHERE v.vaccination_name NOT IN (
                                (SELECT V.VACCINATION_NAME
                                 FROM HVK_VACCINATION V,
                                HVK_RESERVATION R,
                                HVK_PET_RESERVATION prs,
                                HVK_PET_VACCINATION PV,
                                HVK_PET P
                                WHERE R.RESERVATION_NUMBER     = :resNum
                                AND prs.PET_PET_NUMBER         = P.PET_NUMBER
                                AND prs.PET_PET_NUMBER         = PV.PET_PET_NUMBER
                                AND P.PET_NUMBER = :petNum
                                AND prs.RES_RESERVATION_NUMBER = R.RESERVATION_NUMBER
                                AND V.VACCINATION_NUMBER       = PV.VACC_VACCINATION_NUMBER
                                ))
                                UNION
                                (SELECT V.VACCINATION_NAME
                                FROM HVK_VACCINATION V,
                                HVK_RESERVATION R,
                                HVK_PET_RESERVATION prs,
                                HVK_PET_VACCINATION PV,
                                HVK_PET P
                                WHERE R.RESERVATION_NUMBER       = :resNum
                                AND prs.PET_PET_NUMBER           = P.PET_NUMBER
                                AND P.PET_NUMBER = :petNum
                                AND prs.PET_PET_NUMBER           = PV.PET_PET_NUMBER
                                AND prs.RES_RESERVATION_NUMBER   = R.RESERVATION_NUMBER
                                AND V.VACCINATION_NUMBER         = PV.VACC_VACCINATION_NUMBER
                                AND (PV.VACCINATION_EXPIRY_DATE < R.RESERVATION_END_DATE
                                OR PV.VACCINATION_CHECKED_STATUS = 'N')
                                ) order by VACCINATION_NAME";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("resNum", _resNum);
            cmd.Parameters.Add("petNum", _petNum);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("vacDS");
            da.Fill(ds, "HVK_VACCINATION");
            return ds;

        }
    }
}
