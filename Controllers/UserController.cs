﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Clara.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
    }
}
