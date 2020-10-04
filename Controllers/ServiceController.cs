using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clara.Models;
using Clara.Repository.Interface;
using Clara.Utility;
using Clara.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clara.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {
        
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ServiceController(IMapper mapper, IRepositoryManager repositoryManager, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            CreateServiceViewModel model = new CreateServiceViewModel();

            var categoryList = _repositoryManager.Category.GetAllCategories.OrderBy(c => c.CategoryName).ToList();

            categoryList.Insert(0, new Category { CategoryId = 0, CategoryName = "--- Select A Category ---" });

            model.Categories = categoryList;

            return View(model);
        }

        public IActionResult Success()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var service = _mapper.Map<Service>(model);
                 _repositoryManager.Service.CreateService(service);
                await _repositoryManager.saveAsync();
                return RedirectToAction(nameof(Success));
            }
            return View(model);
        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Services(Guid id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Services(int? pageNumber, string category, string location, string search)
        {
            int pageSize = 3;
            List<ServicesViewModel> services;
            string serviceTop = string.Empty;
            var locationIncluded = location ?? "All Location";

            if (!string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(location) && !string.IsNullOrEmpty(search))
            {
                services = _repositoryManager.Service.GetServicesByLocationAndSearch(category, location, search)
                    .Select(service => _mapper.Map<ServicesViewModel>(service))
                    .ToList();

                
                    serviceTop = $"{category} in {locationIncluded}";
            } 
            
            else if (!string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(location))
            {
                services = _repositoryManager.Service.GetServicesByLocation(category, location)
                    .Select(service => _mapper.Map<ServicesViewModel>(service))
                    .ToList();

                serviceTop = $"{category} in {locationIncluded}";
            }

            else if (!string.IsNullOrEmpty(category))
            {
                services = _repositoryManager.Service.GetServicesByCategory(category)
                    .Select(service => _mapper.Map<ServicesViewModel>(service))
                    .ToList();

                serviceTop = $"{category}";
            }
            else
            {
                services = _repositoryManager.Service.GetAllService()
                    .Select(service => _mapper.Map<ServicesViewModel>(service))
                    .ToList();

                serviceTop = "All Categories";
            }

            ViewBag.servicesTop = serviceTop;
            ViewBag.ServiceCount = services.Count();

            return View(ServicesPagination<ServicesViewModel>.Create(services, pageSize, pageNumber ?? 1));
        }


        [HttpGet]
        public async  Task<IActionResult> Details(Guid serviceId, int categoryId)
        {
            var service = await _repositoryManager.Service.GetServiceById(serviceId);
            var userId = _userManager.GetUserId(User);

            if (service == null)
                return NotFound();

            //Random Services
            var services = _repositoryManager.Service.GetAllService()
                .OrderBy(s => Guid.NewGuid())
                .Take(3)
                .ToList();

            //Comments
            var comments = _repositoryManager.Comment.GetComments(serviceId).ToList();

            DetailsViewModel model = new DetailsViewModel
            {
                Service = service,
                RandomServices = services,
                Comments = comments
            };

            //Bookmark
            var bookmark = _repositoryManager.Bookmark.GetUserBookmark(userId, serviceId);
            if (bookmark != null)
                model.isBookmarked = true;
            else
                model.isBookmarked = false;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Details(DetailsViewModel model)
        {
            var userProfile = _repositoryManager.UserProfile.GetUserProfile(model.UserId);
            var service = await _repositoryManager.Service.GetServiceById(model.ServiceId);

            if (ModelState.IsValid)
            {
                var hasUserComment = _repositoryManager.Comment.HasUserComment(model.UserId, model.ServiceId);

                if (!hasUserComment)
                {
                    Comment comment = new Comment
                    {
                        Message = model.Message,
                        Timestamp = model.Timestamp,
                        UserId = model.UserId,
                        ServiceId = model.ServiceId
                    };

                    _repositoryManager.Comment.AddComment(comment);

                    Notification notification = new Notification
                    {
                        Text = $"{userProfile.FirstName} {userProfile.LastName} left a review on {service.BusinessName} with 3.0 rating",
                    };

                    _repositoryManager.Notification.AddNotication(notification);

                    NotificationApplicationUser userNotification = new NotificationApplicationUser();
                    userNotification.NotificationId = notification.NotificationId;
                    userNotification.UserId = model.UserId;

                    _repositoryManager.UserNotification.AddUserNotification(userNotification);

                    await _repositoryManager.saveAsync();
                    return RedirectToAction(nameof(Details), new { serviceId = model.ServiceId, categoryId = model.CategoryId });
                }

                ViewBag.CommentMessage = "Sorry, You have already Reviewed This Service";
                return View(model);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult AutoCompleteResult(string search)
        {
            return Json(_repositoryManager.Service.GetSearchResult(search).ToList());
        }


    }
}
