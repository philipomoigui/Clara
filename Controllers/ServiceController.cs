using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clara.Infrastructure;
using Clara.Models;
using Clara.Repository.Interface;
using Clara.Utility;
using Clara.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;

namespace Clara.Controllers
{
    public class ServiceController : Controller
    {
        
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHubContext<SignalServer> _hubContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ServiceController(IMapper mapper, IRepositoryManager repositoryManager, UserManager<ApplicationUser> userManager, IHubContext<SignalServer> hubContext, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
            _userManager = userManager;
            _hubContext = hubContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
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
        [Authorize]
        public async Task<IActionResult> Create(CreateServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = _mapper.Map<Service>(model);
                service.ImageURL = ImagesUpload(model);
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
            int pageSize = 6;
            List<ServicesViewModel> services;
            string serviceTop = string.Empty;
            var locationIncluded = location ?? "All Location";

            //category List
            var categoryList = _repositoryManager.Category.GetAllCategories.OrderBy(c => c.CategoryName).ToList();
            categoryList.Insert(0, new Category { CategoryId = 0, CategoryName = "Select Category" });
            if (category == "Select Category")
                category = null;


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

                serviceTop = $"{category} Services";
            } 
            else if (!string.IsNullOrEmpty(location))
            {
                services = _repositoryManager.Service.GetServicesByLocation(location)
                    .Select(service => _mapper.Map<ServicesViewModel>(service))
                    .ToList();

                serviceTop = $"Services In {location}";
            }
            else
            {
                services = _repositoryManager.Service.GetAllService()
                    .Select(service => _mapper.Map<ServicesViewModel>(service))
                    .ToList();

                serviceTop = "All Services";
            }

            ViewBag.servicesTop = serviceTop;
            ViewBag.ServiceCount = services.Count();
            ViewBag.CategoryList = categoryList;

            return View(ServicesPagination<ServicesViewModel>.Create(services, pageSize, pageNumber ?? 1));
        }


        [HttpGet]
        public async  Task<IActionResult> Details(Guid serviceId, int categoryId)
        {
            var service = await _repositoryManager.Service.GetServiceById(serviceId);

            var userId = _userManager.GetUserId(User);

            if (service == null)
                return View("Notfound");

            //Random Services
            var services = _repositoryManager.Service.GetRandomService(serviceId);
               
            //Comments
            var comments = _repositoryManager.Comment.GetComments(serviceId).ToList();

            //Rating
            var totalRating = Convert.ToInt32(TotalRating(serviceId));

            DetailsViewModel model = new DetailsViewModel
            {
                Service = service,
                RandomServices = services,
                Comments = comments,
                Amenities = formatAmenties(service),
                Rating = totalRating,
                ImagesUrl = formatImage(service),
                ImageUrl = formatImage(service)[0]
                
            };

            //Bookmark
            var bookmark = _repositoryManager.Bookmark.isServiceBookmarked(userId, serviceId);
            if (bookmark != null)
                model.isBookmarked = true;
            else
                model.isBookmarked = false;

            return View(model);
        }

        private int TotalRating(Guid serviceId)
        {
            var ratings = _repositoryManager.Comment.GetTotalServiceRating(serviceId);
            int total = 0;
            foreach (var rating in ratings)
            {
                total += rating;
            }
            if(ratings.Count() != 0)
                return total / ratings.Count();

            return 0;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(DetailsViewModel model)
        {
            var userProfile = _repositoryManager.UserProfile.GetUserProfile(model.UserId);

            var service = await _repositoryManager.Service.GetServiceById(model.ServiceId);

            if (ModelState.IsValid)
            {
                var hasUserComment = _repositoryManager.Comment.HasUserComment(model.UserId, model.ServiceId);

               var comment =  _mapper.Map<Comment>(model);

                _repositoryManager.Comment.AddComment(comment);

                SendNotificationToUser(userProfile, service, comment);

                await _repositoryManager.saveAsync();
                await _hubContext.Clients.All.SendAsync("displayNotification", "");

                return RedirectToAction(nameof(Details), new { serviceId = model.ServiceId, categoryId = model.CategoryId });
            }

            return View(model);
        }

        private void SendNotificationToUser(UserProfile userProfile, Service service, Comment comment)
        {
            Notification notification = new Notification
            {
                Text = $"{userProfile.FirstName} {userProfile.LastName} left a review on {service.BusinessName} with a {comment.rating}.0 rating",
            };

            _repositoryManager.Notification.AddNotification(notification);

            NotificationApplicationUser userNotification = new NotificationApplicationUser();
            userNotification.NotificationId = notification.NotificationId;
            userNotification.UserId = service.User.Id;

            _repositoryManager.UserNotification.AddUserNotification(userNotification);
        }

        private string ImagesUpload(CreateServiceViewModel model)
        {
            string allFileName = string.Empty;

            if(model.Photos != null  && model.Photos.Count > 0)
            {
                foreach(var photo in model.Photos)
                {
                    string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    photo.CopyToAsync(new FileStream(filePath, FileMode.Create));
                    if(string.IsNullOrEmpty(allFileName))
                    {
                        allFileName += uniqueFileName;
                    }
                    allFileName = allFileName + "," + uniqueFileName;
                }
            }
            return allFileName;
        }

        private List<string> formatAmenties(Service service)
        {
            var amenities = new string[] { };
            if (service.Amenities.Contains(','))
            {
                amenities = service.Amenities.Trim().Split(",");
                return amenities.ToList();
            } else
            {
                List<string> value = new List<string>();
                value.Add(service.Amenities);
                return value;
            }
   
        }

        private List<string> formatImage(Service service)
        {
            return service.ImageURL.Trim().Split(',').ToList();
        }

    }
}