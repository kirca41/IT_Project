using IT_Project.Models;
using IT_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IT_Project.Controllers
{
    public class TheatrePlaysController : Controller
    {

        private ApplicationDbContext _db = new ApplicationDbContext();  

        // GET: TheatrePlays
        public ActionResult Index()
        {
            var model = (from m in _db.TheatrePlays
                          select new TheatrePlayViewModel 
                          { TheatrePlayId = m.TheatrePlayId, Title = m.Title, Author = m.Author, Genre = m.Genre, Poster = m.Poster }).ToList();
            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Add()
        {
            var model = new TheatrePlay();
            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Add(TheatrePlay Model)
        {
            if (!ModelState.IsValid || Model.File.ContentLength <= 0)
            {
                return HttpNotFound();
            }

            Model.Poster = new byte[Model.File.ContentLength];
            Model.File.InputStream.Read(Model.Poster, 0, Model.File.ContentLength);

            _db.TheatrePlays.Add(Model);
            _db.SaveChanges();

            return Redirect("/Home");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            var model = _db.TheatrePlays.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Edit(TheatrePlay Model)
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
                    var curr = _db.TheatrePlays.Find(Model.TheatrePlayId);
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
        public ActionResult Delete(int id)
        {
            var model = _db.TheatrePlays.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            var modelInfos = _db.TheatrePlayInfos.Where(m => m.TheatrePlayId == id).ToList();
            _db.TheatrePlayInfos.RemoveRange(modelInfos);
            _db.TheatrePlays.Remove(model);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = _db.TheatrePlays.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        public ActionResult Infos(int id)
        {
            var model = _db.TheatrePlayInfos.Where(m => m.TheatrePlayId == id).ToList();
            var stage = _db.TheatrePlays.Find(id).Stage;
            if (stage == "Мала")
            {
                ViewBag.Capacity = 300;
            }
            else
            {
                ViewBag.Capacity = 500;
            }
            return PartialView(model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }
    }
}