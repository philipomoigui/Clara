using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clara.Models;
using Clara.Repository;
using Clara.Repository.Interface;
using Clara.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Clara.Controllers
{
    public class BookingController : Controller
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public BookingController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public IActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Booking(Guid serviceId)
        {
            if (ModelState.IsValid)
            {
                if (serviceId == null)
                    return NotFound();

                var service = _repositoryManager.Service.GetServiceById(serviceId);
                if (service == null)
                    return NotFound();

                BookingViewModel model = new BookingViewModel();

                var booking = _mapper.Map<Booking>(model);
                _repositoryManager.Booking.AddBooking(booking);
                await _repositoryManager.saveAsync();
                return RedirectToAction(nameof(Success));
            }

            return View();
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
