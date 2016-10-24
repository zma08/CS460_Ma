using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Versioning;
using System.Web;
using System.Web.Mvc;
using AshLoan.Models;

namespace AshLoan.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Action name Index which send a home page to user
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// By default this is HttpGet method (form) will be sent to user when requested
        /// receiving user input data from the form by Request.QueryString[key],from the input of the user age and indentify if user is a baby or adult...
        /// </summary>
        /// <returns></returns>
        public ActionResult Task1()
        {

            int n;
            string name = Request.QueryString["fName"];//get user input from querystring from the url
            string age = Request.QueryString["age"];
            // Debug.WriteLine(Request.Form.Count);//there is not form data at a Http get 
                if (String.IsNullOrWhiteSpace(name) || !Int32.TryParse(age, out n))//if the input text is empty or white space or the age is not a number or empty return a message to user
                {
                    ViewBag.message = "please input your name and your age should be a integer";
                }
                else
                {
                    int age0 = Convert.ToInt32(age);
                    Debug.WriteLine(n == age0);
                    //pre-build a message, when the user info come in and it will return a message to user
                    if (age0 < 10)
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
        /// <summary>
        /// this is a http get method, when user first load then will be sent to user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Task2()
        {
            
            Debug.WriteLine("we are in Task2 "+Request.HttpMethod);//indentify that this is a http get method
            return View();
        }
        /// <summary>
        /// A http post method with parameter FormCollection when user submit the form, extract the input data by the formcollection object
        /// of method f[]
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        [HttpPost]//this is http post method, receiving user input data from the form by FormCollection, Form[key], key is name of attribute of the text input

        public ActionResult Task2(FormCollection f)
        {
            //NameValueCollection a = Request.Form;
            Debug.WriteLine("We are in Task2 "+Request.HttpMethod);
            //Debug.WriteLine(a.Count);//in post method form data will be submit
            //No empty/null input in the form will be allowed, and 2nd input can only be yes or no
            if (String.IsNullOrWhiteSpace(f["Name"]) || ( (!f["Employed"].Equals("yes") ) && (!f["Employed"].Equals("no")))
)            {
                ViewBag.Message = "please enter your name and type yes or no only for employed status";
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

            return View( );
        }
        /// <summary>
        /// This form will be first loaded as a http get method when user first request to load this page,
        /// or user input failed the validation, this page will be sent to user along with the error message,
        /// if the first time load the error message space will be hidden
        /// </summary>
        /// <returns></returns>
        
       
        [HttpGet]
        public ActionResult Loan()
        {
            Debug.WriteLine("we are in origin loan"+Request.HttpMethod);
            Debug.WriteLine("modelstate.isvalida: "+ModelState.IsValid);
            return View();
        }
        /// <summary>
        /// This form will be sent to user after server received a post method from client and deal with it
        /// if all input has been validated, the input data will be received, 
        /// since model binding the type of the input will be matching the Object property type'
        /// after calculation, the new page/action name called Result will be sent to use with parameter of the Calculator object
        /// they are binded/strongly typed and data will be availbale for the Result view tp access.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Loan(Calculator c)//Model binding
        {
            Debug.WriteLine("we are in overload loan"+Request.HttpMethod);
            Debug.WriteLine("user input principal is: "+ c.pr);
            if (ModelState.IsValid)
            {
                /* int num;

                 if(Double.IsNaN(c.pr) || Double.IsNaN(c.rate) || Int32.TryParse((c.rate).ToString(), out num))
                 {
                     ViewBag.message = "Principal needs to be a number";
                     return View();
                 }
                 if ( Double.IsNaN(c.rate) )
                 {
                     ViewBag.message = "Interste needs to be a number";
                     return View();
                 }
                 if ( Int32.TryParse((c.term).ToString(), out num))
                 {
                     ViewBag.message = "term needs to be total of months in ineger";
                     return View();
                 }
                 else
                 {
                     return View("Result", c);
                 }*/
                return View("Result", c);//if all constrain are satisfied the new ViewResult called Result will be sent to user with model object

            }
            else
            {
                return View();
            }
            
        }

    }
}