using System.ComponentModel.DataAnnotations;

namespace MutipleStoreWebApp.Data
{
    public class Store
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Slug { get; set; }

        [Required]
        [StringLength(100)]
        public string OwnerEmail { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<Category> Categories { get; set; } 
    }
}

