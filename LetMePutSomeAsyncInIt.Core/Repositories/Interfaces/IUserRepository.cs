using LetMePutSomeAsyncInIt.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetMePutSomeAsyncInIt.Core.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetByID(int id);
    }
}
