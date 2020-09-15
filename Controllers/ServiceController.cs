using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clara.Models;
using Clara.Repository.Interface;
using Clara.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Clara.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServicesRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceController(IServicesRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

            return View();
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
                //return RedirectToAction(nameof(Detail), new {id = service.ServiceId });
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
    }
}
