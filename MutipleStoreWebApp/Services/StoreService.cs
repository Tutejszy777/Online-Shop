using Microsoft.EntityFrameworkCore;
using MutipleStoreWebApp.Data;

namespace MutipleStoreWebApp.Services
{
    public class StoreService : IStoreService
    {
        private readonly ApplicationDbContext _context;

        public StoreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Store> GetStoreBySlug(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
                throw new Exception();

            var store = await _context.Stores.FirstOrDefaultAsync(s => s.Address == slug);

            return store;
        }
    }
}
