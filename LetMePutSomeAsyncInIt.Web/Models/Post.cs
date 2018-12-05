using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetMePutSomeAsyncInIt.Web.Models
{
    public class Post
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}