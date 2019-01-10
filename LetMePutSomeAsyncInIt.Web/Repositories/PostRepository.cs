using LetMePutSomeAsyncInIt.Web.Models;
using LetMePutSomeAsyncInIt.Web.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace LetMePutSomeAsyncInIt.Web.Repositories
{

    public class PostRepository : IPostRepository
    {
        public List<Post> GetAll()
        {
            using (WebClient client = new WebClient())
            {
                var allPosts = client.DownloadString("https://jsonplaceholder.typicode.com/posts");

                return JsonConvert.DeserializeObject<List<Post>>(allPosts);
            }
        }

        public Post GetByID(int id)
        {
            using (WebClient client = new WebClient())
            {
                var jsonPost = client.DownloadString("https://jsonplaceholder.typicode.com/posts/" + id.ToString());

                return JsonConvert.DeserializeObject<Post>(jsonPost);
            }
        }

        public List<Post> GetForUser(int userID)
        {
            using (WebClient client = new WebClient())
            {
                var jsonPost = client.DownloadString("https://jsonplaceholder.typicode.com/posts?userId=" + userID.ToString());

                return JsonConvert.DeserializeObject<List<Post>>(jsonPost);
            }
        }
    }
}