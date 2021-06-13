using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Entiiies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Configurations
{
    public class ProductConfi : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.Price).IsRequired(true);
            builder.Property(x => x.Stock).IsRequired(true).HasDefaultValue(0);
            builder.Property(x => x.ViewCount).IsRequired(true).HasDefaultValue(0);
            builder.Property(x => x.OriginalPrice).IsRequired(true);

        }
    }
}
