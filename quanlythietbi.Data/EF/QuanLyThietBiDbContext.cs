using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using quanlythietbi.Data.Configurations;
using quanlythietbi.Data.Entities;
using quanlythietbi.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace quanlythietbi.Data.EF
{
    public class QuanLyThietBiDbContext : IdentityDbContext<AppUser,AppRole,Guid>
    {
        
        public QuanLyThietBiDbContext( DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //cònigure using Fluent API
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new DonViConfiguration());
            modelBuilder.ApplyConfiguration(new NhaMayConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInDonviConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());

            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());

            //Data seeding
            modelBuilder.Seed();


            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClainms");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x=> new { x.UserId, x.RoleId});
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x=> x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClainms");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserToken").HasKey(x=>x.UserId);
       


            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DonVi> DonVis { get; set; }
        public DbSet<NhaMay> NhaMays { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInCategory> ProductInCategories  { get; set; }
        public DbSet<ProductInDonvi> ProductInDonvis { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
    }
}
