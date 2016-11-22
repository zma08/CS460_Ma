using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Diagnostics;

namespace PiratesWeb.Controllers
{
    public class PSController : Controller
    {

        PiratesContext db = new PiratesContext();
        [HttpGet]
        public ActionResult ShowPirates(int? page)
        {

            return View(db.Pirates.ToList().ToPagedList(page ?? 1, 3));
        }

        [HttpGet]
        public ActionResult CreatePirates()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePirates(Pirate pirate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Pirates.Add(pirate);
                    db.SaveChanges();
                    return RedirectToAction("ShowPirates");
                }
                catch (Exception) { ModelState.AddModelError("", "Pirate has not been added"); }
            }
            return View(pirate);
        }
        public ActionResult ShowShips()
        {
            return View(db.Ships.ToList());
        }

        public ActionResult ShowCrew()
        {
            return View(db.Crews.ToList());
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pirate pirate = db.Pirates.Find(id);
            if (pirate == null)
            {
                return HttpNotFound();
            }
            return View(pirate);

        }
        [HttpPost]
        public ActionResult Edit(int? id, Pirate pirate, DateTime Date)
        {
            if (id == null)  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //if (System.DateTime.Now < Date) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); return View("ShowPirates"); }
          
            Pirate p = db.Pirates.Find(id);
            if (TryUpdateModel(p, "", new string[] { "Name", "Date" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("ShowPirates");
                }
                catch (Exception) { ModelState.AddModelError("","Edit failed"); }
            }
            return View(p);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pirate pirate = db.Pirates.FirstOrDefault(x => x.Id == id);
            if (pirate == null)
            {
                return HttpNotFound();
            }

            return View(pirate);

        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pirate pirate = db.Pirates.Find(id);
            if (pirate == null)
            {
                return HttpNotFound();
            }

            return View(pirate);
        }
        [HttpPost]
        public ActionResult Delete(int? id, Pirate pirate)
        {
            try
            {
                Pirate p = db.Pirates.Find(id);
                db.Pirates.Remove(p);
                db.SaveChanges();
                return RedirectToAction("ShowPirates");
            }
            catch (Exception) { ModelState.AddModelError("","deletion failed"); }
            return View(pirate);
        }

        public ActionResult Booty()
        {
            List<dynamic> list = new List<dynamic>();
            decimal bootyTotal = 0;
            foreach( var p in db.Pirates.ToList())
            {
                foreach(var c in db.Crews.Where(x=>x.PirateId==p.Id).ToList())
                {
                    bootyTotal += c.Booty;
                }
                var info = new
                {
                    pirate = p.Name,
                    booty = bootyTotal
                };
                list.Add(info);                
            }
            var sorted = list.OrderByDescending(x => x.booty).ToList();
            return Json(sorted,JsonRequestBehavior.AllowGet);
           
          
        }
        protected void dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}