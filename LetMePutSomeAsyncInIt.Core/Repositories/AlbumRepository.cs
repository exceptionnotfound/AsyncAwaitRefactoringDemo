using LetMePutSomeAsyncInIt.Core.Models;
using LetMePutSomeAsyncInIt.Core.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LetMePutSomeAsyncInIt.Core.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        public List<Album> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var albumTask = Task.Run(() => client.GetAsync("https://jsonplaceholder.typicode.com/albums"));

                return JsonConvert.DeserializeObject<List<Album>>(albumTask.Result.Content.ReadAsStringAsync().Result);
            }
        }

        public Album GetByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var albumJson = client.GetAsync("https://jsonplaceholder.typicode.com/albums/" + id.ToString()).Result.Content.ReadAsStringAsync().Result;
                var album = JsonConvert.DeserializeObject<Album>(albumJson);

                var photosJson = client.GetAsync("https://jsonplaceholder.typicode.com/photos?albumId=" + id.ToString()).Result.Content.ReadAsStringAsync().Result;
                album.Photos = JsonConvert.DeserializeObject<List<Photo>>(photosJson);

                return album;
            }
        }

        public List<Album> GetForUser(int userID)
        {
            using (HttpClient client = new HttpClient())
            {
                var albumJson = client.GetAsync("https://jsonplaceholder.typicode.com/albums?userId=" + userID.ToString()).Result.Content.ReadAsStringAsync().Result;
                var albums = JsonConvert.DeserializeObject<List<Album>>(albumJson);

                return albums;
            }
        }
    }
}
