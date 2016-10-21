using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Versioning;
using System.Web;
using System.Web.Mvc;

namespace AshLoan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Task1()
        {

            int n;
            Debug.WriteLine(Request.HttpMethod);
            string name = Request.QueryString["fName"];
            string age = Request.QueryString["age"];
            Debug.WriteLine(Request.Form.Count);//there is not form data at a Http get 
            Debug.WriteLine("name: {0}, age: {1}",name, age);
            Debug.WriteLine("name: {0}, age: {1}", Request.QueryString["fName"], Request.QueryString["age"]);
            
            if (String.IsNullOrWhiteSpace(name) || !Int32.TryParse(age, out n))
            {
                ViewBag.message = "please input your name and your age should be a integer";
            }
            else
            {
                int age0 = Convert.ToInt32(age);
                Debug.WriteLine(n==age0);
                if (age0< 10)
                {
                    ViewBag.message = String.Format("Hi {0},you are a baby.", name);
                }
                if (age0 < 19 && age0 >= 10)
                {
                    ViewBag.message = String.Format("Hi {0},you are a teenager.", name);
                }
                if (age0 < 60 && age0 >= 19)
                {
                    ViewBag.message = String.Format("Hi {0},you are a adult.", name);
                }
                if (age0 > 60)
                {
                    ViewBag.message = String.Format("Hi {0},you are a senior.", name);
                }

            }
            
            return View();
        }

        public ActionResult Task2()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Loan()
        {
            return View();
        }
    }
}