using System;
using System.Collections.Generic;
using System.Text;

namespace quanlythietbi.ViewModels.Catalog.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string MaTb { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string Xuat_xu { get; set; }
        public string HangSX { get; set; }
        public DateTime NamSx { get; set; }
        public DateTime NamSd { get; set; }
        public string Vi_tri_lap { get; set; }
        public string TenNM { get; set; }
        public int DonViId { get; set; }
        public string NguonDien { get; set; }
        public string CongSuat { get; set; }
        public string DoDay { get; set; }
        public string HutSau { get; set; }
        public string LuuLuong { get; set; }
        public string HongHutXa { get; set; }
        public string VongQuay { get; set; }
        public string NMName { get; set; }
    }
}
