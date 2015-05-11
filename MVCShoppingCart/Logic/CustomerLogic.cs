using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCShoppingCart.DAL;
using MVCShoppingCart.Models;

namespace MVCShoppingCart.Logic
{
    public class CustomerLogic
    {
        ShoppingCartContext db = new ShoppingCartContext();

        public List<Customer> ToList()
        {
            return db.Customers.ToList();
        }
    }
}