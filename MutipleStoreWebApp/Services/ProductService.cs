using Microsoft.EntityFrameworkCore;
using MutipleStoreWebApp.Data;

namespace MutipleStoreWebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsByStoreId(int storeId)
        {
            return await _context.Products
                .Where(p => p.StoreId == storeId)
                .ToListAsync();
        }
    }
}
