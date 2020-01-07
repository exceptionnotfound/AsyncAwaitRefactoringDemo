using LetMePutSomeAsyncInIt.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Index()
        {
            var albums = _albumRepo.GetAll();
            return View(albums);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var album = _albumRepo.GetByID(id);
            return View(album);
        }
    }
}