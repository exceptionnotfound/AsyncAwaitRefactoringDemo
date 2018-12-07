using LetMePutSomeAsyncInIt.Final.Models;
using LetMePutSomeAsyncInIt.Final.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace LetMePutSomeAsyncInIt.Web.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        public List<Album> GetAll()
        {
            using (WebClient client = new WebClient())
            {
                var albumJson = client.DownloadString("https://jsonplaceholder.typicode.com/albums");

                return JsonConvert.DeserializeObject<List<Album>>(albumJson);
            }
        }

        public Album GetByID(int id)
        {
            using (WebClient client = new WebClient())
            {
                var albumJson = client.DownloadString("https://jsonplaceholder.typicode.com/albums/" + id.ToString());
                var album = JsonConvert.DeserializeObject<Album>(albumJson);

                var photosJson = client.DownloadString("https://jsonplaceholder.typicode.com/albums/" + id.ToString() + "/photos");
                album.Photos = JsonConvert.DeserializeObject<List<Photo>>(photosJson);

                return album;
            }
        }

        public List<Album> GetForUser(int userID)
        {
            using (WebClient client = new WebClient())
            {
                var albumJson = client.DownloadString("https://jsonplaceholder.typicode.com/users/" + userID.ToString() + "/albums");
                var albums = JsonConvert.DeserializeObject<List<Album>>(albumJson);

                return albums;
            }
        }
    }
}