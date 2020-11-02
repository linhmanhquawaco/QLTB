using System;
using System.Collections.Generic;
using System.Text;

namespace quanlythietbi.Data.Entities
{
    public class DonVi
    {
        public int DonViId { get; set; }
        public string DonViName { get; set; }
        public List<NhaMay> NhaMays { get; set; }
        public List<ProductInDonvi> productInDonvis { get; set; }

    }
}
