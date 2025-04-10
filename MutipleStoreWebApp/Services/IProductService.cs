using MutipleStoreWebApp.Data;

namespace MutipleStoreWebApp.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsByStoreId(int storeId);
    }
}