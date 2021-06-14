using Microsoft.EntityFrameworkCore;
using ShopOnline.Data.Configurations;
using ShopOnline.Data.Entities;
using ShopOnline.Data.Extension;

namespace ShopOnline.Data.EF
{
    public class EshopDbContext : DbContext
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
    }
}
