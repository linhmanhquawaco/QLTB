using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using quanlythietbi.Application.Common;
using quanlythietbi.Data.EF;
using quanlythietbi.Data.Entities;
using quanlythietbi.Utilities.Exceptions;
using quanlythietbi.ViewModels.Catalog.ProductImage;
using quanlythietbi.ViewModels.Catalog.Products;

using quanlythietbi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace quanlythietbi.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly QuanLyThietBiDbContext _context;
        private readonly IStorageService _storageServices;

        public ManageProductService(QuanLyThietBiDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageServices = storageService;
        }

        public async Task<int> AddImage(int productId, ProductImageCreateRequest request)
        {
            var productImage = new ProductImage()
            {
                IsDefault = request.IsDefault,
                SortOrder = request.SortOrder,
                DateCreated = DateTime.Now,
                ProductId = productId,
                Caption = request.caption
            };
            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
            return productImage.Id;
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                MaTb = request.MaTb,
                SerialNumber = request.SerialNumber,
                Name = request.Name,
                Xuat_xu = request.Xuat_xu,
                HangSX = request.HangSX,
                NamSd = request.NamSd,
                NguonDien = request.NguonDien,
                CongSuat = request.CongSuat,
                DoDay = request.DoDay,
                HutSau = request.HutSau,
                LuuLuong = request.LuuLuong,
                HongHutXa = request.HongHutXa,
                VongQuay = request.VongQuay
            };
            //Save Image
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize =request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new QLTBException($"Không tìm thấy sản phẩm: {productId}");

            var Images = _context.ProductImages.Where(i => i.ProductId == productId);
            foreach (var image in Images)
            {
                await _storageServices.DeleteFileAsync(image.ImagePath);
            }
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join pid in _context.ProductInDonvis on p.Id equals pid.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pic, pid };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(a => a.p.Name.Contains(request.Keyword));
            }
            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }

            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.p.Name,
                    DonViId = x.pid.DonViId,
                    MaTb = x.p.MaTb,
                    CongSuat = x.p.CongSuat
                }).ToListAsync();

            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<ProductViewModel> GetById(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            var productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                SerialNumber = product.SerialNumber,
                MaTb = product.MaTb,
                Name = product.Name,
                Xuat_xu = product.Xuat_xu,
                HangSX = product.HangSX,
                NamSx = product.NamSx,
                NamSd = product.NamSd,
                Vi_tri_lap = product.Vi_tri_lap,
                TenNM = product.TenNM,
                DonViId = product.DonViId,
                NguonDien = product.NguonDien,
                CongSuat = product.CongSuat,
                DoDay = product.DoDay,
                HutSau = product.HutSau,
                LuuLuong = product.LuuLuong,
                HongHutXa = product.HongHutXa,
                VongQuay = product.VongQuay
            };

            return productViewModel;
        }

        public async Task<ProductImageViewModel> GetImageById(int imageId)
        {
            var image = await _context.ProductImages.FindAsync(imageId);
            if (image == null)
                throw new QLTBException($"Không tìm thấy sản phẩm: {imageId}");

            var viewmodel = new ProductImageViewModel()
            {
                Caption = image.Caption,
                DateCreated = image.DateCreated,
                SortOrder = image.SortOrder,
                FileSize = image.FileSize,
                IsDefault = image.IsDefault,
                ImagePath = image.ImagePath,
                ProductId = image.ProductId,
                Id = image.Id
            };
            return viewmodel;
        }

        public async Task<List<ProductImageViewModel>> GetListImages(int productId)
        {
            return await _context.ProductImages.Where(x => x.ProductId == productId)
                .Select(i => new ProductImageViewModel
                {
                    Caption = i.Caption,
                    DateCreated = i.DateCreated,
                    SortOrder = i.SortOrder,
                    FileSize = i.FileSize,
                    IsDefault = i.IsDefault,
                    ImagePath = i.ImagePath,
                    ProductId = i.ProductId,
                    Id = i.Id
                }).ToListAsync();
        }

        public async Task<int> RemoveImage(int imageId)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new QLTBException($"không tìm thấy ảnh có id {imageId}");
            _context.ProductImages.Remove(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (product == null) throw new QLTBException($"Không tìm thấy sản phẩm: {request.Id}");
            product.Name = request.Name;
            product.SerialNumber = request.SerialNumber;
            product.HongHutXa = request.HongHutXa;
            product.VongQuay = request.VongQuay;

            //Save Image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new QLTBException($"không tìm thấy ảnh có id {imageId}");

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Update(productImage);
            await _context.SaveChangesAsync();
            return await _context.SaveChangesAsync();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageServices.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}