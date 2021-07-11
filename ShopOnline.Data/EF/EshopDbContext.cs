using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Data.Configurations;
using ShopOnline.Data.Entities;
using ShopOnline.Data.Extension;
using System;

namespace ShopOnline.Data.EF
{
    public class EshopDbContext : IdentityDbContext<AppUser,AppRole,Guid>
    {
        public EshopDbContext( DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartConfi());

            modelBuilder.ApplyConfiguration(new AppConfigConfi());

            modelBuilder.ApplyConfiguration(new ProductConfi());

            modelBuilder.ApplyConfiguration(new CategoryConfi());

            modelBuilder.ApplyConfiguration(new ProductInCategoryConfi());

            modelBuilder.ApplyConfiguration(new OrderConfi());

            modelBuilder.ApplyConfiguration(new OrderDetailConfi());

            modelBuilder.ApplyConfiguration(new CategoryTranslationConfi());

            modelBuilder.ApplyConfiguration(new ContactConfi());

            modelBuilder.ApplyConfiguration(new LanguageConfi());

            modelBuilder.ApplyConfiguration(new ProductTransactionConfi());

            modelBuilder.ApplyConfiguration(new PromotionConfi());

            modelBuilder.ApplyConfiguration(new TransactionConfi());

            modelBuilder.ApplyConfiguration(new AppUserConfi());

            modelBuilder.ApplyConfiguration(new ProductImageConfi());

            modelBuilder.ApplyConfiguration(new AppRoleConfi());
            
            modelBuilder.ApplyConfiguration(new SlideConfi());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");

            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
            //base.OnModelCreating(modelBuilder);

            //data seeding
            modelBuilder.Seed();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<ProductInCategory> ProductInCategories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
    }
}
