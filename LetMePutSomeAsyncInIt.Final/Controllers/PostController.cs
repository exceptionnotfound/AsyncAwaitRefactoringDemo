using LetMePutSomeAsyncInIt.Final.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LetMePutSomeAsyncInIt.Final.Controllers
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
        public async Task<ActionResult> Index()
        {
            var posts = await _postRepo.GetAll();
            return View(posts);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByID(int id)
        {
            var post = await _postRepo.GetByID(id);
            return View(post);
        }
    }
}
