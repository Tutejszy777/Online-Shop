using Microsoft.AspNetCore.Http;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var user = _httpContextAccessor.HttpContext?.User;
            var userEmail = user?.FindFirst(ClaimTypes.Email)?.Value;

            modelBuilder.Entity<Product>().HasQueryFilter(p => userEmail == null || p.Store.OwnerEmail == userEmail);
        }
    }
}
