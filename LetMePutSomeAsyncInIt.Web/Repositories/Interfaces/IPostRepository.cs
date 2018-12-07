using LetMePutSomeAsyncInIt.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LetMePutSomeAsyncInIt.Web.Repositories.Interfaces
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        Post GetByID(int id);
        List<Post> GetForUser(int userID);
    }
}