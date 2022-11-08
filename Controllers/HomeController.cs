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
            int chieurap = 28;
            int phimle = 27;
            int tvshow = 26;
            int TVB = 25;
            int hoathinh = 18;
            List<Film> topFilm = db.Films.FromSqlRaw("select * from selectTopFilm").ToList();
            List<Film> movie = db.Films.FromSqlRaw($"exec listFilmWithGenretop8 '{chieurap}'").ToList();
            List<Film> leFilm = db.Films.FromSqlRaw($"exec listFilmWithGenretop8 '{phimle}'").ToList();
            List<Film> tv = db.Films.FromSqlRaw($"exec listFilmWithGenretop8 '{tvshow}'").ToList();
            List<Film> tvbFilm = db.Films.FromSqlRaw($"exec listFilmWithGenretop8 '{TVB}'").ToList();
            List<Film> anime = db.Films.FromSqlRaw($"exec listFilmWithGenretop8 '{hoathinh}'").ToList();
            ListFilm list = new ListFilm();
            list.topFilm = topFilm;
            list.cgvFilm = movie;
            list.AnimeFilm = anime;
            list.TVBFilm = tvbFilm;
            list.TvShow = tv;
            list.singleFilm = leFilm;
            return View(list);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserID");
            HttpContext.Session.Remove("UserLevel");
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index");
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