﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tivoy.Controllers
{
    public class TourController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}