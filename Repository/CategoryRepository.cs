using Clara.DataAccess;
using Clara.Models;
using Clara.Repository.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Category> GetAllCategories => _applicationDbContext.Categories;

        public IEnumerable<SelectListItem> GetCategoriesList()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<SelectListItem> GetCategoriesList()
        //{
        //    var categories = _applicationDbContext.Categories.OrderBy(c => c.CategoryName).ToList();

        //    categories.Insert(0, new Category { CategoryId = 0, CategoryName = "--- Select A Category ---" });

        //    return categories;
        //}
    }
}
