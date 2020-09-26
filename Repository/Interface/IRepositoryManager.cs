using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository.Interface
{
    public interface IRepositoryManager
    {
        IServicesRepository Service { get; }
        ICommentRepository Comment { get; }
        IUserRepository UserProfile { get; }
        ICategoryRepository Category { get; }
        Task saveAsync();
    }
}
