using LetMePutSomeAsyncInIt.CoreFinal.Models;
using LetMePutSomeAsyncInIt.CoreFinal.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LetMePutSomeAsyncInIt.CoreFinal.Repositories
{
    public class PostRepository : IPostRepository
    {
        public async Task<List<Post>> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var posts = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");

                return JsonConvert.DeserializeObject<List<Post>>(posts);
            }
        }

        public async Task<Post> GetByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var post = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/" + id.ToString());

                return JsonConvert.DeserializeObject<Post>(post);
            }
        }

        public async Task<List<Post>> GetForUser(int userID)
        {
            using (HttpClient client = new HttpClient())
            {
                var posts = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts?userId=" + userID.ToString());

                return JsonConvert.DeserializeObject<List<Post>>(posts);
            }
        }
    }
}
