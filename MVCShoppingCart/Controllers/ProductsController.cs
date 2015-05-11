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
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            var productService = new ProductLogic();
            var productListVM = new List<ProductListVM>();
            productListVM = productService.GetProductListVM();
            
            return View(productListVM);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
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
    }
}
