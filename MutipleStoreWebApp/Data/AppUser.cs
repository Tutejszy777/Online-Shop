using Microsoft.AspNetCore.Identity;

namespace MutipleStoreWebApp.Data
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly LastLoggin { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public int? StoreId { get; set; }  // Null for Admin
        public Store? Store { get; set; }
    }
}
