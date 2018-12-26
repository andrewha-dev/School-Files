using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L08DB;
using System.Data;

namespace L08BLL
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public List<Album> Albums { get; set; }

        public Artist()
        {
            ArtistId = 0;
            Name = "";
            Albums = new List<Album>();
        }

        public Artist(int _ArtistId, string _Name, List<Album> _Albums)
        {
            ArtistId = _ArtistId;
            Name = _Name;
            Albums = _Albums;
        }

        public Artist ArtistNameAndAlbumNameSingle(int _AlbumName)
        {
            Artist artist = new Artist();
            Album album = new Album();
            AlbumDB alDB = new AlbumDB();
            DataTable result = alDB.GetArtistAndAlbumName(_AlbumName);

            if (result != null)
            {
                artist.Name = result.Rows[0]["NAME"].ToString();
                album.Title = result.Rows[0]["TITLE"].ToString();
                artist.Albums.Add(album);
            }

            return artist;

        }

        
    }
}
