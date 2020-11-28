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

        public async Task<Album> GetAlbumAsync(int id)
        {
            var response = await _client.GetAsync($"album/{id}");
            var result = await response.Content.ReadAsAsync<Album>(); //RootObject
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




    }
}
