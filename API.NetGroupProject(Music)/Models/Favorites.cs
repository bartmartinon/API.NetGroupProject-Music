using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;


namespace API.NetGroupProject_Music_.Models
{


       
    public partial class Favorites
    {
        public Favorites()
        {
            InverseUser = new HashSet<Favorites>();
        }
        [Required(ErrorMessage = " Invalid ")]
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Artist Id is too long")]
        public string ArtistId { get; set; }
        [MaxLength(50, ErrorMessage = "Album Id is too long")]
        public string Title { get; set; }
        [MaxLength(50, ErrorMessage = "Track Id too long")]
        public string Album { get; set; }
        [StringLength(60, ErrorMessage = "Artist is too long.")]
        public string Artist { get; set; }

        public int? UserId { get; set; }
        public virtual Favorites User { get; set; }
        public virtual ICollection<Favorites> InverseUser { get; set; }

        // public Favorites() { }
        public Favorites(string album, string artist, string artistid, string title)
        {
            Album = album;
            Artist = artist;
            ArtistId = artistid;
            Title = title;
        }
    }

}
