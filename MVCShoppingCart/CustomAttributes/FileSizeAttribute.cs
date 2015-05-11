using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCShoppingCart.CustomAttributes
{
    public class FileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public FileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        public override bool IsValid(object value)
        {
            HttpPostedFileBase file = (HttpPostedFileBase)value;
            
            if (file == null)
                return true;

            return _maxFileSize > file.ContentLength;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("The file size should not exceed {0}", _maxFileSize);
        }
    }
}