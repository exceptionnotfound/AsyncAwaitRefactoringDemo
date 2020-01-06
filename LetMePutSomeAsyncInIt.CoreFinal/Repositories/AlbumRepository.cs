using LetMePutSomeAsyncInIt.CoreFinal.Models;
using LetMePutSomeAsyncInIt.CoreFinal.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace LetMePutSomeAsyncInIt.CoreFinal.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        public async Task<List<Album>> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var albums = await client.GetStringAsync("https://jsonplaceholder.typicode.com/albums");

                return JsonConvert.DeserializeObject<List<Album>>(albums);
            }
        }

        public async Task<Album> GetByID(int id, CancellationToken token)
        {
            using (HttpClient client = new HttpClient())
            {
                var albumResponse = await client.GetAsync("https://jsonplaceholder.typicode.com/albums/" + id.ToString(), token);
                var albumJson = albumResponse.Content.ReadAsStringAsync().Result;
                var album = JsonConvert.DeserializeObject<Album>(albumJson);

                var photosResponse = await client.GetAsync("https://jsonplaceholder.typicode.com/photos?albumId=" + id.ToString(), token);
                var photosJson = photosResponse.Content.ReadAsStringAsync().Result;
                album.Photos = JsonConvert.DeserializeObject<List<Photo>>(photosJson);

                return album;
            }
        }

        public async Task<List<Album>> GetForUser(int userID)
        {
            using (HttpClient client = new HttpClient())
            {
                var albums = await client.GetStringAsync("https://jsonplaceholder.typicode.com/albums?userId=" + userID.ToString());
                return JsonConvert.DeserializeObject<List<Album>>(albums);
            }
        }
    }
}
