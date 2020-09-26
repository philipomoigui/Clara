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
        private readonly IRepositoryManager _repositoryManager;

        public CategoryMenu(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public IViewComponentResult Invoke()
        {
           var categories =  _repositoryManager.Category.GetAllCategories.OrderBy(category => category.CategoryName);
            return View(categories);
        }
    }
}
