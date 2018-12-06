using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetMePutSomeAsyncInIt.Web.Models
{
    public class Photo
    {
        public int ID { get; set; }
        public int AlbumID { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public string ThumbnailURL { get; set; }
    }
}