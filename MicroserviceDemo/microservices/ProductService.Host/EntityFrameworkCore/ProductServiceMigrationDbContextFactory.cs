using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ProductService.Host.EntityFrameworkCore
{
    public class ProductServiceMigrationDbContextFactory : IDesignTimeDbContextFactory<ProductServiceMigrationDbContext>
    {
        public ProductServiceMigrationDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ProductServiceMigrationDbContext>()
                .UseMySql(configuration.GetConnectionString("ProductManagement"), new MariaDbServerVersion(new Version(10, 6, 5)));

            return new ProductServiceMigrationDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
