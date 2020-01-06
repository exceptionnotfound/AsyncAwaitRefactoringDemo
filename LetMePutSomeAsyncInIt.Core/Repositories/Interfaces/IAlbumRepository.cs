using LetMePutSomeAsyncInIt.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LetMePutSomeAsyncInIt.Core.Repositories.Interfaces
{
    public interface IAlbumRepository
    {
        Album GetByID(int id);
        List<Album> GetForUser(int userID);

        List<Album> GetAll();
    }
}
