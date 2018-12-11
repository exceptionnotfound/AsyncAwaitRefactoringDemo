using LetMePutSomeAsyncInIt.Final.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LetMePutSomeAsyncInIt.Final.Controllers
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
        public async Task<ActionResult> Index()
        {
            var albums = await _albumRepo.GetAll();
            return View(albums);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByID(int id)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            source.CancelAfter(1000);
            var album = await _albumRepo.GetByID(id, source.Token);
            return View(album);
        }
    }
}