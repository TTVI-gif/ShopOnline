using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace ShopOnline.Data.EF
{
    class EShopDbContextFactory : IDesignTimeDbContextFactory<EshopDbContext>
    {
        public EshopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ShopOnline");

            var optionsBuilder = new DbContextOptionsBuilder<EshopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new EshopDbContext(optionsBuilder.Options);
        }
    }
}
