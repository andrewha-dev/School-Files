using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace L08DB
{
    public class AlbumDB
    {
        public DataTable GetArtistAndAlbumName(int _AlbumId)
        {
            DataTable dataTable;
            try
            {
                decimal theDecimal = Convert.ToDecimal(_AlbumId);
                dsChinookTableAdapters.ALBUMTableAdapter adapt = new dsChinookTableAdapters.ALBUMTableAdapter();
                adapt.ClearBeforeFill = true;
                dataTable = adapt.GetDataByAlbArtName(theDecimal);

            }
            catch(Exception e)
            {
                dataTable = null;
                
            }

            return dataTable;
        }
    }
}
