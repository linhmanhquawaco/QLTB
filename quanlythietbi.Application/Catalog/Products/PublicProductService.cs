
using quanlythietbi.Data.EF;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using quanlythietbi.ViewModels.Catalog.Products;
using quanlythietbi.ViewModels.Common;


namespace quanlythietbi.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductServicecs
    {
        private readonly QuanLyThietBiDbContext _context;
        public PublicProductService(QuanLyThietBiDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            /*var query = from p in _context.Products
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join pid in _context.ProductInDonvis on p.Id equals pid.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pic, pid };*/
            var query = _context.Products;
            var data = await query.Select(x => new ProductViewModel()
                {
                Id = x.Id,
                Name = x.Name,
                MaTb = x.MaTb,
                CongSuat = x.CongSuat,
                LuuLuong = x.LuuLuong,
                NguonDien = x.NguonDien

            }).ToListAsync();
            return data;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join pid in _context.ProductInDonvis on p.Id equals pid.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pic, pid };

            if (request.CategoryId.HasValue && request.CategoryId.Value > 0) 
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }

            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.p.Name,
                    MaTb = x.p.MaTb,
                    CongSuat = x.p.CongSuat,
                    LuuLuong = x.p.LuuLuong,
                    NguonDien = x.p.NguonDien

                }).ToListAsync();

            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

       
    }
}
