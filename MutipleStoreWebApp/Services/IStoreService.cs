using MutipleStoreWebApp.Data;

namespace MutipleStoreWebApp.Services
{
    public interface IStoreService
    {
        Task<Store?> GetStoreBySlug(string slug);
    }
}
