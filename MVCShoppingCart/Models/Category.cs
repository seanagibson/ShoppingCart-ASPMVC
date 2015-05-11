using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCShoppingCart.Models
{
    public class Category
    {
        [Display(Name="Category Id")]
        public int CategoryId { get; set; }

        [Display(Name="Product Category")]
        public string Title { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}