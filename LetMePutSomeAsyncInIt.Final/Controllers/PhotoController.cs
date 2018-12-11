using LetMePutSomeAsyncInIt.Final.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LetMePutSomeAsyncInIt.Final.Controllers
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
        public async Task<ActionResult> Index()
        {
            var allPhotos = await _photoRepo.GetAll();
            return View(allPhotos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByID(int id)
        {
            var photo = await _photoRepo.GetByID(id);
            return View(photo);
        }
    }
}