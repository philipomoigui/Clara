using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clara.Models;
using Clara.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Clara.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Account()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Personal()
        {
            UserProfile userProfile = new UserProfile();

            UserProfileViewModel model = new UserProfileViewModel
            {

            };

            return View();
        }

        [HttpPost]
        public IActionResult Personal(UserProfileViewModel model)
        {

            return View();
        }
    }
}
