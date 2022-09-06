using IT_Project.Models;
using IT_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IT_Project.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            var model = (from m in _db.Movies
                         select new MovieViewModel
                         { MovieId = m.MovieId, Title = m.Title, Director = m.Director, Genre = m.Genre, Poster = m.Poster }).ToList();
            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Add()
        {
            var model = new Movie();
            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Add(Movie Model)
        {
            if (!ModelState.IsValid || Model.File.ContentLength <= 0)
            {
                return HttpNotFound();
            }

            Model.Poster = new byte[Model.File.ContentLength];
            Model.File.InputStream.Read(Model.Poster, 0, Model.File.ContentLength);

            _db.Movies.Add(Model);
            _db.SaveChanges();

            return Redirect("/Home");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _db.Movies.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Edit(Movie Model)
        {
            if (ModelState.ContainsKey("File"))
            {
                ModelState["File"].Errors.Clear();
            }

            if (ModelState.IsValid)
            {
                if (Model.File != null && Model.File.ContentLength > 0)
                {
                    Model.Poster = new byte[Model.File.ContentLength];
                    Model.File.InputStream.Read(Model.Poster, 0, Model.File.ContentLength);
                }
                else
                {
                    var curr = _db.Movies.Find(Model.MovieId);
                    _db.Entry(curr).State = EntityState.Detached;

                    HttpPostedFileBase custom = (HttpPostedFileBase)new HttpPostedFileBaseCustom(curr.Poster);
                    Model.File = custom;
                }

                _db.Entry(Model).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", Model);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            var model = _db.Movies.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            var modelInfos = _db.MovieInfos.Where(m => m.MovieId == id).ToList();
            _db.MovieInfos.RemoveRange(modelInfos);
            _db.Movies.Remove(model);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = _db.Movies.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        public ActionResult Infos(int id)
        {
            var model = _db.MovieInfos.Where(m => m.MovieId == id).ToList();
            ViewBag.Capacity = 500;

            return PartialView(model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }
    }
}