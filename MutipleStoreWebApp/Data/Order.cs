using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MutipleStoreWebApp.Data.Static;

namespace MutipleStoreWebApp.Data
{

    public class Order
    {
        public int Id { get; set; }

        [Required]
        public DateOnly OrderDate { get; set; }
        public DateOnly StatusChanged { get; set; }
        public Status Status { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Total { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
