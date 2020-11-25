using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ThirdParty.Json.LitJson;

namespace API.NetGroupProject_Music_.Models
{
    public enum SearchType
    {
        search,
        album,
        genre,
        artist,
        track
    }
    public class MusicDAL
    {
        private readonly HttpClient _client;
        public MusicDAL(HttpClient client)
        {
            _client = client;
        }
       /* public async Task<List<MusicAlbum>> GetAlbumsAsync()
        {
            var response = await _client.GetAsync("Albums");
            var result = await response.Content.ReadAsAsync<List<MusicAlbum>>(); //RootObject
            return result;
       } */

        public async Task<MusicAlbum> GetSearchAsync()
        {
            var response = await _client.GetAsync("Search");
            var result = await response.Content.ReadAsAsync<MusicAlbum>(); //RootObject
            return result;
        }

        //public static string CallMusicAPI()
        // {

        //   string apiKey = Secret.OmbdKey;
        // string endpoint;
        //}

        //public async Task<List<MusicAlbum>> GetAlbumsAsync()
        //{
        //  return await _client.GetFromJsonAsync<List<MusicAlbum>>("Albums");
        //}

        /*  public async Task<List<MusicAlbum>> GetAlbumsAsync()
          {
              var response = await _client.GetAsync("Albums");
              var jsonresult = await response.Content.ReadAsStringAsync();

              List<MusicAlbum> musicAlbums = JsonSerializer.Deserializer<List<MusicAlbum>>(JsonData);
              return musicAlbums;
          } */

    }
}
