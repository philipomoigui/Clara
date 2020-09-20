using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clara.Models;
using Clara.Repository.Interface;
using Clara.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Clara.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IMapper mapper, IUserRepository userRepository, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Account()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Personal()
        {
            var userId = _userManager.GetUserId(User);
            var userProfile = _userRepository.GetUserProfile(userId);
           var model =  _mapper.Map<UserProfileViewModel>(userProfile);

            return View(model);
        }

        [HttpPost]
        public IActionResult Personal(UserProfileViewModel model)
        {

            return View();
        }
    }
}
