using AdventureTx.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace AdventureTx.Controllers
{
    public class HomeController : Controller
    {
        
        ProductContext db = new ProductContext();
        public ActionResult Index()
        {
           
                return View(db.ProductCategories.ToList());
            
                
        }
        [HttpPost]
        public ActionResult Index(string search)
        {
            Debug.WriteLine(search);
            if (String.IsNullOrEmpty(search)) return HttpNotFound();
            var p = db.Products.Where(x => x.Name.ToUpper().Contains(search.ToUpper())).ToList();
            return View("SearchResult", p);//render a new view directly with viewResult with a object that filtered, notice that redirectToAction cant not be passed with a object parameter
        }

        public ActionResult ListItem(int? id, int? page)
        {
            
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var p = db.Products.Where(x => x.ProductSubcategoryID == id).ToList().ToPagedList(page ?? 1, 6);
            var pho = db.ProductProductPhotoes.FirstOrDefault(x => x.ProductID == id).ProductPhoto;
            //vm.product = p;
            //vm.productPhoto = pho;
            return View(p);
        }
        [HttpGet]
        public ActionResult ProductDetail(int? id, int? ModelId)
        {
           
            ProductViewMovel vm = new ProductViewMovel();
            ProductDescription description;
            if (ModelId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);            
            else description = db.ProductModelProductDescriptionCultures.FirstOrDefault(x => x.ProductModelID == ModelId).ProductDescription;
            var photo = db.ProductProductPhotoes.FirstOrDefault(x => x.ProductID == id).ProductPhoto.LargePhoto;
            vm.productDescription = description;
            var img = String.Format("data:img/gif;base64,{0}", Convert.ToBase64String(photo));
            vm.photoString = img;
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            else  vm.productId = (int)id;
            return View(vm);
        }
        [HttpGet]
        public ActionResult WriteReview(int? id)
        {
            Debug.WriteLine(id);
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var review = db.ProductReviews.Create();
            //var review = new ProductReview();//navigation property can not be accessed or created later on
            review.ProductID = (int)id;
            return View(review);
        }
        [HttpPost]
        public ActionResult WriteReview(ProductReview productReview)
        {
            Debug.WriteLine(productReview.ProductID);
            if(ModelState.IsValid)
            {
                try
                {
                    productReview.ReviewDate = System.DateTime.Now;
                    productReview.ModifiedDate = System.DateTime.Now;
                    db.ProductReviews.Add(productReview);
                    db.SaveChanges();
                    return View("Thanks", productReview);
                }
                catch (Exception) { ModelState.AddModelError("","changes can not be saved"); }
                
                
            }
            return View(productReview);
        }

        public ActionResult CheckReview(int? pId)
        {
            Debug.WriteLine(pId);
            if (pId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            bool isR = false;
            var reviewMessage = "";
            var review = db.ProductReviews.Where(x => x.ProductID == pId).
                Select(x=> new { ReviewerName = x.ReviewerName, ReviewDate=x.ReviewDate, Rating = x.Rating, Review = x.Comments}).ToList();
            if (review.Count() == 0)
            {
                isR = false;
                reviewMessage = "Sorry there is no review currently for this product";
            }
            else
            {
                isR = true;
                reviewMessage = "";
            }
            var reviews = new
            {
                message = reviewMessage,
                productReviews = review,
                isReviewed = isR

            };
            return Json(reviews,JsonRequestBehavior.AllowGet);
        }
        public void dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}