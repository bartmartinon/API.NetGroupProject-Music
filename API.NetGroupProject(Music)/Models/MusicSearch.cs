using API.NetGroupProject_Music_.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NetGroupProject_Music_.Models
{


    public class MusicSearch
    {
        public Datum[] data { get; set; }
        public int total { get; set; }
        public string prev { get; set; }
        public string next { get; set; }

        public List<Datum> Datums{get;set;}
    }

    //public void SaveTracks(List<Datum> tracks)
    //{
    //    if (tracks !=null)
    //    {
    //        using (var context = new ApplicationDbContext())
    //        {
    //            foreach (var track in tracks)
    //            {
    //                var record = context.Model.Find(track.id);
    //                if (record !=null)
    //                {

    //                }
    //            }
    //        }
    //    }
    //}
    public class Datum //track
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
        public Artist artist { get; set; }
        public Album album { get; set; }
        public string type { get; set; } //track
    }

    public class Artist
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string picture { get; set; }
        public string picture_small { get; set; }
        public string picture_medium { get; set; }
        public string picture_big { get; set; }
        public string picture_xl { get; set; }
        public string tracklist { get; set; }
        public string type { get; set; }
    }

    public class Album
    {
        public int id { get; set; }
        public string title { get; set; }
        public string cover { get; set; }
        public string cover_small { get; set; }
        public string cover_medium { get; set; }
        public string cover_big { get; set; }
        public string cover_xl { get; set; }
        public string md5_image { get; set; }
        public string tracklist { get; set; }
        public string type { get; set; }
    }
    public class Tracks
    {
        public MusicTrack[] data { get; set; }
    }
    public class MusicTrack
    {
        
        public int id { get; set; }
        [JsonProperty ("title") ]
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
        //public Genres genres { get; set; }
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
        //public Tracks tracks { get; set; }
        
    }
    public class Genres
    {
        public Datum[] data { get; set; }
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