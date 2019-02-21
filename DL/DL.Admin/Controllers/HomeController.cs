using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DL.Admin.Models;
using DL.IServices;

namespace DL.Admin.Controllers
{

	public class HomeController : Controller
    {
        private readonly ISysManagerServices _sysManagerService;
        private readonly ISysMenuServices _sysMenuService;

        public HomeController(ISysManagerServices sysManagerService, ISysMenuServices sysMenuService)
        {
            this._sysManagerService = sysManagerService;
            this._sysMenuService = sysMenuService;
        }
        public IActionResult Index()
        {
            var list = _sysManagerService.GetList();
            var menulist = _sysMenuService.GetList();
            return View();
        }
		public IActionResult AdminLogin()
		{
			
			return View();
		}
		//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		//public IActionResult Error()
		//{
		//    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		//}
	}
}
