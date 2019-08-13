using StockTrackCoreWebApiReactReduxDLL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackCoreWebApiReactReduxDLL.Service
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProducts();
        Task<bool> SaveProduct(ProductModel contact);
        Task<bool> DeleteProduct(int contactId);
    }
}
