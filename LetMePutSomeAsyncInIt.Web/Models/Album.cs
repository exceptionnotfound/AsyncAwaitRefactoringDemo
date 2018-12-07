using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetMePutSomeAsyncInIt.Web.Models
{
    public class Album
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }

        public List<Photo> Photos { get; set; }
    }
}