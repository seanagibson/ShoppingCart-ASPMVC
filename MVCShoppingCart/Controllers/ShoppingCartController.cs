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

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCartLogic.GetCart(this.HttpContext);

            var productService = new ProductLogic();
            var productToRemove = productService.FindProduct(id);

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
    }
}