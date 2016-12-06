using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace FinalEx.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        //AContext db = new AContext();
        //List 
        //[HttpGet]
        //public ActionResult ShowA(int? page)
        //{

        //    return View(db.As.ToList().ToPagedList(page ?? 1, 3));//the nullable page defualt will be set as 1 and page size is 3 since
        //}
        //Create ...
        //[HttpGet]
        //public ActionResult CreateA()
        //{
        //    return View();
        //}
        
        //[HttpPost]
        //public ActionResult CreateA(A a)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            db.As.Add(a);
        //            db.SaveChanges();
        //            return RedirectToAction("ShowA");
        //        }
        //        catch (Exception) { ModelState.AddModelError("", "A can not be added"); }
        //    }
        //    return View(a);
        //}
       
       
       
        //[HttpGet]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    A a = db.As.Find(id);
        //    if (a == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(a);

        //}

        //[HttpPost]
        //public ActionResult Edit(int? id, A a)
        //{
        //    if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //if (System.DateTime.Now < Date) { return ModelState.AddModelError("","The input date is not valid"); }

        //    A a = db.As.Find(id);
        //    if (TryUpdateModel(p, "", new string[] { "Name", "Date" }))
        //    {
        //        try
        //        {
        //            db.SaveChanges();
        //            return RedirectToAction("ShowA");
        //        }
        //        catch (Exception) { ModelState.AddModelError("", "Edit failed"); }
        //    }
        //    return View(p);
        //}
       
        //Details
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    A a = db.As.FirstOrDefault(x => x.Id == id);
        //    if (a == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(a);
        //}
        
        //Delete
        //[HttpGet]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    A a = db.As.Find(id);
        //    if (a == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(a);
        //}
       
        //[HttpPost]
        //public ActionResult Delete(int? id, Pirate pirate)
        //{
        //    try
        //    {
        //        A a = db.As.Find(id);
        //        db.As.Remove(a);
        //        db.SaveChanges();
        //        return RedirectToAction("ShowAs");
        //    }
        //    catch (Exception) { ModelState.AddModelError("", "deletion failed"); }
        //    return View(a);
        //}
        
        //public ActionResult Booty()
        //{

        //    List<dynamic> list = new List<dynamic>();
        //    decimal bootyTotal = 0;
        //    foreach (var p in db.Pirates.ToList())
        //    {
        //        foreach (var c in db.Crews.Where(x => x.PirateId == p.Id).ToList())
        //        {
        //            bootyTotal += c.Booty;
        //        }
        //        var info = new
        //        {
        //            pirate = p.Name,
        //            booty = bootyTotal
        //        };
        //        list.Add(info);
        //    }
        //    var sorted = list.OrderByDescending(x => x.booty).ToList();
        //-------
        //    var sorted = db.B.GroupBy(x=>x.AId).ToList().Select(g=>new{Name = g.First().A.Name, Booty = g.Sum(c=>c.Booty)}).OrderByDescending(A=>A.Booty).ToList();
        //    return Json(sorted, JsonRequestBehavior.AllowGet);


        //}

       
        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}


    }
}