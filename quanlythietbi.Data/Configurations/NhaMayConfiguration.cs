using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quanlythietbi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace quanlythietbi.Data.Configurations
{
    public class NhaMayConfiguration : IEntityTypeConfiguration<NhaMay>
    {
        public void Configure(EntityTypeBuilder<NhaMay> builder)
        {
            builder.ToTable("NhaMays");
            builder.HasKey(x => new { x.DonViId, x.ProductId});
            builder.Property(x => x.NMName).HasMaxLength(100).IsRequired().IsUnicode();
            builder.HasOne(x => x.DonVi).WithMany(x => x.NhaMays).HasForeignKey(x => x.DonViId);
            builder.HasOne(x => x.Product).WithMany(x => x.NhaMays).HasForeignKey(x => x.ProductId);
        }
    }
}
