using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCShoppingCart.DAL;
using MVCShoppingCart.Models;
using MVCShoppingCart.ViewModel;


namespace MVCShoppingCart.Logic
{
    public class ProductLogic
    {
        ShoppingCartContext db = new ShoppingCartContext();

        public void CreateNewProduct(Product product)
        {
            var newProduct = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Quantity = product.Quantity,
                Price = product.Price,
                Cost = product.Cost,
                PurchaseDate = product.PurchaseDate,
                CategoryId = product.CategoryId,
                StoreManagerId = product.StoreManagerId,
            };
            db.Products.Add(newProduct);
            db.SaveChanges();
        }

        public List<Product> ToList()
        {
            var productList = db.Products.ToList();
            return productList;
        }

        public Product FindProduct(int? id)
        {
            var product = db.Products.Find(id);
            return product;
        }

        public void EditProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveProduct(int id)
        {
            Product product = db.Products.Find(id);
            RemoveProductImages(id);
            db.Products.Remove(product);
            db.SaveChanges();
        }

        private void RemoveProductImages(int id)
        {
            var productImagesToRemove = (from images in db.Images
                                         where images.ProductId == id
                                         select images).ToList();
            foreach (var image in productImagesToRemove)
            {
                db.Images.Remove(image);
            }
            db.SaveChanges();
        }

        public List<ProductListVM> GetProductListVM()
        {
            var productListVM = new List<ProductListVM>();

            foreach (var product in db.Products)
            {
                var productVM = new ProductListVM()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Price = product.Price,
                    ThumbnailImagePath = product.ThumbnailImagePath,
                };

                productListVM.Add(productVM);
            }

            return productListVM;
        }
    }
}