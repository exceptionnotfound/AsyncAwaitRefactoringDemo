using LetMePutSomeAsyncInIt.Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetMePutSomeAsyncInIt.Final.Repositories.Interfaces
{
    public interface IAlbumRepository
    {
        Album GetByID(int id);
        List<Album> GetForUser(int userID);

        List<Album> GetAll();
    }
}