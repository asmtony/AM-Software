using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockTrackAspNetCore.Models;
using StockTrackAspNetCore.Models.DTO;
using StockTrackAspNetCore.Models.Services;

namespace StockTrackAspNetCore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productSerice;

        public ProductsController(IProductService productSerice)
        {
            _productSerice = productSerice;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            long webCompanyId = 1;
            //var stockTrackAspNetCoreContext = _context.Products.Include(p => p.WebCompany);
            List<ProductDto> products = await _productSerice.Get(webCompanyId);
            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(long? productId)
        {
            long webCompanyId = 1;
            if (productId == null)
            {
                return NotFound();
            }

            //ProductDto product =
            //List<ProductDto> products = await _productSerice.GetProduct();
            ProductDto  product = await _productSerice.Get(webCompanyId, productId.Value);
               // .Include(p => p.WebCompany)
               // .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            //ViewData["WebCompanyId"] = new SelectList(_context.Set<WebCompany>(), "WebCompanyId", "WebCompanyId");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Description,PackSize,TaxCode,WebCompanyId,DateAdded")] ProductDto product)
        {
            /*
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WebCompanyId"] = new SelectList(_context.Set<WebCompany>(), "WebCompanyId", "WebCompanyId", product.WebCompanyId);
            */

            if (ModelState.IsValid)
            {
                await _productSerice.SaveProduct(product);
            }
                return View(product);
        }

        /*
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["WebCompanyId"] = new SelectList(_context.Set<WebCompany>(), "WebCompanyId", "WebCompanyId", product.WebCompanyId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int64 id, [Bind("ProductId,Name,Description,PackSize,TaxCode,WebCompanyId,DateAdded")] ProductDto product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["WebCompanyId"] = new SelectList(_context.Set<WebCompany>(), "WebCompanyId", "WebCompanyId", product.WebCompanyId);
            return View(product);
        }

        /*
        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.WebCompany)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */

            /*
        private bool ProductExists(Int64 id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
        */
    }
}
