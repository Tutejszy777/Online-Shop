using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MutipleStoreWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
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

            var hasher = new PasswordHasher<AppUser>();
            builder.Entity<AppUser>().HasData(
            new AppUser
            {
                Id = "e7f0b276-1e12-4ca5-b85c-ff5615874655",
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                UserName = "admin@localhost.com",
                NormalizedUserName = "ADMIN@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                EmailConfirmed = true,
                FirstName = "admin",
                LastName = "admin",
                LastLoggin = DateOnly.MinValue,
                StoreId = null
            },
            new AppUser
            {
                Id = "47741e2f-6ed9-4c5e-a577-24dd18dc6a0a",
                Email = "owner@localhost.com",
                NormalizedEmail = "OWNER@LOCALHOST.COM",
                UserName = "owner@localhost.com",
                NormalizedUserName = "OWNER@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                EmailConfirmed = true,
                FirstName = "owner",
                LastName = "owner",
                LastLoggin = DateOnly.MinValue,
                StoreId = 1
            },
            new AppUser
            {
                Id = "7db00e3d-12e3-4f9e-99ff-796223ed024f",
                Email = "customer@localhost.com",
                NormalizedEmail = "CUSTOMER@LOCALHOST.COM",
                UserName = "customer@localhost.com",
                NormalizedUserName = "CUSTOMER@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                EmailConfirmed = true,
                FirstName = "customer",
                LastName = "customer",
                LastLoggin = DateOnly.MinValue,
                StoreId = 1
            });

            builder.Entity<Category>().HasData(
                new Category 
                { 
                    Id = 1, 
                    Name = "DEFAULT",
                    Description = "item",
                    StoreId = 1
                });

            builder.Entity<Store>().HasData(
                new Store
                {
                    Id = 1,
                    Name = "DEFAULT",
                    Address = "DEFAULT",
                    OwnerEmail = "owner@localhost.com",
                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "f64f1b15-0d0c-4b20-997c-4649d9d31b64",
                    UserId = "e7f0b276-1e12-4ca5-b85c-ff5615874655"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "1d102caa-dcd1-4c0d-ac38-76e2b8b04f33",
                    UserId = "47741e2f-6ed9-4c5e-a577-24dd18dc6a0a"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "fc57d154-917f-4485-9f9d-2f745c3490f9",
                    UserId = "7db00e3d-12e3-4f9e-99ff-796223ed024f"
                });

            // global query unfished
            //var user = _httpContextAccessor.HttpContext?.User;
            //var userEmail = user?.FindFirst(ClaimTypes.Email)?.Value;

            //builder.Entity<Product>().HasQueryFilter(p => userEmail == null || p.Store.OwnerEmail == userEmail);
        }
    }
}
