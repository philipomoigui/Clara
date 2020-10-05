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
        Bookmark isServiceBookmarked(string userId, Guid serviceId);
        void DeleteFromBookMark(Bookmark bookmark);
        IEnumerable<Bookmark>GetUserBookmarks(string userId);
    }
}
