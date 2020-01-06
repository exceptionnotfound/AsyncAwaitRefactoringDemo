using LetMePutSomeAsyncInIt.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetMePutSomeAsyncInIt.Core.Controllers
{
    [Route("Users")]
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
        public ActionResult Index()
        {
            var users = _userRepo.GetAll();
            return View(users);
        }

        [HttpGet("{id}")]
        public ActionResult GetByID(int id)
        {
            var user = _userRepo.GetByID(id);
            user.Albums = _albumRepo.GetForUser(user.ID);
            user.Posts = _postRepo.GetForUser(user.ID);

            return View(user);
        }
    }
}