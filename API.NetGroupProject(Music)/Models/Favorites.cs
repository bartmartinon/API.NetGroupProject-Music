using System;
using System.Collections.Generic;

namespace API.NetGroupProject_Music_.Models
{
    public partial class Favorites
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public Favorites(string album, string artist, int artistid, int albumid)
        {
            Album = album;
            Artist = artist;
            ArtistId = artistid;
            AlbumId = albumid;
        }
    }
}
