using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DL.Admin.Models;
using DL.IServices;

namespace DL.Admin.Controllers
{

	public class HomeController : Controller
    {
        private readonly ISysManagerServices _SysManagerService;
        private readonly ISysMenuServices _SysMenuService;

        public HomeController(ISysManagerServices SysManagerService, ISysMenuServices SysMenuService)
        {
            this._SysManagerService = SysManagerService;
            this._SysMenuService = SysMenuService;
        }
        public IActionResult Index()
        {
            var list = _SysManagerService.GetList();
            var menulist = _SysMenuService.GetList();
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
