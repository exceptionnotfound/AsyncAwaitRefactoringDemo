using LetMePutSomeAsyncInIt.Web.Models;
using LetMePutSomeAsyncInIt.Web.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace LetMePutSomeAsyncInIt.Web.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        public List<Photo> GetAll()
        {
            using (WebClient client = new WebClient())
            {
                var photoJson = client.DownloadString("https://jsonplaceholder.typicode.com/photos");
                return JsonConvert.DeserializeObject<List<Photo>>(photoJson);
            }
        }

        public Photo GetByID(int id)
        {
            using (WebClient client = new WebClient())
            {
                var photoJson = client.DownloadString("https://jsonplaceholder.typicode.com/photos/" + id.ToString());
                return JsonConvert.DeserializeObject<Photo>(photoJson);
            }
        }
    }
}