using LetMePutSomeAsyncInIt.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetMePutSomeAsyncInIt.Web.Repositories.Interfaces
{
    public interface IAlbumRepository
    {
        Album GetByID(int id);
        List<Album> GetForUser(int userID);

        List<Album> GetAll();
    }
}