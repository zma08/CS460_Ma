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
            Debug.WriteLine(Request.HttpMethod);//http method
            string name = Request.QueryString["fName"];//get user input from querystring from the url
            string age = Request.QueryString["age"];
           // Debug.WriteLine(Request.Form.Count);//there is not form data at a Http get 
            Debug.WriteLine("name: {0}, age: {1}",name, age);
            
            if (String.IsNullOrWhiteSpace(name) || !Int32.TryParse(age, out n))//if the input text is empty or white space or the age is not a number or empty return a message to user
            {
                ViewBag.message = "please input your name and your age should be a integer";
            }
            else
            {
                int age0 = Convert.ToInt32(age);
                Debug.WriteLine(n==age0);
                //pre-build a message, when the user info come in and it will return a message to user
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
                    ViewBag.message = String.Format("Hi {0},you are an adult.", name);
                }
                if (age0 > 60)
                {
                    ViewBag.message = String.Format("Hi {0},you are a senior.", name);
                }

            }
            
            return View();
        }

        [HttpGet]//this is a http get method
        public ActionResult Task2()
        {
            
            Debug.WriteLine("we are in Task2 "+Request.HttpMethod);//indentify that this is a http get method
            return View();
        }

        [HttpPost]//this is http post method
        public ActionResult Task2(FormCollection f)
        {
            NameValueCollection a = Request.Form;//
            Debug.WriteLine("We are in Task2 "+Request.HttpMethod);
            Debug.WriteLine(a.Count);//in post method form data will be submit
            if (String.IsNullOrWhiteSpace(f["Name"]) || ( (!f["Employed"].Equals("yes") ) && (!f["Employed"].Equals("no")))
)            {
                ViewBag.Message = "please enter your name and type yes or no ony for employed status";
            }
            else
            {
                if (f["Employed"].Equals("yes"))
                {
                    ViewBag.Message = f["Name"]+", working hard is good for you (;";
                }
                else
                {
                    ViewBag.Message = f["Name"]+", your should go get a job or go to school (;";
                }
            }

            return View();
        }
        public ActionResult Loan()
        {
            return View();
        }
    }
}