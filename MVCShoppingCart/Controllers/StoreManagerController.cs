using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCShoppingCart.DAL;
using MVCShoppingCart.Models;
using MVCShoppingCart.Logic;
using MVCShoppingCart.ViewModel;

namespace MVCShoppingCart.Controllers
{
    public class StoreManagerController : Controller
    {
        // GET: StoreManager
        public ActionResult Index()
        {
            var productService = new ProductLogic();
            return View(productService.ToList());
        }

        // GET: StoreManager/Details/5
        public ActionResult ProductDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productService = new ProductLogic();
            Product product = productService.FindProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: StoreManager/Create
        public ActionResult ProductCreate()
        {
            var categoryList = new CategoryLogic();
            ViewBag.CategoryId = categoryList.SetCategoryViewBag();

            return View();
        }

        // POST: StoreManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductCreate([Bind(Include = "ProductId,Name,Description,CategoryId,Quantity,Price,Cost,PurchaseDate,SoldDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                var newProduct = new ProductLogic();
                newProduct.CreateNewProduct(product);
                return RedirectToAction("Index", "StoreManager");
            }

            return View(product);
        }

        // GET: StoreManager/Product/Edit/5
        public ActionResult ProductEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productService = new ProductLogic();
            Product product = productService.FindProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var categoryList = new CategoryLogic();
            ViewBag.CategoryId = categoryList.SetCategoryViewBag(id);
            return View(product);
        }

        // POST: StoreManager/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductEdit([Bind(Include = "ProductId,Name,Description,Quantity,Price,Cost,PurchaseDate,SoldDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                var productService = new ProductLogic();
                productService.EditProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: StoreManager/Delete/5
        public ActionResult ProductDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productService = new ProductLogic();
            Product product = productService.FindProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var productService = new ProductLogic();
            productService.RemoveProduct(id);
            return RedirectToAction("Index", "StoreManager");
        }

        public ActionResult Categories()
        {
            var categories = new CategoryLogic();
            return View(categories.ToList());
        }

        public ActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryCreate(string title)
        {
            if (ModelState.IsValid)
            {
                var category = new CategoryLogic();
                category.CreateNewCategory(title);
                return RedirectToAction("Categories");
            }
            return View();
        }

        public ActionResult CategoryDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoryService = new CategoryLogic(); 
            Category category = categoryService.FindCategory(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryDelete(Category category)
        {
            var categoryService = new CategoryLogic();
            categoryService.DeleteCategory(category.CategoryId);
            return RedirectToAction("Categories");
        }

        public ActionResult ImageUpload(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var productService = new ProductLogic();
            Product product = productService.FindProduct(id);
            
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ImageUpload(ImageUploadVM imageFile)
        {
            var imageUploadService = new ImageUploadLogic();

            if (imageUploadService.Upload(imageFile.Image, imageFile.ImageThumbnail, imageFile.ProductId))
            {
                ViewBag.Message = "Upload successful";
                return RedirectToAction("ProductDetails", "StoreManager", new { id = imageFile.ProductId });
            }
            else
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("Upload");
            }
        }

        public ActionResult Customers()
        {
            var customers = new CustomerLogic();
            return View(customers.ToList());
        }
    }
}
