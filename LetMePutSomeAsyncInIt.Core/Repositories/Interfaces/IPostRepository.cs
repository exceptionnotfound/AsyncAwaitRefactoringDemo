using LetMePutSomeAsyncInIt.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetMePutSomeAsyncInIt.Core.Repositories.Interfaces
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        Post GetByID(int id);
        List<Post> GetForUser(int userID);
    }
}
