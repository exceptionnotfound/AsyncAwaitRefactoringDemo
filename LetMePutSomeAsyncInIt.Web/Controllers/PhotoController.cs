using LetMePutSomeAsyncInIt.Web.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetMePutSomeAsyncInIt.Web.Controllers
{
    [RoutePrefix("Photo")]
    public class PhotoController : Controller
    {
        private IPhotoRepository _photoRepo;

        public PhotoController(IPhotoRepository photoRepo)
        {
            _photoRepo = photoRepo;
        }

        [HttpGet]
        [Route("")]
        [Route("index")]
        // GET: Photo
        public ActionResult Index()
        {
            var allPhotos = _photoRepo.GetAll();
            return View(allPhotos);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetByID(int id)
        {
            var photo = _photoRepo.GetByID(id);
            return View(photo);
        }
    }
}