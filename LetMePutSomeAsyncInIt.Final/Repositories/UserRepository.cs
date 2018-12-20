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
    public class UserRepository : IUserRepository
    {
        public async Task<List<User>> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonPost = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");

                return JsonConvert.DeserializeObject<List<User>>(jsonPost);
            }
        }

        public async Task<User> GetByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var userJson = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users/" + id.ToString());
                var user = JsonConvert.DeserializeObject<User>(userJson);

                return user;
            }
        }
    }
}