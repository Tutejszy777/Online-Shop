using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MutipleStoreWebApp.Data;

namespace MutipleStoreWebApp.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            throw new NotImplementedException();
            //builder.HasKey(o => o.Id); and other methods
        }
    }
}
