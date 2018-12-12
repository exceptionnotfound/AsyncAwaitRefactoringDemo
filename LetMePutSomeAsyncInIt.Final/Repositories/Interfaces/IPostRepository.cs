using LetMePutSomeAsyncInIt.Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LetMePutSomeAsyncInIt.Final.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAll();
        Task<Post> GetByID(int id);
        Task<List<Post>> GetForUser(int userID);
    }
}