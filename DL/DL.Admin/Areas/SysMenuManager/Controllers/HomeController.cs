﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DL.Admin.Areas.SysMenuManager.Controllers
{
	[Area("SysMenuManager")]
	public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}