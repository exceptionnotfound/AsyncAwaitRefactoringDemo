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
                var photo = Task.Run(() => client.GetStringAsync("https://jsonplaceholder.typicode.com/photos/"));
                return JsonConvert.DeserializeObject<List<Photo>>(photo.Result);
            }
        }

        public Photo GetByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var photoJson = client.GetStringAsync("https://jsonplaceholder.typicode.com/photos/" + id.ToString()).Result;
                return JsonConvert.DeserializeObject<Photo>(photoJson);
            }
        }
    }
}
