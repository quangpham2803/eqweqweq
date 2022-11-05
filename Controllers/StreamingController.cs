using Microsoft.AspNetCore.Mvc;

namespace hentaweb_v2.Controllers
{
    public class StreamingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
