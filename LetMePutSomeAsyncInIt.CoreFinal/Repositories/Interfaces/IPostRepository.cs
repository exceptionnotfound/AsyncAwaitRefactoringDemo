using LetMePutSomeAsyncInIt.CoreFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetMePutSomeAsyncInIt.CoreFinal.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAll();
        Task<Post> GetByID(int id);
        Task<List<Post>> GetForUser(int userID);
    }
}
