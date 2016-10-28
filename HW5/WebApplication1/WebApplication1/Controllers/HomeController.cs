using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using System.Diagnostics;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db = new StudentContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
           

            return View();
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();

                return RedirectToAction("ShowRecord");
            }
            else
            {
                return View(student);
            }
           
        }

        public ActionResult ShowRecord()
        {
            

            return View(db.Students.ToList());
        }
    }
}