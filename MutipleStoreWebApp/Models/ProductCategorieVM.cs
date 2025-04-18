using Microsoft.AspNetCore.Mvc.Rendering;
using MutipleStoreWebApp.Data;

namespace MutipleStoreWebApp.Models
{
    public class ProductCategorieVM
    {
        public List<Product>? Products { get; set; }
        public SelectList Categories { get; set; }
        public int? categoryId { get; set; }
        public string? searchString { get; set; }
    }
}
