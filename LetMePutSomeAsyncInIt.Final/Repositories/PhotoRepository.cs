using LetMePutSomeAsyncInIt.Final.Models;
using LetMePutSomeAsyncInIt.Final.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace LetMePutSomeAsyncInIt.Web.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        public async Task<List<Photo>> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var photoJson = await client.GetStringAsync("https://jsonplaceholder.typicode.com/photos/");
                return JsonConvert.DeserializeObject<List<Photo>>(photoJson);
            }
        }

        public async Task<Photo> GetByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var photoTask = await client.GetStringAsync("https://jsonplaceholder.typicode.com/photos/" + id.ToString());
                return JsonConvert.DeserializeObject<Photo>(photoTask);
            }
        }
    }
}