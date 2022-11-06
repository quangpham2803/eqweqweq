using hentaweb_v2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace hentaweb_v2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        hentawebContext db = new hentawebContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserID") != null)
            {
                var list = db.UserSystems.FromSqlRaw($"exec USP_FINDUSER {HttpContext.Session.GetInt32("UserID")}").ToList();
                UserSystem user = list[0];
                return View(user);
            }
            else
            {
                UserSystem user = new UserSystem();
                user.UserId = 0;
                user.UserName = "";
                user.UserEmail = "";
                user.UserLevel = -1;
                user.UserPassword = "";
                user.UserInfo = "";
                user.UserImage = "";
                return View(user);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}