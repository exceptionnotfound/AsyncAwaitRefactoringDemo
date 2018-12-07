using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetMePutSomeAsyncInIt.Web.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }

        public Address Address { get; set; }
        public Company Company { get; set; }
        public List<Post> Posts { get; set; }
        public List<Album> Albums { get; set; }

        public User()
        {
            Posts = new List<Post>();
            Albums = new List<Album>();
        }
    }
}