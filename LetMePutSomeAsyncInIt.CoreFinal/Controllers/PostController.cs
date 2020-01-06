using LetMePutSomeAsyncInIt.CoreFinal.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LetMePutSomeAsyncInIt.Core.Controllers
{
    [Route("Posts")]
    public class PostController : Controller
    {
        private IPostRepository _postRepo;

        public PostController(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            return View(await _postRepo.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            return View(await _postRepo.GetByID(id));
        }
    }
}