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
        public ActionResult Index()
        {
            var allPhotos = _photoRepo.GetAll();
            return View(allPhotos);
        }

        [HttpGet("{id}")]
        public ActionResult GetByID(int id)
        {
            var photo = _photoRepo.GetByID(id);
            return View(photo);
        }
    }
}