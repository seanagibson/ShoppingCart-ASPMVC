using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCShoppingCart.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [Display(Name="Product")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ThumbnailImagePath { get; set; }
        
        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SoldDate { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int? StoreManagerId { get; set; }

        public virtual StoreManager StoreManager { get; set; }

        public virtual List<Image> Images { get; set; }
    }
}