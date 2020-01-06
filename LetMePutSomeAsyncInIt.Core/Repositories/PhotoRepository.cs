using LetMePutSomeAsyncInIt.Core.Models;
using LetMePutSomeAsyncInIt.Core.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LetMePutSomeAsyncInIt.Core.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        public List<Photo> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var photoJson = client.GetAsync("https://jsonplaceholder.typicode.com/photos/").Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Photo>>(photoJson);
            }
        }

        public Photo GetByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var photoJson = client.GetAsync("https://jsonplaceholder.typicode.com/photos/" + id.ToString()).Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Photo>(photoJson);
            }
        }
    }
}
