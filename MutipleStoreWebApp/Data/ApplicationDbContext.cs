using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MutipleStoreWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Store> Stores { get; set; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // (global query filter) to enforce store isolation at the database level.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // seeding
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "f64f1b15-0d0c-4b20-997c-4649d9d31b64",
                    Name = Static.Roles.Admin,
                    NormalizedName = Static.Roles.Admin.ToUpper()
                },
                new IdentityRole
                {
                    Id = "1d102caa-dcd1-4c0d-ac38-76e2b8b04f33",
                    Name = Static.Roles.Owner,
                    NormalizedName = Static.Roles.Owner.ToUpper()
                },
                new IdentityRole
                {
                    Id = "fc57d154-917f-4485-9f9d-2f745c3490f9",
                    Name = Static.Roles.Customer,
                    NormalizedName = Static.Roles.Customer.ToUpper()
                });

            // global query
            var user = _httpContextAccessor.HttpContext?.User;
            var userEmail = user?.FindFirst(ClaimTypes.Email)?.Value;

            builder.Entity<Product>().HasQueryFilter(p => userEmail == null || p.Store.OwnerEmail == userEmail);
        }
    }
}
