 using Microsoft.EntityFrameworkCore;
using quanlythietbi.Data.Configurations;
using quanlythietbi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace quanlythietbi.Data.EF
{
    public class QuanLyThietBiDbContext : DbContext
    {
        
        public QuanLyThietBiDbContext( DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new DonViConfiguration());
            modelBuilder.ApplyConfiguration(new NhaMayConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInDonviConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DonVi> DonVis { get; set; }
        public DbSet<NhaMay> NhaMays { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInCategory> ProductInCategories  { get; set; }
        public DbSet<ProductInDonvi> ProductInDonvis { get; set; }
    }
}
