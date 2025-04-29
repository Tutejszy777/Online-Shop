using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MutipleStoreWebApp.Data;
using MutipleStoreWebApp.Models;

namespace MutipleStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(string SelectedCategory, string SearchString, int id = 1)
        {
            var shop = await _context.Stores
                .Include(s => s.Products)
                    .ThenInclude(p => p.Category)
                .Include(s => s.Categories)
                .AsNoTracking()
                .FirstOrDefaultAsync(k => k.Id == id);

            if (shop != null && !String.IsNullOrEmpty(SearchString))
            {
                shop.Products = shop.Products
                    .Where(p => p.Name.ToUpper().Contains(SearchString.ToUpper()))
                    .ToList();
            }

            if (shop != null && !String.IsNullOrEmpty(SelectedCategory))
            {
                int.TryParse(SelectedCategory, out int categoryId);
                shop.Products = shop.Products
                    .Where(p => p.CategoryId == categoryId)
                    .ToList();
            }

            if (shop == null)
            {
                return NotFound();
            }

            var shopModel = new ShopPageVM
            {
                Products = shop.Products.ToList(),
                Categories = new SelectList(_context.Categories.Where(p => p.StoreId == id), "Id", "Name"),
                SelectedCategory = SelectedCategory,
                SearchString = SearchString,
                StoreId = shop.Id,
                StoreName = shop.Name,
                StoreSlug = shop.Slug,
                ShopProducts = shop.Products,
                CategoryProducts = shop.Categories // model requires corrections for optimization 
            };// create categore.tolist delete shopproducts and categoryproducts.


            return View(shopModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Store)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
