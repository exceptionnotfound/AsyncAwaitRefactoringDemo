using LetMePutSomeAsyncInIt.CoreFinal.Models;
using LetMePutSomeAsyncInIt.CoreFinal.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace LetMePutSomeAsyncInIt.CoreFinal.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<User>> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var users = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");

                return JsonConvert.DeserializeObject<List<User>>(users);
            }
        }

        public async Task<User> GetByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var user = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users/" + id.ToString());
                
                return JsonConvert.DeserializeObject<User>(user);
            }
        }
    }
}
