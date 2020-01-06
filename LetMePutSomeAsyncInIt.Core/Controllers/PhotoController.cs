using LetMePutSomeAsyncInIt.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetMePutSomeAsyncInIt.Core.Controllers
{
    [Route("Photos")]
    public class PhotoController : Controller
    {
        private IPhotoRepository _photoRepo;

        public PhotoController(IPhotoRepository photoRepo)
        {
            _photoRepo = photoRepo;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var allPhotos = _photoRepo.GetAll();
            return View(allPhotos);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var photo = _photoRepo.GetByID(id);
            return View(photo);
        }
    }
}