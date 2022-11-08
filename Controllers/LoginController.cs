using Microsoft.AspNetCore.Mvc;
using hentaweb_v2.Models;
using Microsoft.EntityFrameworkCore;

namespace hentaweb_v2.Controllers
{
    public class LoginController : Controller
    {
        hentawebContext db = new hentawebContext();
        //GET
        public IActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            String useremail = form["useremail"];
            String userpass = form["userpass"];
            var list = db.UserSystems.FromSqlRaw($"exec USP_LOGIN '{useremail}','{userpass}'").ToList();
            if (list.Count >0)
            {
                UserSystem user = list[0];
                HttpContext.Session.SetInt32("UserID", user.UserId);
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.SetInt32("UserLevel", user.UserLevel);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
