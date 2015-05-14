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

        public void CreateNewCustomer(Customer customer)
        {
            var newCustomer = new Customer
            {
                UserName = "",
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                StreetAddress1 = customer.StreetAddress1,
                StreetAddress2 = customer.StreetAddress2,
                City = customer.City,
                State = customer.State,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Email = customer.Email,
                Phone = customer.Phone,
            };

            db.Customers.Add(newCustomer);
            db.SaveChanges();
        }

        public List<Customer> ToList()
        {
            return db.Customers.ToList();
        }
    }
}