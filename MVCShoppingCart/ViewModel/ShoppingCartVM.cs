using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCShoppingCart.Models;

namespace MVCShoppingCart.ViewModel
{
    public class ShoppingCartVM
    {
        public List<CartItem> CartItems { get; set; }

        public decimal CartSubTotal { get; set; }

        public decimal CartSalesTax { get; set; }

        public decimal CartTotal { get; set; }
    }
}