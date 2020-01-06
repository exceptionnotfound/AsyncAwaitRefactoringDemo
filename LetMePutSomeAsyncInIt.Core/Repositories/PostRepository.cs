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
    public class PostRepository : IPostRepository
    {
        public List<Post> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var allPosts = client.GetAsync("https://jsonplaceholder.typicode.com/posts").Result.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Post>>(allPosts);
            }
        }

        public Post GetByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonPost = client.GetAsync("https://jsonplaceholder.typicode.com/posts/" + id.ToString()).Result.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Post>(jsonPost);
            }
        }

        public List<Post> GetForUser(int userID)
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonPost = client.GetAsync("https://jsonplaceholder.typicode.com/posts?userId=" + userID.ToString()).Result.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Post>>(jsonPost);
            }
        }
    }
}
