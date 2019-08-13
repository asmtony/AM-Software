using StockTrackAspNetCore.Models.DTO;
using StockTrackAspNetCore.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackAspNetCore.Tests.Fakes
{
    
    public class ProductServiceFake : IProductService
    {
        public async static Task<List<ProductDto>> GetProductData()
        {
            ProductServiceFake fakeProductList = new ProductServiceFake();
            return await fakeProductList.Get(1);
        }
        private readonly List<ProductDto> _productData;

        public ProductServiceFake()
        {
            _productData = new List<ProductDto>()
            {
                new ProductDto() { ProductId = 1, WebCompanyId = 1,
                    Name = "Orange Juice", Description="Orange Tree", Price = 5.00M },
                new ProductDto() { ProductId = 2, WebCompanyId = 1,
                    Name = "Diary Milk", Description="Cow", Price = 4.00M },
                new ProductDto() { ProductId = 3, WebCompanyId = 1,
                    Name = "Frozen Pizza", Description="Uncle Mickey", Price = 12.00M }
            };
        }

        public Task<bool> DeleteProduct(long productId)
        {
            var existing = _productData.First(a => a.ProductId == productId);
            return Task.FromResult( _productData.Remove(existing));
        }

        public async Task<List<ProductDto>> Get(long webCompanyId)
        {
            var productsDto = await Task.FromResult(_productData.Where(a => a.WebCompanyId == webCompanyId).ToList());
            return productsDto;
        }

        public Task<ProductDto> Get(long webCompanyId, long productId)
        {
            var productsDto = _productData.Where(a => a.WebCompanyId == webCompanyId && a.ProductId == productId).FirstOrDefault();
            return Task.FromResult(productsDto);
        }

        public Task<ProductDto> SaveProduct(ProductDto productDto)
        {
            productDto.ProductId = (_productData.Count) + 1;
            _productData.Add(productDto);
            return Task.FromResult( productDto);
        }
    }
}
