using LetMePutSomeAsyncInIt.Final.Models;
using LetMePutSomeAsyncInIt.Final.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace LetMePutSomeAsyncInIt.Web.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        public async Task<List<Album>> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var albumJson = await client.GetStringAsync("https://jsonplaceholder.typicode.com/albums");

                return JsonConvert.DeserializeObject<List<Album>>(albumJson);
            }
        }

        public async Task<Album> GetByID(int id, CancellationToken token)
        {
            using (HttpClient client = new HttpClient())
            {
                var albumResponse = await client.GetAsync("https://jsonplaceholder.typicode.com/albums/" + id.ToString(), token);
                var albumJson = await albumResponse.Content.ReadAsStringAsync();
                var album = JsonConvert.DeserializeObject<Album>(albumJson);

                var photosResponse = await client.GetAsync("https://jsonplaceholder.typicode.com/photos?albumId=" + id.ToString(), token);
                var photosJson = await photosResponse.Content.ReadAsStringAsync();
                album.Photos = JsonConvert.DeserializeObject<List<Photo>>(photosJson);

                return album;
            }
        }

        public async Task<List<Album>> GetForUser(int userID)
        {
            using (HttpClient client = new HttpClient())
            {
                var albumJson = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users/" + userID.ToString() + "/albums");
                var albums = JsonConvert.DeserializeObject<List<Album>>(albumJson);

                return albums;
            }
        }
    }
}