using Clara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository.Interface
{
    public interface ICommentRepository : IRepositoryBase<Comment>
    {
        void AddComment(Comment comment);
        bool HasUserComment(string userId, Guid serviceId);
        IEnumerable<Comment> GetComments(Guid serviceId);

    }
}
