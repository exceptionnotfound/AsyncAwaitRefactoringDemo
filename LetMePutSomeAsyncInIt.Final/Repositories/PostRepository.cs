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

    public class PostRepository : IPostRepository
    {
        public async Task<List<Post>> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var allPosts = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");

                return JsonConvert.DeserializeObject<List<Post>>(allPosts);
            }
        }

        public async Task<Post> GetByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonPost = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/" + id.ToString());

                return JsonConvert.DeserializeObject<Post>(jsonPost);
            }
        }

        public async Task<List<Post>> GetForUser(int userID)
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonPost = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts?userId=" + userID.ToString());

                return JsonConvert.DeserializeObject<List<Post>>(jsonPost);
            }
        }
    }
}