using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCShoppingCart.Models;
using MVCShoppingCart.Logic;
using MVCShoppingCart.ViewModel;

namespace MVCShoppingCart.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = ShoppingCartLogic.GetCart(this.HttpContext);

            var CartViewModel = new ShoppingCartVM
            {
                CartItems = cart.GetCartItems(),
                CartSubTotal = cart.GetSubtotal(),
                CartSalesTax = cart.GetSalesTax(),
                CartTotal = cart.GetTotal(),
            };
            return View(CartViewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var productService = new ProductLogic();
            var productAdded = productService.FindProduct(id);

            ShoppingCartLogic cart = ShoppingCartLogic.GetCart(this.HttpContext);
            cart.AddToCart(productAdded);

            return RedirectToAction("Index");
        }

        //AJAX post
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCartLogic.GetCart(this.HttpContext);

            var shoppingCart = new ShoppingCartLogic();
            int productId = shoppingCart.GetCartItemProductId(id);
            var productService = new ProductLogic();
            Product productToRemove = productService.FindProduct(productId);

            int itemCount = cart.RemoveFromCart(id);

            var removeViewModel = new ShoppingCartRemoveVM
            {
                Message = Server.HtmlEncode(productToRemove.Name) +
                    " has been removed from your shopping cart.",
                CartCount = cart.GetCount(),
                CartSubTotal = cart.GetSubtotal(),
                CartSalesTax = cart.GetSalesTax(),
                CartTotal = cart.GetTotal(),
                ItemCount = itemCount,
                DeleteId = id,
            };

            return Json(removeViewModel);
        }

        public ActionResult CustomerInfo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerInfo([Bind(Include = "FirstName,LastName,StreetAddress1,StreetAddress2,City,State,PostalCode,Country,Email,Phone")] Customer customer)
        {
            var customerLogic = new CustomerLogic();
            customerLogic.CreateNewCustomer(customer);
            return RedirectToAction("Payment");
        }

        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }
    }
}