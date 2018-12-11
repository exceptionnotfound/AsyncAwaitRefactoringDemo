using LetMePutSomeAsyncInIt.Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LetMePutSomeAsyncInIt.Final.Repositories.Interfaces
{
    public interface IPhotoRepository
    {
        Task<Photo> GetByID(int id);
        Task<List<Photo>> GetAll();
    }
}