using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using MVCShoppingCart.Models;

namespace MVCShoppingCart.DAL
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext()
            : base("ShoppingCartContext")
        {
        }

        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StoreManager> StoreManagers { get; set; }
    }
}