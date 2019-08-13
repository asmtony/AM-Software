using Microsoft.EntityFrameworkCore;
using StockTrackCoreWebApiReactReduxDAL.EntityModels;
using StockTrackCoreWebApiReactReduxDLL.Model;
using StockTrackCoreWebApiReactReduxDLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackCoreWebApiReactReduxDLL.Service
{
    public class ProductService : IProductService
    {
        public async Task<List<ProductModel>> GetProducts()
        {
            using (StockTrackContext db = new StockTrackContext())
            {
                return await (from p in db.Products.AsNoTracking()
                              select new ProductModel
                              {
                                  ProductId = p.ProductId,
                                  Name = p.Name,
                                  Description = p.Description,
                                  TaxCode = p.TaxCode,
                                  PackSize = p.PackSize
                              }).ToListAsync();
            }
        }

        public async Task<bool> SaveProduct(ProductModel contactModel)
        {
            using (StockTrackContext db = new StockTrackContext())
            {
                StockTrackCoreWebApiReactReduxDAL.EntityModels.Products contact = db.Products.Where
                         (x => x.ProductId == contactModel.ProductId).FirstOrDefault();
                if (contact == null)
                {
                    contact = new Products()
                    {
                        Name = contactModel.Name,
                        Description = contactModel.Description,
                        TaxCode = contactModel.TaxCode,
                        PackSize = contactModel.PackSize,
                        WebCompanyId = contactModel.WebCompanyId
                    };
                    db.Products.Add(contact);
                }
                else
                {
                    contact.Name = contactModel.Name;
                    contact.Description = contactModel.Description;
                    contact.TaxCode = contactModel.TaxCode;
                    contact.PackSize = contactModel.PackSize;
                }
                return await db.SaveChangesAsync() >= 1;
            }
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            using (StockTrackContext db = new StockTrackContext())
            {
                StockTrackCoreWebApiReactReduxDAL.EntityModels.Products product =
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