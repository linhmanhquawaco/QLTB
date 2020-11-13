using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quanlythietbi.Application.Catalog.Products;
using quanlythietbi.ViewModels.Catalog.ProductImage;
using quanlythietbi.ViewModels.Catalog.Products;

namespace quanlythietbi.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IPublicProductServicecs _publicProductServicecs;
        private readonly IManageProductService _manageProductServicecs;

        public ProductsController(IPublicProductServicecs publicProductServicecs, IManageProductService manageProductServicecs)
        {
            _publicProductServicecs = publicProductServicecs;
            _manageProductServicecs = manageProductServicecs;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _publicProductServicecs.GetAll();
            return Ok(products);
        }

        //http://localhost:port/product/public?pageIndex=1&pageSize=10&category =
        [HttpGet("public-paging")]
        public async Task<IActionResult> GetAllPageing([FromQuery] GetPublicProductPagingRequest request)
        {
            var products = await _publicProductServicecs.GetAllByCategoryId(request);
            return Ok(products);
        }

        //http://localhost:port/product/1
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById(int productId)
        {
            var product = await _manageProductServicecs.GetById(productId);
            if (product == null)
                return BadRequest("không tìm thấy sản phẩm");
            return Ok(product);
        }

        //http://localhost:port/product/1
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _manageProductServicecs.Create(request);
            if (productId == 0)
                return BadRequest();

            var product = await _manageProductServicecs.GetById(productId);

            return CreatedAtAction(nameof(GetById), new { id = productId }, productId);
        }

        //http://localhost:port/product/1
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _manageProductServicecs.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var affectedResult = await _manageProductServicecs.Delete(productId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        //Images

        [HttpGet("{productId}/Image/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            var image = await _manageProductServicecs.GetImageById(imageId);
            if (image == null)
                return BadRequest("không tìm thấy sản phẩm");
            return Ok(image);
        }

        // thêm ảnh
        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _manageProductServicecs.AddImage(productId, request);
            if (imageId == 0)
                return BadRequest();

            var image = await _manageProductServicecs.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }

        //update ảnh
        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageProductServicecs.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

        //xoá ảnh

        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageProductServicecs.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }
    }
}