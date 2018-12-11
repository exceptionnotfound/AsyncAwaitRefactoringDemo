using LetMePutSomeAsyncInIt.Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace LetMePutSomeAsyncInIt.Final.Repositories.Interfaces
{
    public interface IAlbumRepository
    {
        Task<Album> GetByID(int id, CancellationToken token);
        Task<List<Album>> GetForUser(int userID);

        Task<List<Album>> GetAll();
    }
}