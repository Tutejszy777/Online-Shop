using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MutipleStoreWebApp.Data
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateOnly LastLoggin { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public int? StoreId { get; set; }  // Null for Admin
        public Store? Store { get; set; }
    }
}
