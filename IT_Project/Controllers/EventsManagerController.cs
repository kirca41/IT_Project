using IT_Project.Models;
using IT_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_Project.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class EventsManagerController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: EventsManager
        public ActionResult Index()
        {
            var model = new EventInfoViewModel();
            model.Plays = _db.TheatrePlayInfos.GroupBy(x => x.Title).ToDictionary(g => g.Key, g => g.OrderBy(x => x.DateAndTime).ToList());
            model.Movies = _db.MovieInfos.GroupBy(x => x.Title).ToDictionary(g => g.Key, g => g.OrderBy(x => x.DateAndTime).ToList());

            return View(model);
        }

        public ActionResult Plays()
        {
            List<string> titles = _db.TheatrePlays.Select(p => p.Title).ToList();
            titles.Insert(0, "---");
            ViewBag.Titles = titles;
            return View();
        }

        public ActionResult AddPlayInfo(string title)
        {
            var play = _db.TheatrePlays.Where(p => p.Title == title).FirstOrDefault();
            if (play == null)
            {
                return HttpNotFound();
            }

            var model = new TheatrePlayInfo();
            model.TheatrePlayId = play.TheatrePlayId;
            model.Title = play.Title;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddPlayInfo(TheatrePlayInfo model)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            _db.TheatrePlayInfos.Add(model);
            _db.SaveChanges();

            return RedirectToAction("Plays");
        }

        public ActionResult EditPlayInfo(int? id)
        {
            var model = _db.TheatrePlayInfos.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult EditPlayInfo(TheatrePlayInfo model)
        {
            if (!ModelState.IsValid)
            {
                return View(_db.TheatrePlayInfos.Find(model.Id));
            }

            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeletePlayInfo(int? id)
        {
            var model = _db.TheatrePlayInfos.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            _db.TheatrePlayInfos.Remove(model);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Movies()
        {
            List<string> titles = _db.Movies.Select(p => p.Title).ToList();
            titles.Insert(0, "---");
            ViewBag.Titles = titles;
            return View();
        }

        public ActionResult AddMovieInfo(string title)
        {
            var movie = _db.Movies.Where(p => p.Title == title).FirstOrDefault();
            if (movie == null)
            {
                return HttpNotFound();
            }

            var model = new MovieInfo();
            model.MovieId = movie.MovieId;
            model.Title = movie.Title;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddMovieInfo(MovieInfo model)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            _db.MovieInfos.Add(model);
            _db.SaveChanges();

            return RedirectToAction("Movies");
        }

        public ActionResult EditMovieInfo(int? id)
        {
            var model = _db.MovieInfos.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult EditMovieInfo(MovieInfo model)
        {
            if (!ModelState.IsValid)
            {
                return View(_db.MovieInfos.Find(model.Id));
            }

            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteMovieInfo(int? id)
        {
            var model = _db.MovieInfos.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            _db.MovieInfos.Remove(model);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }

    }
}