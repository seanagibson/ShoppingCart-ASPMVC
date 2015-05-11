﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCShoppingCart.ViewModel
{
    public class ProductListVM
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ThumbnailImagePath { get; set; }
    }
}