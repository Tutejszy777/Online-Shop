using MutipleStoreWebApp.Data;

namespace MutipleStoreWebApp.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context) 
        {
            _context = context;
        }

        //public async Task<List<Order>> GetUserOrders(Guid userId)
        //{

        //}
    }
}
