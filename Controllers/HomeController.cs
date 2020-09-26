using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Clara.Models;
using Clara.ViewModels;
using Microsoft.AspNetCore.Identity;
using Clara.Repository.Interface;

namespace Clara.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IRepositoryManager _repositoryManger;
       

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IRepositoryManager repositoryManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _repositoryManger = repositoryManager;
            
        }

        public IActionResult Index()
        {
            var categoryList = _repositoryManger.Category.GetAllCategories.OrderBy(c => c.CategoryName).ToList();
            categoryList.Insert(0, new Category { CategoryId = 0, CategoryName = "Select Category" });

            HomeIndexViewModel model = new HomeIndexViewModel
            {
                PopularHalls = _repositoryManger.Service.GetPopularCategory(233).ToList(),
                PopularLogistics = _repositoryManger.Service.GetPopularCategory(234).ToList(),
                PopularPlanner = _repositoryManger.Service.GetPopularCategory(235).ToList(),
                PopularFood = _repositoryManger.Service.GetPopularCategory(236).ToList(),
                PopularAccomodation = _repositoryManger.Service.GetPopularCategory(237).ToList(),
                CategoryList = categoryList
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
