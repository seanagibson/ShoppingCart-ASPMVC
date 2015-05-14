using MVCShoppingCart.DAL;
using MVCShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCShoppingCart.Logic
{
    public class ShoppingCartLogic
    {
        ShoppingCartContext db = new ShoppingCartContext();

        public string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public static ShoppingCartLogic GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCartLogic();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public static ShoppingCartLogic GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    //Create new GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public void AddToCart(Product product)
        {
            var cartItem = db.CartItems.SingleOrDefault(c => c.CartId == ShoppingCartId &&
                c.ProductId == product.ProductId);

            if (cartItem == null)
            {
                //create new cart item
                cartItem = new CartItem
                {
                    CartItemId = db.CartItems.Count() + 1,
                    CartId = ShoppingCartId,
                    ProductId = product.ProductId,
                    //Product = product,
                    Count = 1,
                    DateCreated = DateTime.Now,
                };
                db.CartItems.Add(cartItem);
                db.SaveChanges();
            }
            else
            {
                //item exists in cart, so add one to quantity
                cartItem.Count++;
            }
        }

        public int RemoveFromCart(int id)
        {
            var cartItem = db.CartItems.Single(
                cart => cart.CartId == ShoppingCartId &&
                cart.CartItemId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                                
                db.CartItems.Remove(cartItem);
                db.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = db.CartItems.Where(cart => cart.CartId == ShoppingCartId).ToList();
            foreach (var item in cartItems)
            {
                db.CartItems.Remove(item);
            }
        }

        public List<CartItem> GetCartItems()
        {
            return db.CartItems.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }

        public int GetCartItemProductId(int id)
        {
            var cartItem = db.CartItems.Find(id);

            return cartItem.ProductId;
        }

        public int GetCount()
        {
            //get count of each item in cart and sum
            int? count = (from cartItems in db.CartItems
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();
            return count ?? 0;
        }

        public decimal GetSubtotal()
        {
            decimal? subtotal = (from cartItems in db.CartItems
                                 where cartItems.CartId == ShoppingCartId
                                 select (int?)cartItems.Count *
                                 cartItems.Product.Price).Sum();
            return subtotal ?? decimal.Zero;
        }

        public decimal GetSalesTax()
        {
            double? salesTaxRate = db.StoreManagers.First().SalesTaxRate;

            decimal? salesTaxTotal = GetSubtotal() * (decimal)salesTaxRate;
            return salesTaxTotal ?? decimal.Zero;
        }

        public decimal GetTotal()
        {
            decimal? total = GetSubtotal() + GetSalesTax();
            return total ?? decimal.Zero;
        }

        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Count,
                    UnitPrice = item.Product.Price,
                };

                orderTotal += (item.Count * item.Product.Price);

                db.OrderDetails.Add(orderDetail);
            }

            order.Total = orderTotal;

            db.SaveChanges();

            EmptyCart();

            return order.OrderId;
        }

        public void MigrateCart(string userName)
        {
            var shoppingCart = db.CartItems.Where(c => c.CartId == ShoppingCartId);

            foreach (var item in shoppingCart)
            {
                item.CartId = userName;
            }
            db.SaveChanges();
        }
    }
}