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
            var user = db.UserSystems.FromSqlRaw($"exec USP_LOGIN '{useremail}','{userpass}'").FirstOrDefault();
            if (user != null)
            {
                HttpContext.Session.SetString("UserID", user.UserName);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
