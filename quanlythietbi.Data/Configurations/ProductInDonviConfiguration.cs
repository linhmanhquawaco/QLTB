using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quanlythietbi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace quanlythietbi.Data.Configurations
{
    public class ProductInDonviConfiguration : IEntityTypeConfiguration<ProductInDonvi>
    {
        public void Configure(EntityTypeBuilder<ProductInDonvi> builder)
        {
            builder.HasKey(t => new { t.DonViId, t.ProductId });
            builder.ToTable("productInDonvis");
            builder.HasOne(t => t.Product).WithMany(pd => pd.ProductInDonvis)
                .HasForeignKey(pc => pc.ProductId);
            builder.HasOne(t => t.DonVi).WithMany(Pd => Pd.productInDonvis)
                .HasForeignKey(pd => pd.DonViId);
        }
    }
}
