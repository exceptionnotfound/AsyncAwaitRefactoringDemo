using LetMePutSomeAsyncInIt.Web.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetMePutSomeAsyncInIt.Web.Controllers
{
    [RoutePrefix("User")]
    public class UserController : Controller
    {
        private IUserRepository _userRepo;
        private IAlbumRepository _albumRepo;
        private IPostRepository _postRepo;

        public UserController(IUserRepository userRepo, IAlbumRepository albumRepo, IPostRepository postRepo)
        {
            _userRepo = userRepo;
            _albumRepo = albumRepo;
            _postRepo = postRepo;
        }

        [HttpGet]
        [Route("~/")]
        [Route("")]
        [Route("Index")]
        // GET: User
        public ActionResult Index()
        {
            var users = _userRepo.GetAll();
            return View(users);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetByID(int id)
        {
            var user = _userRepo.GetByID(id);
            user.Albums = _albumRepo.GetForUser(user.ID);
            user.Posts = _postRepo.GetForUser(user.ID);

            return View(user);
        }
    }
}