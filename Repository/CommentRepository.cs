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
                  .OrderByDescending(e => e.Timestamp);
        }
    }
}
