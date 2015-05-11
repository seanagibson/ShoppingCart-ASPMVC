using MVCShoppingCart.DAL;
using MVCShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCShoppingCart.Logic
{
    public class CategoryLogic
    {
        ShoppingCartContext db = new ShoppingCartContext();

        public void CreateNewCategory(string categoryTitle)
        {
            Category newCategory = new Category
            {
                CategoryId = db.Categories.Count() + 1,
                Title = categoryTitle,
            };

            db.Categories.Add(newCategory);
            db.SaveChanges();
        }

        public SelectList SetCategoryViewBag(int? categoryId = null)
        {
            if (categoryId == null)
            {
                return new SelectList(db.Categories, "CategoryId", "Title");
            }
            else
            {
                return new SelectList(db.Categories.ToArray(), "CategoryId", "Title", categoryId);
            }
        }

        public void DeleteCategory(int categoryId)
        {
            var categoryToDelete = db.Categories.Find(categoryId);
            db.Categories.Remove(categoryToDelete);
            db.SaveChanges();
        }

        public List<Category> ToList()
        {
            var categories = db.Categories.ToList();
            return categories;
        }

        public Category FindCategory(int? id)
        {
            var category = db.Categories.Find(id);
            return category;
        }
    }
}