using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelBooking.Models;

namespace HotelBooking.Controllers
{
    public class BookingController : Controller
    /**
\brief Dodanie kontrolera Booking

\detalis tworzenie, edytowanie, kasowanie rezerwacji

\param <Create()> - tworzenie rezerwacji
\param <Edit()> - edycja rezerwacji
\param <Delete()> - kasowanie rezerwacji


**/
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private IEnumerable<SelectListItem> GetRooms()
        {
            var rooms = db.Rooms.Where(x => x.IsAvailable == true).Select(x =>
            new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Name,
            });

            return new SelectList(rooms, "Value", "Text");
        }

        // GET: Booking
        public ActionResult Index()
        {
            return View(db.Bookings.ToList());
        }

        // GET: Booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            var model = new BookingViewModel
            {
                Rooms = GetRooms()
            };

            return View(model);
        }

        // POST: Booking/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Advance,StartDate,EndDate,SelectedRoomId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                var roomId = booking.SelectedRoomId;
                var roomObject = db.Rooms.Find(roomId);
                roomObject.IsAvailable = false;
                db.Entry(roomObject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Booking/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Advance,StartDate,EndDate")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            var roomId = booking.SelectedRoomId;
            var roomObject = db.Rooms.Find(roomId);
            roomObject.IsAvailable = true;
            db.Entry(roomObject).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
