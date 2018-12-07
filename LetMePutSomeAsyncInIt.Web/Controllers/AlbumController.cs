using LetMePutSomeAsyncInIt.Web.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetMePutSomeAsyncInIt.Web.Controllers
{
    [RoutePrefix("albums")]
    public class AlbumController : Controller
    {
        private IAlbumRepository _albumRepo;

        public AlbumController(IAlbumRepository albumRepo)
        {
            _albumRepo = albumRepo;
        }

        [HttpGet]
        [Route("")]
        [Route("index")]
        // GET: Album
        public ActionResult Index()
        {
            var albums = _albumRepo.GetAll();
            return View(albums);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetByID(int id)
        {
            var album = _albumRepo.GetByID(id);
            return View(album);
        }
    }
}