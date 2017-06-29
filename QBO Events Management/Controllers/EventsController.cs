using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QBO_Events_Management.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace QBO_Events_Management.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {

            //return View(db.Events.ToList());
            string organizer = "https://www.eventbriteapi.com/v3/organizers/14330786176/events/?token=RHB5LVF477QSIZN4JYP5";
            var json = new WebClient().DownloadString(organizer);

            EventBriteEvents e = JsonConvert.DeserializeObject<EventBriteEvents>(json); 


            //var format = JObject.Parse(json);

            //string EventName = (string)format["events"]["name"];

            //ViewBag.Renche = EventName;
            //List<string> Events = new List<string>();
            //int length = (int)format["pagination"]["object_count"];
            //for (int i = 0; i < length; i++)
            //{

            //    var EventID = (string)format[i]["events"]["id"];
            //    string EventName = (string)format[i]["events"]["name"];
            //    string EventDescription = (string)format[i]["events"]["name"];
            //    i++;

            //}


            return View(e.Events);
        }

        // GET: Events/Details/5
        public ActionResult Details(string id)
        {
            if (id.Contains(" "))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string details = "https://www.eventbriteapi.com/v3/events/"+id+"/?token=RHB5LVF477QSIZN4JYP5";
            var json = new WebClient().DownloadString(details);
            EventBriteEvents e = JsonConvert.DeserializeObject<EventBriteEvents>(json);

            return View(e.Events);
            /*
            string attendees = "https://www.eventbriteapi.com/v3/events/" + id + "/attendees/?token=RHB5LVF477QSIZN4JYP5";

            var json = new WebClient().DownloadString(attendees);

            EventAttendees e = JsonConvert.DeserializeObject<EventAttendees>(json);

            if (e == null)
            {
                return HttpNotFound();
            }

            return View(e.Attendees);
            */

            /*Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);*/
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eventID,Name,Details,Date,Time,Venue")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eventID,Name,Details,Date,Time,Venue")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
