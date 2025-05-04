using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MutipleStoreWebApp.Data.Static;

namespace MutipleStoreWebApp.Data
{
    public class Shipment
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
        public DateTime ShippedDate { get; set; }

        public string TrackingNumber { get; set; }
        public string Carrier { get; set; }
        public Status Status { get; set; }
    }
}
