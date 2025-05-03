using MutipleStoreWebApp.Data.Static;

namespace MutipleStoreWebApp.Data
{
    public class Order
    {
        public int Id { get; set; }

        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public int StoreId { get; set; }
        public Store? Store { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
        public DateTime? Created { get; set; } = default(DateTime?);

        public Status Status { get; set; } 

        public decimal? Total { get; set; }

    }
}
