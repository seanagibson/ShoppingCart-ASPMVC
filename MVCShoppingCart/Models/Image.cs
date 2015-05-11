using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCShoppingCart.Models
{
    public class Image
    {
        public int ImageID { get; set; }

        public string ImageTitle { get; set; }

        public string ImagePath { get; set; }

        public bool IsImageThumbnail { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}