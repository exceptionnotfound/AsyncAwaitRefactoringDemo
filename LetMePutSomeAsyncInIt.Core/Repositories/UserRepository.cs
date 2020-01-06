using LetMePutSomeAsyncInIt.Core.Models;
using LetMePutSomeAsyncInIt.Core.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace LetMePutSomeAsyncInIt.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonPost = client.GetAsync("https://jsonplaceholder.typicode.com/users").Result.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<User>>(jsonPost);
            }
        }

        public User GetByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var userJson = client.GetAsync("https://jsonplaceholder.typicode.com/users/" + id.ToString()).Result.Content.ReadAsStringAsync().Result;
                var user = JsonConvert.DeserializeObject<User>(userJson);

                return user;
            }
        }
    }
}
