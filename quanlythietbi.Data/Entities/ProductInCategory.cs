﻿         using System;
using System.Collections.Generic;
using System.Text;

namespace quanlythietbi.Data.Entities
{
    public class ProductInCategory
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
