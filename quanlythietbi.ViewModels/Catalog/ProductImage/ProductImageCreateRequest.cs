using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace quanlythietbi.ViewModels.Catalog.ProductImage
{
   public  class ProductImageCreateRequest
    {

        public string caption { get; set; }
        public bool IsDefault { get; set; }
        public int SortOrder { get; set; }
        public long FileSize { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
