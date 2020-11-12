using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quanlythietbi.Data.Entities;
using quanlythietbi.Data.Enums;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace quanlythietbi.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.MaTb).HasMaxLength(200);
            builder.Property(x => x.SerialNumber).HasMaxLength(100);
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(100);
            builder.Property(x => x.Xuat_xu).IsUnicode().HasMaxLength(50);
            builder.Property(x => x.HangSX).IsUnicode().HasMaxLength(50);
            builder.Property(x => x.NamSd).HasMaxLength(20);
            builder.Property(x => x.DonViID) ;
            builder.Property(x => x.NguonDien).HasDefaultValue(380);
            builder.Property(x => x.CongSuat);
            builder.Property(x => x.HutSau);
            builder.Property(x => x.LuuLuong);
            builder.Property(x => x.HongHutXa);
            builder.Property(x => x.VongQuay);
            builder.Property(x => x.status).HasDefaultValue(Status.Active);
    }
    }
}
