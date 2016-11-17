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
        /// <summary>
        /// entity framework also called ORM(Object Relation mapper), 
        /// they will allow us to get access data from the database, and interacting with them
        /// </summary>
        StudentContext db = new StudentContext();

        /// <summary>
        /// home page/Landing page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// once client has sent the request this form will be responsed to client
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
           

            return View();
        }
        /// <summary>
        /// it is a strongly typed view, once the data comes in from the client, 
        /// and pass through the validation then add to the database and save the changes
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();

                return RedirectToAction("ShowRecord");//redirect user when add successfully
            }
            else
            {
                return View(student);//if not pass data validation return to the view and show error message
            }
           
        }
        /// <summary>
        /// shows all students record in the database
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowRecord()
        {
            return View(db.Students.ToList());
        }
    }
}