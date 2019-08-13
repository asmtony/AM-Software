using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackCoreWebApiReactReduxDLL.Model;
using StockTrackCoreWebApiReactReduxDLL.Service;

namespace StockTrackCoreWebApiReactRedux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        [HttpGet]
        [Route("Contacts")]
        public async Task<IActionResult> Contacts()
        {
            return Ok(await _productService.GetProducts());
        }

        [HttpPost]
        [Route("SaveContact")]
        public async Task<IActionResult> SaveContact([FromBody] ProductModel model)
        {
            return Ok(await _productService.SaveProduct(model));
        }

        [HttpDelete]
        [Route("DeleteContact/{contactId}")]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            return Ok(await _productService.DeleteProduct(contactId));
        }
    }
}