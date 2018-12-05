using LetMePutSomeAsyncInIt.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetMePutSomeAsyncInIt.Web.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetByID(int id);
    }
}