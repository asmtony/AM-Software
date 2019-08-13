using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StockTrackAspNetCore.Database.EntityModels;
using StockTrackAspNetCore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackAspNetCore.Models.Services
{
    public class ProductService : IProductService
    {

        private readonly IMapper _mapper;
        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Get(long webCompanyId)
        {
            List<ProductDto> productsDto = new List<ProductDto>();
            // _mapper.Map<User>(entity)
            using (ASMContext context = new ASMContext())
            {
                var products = await context.Products.Where(p => p.WebCompanyId == webCompanyId).AsNoTracking().ToListAsync();
                var webCompany = await context.WebCompanies.Where(c => c.WebCompanyId == webCompanyId).AsNoTracking().ToListAsync();

                var productDto = _mapper.Map<ProductDto>(products);

                productsDto = Mapper.Map<List<ProductDto>>(products)
                  .Map(webCompany);

                /*
                products = await (from p in db.Products.AsNoTracking()                         

                                   
                              select new ProductDto
                              {
                                  ProductId = p.ProductId,
                                  Name = p.Name,
                                  Description = p.Description,
                                  ProductCode = p.ProductCode,
                                  ProductCodeOther = p.ProductCodeOther,
                                  Barcode = p.Barcode,
                                  PackSize = p.PackSize,
                                  CompanyName = p.WebCompany.CompanyName,
                                  WebCompanyId = p.WebCompanyId
                              }).ToListAsync();
                              */

            }
            return productsDto;
        }

        public async Task<ProductDto> Get(long webCompanyId, long productId)
        {
           //  var d = await db.Employee.FirstOrDefaultAsync(x => x.FirstName == "Jack");
            // _mapper.Map<User>(entity)
            using (ASMContext db = new ASMContext())
            {
                var product = await db.Products
               .Include(p => p.WebCompany)
               .FirstOrDefaultAsync(m => m.ProductId == productId && m.WebCompanyId == webCompanyId);
                var productDto = _mapper.Map<ProductDto>(product);
                return productDto;
            }
        }

        public async Task<ProductDto> SaveProduct(ProductDto productDto)
        {
            using (ASMContext db = new ASMContext())
            {
                Database.EntityModels.Product p = db.Products.Where
                         (x => x.ProductId == productDto.ProductId).FirstOrDefault();
                if (p == null)
                {
                    p = new Product()
                    {
                        Name = productDto.Name,
                        Description = productDto.Description,
                        ProductCode = productDto.ProductCode,
                        ProductCodeOther = productDto.ProductCodeOther,
                        Barcode = productDto.Barcode,
                        PackSize = productDto.PackSize,
                        WebCompanyId = productDto.WebCompanyId
                    };
                    db.Products.Add(p);
                }
                else
                {
                    p.Name = productDto.Name;
                    p.Description = productDto.Description;
                    p.ProductCode = productDto.ProductCode;
                    p.ProductCodeOther = productDto.ProductCodeOther;
                    p.Barcode = productDto.Barcode;
                    p.PackSize = productDto.PackSize;
                    p.WebCompanyId = productDto.WebCompanyId;
                }
                await db.SaveChangesAsync();
                productDto = await Get(productDto.WebCompanyId, productDto.ProductId);
                return productDto;
            }
        }

        public async Task<bool> DeleteProduct(long productId)
        {
            using (ASMContext db = new ASMContext())
            {
                Database.EntityModels.Product product =
                         db.Products.Where(x => x.ProductId == productId).FirstOrDefault();
                if (product != null)
                {
                    db.Products.Remove(product);
                }
                return await db.SaveChangesAsync() >= 1;
            }
        }
    }
}
