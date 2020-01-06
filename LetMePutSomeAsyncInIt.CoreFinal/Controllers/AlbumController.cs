using LetMePutSomeAsyncInIt.CoreFinal.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace LetMePutSomeAsyncInIt.Core.Controllers
{
    [Route("Albums")]
    public class AlbumController : Controller
    {
        private IAlbumRepository _albumRepo;

        public AlbumController(IAlbumRepository albumRepo)
        {
            _albumRepo = albumRepo;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var albums = await _albumRepo.GetAll();
            return View(albums);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByID(int id)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            source.CancelAfter(1000);
            var album = await _albumRepo.GetByID(id, source.Token);
            return View(album);
        }
    }
}