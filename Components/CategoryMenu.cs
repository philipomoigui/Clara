using Clara.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Components
{
    public class CategoryMenu: ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
           var categories =  _categoryRepository.GetAllCategories.OrderBy(category => category.CategoryName);
            return View(categories);
        }
    }
}
