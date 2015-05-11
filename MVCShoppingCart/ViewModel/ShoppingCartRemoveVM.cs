using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCShoppingCart.ViewModel
{
    public class ShoppingCartRemoveVM
    {
        public string Message { get; set; }

        public decimal CartSubTotal { get; set; }

        public decimal CartSalesTax { get; set; }

        public decimal CartTotal { get; set; }

        public int CartCount { get; set; }

        public int ItemCount { get; set; }

        public int DeleteId { get; set; }
    }
}