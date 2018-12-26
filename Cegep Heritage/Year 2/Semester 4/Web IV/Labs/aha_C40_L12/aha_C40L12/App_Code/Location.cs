using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;

namespace aha_C40L12.App_Code
{
    public class Location
    {
        public int roomId { get; set; }
        public string roomLoc { get; set; }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<Location> getLocation()
        {
            LocationDB lDB = new LocationDB();
            List<Location> listLoc = new List<Location>();
            DataSet ds = new DataSet();
            ds = lDB.selectAllLocation();
            listLoc = convertLocList(ds);
            return listLoc;
        }


        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public string getLocationById(int? _locationId)
        {
            LocationDB lDB = new LocationDB();
            return lDB.selectLocationByID(_locationId);
        }


        private List<Location> convertLocList(DataSet _ds)
        {
            List<Location> listLoc = new List<Location>();
            DataTable dt = _ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Location loc = new Location();
                loc.roomId = Convert.ToInt16(row["ROOMID"]);
                loc.roomLoc = (row["ADDRESS"].ToString());
                listLoc.Add(loc);
            }
            return listLoc;
        }

        

    }
}