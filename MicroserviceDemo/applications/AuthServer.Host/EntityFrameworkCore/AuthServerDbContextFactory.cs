using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AuthServer.Host.EntityFrameworkCore
{
    public class AuthServerDbContextFactory : IDesignTimeDbContextFactory<AuthServerDbContext>
    {
        public AuthServerDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            string connectionString = configuration.GetConnectionString("Default");

            var builder = new DbContextOptionsBuilder<AuthServerDbContext>()
                .UseMySql(connectionString, new MariaDbServerVersion(new Version(10, 6, 5)));

            return new AuthServerDbContext(builder.Options);
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
