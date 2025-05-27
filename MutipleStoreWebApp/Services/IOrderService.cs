using MutipleStoreWebApp.Data;

namespace MutipleStoreWebApp.Services
{
    public interface IOrderService
    {
        Task<Order> GetById(int? id);
        Task<List<Order>> GetAllOrders();
        Task CreateOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int id);
    }
}
