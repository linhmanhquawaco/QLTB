using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quanlythietbi.Application.Catalog.Products;

namespace quanlythietbi.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductServicecs _publicProductServicecs;
        public ProductController (IPublicProductServicecs publicProductServicecs)
        {
            _publicProductServicecs = publicProductServicecs;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _publicProductServicecs.GetAll();
            return Ok(products);
        }
    }
}
