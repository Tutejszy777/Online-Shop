using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MutipleStoreWebApp.Data.Static;

namespace MutipleStoreWebApp.Data
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        [Required]
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        [Required]
        public int StoreId { get; set; }
        public Store? Store { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public Status Status { get; set; }
    }
}
