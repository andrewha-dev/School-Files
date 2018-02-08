using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L08BLL
{
    public class Track
    {
        public int TrackId { get; private set; }
        public string Name { get; private set; }
        public int? AlbumId { get; private set; }
        public int MediaTypeId { get; private set; }
        public int? GenreId { get; private set; }
        public string Composer { get; private set; }
        public decimal Milliseconds  { get; private set; }
        public decimal? Bytes { get; private set; }
        public decimal UnitPrice { get; private set; }
        public Track()
        {
            TrackId = 0;
            Name = "";
            AlbumId = null;
            MediaTypeId = 0;
            GenreId = null;
            Composer = "";
            Milliseconds = 0.0m;
            Bytes = null;
            UnitPrice = 0.0m;
        }
        public Track(int _TrackId, string _Name, int _AlbumId, int _MediaTypeId, int _GenreId, string _Composer, decimal _Milliseconds, decimal _Bytes, decimal _UnitPrice)
        {
            TrackId = _TrackId;
            Name = _Name;
            AlbumId = _AlbumId;
            MediaTypeId = _MediaTypeId;
            GenreId = _GenreId;
            Composer = _Composer;
            Milliseconds = _Milliseconds;
            Bytes = _Bytes;
            UnitPrice = _UnitPrice;
        }



    }
}
