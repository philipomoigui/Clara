using Clara.DataAccess;
using Clara.Models;
using Clara.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository
{
    public class BookmarkRepository: RepositoryBase<Bookmark>, IBookmarkRepository
    {
        public BookmarkRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public void AddToBookmark(Bookmark bookmark)
        {
            Create(bookmark);
        }

        public void DeleteFromBookMark(Bookmark bookmark)
        {
            Delete(bookmark);
        }

        public IEnumerable<Bookmark> GetUserBookmarks(string userId)
        {
           return  FindByCondition(b => b.UserId.Equals(userId))
                .ToList();
        }

        public Bookmark isServiceBookmarked(string userId, Guid serviceId)
        {
           return  FindByCondition(b => b.UserId == userId && b.ServiceId.Equals(serviceId)).FirstOrDefault();
        }

        IEnumerable<Service> IBookmarkRepository.GetUserBookmarks(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
