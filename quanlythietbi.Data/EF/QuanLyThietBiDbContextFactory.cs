using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace quanlythietbi.Data.EF
{
    public class QuanLyThietBiDbContextFactory : IDesignTimeDbContextFactory<QuanLyThietBiDbContext>
    {
        public QuanLyThietBiDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("QuanLyThietBiDb");

            var optionsBuilder = new DbContextOptionsBuilder<QuanLyThietBiDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new QuanLyThietBiDbContext(optionsBuilder.Options);
        }
    }
}
