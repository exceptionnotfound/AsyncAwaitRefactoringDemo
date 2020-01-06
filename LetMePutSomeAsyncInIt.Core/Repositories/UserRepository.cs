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
                var user = client.GetStringAsync("https://jsonplaceholder.typicode.com/users").Result;
                return JsonConvert.DeserializeObject<List<User>>(user);
            }
        }

        public User GetByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var user = client.GetStringAsync("https://jsonplaceholder.typicode.com/users/" + id.ToString()).Result;
                return JsonConvert.DeserializeObject<User>(user);
            }
        }
    }
}
