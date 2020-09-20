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
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CommentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task AddCommentAsync(Comment comment)
        {
            await _applicationDbContext.AddAsync(comment);
        }

        public async Task<bool> CompleteAsync()
        {
            return (await _applicationDbContext.SaveChangesAsync() >= 0 );
        }

        public IQueryable<Comment> GetComments(Guid serviceId)
        {
            return _applicationDbContext.Comments
                  .AsNoTracking()
                  .Where(c => c.ServiceId == serviceId)
                  .Include(c => c.User)
                  .OrderByDescending(e => e.Timestamp);
        }
    }
}
