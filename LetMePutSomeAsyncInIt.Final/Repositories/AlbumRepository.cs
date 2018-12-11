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
            //First, using a random number 100-2000, determine how many milliseconds this will take.
            //This is an example only.  In the real world, of course we will not impose wait times.
            Random rand = new Random(DateTime.Now.Millisecond);
            int finalDelay = rand.Next(100, 2000);
            int totalWaited = 100;

            while(totalWaited < finalDelay)
            {
                await Task.Delay(100);
                totalWaited += 100;
                token.ThrowIfCancellationRequested();
            }

            using (HttpClient client = new HttpClient())
            {
                var albumJson = await client.GetStringAsync("https://jsonplaceholder.typicode.com/albums/" + id.ToString());
                var album = JsonConvert.DeserializeObject<Album>(albumJson);

                var photosJson = await client.GetStringAsync("https://jsonplaceholder.typicode.com/albums/" + id.ToString() + "/photos");
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