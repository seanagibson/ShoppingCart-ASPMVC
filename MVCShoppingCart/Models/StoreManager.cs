using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCShoppingCart.Models
{
    public class StoreManager
    {
        public int StoreManagerId { get; set; }

        [Display(Name="Store Address")]
        public string StoreAddress { get; set; }

        [Display(Name="City")]
        public string StoreCity { get; set; }

        [Display(Name="State")]
        public string StoreState { get; set; }

        [Display(Name="Zip Code")]
        public int StoreZipCode { get; set; }

        [Display(Name="Sales Tax Rate")]
        public double SaleTaxRate { get; set; }

        public List<Product> Products { get; set; }
    }
}