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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clara.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly IServicesRepository _serviceRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICommentRepository _commentRepository;

        public ServiceController(IServicesRepository serviceRepository, IMapper mapper, ICategoryRepository categoryRepository, ICommentRepository commentRepository)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _commentRepository = commentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            CreateServiceViewModel model = new CreateServiceViewModel();

            var categoryList = _categoryRepository.GetAllCategories.OrderBy(c => c.CategoryName).ToList();

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
                await _serviceRepository.CreateServiceAsync(service);
                await _serviceRepository.SaveAsync();
                return RedirectToAction(nameof(Success));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(Guid id)
        {
            var service = _serviceRepository.GetServiceById(id);
            if (service == null)
                return NotFound();

            var model= _mapper.Map<DetailViewModel>(service);
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Service service = _serviceRepository.GetServiceById(id);
            if(service == null)
                return NotFound();

            var model = _mapper.Map<EditViewModel>(service);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = _serviceRepository.GetServiceById(model.ServiceId);
                if (service == null)
                    return NotFound();

               var updateService =  _mapper.Map<Service>(model);
                 _serviceRepository.UpdateService(updateService);
                await _serviceRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            _serviceRepository.DeleteService(id);
            await _serviceRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Services(Guid id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Services(int? pageNumber)
        {
           var services = _serviceRepository.GetAllService()
                .Select(service => new ServicesViewModel
                {
                    ServiceId = service.ServiceId,
                    BusinessName = service.BusinessName,
                    BusinessEmail = service.BusinessEmail,
                    AddressLine = service.AddressLine,
                    City = service.City,
                    State = service.State,
                    ZipCode = service.ZipCode,
                    CategoryId = service.CategoryId,
                    Category = service.Category
                })
                .ToList();
            //ServicesViewModel model = new ServicesViewModel
            //{
            //    Services = services
            //};

            int pageSize = 3;

            return View(ServicesPagination<ServicesViewModel>.Create(services, pageSize, pageNumber ?? 1));
        }

        [HttpGet]
        public IActionResult Details(Guid serviceId, int categoryId)
        {
            var service = _serviceRepository.GetServiceById(serviceId);
            if (service == null)
                return NotFound();

            //Random Services
            var services = _serviceRepository.GetAllService()
                .Where(s => s.CategoryId == categoryId)
                .OrderBy(s => Guid.NewGuid())
                .Take(3)
                .ToList();

            //Comments
            var comments = _commentRepository.GetComments(serviceId).ToList();

            DetailsViewModel model = new DetailsViewModel
            {
                Service = service,
                RandomServices = services,
                Comments = comments
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Details(DetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var comment = _mapper.Map<Comment>(model);
                Comment comment = new Comment
                {
                    Message = model.Message,
                    Timestamp = model.Timestamp,
                    UserId = model.UserId,
                    ServiceId = model.ServiceId
                };

                await _commentRepository.AddCommentAsync(comment);
                await _commentRepository.CompleteAsync();
                return RedirectToAction(nameof(Details), new {serviceId = model.ServiceId, categoryId = model.CategoryId });
                //RedirectToAction("Services");
                //return View();
            }

            return View(model);
        }
    }
}
