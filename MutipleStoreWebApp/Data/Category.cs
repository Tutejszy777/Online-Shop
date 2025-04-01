using System.ComponentModel.DataAnnotations;

namespace MutipleStoreWebApp.Data
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int StoreId { get; set; }
        public Store? Store { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

