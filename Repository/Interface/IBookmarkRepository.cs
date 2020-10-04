using Clara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository.Interface
{
    public interface IBookmarkRepository
    {
        void AddToBookmark(Bookmark bookmark);
        Bookmark GetUserBookmark(string userId, Guid serviceId);
        void DeleteFromBookMark(Bookmark bookmark);
    }
}
