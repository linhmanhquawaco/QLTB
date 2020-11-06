using System;
using System.Collections.Generic;
using System.Text;

namespace quanlythietbi.Data.Entities
{
    public class NhaMay
    {
        
        public string NMName { get; set; }
        public int DonViId { get; set; }
        public int ProductId { get; set; }

        public DonVi DonVi { get; set; }
        public Product Product { get; set; }
    }
}
