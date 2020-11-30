using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.NetGroupProject_Music_.Models
{
    public partial class Favorites
    {
        [Required(ErrorMessage = " Invalid ")]
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Artist Id is too long")]
        public int ArtistId { get; set; }
        [MaxLength(50, ErrorMessage = "Album Id is too long")]
        public int AlbumId { get; set; }
        [MaxLength(50, ErrorMessage = "Track Id too long")]
        public int TrackId { get; set; }
        [StringLength(50, ErrorMessage = "Album is too long.")]
        public string Album { get; set; }
        [StringLength(60, ErrorMessage = "Artist is too long.")]
        public string Artist { get; set; }
        public Favorites(string album, string artist, int artistid, int albumid, int trackid)
        {
            Album = album;
            Artist = artist;
            ArtistId = artistid;
            AlbumId = albumid;
            TrackId = trackid;
        }
    }
}
