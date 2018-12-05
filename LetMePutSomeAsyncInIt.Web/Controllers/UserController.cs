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

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
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
            return View(_userRepo.GetByID(id));
        }
    }
}