using hentaweb_v2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hentaweb_v2.Controllers
{
    public class WatchController : Controller
    {
        hentawebContext db = new hentawebContext();
        public IActionResult Index(int? id)
        {
            WatchInfo watchInfo = new WatchInfo();
            var f = db.Films.FromSqlRaw($"exec FindFilmbyID '{id}'").ToList();
            List<Film> list = db.Films.FromSqlRaw($"exec listFilmLikeCurrent '{id}'").ToList();
            watchInfo.film = f[0];
            watchInfo.listFilmLike = list;
            return View(watchInfo);
        }
    }
}
