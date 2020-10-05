using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Clara.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Booking()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
