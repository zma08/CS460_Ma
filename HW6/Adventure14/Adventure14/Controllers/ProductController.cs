﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;  
using System.Net;
using System.Web;
using System.Web.Mvc;
using Adventure14.Models;

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
        public ActionResult ProductItem(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                return View(db.Products.Where(pk => pk.ProductSubcategoryID == id).ToList());
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
        public ActionResult ListAllReviews()
        {
            return View(db.ProductReviews.ToList());
        }

        public ActionResult ProductDetai(int? id, int? Mid)
        {
            if (id==null||Mid==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vm = new ProductDescriptionViewModel();
                var description = db.ProductModelProductDescriptionCultures.Where(pk => pk.ProductModelID == Mid).FirstOrDefault().ProductDescription;
                var Photo = db.ProductProductPhotoes.Where(x => x.ProductID == id).SingleOrDefault().ProductPhoto;
                vm.ProductDescription = description;
                vm.ProductPhoto = Photo;
                
                return View(vm);
            }
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