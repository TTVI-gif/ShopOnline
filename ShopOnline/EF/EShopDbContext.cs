using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Configurations;
using ShopOnline.Entiiies;
using ShopOnline.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ShopOnline.EF
{
    public class EShopDbContext : IdentityDbContext<AppUsers, AppRole, Guid>
    {
        public EShopDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppconfigConfi());

            modelBuilder.ApplyConfiguration(new ProductConfi());

            modelBuilder.ApplyConfiguration(new CategoryConfi());

            modelBuilder.ApplyConfiguration(new ProductInCategoryConfi());

            modelBuilder.ApplyConfiguration(new CartConfi());

            modelBuilder.ApplyConfiguration(new CategoryTranslationConfi());

            modelBuilder.ApplyConfiguration(new ContactConfi());

            modelBuilder.ApplyConfiguration(new OrdetConfi());

            modelBuilder.ApplyConfiguration(new OrderDetailConfi());

            modelBuilder.ApplyConfiguration(new LanguageConfi());

            modelBuilder.ApplyConfiguration(new ProductTransactionConfi());

            modelBuilder.ApplyConfiguration(new PromotionConfi());

            modelBuilder.ApplyConfiguration(new TransactionConfi());

            modelBuilder.ApplyConfiguration(new AppUserConfi());
            modelBuilder.ApplyConfiguration(new AppRoleConfi());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
            //data seeding
            modelBuilder.Seed();

            //base.OnModelCreating(modelBuilder);

        }


        public DbSet<Product> products { get; set; }
        public DbSet<AppConfig> appConfigs { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<CategoryTranslation> categoryTranslations { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Language> languages { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<ProductInCategory> productInCategories { get; set; }
        public DbSet<ProductTranslation> productTranslations { get; set; }
        public DbSet<Promotion> promotions { get; set; }
        public DbSet<Transaction> transactions { get; set; }
        public DbSet<AppUsers> AppUsers { get; set; }
        public DbSet<AppRole> appRoles { get; set; }
    }
}
