using Clara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository.Interface
{
    public interface IHomeRepository
    {
        IQueryable<Service> GetPopularCategory(int categoryId);
    }
}
