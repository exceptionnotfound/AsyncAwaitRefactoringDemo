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
                var posts = client.GetStringAsync("https://jsonplaceholder.typicode.com/posts").Result;

                return JsonConvert.DeserializeObject<List<Post>>(posts);
            }
        }

        public Post GetByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var post = client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/" + id.ToString()).Result;
                return JsonConvert.DeserializeObject<Post>(post);
            }
        }

        public List<Post> GetForUser(int userID)
        {
            using (HttpClient client = new HttpClient())
            {
                var posts = client.GetStringAsync("https://jsonplaceholder.typicode.com/posts?userId=" + userID.ToString()).Result;
                return JsonConvert.DeserializeObject<List<Post>>(posts);
            }
        }
    }
}
