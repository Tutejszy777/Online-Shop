using Microsoft.AspNetCore.Mvc.Rendering;
using MutipleStoreWebApp.Data;

namespace MutipleStoreWebApp.Models
{
    public class ShopPageVM
    {
        public List<Product>? Products { get; set; } // Products to display by default
        public SelectList? Categories { get; set; }
        public string? SelectedCategory { get; set; }
        public string? SearchString { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; } = string.Empty;
        public string StoreSlug { get; set; } = string.Empty;
        public ICollection<Product> ShopProducts { get; set; }
        public ICollection<Category> CategoryProducts { get; set; }
    }
}
