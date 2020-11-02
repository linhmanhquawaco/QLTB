using System;
using System.Collections.Generic;
using System.Text;

namespace quanlythietbi.Data.Entities
{
    public class ProductInDonvi
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public int DonViId { get; set; }
        public DonVi DonVi { get; set; }
    }
}
