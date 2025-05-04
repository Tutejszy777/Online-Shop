using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MutipleStoreWebApp.Data.Static;

namespace MutipleStoreWebApp.Data
{
    public class Invoice
    {
        public int Id { get; set; }

        public Order? Order { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public Status Status { get; set; }
    }
}
