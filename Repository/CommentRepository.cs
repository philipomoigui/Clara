using Clara.DataAccess;
using Clara.Models;
using Clara.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CommentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void AddComment(Comment comment)
        {
            Create(comment);
        }

        public IEnumerable<Comment> GetComments(Guid serviceId)
        {
            return FindByCondition(c => c.ServiceId == serviceId)
                  .Include(c => c.User)
                  .OrderByDescending(e => e.Timestamp)
                  .Take(5)
                  .ToList();
        }

        public bool HasUserComment(string userId, Guid serviceId)
        {
            return FindByCondition(c => c.UserId.Equals(userId) && c.ServiceId.Equals(serviceId))
                .Any();
        }

        public IEnumerable<Comment> GetUserComments(string userId)
        {
            return FindByCondition(c => c.Service.UserId.Equals(userId))
                .Include(c => c.User)
                .Take(5)
                .ToList();
        }

        public IEnumerable<int> GetTotalServiceRating(Guid serviceId)
        {
            return FindByCondition(c => c.ServiceId.Equals(serviceId))
                .Select(c => c.rating)
                .ToList();
        }
    }
}
