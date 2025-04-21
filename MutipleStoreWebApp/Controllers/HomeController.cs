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

        public async Task<IActionResult> Index(int id, string SelectedCategory, string SearchString)
        {
            var shop = await _context.Stores
                .Include(s => s.Products)
                    .ThenInclude(p => p.Category)
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
                var categoryId = _context.Categories.FirstOrDefault(c => c.Name == SelectedCategory)?.Id;
                shop.Products = (ICollection<Product>)shop.Products
                    .Where(p => p.CategoryId == categoryId);
            }

            if (shop == null)
            {
                return NotFound();
            }

            var shopModel = new ShopPageVM
            {
                Products = shop.Products.ToList(),
                Categories = new SelectList(_context.Categories, "Id", "Name"),
                SelectedCategory = SelectedCategory,
                SearchString = SearchString,
                StoreId = shop.Id,
                StoreName = shop.Name,
                StoreSlug = shop.Slug,
                ShopProducts = (ICollection<Product>)shop.Products,
                CategoryProducts = _context.Categories.Include(c => c.Products).ToList()
            };


            return View(shopModel);
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
