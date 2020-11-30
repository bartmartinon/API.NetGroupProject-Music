using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ThirdParty.Json.LitJson;
//using Newtonsoft.Json;

namespace API.NetGroupProject_Music_.Models
{
    public enum SearchType
    {
        search,
        album,
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

        public async Task<AlbumSearch> GetAlbumAsync(int id)
        {
            var response = await _client.GetAsync($"album/{id}");
            var result = await response.Content.ReadAsAsync<AlbumSearch>(); //RootObject
            return result;
        }

        public async Task<MusicSearch> GetMusicAsync(string artist)
        {
            var response = await _client.GetAsync($"search?q={artist}");

            //var response = await _client.GetAsync($"album/{album}");
            var result = await response.Content.ReadAsAsync<MusicSearch>();

            return result;
        }
        public async Task<MusicSearch> GetTrackAsync(string song)
        {
            var response = await _client.GetAsync($"search?q={song}");

            var result = await response.Content.ReadAsAsync<MusicSearch>();

           

            return result;
        }


        public async Task<MusicSearch> GetSearchAsync(string data)
        {
            var response = await _client.GetAsync($"search?q={data}");
            var result = await response.Content.ReadAsAsync<MusicSearch>();

            return result;


        }

        public async Task<MusicSearch> MusicTESTSearchAsync(string data)
        {
            var response = await _client.GetAsync($"search?q={data}");
            var result = await response.Content.ReadAsAsync<MusicSearch>();

            return result;
        }

        public async Task<Datum> MusicSearch(int id)
        {
            var response = await _client.GetAsync($"album/{id}/tracks");
            var result = await response.Content.ReadAsAsync<Datum>();
            return result;

        }

        //public async Task<List<MusicTrack>> GetTrackListAsync(int id)
        //{
        //    var response = await _client.GetAsync($"album/{id}/tracks");
        //    var jsonData = await response.Content.ReadAsStringAsync();

        //    List<MusicTrack> musicTracks = JsonSerializer.Deserialize<List<MusicTrack>>(jsonData);

        //    return musicTracks;

        //}

        public async Task<MusicSearch> GetTrackListAsync(int id )
        {
            var response = await _client.GetAsync($"album/{id}/tracks");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<MusicSearch>();
                return result;
            }
            return new MusicSearch();
        }



    }
}
