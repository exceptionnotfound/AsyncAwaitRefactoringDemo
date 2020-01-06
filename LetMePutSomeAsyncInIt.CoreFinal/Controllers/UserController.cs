using LetMePutSomeAsyncInIt.CoreFinal.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {
            var users = await _userRepo.GetAll();
            return View(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByID(int id)
        {
            var user = await _userRepo.GetByID(id);
            user.Albums = await _albumRepo.GetForUser(user.ID);
            user.Posts = await _postRepo.GetForUser(user.ID);

            return View(user);
        }
    }
}