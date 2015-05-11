using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCShoppingCart.Models
{
    public class StoreManager
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StoreManagerId { get; set; }

        public string StoreAddress { get; set; }

        public string StoreCity { get; set; }

        public string StoreState { get; set; }

        public int StoreZipCode { get; set; }

        public double SaleTaxRate { get; set; }

        public List<Product> Products { get; set; }
    }
}