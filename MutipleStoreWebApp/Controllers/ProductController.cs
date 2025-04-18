using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MutipleStoreWebApp.Data;
using MutipleStoreWebApp.Models;
using MutipleStoreWebApp.Services;

namespace MutipleStoreWebApp.Controllers
{
    [Authorize(Roles = "Admin,Owner")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductController(ApplicationDbContext context, IProductService productService, IHttpContextAccessor httpContext)
        {
            _context = context;
            _productService = productService;
            _httpContextAccessor = httpContext;
        }

        // GET: Product
        public async Task<IActionResult> Index(string category, string searchString)
        {
            //if (HttpContext.Items["ShopId"] is int shopId)
            //{
            //    return View(await _productService.GetProductsByStoreId(shopId));
            //} UNFINISHED

            if(_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }

            var categories = from m in _context.Categories
                             orderby m.Name
                             select m.Name;

            var products = from p in _context.Products
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            if(!String.IsNullOrEmpty(category))
            {
                var categoryId = _context.Categories.FirstOrDefault(c => c.Name == category)?.Id;
                products = products.Where(p => p.CategoryId == categoryId);
            }


            var producteCategoryVM = new ProductCategorieVM
            {
                Categories = new SelectList(await categories.Distinct().ToListAsync()),
                Products = await products.ToListAsync()
            };

            return View(producteCategoryVM);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Store)
                .FirstOrDefaultAsync(m => m.Id == id);


            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,ImageUrl,StockQuantity,CategoryId,StoreId,IsAvailable")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedAt = DateTime.UtcNow;
                product.UpdatedAt = DateTime.UtcNow;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name", product.StoreId);
            return View(product);
        }

        // GET: Product/Edit/5
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name", product.StoreId);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,ImageUrl,StockQuantity,CategoryId,StoreId,IsAvailable")] Product product)
        {
            if (id != product.Id)
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
                    if (!ProductExists(product.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name", product.StoreId);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Store)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
