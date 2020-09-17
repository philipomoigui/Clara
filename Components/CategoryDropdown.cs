using Clara.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Components
{
    public class CategoryDropdown: ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryDropdown(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var Categories = _categoryRepository.GetAllCategories.OrderBy(c => c.CategoryName);
;            var result = "";
            foreach(var category in Categories)
            {
                result = category.CategoryName;
            }
            ViewBag.Results = result;

            return View();
        }
    }
}
