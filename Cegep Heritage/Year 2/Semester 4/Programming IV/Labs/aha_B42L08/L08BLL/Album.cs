using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L08BLL
{
    public class Album
    {
        const decimal SURCHARGE = 1.10m;
        public int AlbumId { get; private set; }
        public string Title { get; set; }
        
        public List<Track> Tracks { get; private set; }
        public Album()
        {
            AlbumId = 0;
            Title = "";
            Tracks = new List<Track>();
        }

        public Album(int _AlbumId, string _Title, List<Track> _Tracks)
        {
            AlbumId = _AlbumId;
            Title = _Title;
            Tracks = new List<Track>();
        }

        

        public decimal GetPriceOneAlbum(int _AlbumId)
        {
            decimal TotalPrice = 0.0m;
            


            return TotalPrice;
        }
        
        public decimal GetPriceAllTracks(int _AlbumId)
        {
            return 0.0m;
        }

        public string CalcTimeOneAlbum(int _AlbumId)
        {
            return "";
        }

        public string CalcAvgTimeOneAlbum()
        {
            return "";
        }

        public int NumberOfTracksOneAlbum(int _AlbumId)
        {
            return 0;
        }

        

        







    }
}
