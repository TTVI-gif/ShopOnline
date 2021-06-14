﻿using Microsoft.EntityFrameworkCore;using Microsoft.EntityFrameworkCore.Metadata.Builders;using ShopOnline.Data.Entities;using System;using System.Collections.Generic;using System.Text;namespace ShopOnline.Data.Configurations{    class AppConfigConfi : IEntityTypeConfiguration<AppConfig>    {        public void Configure(EntityTypeBuilder<AppConfig> builder)        {            builder.ToTable("AppConfigs");            builder.HasKey(x => x.key);            builder.Property(x => x.Value).IsRequired(true);        }    }}