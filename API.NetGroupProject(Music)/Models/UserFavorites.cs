using System;
using System.Collections.Generic;

namespace API.NetGroupProject_Music_.Models
{
    public partial class UserFavorites
    {
        public UserFavorites()
        {
            InverseIdNetUsersNavigation = new HashSet<UserFavorites>();
        }

        public int Id { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public string Track { get; set; }
        public int? IdNetUsers { get; set; }
        public string TrackId { get; set; }
        public string ArtistId { get; set; }
        public string AlbumId { get; set; }

        public virtual UserFavorites IdNetUsersNavigation { get; set; }
        public virtual ICollection<UserFavorites> InverseIdNetUsersNavigation { get; set; }
    }
}
