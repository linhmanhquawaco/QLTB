﻿using quanlythietbi.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace quanlythietbi.Data.Entities
{
     public class Category
    {
        public int Id { get; set;}
        public bool IsShowOnHome { get; set;}    
        public int? ParentID { get; set;}    
        public Status Status { get; set;}
        public List<ProductInCategory> ProductInCategories { get; set; }
    }   
}
