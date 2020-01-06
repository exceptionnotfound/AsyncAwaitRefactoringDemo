using LetMePutSomeAsyncInIt.CoreFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetMePutSomeAsyncInIt.CoreFinal.Repositories.Interfaces
{
    public interface IPhotoRepository
    {
        Task<Photo> GetByID(int id);
        Task<List<Photo>> GetAll();
    }
}
