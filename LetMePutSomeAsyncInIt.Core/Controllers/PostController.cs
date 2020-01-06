using LetMePutSomeAsyncInIt.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Index()
        {
            return View(_postRepo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetByID(int id)
        {
            return View(_postRepo.GetByID(id));
        }
    }
}