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
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string Owner { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

