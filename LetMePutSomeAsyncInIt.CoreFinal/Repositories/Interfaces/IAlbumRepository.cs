using LetMePutSomeAsyncInIt.CoreFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LetMePutSomeAsyncInIt.CoreFinal.Repositories.Interfaces
{
    public interface IAlbumRepository
    {
        Task<Album> GetByID(int id, CancellationToken token);
        Task<List<Album>> GetForUser(int userID);

        Task<List<Album>> GetAll();
    }
}
