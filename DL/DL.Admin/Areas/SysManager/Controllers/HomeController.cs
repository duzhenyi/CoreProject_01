using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DL.Admin.Areas.SysManager.Controllers
{
    [Area("SysManager")]
    public class HomeController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }
    }
}