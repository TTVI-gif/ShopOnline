using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Entiiies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Configurations
{
    public class OrdetConfi : IEntityTypeConfiguration<Order>

    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OrderDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ShipEmail).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ShipAddress).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ShipName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.ShipPhoneNumber).HasMaxLength(10).IsRequired();
            builder.HasOne(x => x.AppUsers).WithMany(x => x.orders).HasForeignKey(x => x.UserId);
        }
    }
}
