using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.Data.Configurations
{
    public class AppRoleConfi : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("AppRole");
            builder.Property(x => x.Description).IsRequired().HasMaxLength(300);
        }
    }
}
