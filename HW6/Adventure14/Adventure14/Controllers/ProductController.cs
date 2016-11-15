using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;  
using System.Net;
using System.Web;
using System.Web.Mvc;
using Adventure14.Models;
using PagedList;
using PagedList.Mvc;
namespace Adventure14.Controllers
{
    public class ProductController : Controller
    {
        AdventureContext db = new AdventureContext();
        // GET: Product
        public ActionResult Index()
        {
            
            return View(db.ProductCategories.ToList());
        }
        public ActionResult ProductItem(int? id, int? page)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                //download the pagelist.mvc, it will help to generate the page in a better format
                return View(db.Products.Where(pk => pk.ProductSubcategoryID == id).
                    ToList().ToPagedList(page??1,6));//double ? if it is null then page will take defual value as 1, the 2nd parameter set 3 which is page size, like there will be 3 rows displayed in that page
            }
           
        }
        [HttpGet]
        public ActionResult Review(int id)
        {
            
                ProductReview productReview = new ProductReview();
                productReview.ProductID = id;
                return View(productReview);
            
        }
           
        [HttpPost]
        public ActionResult Review(ProductReview productReview)
        {
            if (ModelState.IsValid)
            {
                db.ProductReviews.Add(productReview);
                db.SaveChanges();
               // Debug.WriteLine(productReview.ReviewerName);
                return View("Thanks",productReview);
            }
            else
            {
                return View(productReview);
            }
           

        }
        public ActionResult Reviews(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var r = db.ProductReviews.Where(x => x.ProductID == id).ToList();
                if (r.Count==0)
                {
                    ViewBag.message = "Sorry there is currently no review for this product...";
                }
                return View(r);
            }

        }
        public ActionResult ListAllReviews()
        {
            return View(db.ProductReviews.ToList());
        }

        public ActionResult ProductDetail(int? id, int? Mid)
        {
            if (id==null||Mid==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vm = new ProductDescriptionViewModel();
                ProductDescription description = new ProductDescription();
                if (db.ProductModelProductDescriptionCultures.Where(pk => pk.ProductModelID == Mid).FirstOrDefault() ==
                    null) description = null;
                else
                {
                    description = db.ProductModelProductDescriptionCultures.Where(pk => pk.ProductModelID == Mid).FirstOrDefault().ProductDescription;

                }
                var Photo = db.ProductProductPhotoes.Where(x => x.ProductID == id).SingleOrDefault().ProductPhoto;
                var product = db.Products.Where(x => x.ProductID == id).FirstOrDefault();
                vm.ProductDescription = description;
                vm.ProductPhoto = Photo;
                vm.Product = product;
                return View(vm);
            }
        }

        public ActionResult DeleteCategory(string Name)
        {
           ProductCategory productCategory = db.ProductCategories.Where(x => x.Name.Equals(Name)).FirstOrDefault();
            db.ProductCategories.Remove(productCategory);
            db.SaveChanges();
            return View(db.ProductCategories.ToList());
        }

      
       /* public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategories.Add(productCategory);
                db.SaveChanges();
                return RedirectToAction("Show");
            }
            else
            {
                return View(productCategory);
            }
        }
        public ActionResult Show()
        {
           
            return View(db.ProductCategories.ToList());
        }*/

    }
}