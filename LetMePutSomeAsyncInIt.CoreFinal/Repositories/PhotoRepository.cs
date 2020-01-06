using LetMePutSomeAsyncInIt.CoreFinal.Models;
using LetMePutSomeAsyncInIt.CoreFinal.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LetMePutSomeAsyncInIt.CoreFinal.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        public async Task<List<Photo>> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var photos = await client.GetStringAsync("https://jsonplaceholder.typicode.com/photos/");
                return JsonConvert.DeserializeObject<List<Photo>>(photos);
            }
        }

        public async Task<Photo> GetByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var photoJson = await client.GetStringAsync("https://jsonplaceholder.typicode.com/photos/" + id.ToString());
                return JsonConvert.DeserializeObject<Photo>(photoJson);
            }
        }
    }
}
