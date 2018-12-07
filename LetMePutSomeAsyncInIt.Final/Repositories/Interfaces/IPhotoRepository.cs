using LetMePutSomeAsyncInIt.Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetMePutSomeAsyncInIt.Final.Repositories.Interfaces
{
    public interface IPhotoRepository
    {
        Photo GetByID(int id);
        List<Photo> GetAll();
    }
}