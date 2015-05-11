using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCShoppingCart.CustomAttributes;

namespace MVCShoppingCart.ViewModel
{
    public class ImageUploadVM
    {
        [FileSize(12000)]
        public HttpPostedFileBase Image { get; set; }

        public bool ImageThumbnail { get; set; }

        public int ProductId { get; set; }
    }
}