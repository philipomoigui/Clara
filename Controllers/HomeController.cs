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
        private readonly IHomeRepository _homeRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHomeRepository homeRepository, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _homeRepository = homeRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categoryList = _categoryRepository.GetAllCategories.OrderBy(c => c.CategoryName).ToList();
            categoryList.Insert(0, new Category { CategoryId = 0, CategoryName = "Select Category" });

            HomeIndexViewModel model = new HomeIndexViewModel
            {
                PopularHalls = _homeRepository.GetPopularCategory(233).ToList(),
                PopularLogistics = _homeRepository.GetPopularCategory(234).ToList(),
                PopularPlanner = _homeRepository.GetPopularCategory(235).ToList(),
                PopularFood = _homeRepository.GetPopularCategory(236).ToList(),
                PopularAccomodation = _homeRepository.GetPopularCategory(237).ToList(),
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
