using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FinalEx.Models;
using System.Net;
using System.Diagnostics;

namespace FinalEx.Controllers
{
    public class HomeController : Controller
    {
        ArtContext db = new ArtContext();
        public ActionResult Index()
        {
            return View(db.Genres.ToList());
        }
       
        //List 
        [HttpGet]
        public ActionResult ShowArtists()
        {

            return View(db.Artists.ToList());//the nullable page defualt will be set as 1 and page size is 3 since
        }

        public ActionResult ShowGenres()
        {

            return View(db.Genres.ToList());//the nullable page defualt will be set as 1 and page size is 3 since
        }

        [HttpGet]
        public ActionResult ShowArtWorks()
        {

            return View(db.ArtWorks.ToList());//the nullable page defualt will be set as 1 and page size is 3 since
        }

        [HttpGet]
        public ActionResult ShowClassifications( )
        {

            return View(db.Classifications.ToList());//the nullable page defualt will be set as 1 and page size is 3 since
        }
        //Create ...
        [HttpGet]
        public ActionResult CreateArtist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateArtist(Artist a)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Artists.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("ShowArtists");
                }
                catch (Exception) { ModelState.AddModelError("", "Artist can not be added"); }
            }
            return View(a);
        }



        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist a = db.Artists.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);

        }

        [HttpPost]
        public ActionResult Edit(int? id, Artist a)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //if (System.DateTime.Now < Date) { return ModelState.AddModelError("","The input date is not valid"); }

            Artist artist = db.Artists.Find(id);
            if (TryUpdateModel(artist, "", new string[] { "Name", "BirthDate", "BirthCity" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("ShowArtists");
                }
                catch (Exception) { ModelState.AddModelError("", "Edit failed"); }
            }
            return View(a);
        }

        //Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist a = db.Artists.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }

            return View(a);
        }

        //Delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist a = db.Artists.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }

            return View(a);
        }

        [HttpPost]
        public ActionResult Delete(int? id, Artist a)
        {
            try
            {
                Artist artist = db.Artists.Find(id);
                db.Artists.Remove(artist);
                db.SaveChanges();
                return RedirectToAction("ShowArtists");
            }
            catch (Exception) { ModelState.AddModelError("", "deletion failed"); }
            return View(a);
        }

        public ActionResult Art(string data)
        {

            Debug.WriteLine("data: "+data);
            var jobj = db.Classifications.Where(z => z.GenreName == data).ToList().Select(cl => new { ArtWork = cl.ArtWorkName, Artist = cl.ArtWork.ArtistName }).ToList();
            return Json(jobj, JsonRequestBehavior.AllowGet);


        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


    }
}