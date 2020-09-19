using Clara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository.Interface
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comment comment);
        IQueryable<Comment> GetComments(Guid serviceId);
        Task<bool> CompleteAsync();

    }
}
