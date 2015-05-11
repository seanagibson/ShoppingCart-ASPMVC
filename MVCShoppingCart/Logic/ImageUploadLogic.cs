using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MVCShoppingCart.Models;
using MVCShoppingCart.DAL;


namespace MVCShoppingCart.Logic
{
    public class ImageUploadLogic
    {
        ShoppingCartContext db = new ShoppingCartContext();

        public bool Upload(HttpPostedFileBase image, bool imageThumbnail, int productId)
        {
            var db = new ShoppingCartContext();

            if (image != null && image.ContentLength > 0)
            {
                var imageName = Path.GetFileName(image.FileName);
                var imagePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/"), imageName);
                image.SaveAs(imagePath);

                var imageUploadService = new ImageUploadLogic();
                imageUploadService.addImageDBRecord(imagePath, imageName, imageThumbnail, productId);
                
                return true;
            }
            else
                return false;
        }

        public void addImageDBRecord(string imagePath, string imageName, bool imageThumbnail, int productId)
        {
            var imageUploader = new ImageUploadLogic();
            var newImage = new Image
            {
                ImageID = db.Images.Count() + 1,
                ImageTitle = imageName,
                ImagePath = imagePath,
                IsImageThumbnail = imageThumbnail,
                ProductId = productId,
            };
            db.Images.Add(newImage);
            db.SaveChanges();

            if (imageThumbnail)
            {
                var product = db.Products.Find(productId);
                product.ThumbnailImagePath = imagePath;
                db.SaveChanges();
            }
        }
    }
}