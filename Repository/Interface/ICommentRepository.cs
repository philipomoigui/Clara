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
        IEnumerable<Comment> GetComments(Guid serviceId);

    }
}
