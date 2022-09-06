using IT_Project.Models;
using IT_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_Project.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var model = new HomePageViewModel();
            List<Event> events = new List<Event>();
            events.AddRange(_db.TheatrePlays.OrderBy(p => System.Guid.NewGuid()).Take(3));
            events.AddRange(_db.Movies.OrderBy(m => System.Guid.NewGuid()).Take(3));
            var nextPlayInfo = _db.TheatrePlayInfos.OrderBy(p => p.DateAndTime).First();
            var nextMovieInfo = _db.MovieInfos.OrderBy(m => m.DateAndTime).First();
            var nextPlay = _db.TheatrePlays.Find(nextPlayInfo.TheatrePlayId);
            var nextMovie = _db.Movies.Find(nextMovieInfo.MovieId);
            model.Events = events;
            model.NextPlayInfo = nextPlayInfo;
            model.NextMovieInfo = nextMovieInfo;
            model.NextPlay = nextPlay;
            model.NextMovie = nextMovie;
            if (nextPlay.Stage == "Мала")
            {
                ViewBag.Capacity = 300;
            }
            else
            {
                ViewBag.Capacity = 500;
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }
    }
}