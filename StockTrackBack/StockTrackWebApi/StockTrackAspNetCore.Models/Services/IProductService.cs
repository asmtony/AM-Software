using StockTrackAspNetCore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackAspNetCore.Models.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> Get(long webCompanyId);
        Task<ProductDto> Get(long webCompanyId, long productId);
        Task<ProductDto> SaveProduct(ProductDto productDto);
        Task<bool> DeleteProduct(long productId);
    }
}
