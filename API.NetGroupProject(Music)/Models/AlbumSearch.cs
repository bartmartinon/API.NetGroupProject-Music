using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NetGroupProject_Music_.Models
{

    public class AlbumSearch
    {
        public int id { get; set; }
        public string title { get; set; }
        public string upc { get; set; }
        public string link { get; set; }
        public string share { get; set; }
        public string cover { get; set; }
        public string cover_small { get; set; }
        public string cover_medium { get; set; }
        public string cover_big { get; set; }
        public string cover_xl { get; set; }
        public string md5_image { get; set; }
        public int genre_id { get; set; }
        public Genres genres { get; set; }
        public string label { get; set; }
        public int nb_tracks { get; set; }
        public int duration { get; set; }
        public int fans { get; set; }
        public int rating { get; set; }
        public string release_date { get; set; }
        public string record_type { get; set; }
        public bool available { get; set; }
        public string tracklist { get; set; }
        public bool explicit_lyrics { get; set; }
        public int explicit_content_lyrics { get; set; }
        public int explicit_content_cover { get; set; }
        public Contributor[] contributors { get; set; }
        public Artist artist { get; set; }
        public string type { get; set; }
        public Tracks2 tracks { get; set; }
    }

    public class Genres
    {
        public Datum3[] data { get; set; }
    }

    public class Datum3
    {
        public int id { get; set; }
        public string name { get; set; }
        public string picture { get; set; }
        public string type { get; set; }
    }

    public class ArtistAddtl
    {
        public int id { get; set; }
        public string name { get; set; }
        public string picture { get; set; }
        public string picture_small { get; set; }
        public string picture_medium { get; set; }
        public string picture_big { get; set; }
        public string picture_xl { get; set; }
        public string tracklist { get; set; }
        public string type { get; set; }
    }

    public class Tracks2
    {
        public Datum1[] data { get; set; }
    }

    public class Datum1
    {
        public int id { get; set; }
        public bool readable { get; set; }
        public string title { get; set; }
        public string title_short { get; set; }
        public string title_version { get; set; }
        public string link { get; set; }
        public int duration { get; set; }
        public int rank { get; set; }
        public bool explicit_lyrics { get; set; }
        public int explicit_content_lyrics { get; set; }
        public int explicit_content_cover { get; set; }
        public string preview { get; set; }
        public string md5_image { get; set; }
        public Artist1 artist { get; set; }
        public string type { get; set; }
    }

    public class Artist1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tracklist { get; set; }
        public string type { get; set; }
    }

    public class Contributor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string share { get; set; }
        public string picture { get; set; }
        public string picture_small { get; set; }
        public string picture_medium { get; set; }
        public string picture_big { get; set; }
        public string picture_xl { get; set; }
        public bool radio { get; set; }
        public string tracklist { get; set; }
        public string type { get; set; }
        public string role { get; set; }
    }

}
