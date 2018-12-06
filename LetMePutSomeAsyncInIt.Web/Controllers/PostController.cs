using LetMePutSomeAsyncInIt.Web.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetMePutSomeAsyncInIt.Web.Controllers
{
    [RoutePrefix("Post")]
    public class PostController : Controller
    {
        private IPostRepository _postRepo;

        public PostController(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        // GET: Post
        [HttpGet]
        [Route("")]
        [Route("Index")]
        public ActionResult Index()
        {
            return View(_postRepo.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetByID(int id)
        {
            return View(_postRepo.GetByID(id));
        }
    }
}