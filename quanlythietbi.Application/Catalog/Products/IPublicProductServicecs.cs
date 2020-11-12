
using quanlythietbi.ViewModels.Catalog.Products;

using quanlythietbi.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanlythietbi.Application.Catalog.Products
{
    public interface IPublicProductServicecs
    {
        public Task< PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);
        Task<List<ProductViewModel>> GetAll();
    }
}
