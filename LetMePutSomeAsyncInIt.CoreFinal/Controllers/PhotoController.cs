using LetMePutSomeAsyncInIt.CoreFinal.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index()
        {
            var allPhotos = await _photoRepo.GetAll();
            return View(allPhotos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var photo = await _photoRepo.GetByID(id);
            return View(photo);
        }
    }
}