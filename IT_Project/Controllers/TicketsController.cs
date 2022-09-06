using IT_Project.Models;
using IT_Project.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_Project.Controllers
{
    public class TicketsController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        [Authorize(Roles = "Administrator")]
        public ActionResult Tickets()
        {
            var model = new TicketsViewModel();
            model.Plays = _db.TheatrePlayTicketPurchases.GroupBy(x => x.Info).ToDictionary(g => g.Key, g => g.OrderBy(x => x.PurchaseDate).ToList());
            model.Movies = _db.MovieTicketPurchases.GroupBy(x => x.Info).ToDictionary(g => g.Key, g => g.OrderBy(x => x.PurchaseDate).ToList());

            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Reservations()
        {
            var model = new ReservationsViewModel();
            model.Plays = _db.TheatrePlayReservations.GroupBy(x => x.Info).ToDictionary(g => g.Key, g => g.OrderBy(x => x.ReservationDate).ToList());
            model.Movies = _db.MovieReservations.GroupBy(x => x.Info).ToDictionary(g => g.Key, g => g.OrderBy(x => x.ReservationDate).ToList());

            return View(model);
        }

        public ActionResult AddTheatrePlayReservation(int id)
        {
            var model = new TheatrePlayReservation();
            model.Info = _db.TheatrePlayInfos.Find(id);
            model.TheatrePlayInfoId = id;
            model.UserEmail = User.Identity.GetUserName();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddTheatrePlayReservation(TheatrePlayReservation model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            } 

            model.ReservationDate = DateTime.Now;
            _db.TheatrePlayReservations.Add(model);
            _db.SaveChanges();

            var info = _db.TheatrePlayInfos.Find(model.TheatrePlayInfoId);
            info.TicketsGiven = info.TicketsGiven + model.ReservationCount;
            _db.Entry(info).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Reservations");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult UpdatePaymentTheatrePlayReservation(int id)
        {
            var model = _db.TheatrePlayReservations.Find(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            model.Paid = true;
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Reservations");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult CancelTheatrePlayReservation(int id)
        {
            var model = _db.TheatrePlayReservations.Find(id);
            var info = _db.TheatrePlayInfos.Find(model.TheatrePlayInfoId);
            info.TicketsGiven = info.TicketsGiven - model.ReservationCount;
            _db.TheatrePlayReservations.Remove(model);
            _db.Entry(info).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Reservations");
        }

        public ActionResult AddMovieReservation(int id)
        {
            var model = new MovieReservation();
            model.Info = _db.MovieInfos.Find(id);
            model.MovieInfoId = id;
            model.UserEmail = User.Identity.GetUserName();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddMovieReservation(MovieReservation model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.ReservationDate = DateTime.Now;
            _db.MovieReservations.Add(model);
            _db.SaveChanges();

            var info = _db.MovieInfos.Find(model.MovieInfoId);
            info.TicketsGiven = info.TicketsGiven + model.ReservationCount;
            _db.Entry(info).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Reservations");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult UpdatePaymentMovieReservation(int id)
        {
            var model = _db.MovieReservations.Find(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            model.Paid = true;
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Reservations");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult CancelMovieReservation(int id)
        {
            var model = _db.MovieReservations.Find(id);
            var info = _db.MovieInfos.Find(model.MovieInfoId);
            info.TicketsGiven = info.TicketsGiven - model.ReservationCount;
            _db.MovieReservations.Remove(model);
            _db.Entry(info).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Reservations");
        }

        public ActionResult AddTheatrePlayPurchase(int id)
        {
            var model = new TheatrePlayTicketPurchase();
            model.Info = _db.TheatrePlayInfos.Find(id);
            model.TheatrePlayInfoId = id;
            model.UserEmail = User.Identity.GetUserName();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddTheatrePlayPurchase(TheatrePlayTicketPurchase model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.PurchaseDate = DateTime.Now;
            _db.TheatrePlayTicketPurchases.Add(model);
            _db.SaveChanges();

            var info = _db.TheatrePlayInfos.Find(model.TheatrePlayInfoId);
            info.TicketsGiven = info.TicketsGiven + model.TicketsCount;
            _db.Entry(info).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Tickets");
        }

        public ActionResult AddMoviePurchase(int id)
        {
            var model = new MovieTicketPurchase();
            model.Info = _db.MovieInfos.Find(id);
            model.MovieInfoId = id;
            model.UserEmail = User.Identity.GetUserName();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddMoviePurchase(MovieTicketPurchase model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.PurchaseDate = DateTime.Now;
            _db.MovieTicketPurchases.Add(model);
            _db.SaveChanges();

            var info = _db.MovieInfos.Find(model.MovieInfoId);
            info.TicketsGiven = info.TicketsGiven + model.TicketsCount;
            _db.Entry(info).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Tickets");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }
    }
}