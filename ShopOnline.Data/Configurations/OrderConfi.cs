using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Data.Entities;


namespace ShopOnline.Data.Configurations
{
    public class OrderConfi : IEntityTypeConfiguration<Order>

    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OrderDate);
            builder.Property(x => x.ShipEmail).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ShipAddress).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ShipName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.ShipPhoneNumber).HasMaxLength(10).IsRequired();

        }
    }
}
