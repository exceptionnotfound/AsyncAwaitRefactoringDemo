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
    public class UserRepository : IUserRepository
    {
        public List<User> GetAll()
        {
            using (WebClient client = new WebClient())
            {
                var jsonPost = client.DownloadString("https://jsonplaceholder.typicode.com/users");

                return JsonConvert.DeserializeObject<List<User>>(jsonPost);
            }
        }

        public User GetByID(int id)
        {
            using (WebClient client = new WebClient())
            {
                var userJson = client.DownloadString("https://jsonplaceholder.typicode.com/users/" + id.ToString());
                var user = JsonConvert.DeserializeObject<User>(userJson);

                return user;
            }
        }
    }
}