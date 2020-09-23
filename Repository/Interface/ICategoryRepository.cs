using Clara.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories { get;}
    }
}
